﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InspectionSolution.Models;
using Oracle.ManagedDataAccess.Client;
using System.Security.Cryptography;
using System.Text;

namespace InspectionSolution
{
    
    public class DBConnection
    {
        private readonly SessionHandler sessionHandler = new SessionHandler();
        private OracleConnection DatabaseConnection()
        {
            try
            {
                // create connection
               
                OracleConnection con = new OracleConnection();
                // create connection string using builder
                
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
                ocsb.Password = "ztblais";
                ocsb.UserID = "ztblais";
                ocsb.DataSource = "10.1.100.222:1521/devdb18c.ztbl.com.pk";
                // connect
                con.ConnectionString = ocsb.ConnectionString;
                con.Open();
               
                return con;

            }
            catch (Exception) { return null; }
        }
        public UserModel AutheticateLogin(LoginModel login)
        {
            var con = this.DatabaseConnection();
            UserModel user = new UserModel();
            var enc_pass = getMd5Hash(login.Password);
            using (OracleCommand cmd = con.CreateCommand())
            {
                //con.Open();
                cmd.CommandText = "Select U.*, UM.*, e.Employeefirstname,  e.employeelastname FROM t_user u inner join t_user_maping um on u.USERID = um.userid left join t_audit_emp e on u.PPNO=e.ppno WHERE U.PPNO ='" + login.PPNumber + "' and u.Password ='" + enc_pass + "' and u.ISACTIVE='Y'"; 
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    user.ID = Convert.ToInt32(rdr["USERID"]);
                    user.Name = rdr["Employeefirstname"].ToString() + " "+ rdr["employeelastname"].ToString();
                    user.Email = rdr["LOGIN_NAME"].ToString();
                    user.PPNumber = rdr["PPNO"].ToString();
                    user.UserLocationType = rdr["USER_LOCATION_TYPE"].ToString();
                    user.IsActive = rdr["ISACTIVE"].ToString();
                    if (rdr["DIVISIONID"].ToString() != null && rdr["DIVISIONID"].ToString() != "")
                        user.UserPostingDiv = Convert.ToInt32(rdr["DIVISIONID"]);
                    else
                        user.UserPostingDiv = 0;

                    if (rdr["DEPARTMENTID"].ToString() != null && rdr["DEPARTMENTID"].ToString() != "")
                        user.UserPostingDept = Convert.ToInt32(rdr["DEPARTMENTID"]);
                    else
                        user.UserPostingDept = 0;

                    if (rdr["ZONEID"].ToString() != null && rdr["ZONEID"].ToString() != "")
                        user.UserPostingZone = Convert.ToInt32(rdr["ZONEID"]);
                    else
                        user.UserPostingZone = 0;

                    if (rdr["BRANCHID"].ToString() != null && rdr["BRANCHID"].ToString() != "")
                        user.UserPostingBranch = Convert.ToInt32(rdr["BRANCHID"]);
                    else
                        user.UserPostingBranch = 0;

                    if (rdr["AUDIT_ZONEID"].ToString() != null && rdr["AUDIT_ZONEID"].ToString() != "")
                        user.UserPostingAuditZone = Convert.ToInt32(rdr["AUDIT_ZONEID"]);
                    else
                        user.UserPostingAuditZone = 0;

                    if (rdr["GROUP_ID"].ToString() != null && rdr["GROUP_ID"].ToString() != "")
                        user.UserGroupID = Convert.ToInt32(rdr["GROUP_ID"]);
                    else
                        user.UserGroupID = 0;

                    if (rdr["ROLE_ID"].ToString() != null && rdr["ROLE_ID"].ToString() != "")
                        user.UserRoleID = Convert.ToInt32(rdr["ROLE_ID"]);
                    else
                        user.UserRoleID = 0;

                }
            }
            con.Close();
            sessionHandler.SetSessionUser(user);
            return user;
        }
        public static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(System.Text.Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public List<MenuModel> GetTopMenus()
        {
            var con = this.DatabaseConnection();
            var loggedInUser = sessionHandler.GetSessionUser();
            List<MenuModel> modelList = new List<MenuModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select m.* from t_menu m, t_user_group_map r where m.menu_id = r.menu_id and r.role_id="+loggedInUser.UserRoleID+" ORDER BY M.MENU_ORDER ASC" +
                    "";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MenuModel menu = new MenuModel();
                    menu.Menu_Id = Convert.ToInt32(rdr["MENU_ID"]);
                    menu.Menu_Name = rdr["MENU_NAME"].ToString();
                    menu.Menu_Order = rdr["MENU_ORDER"].ToString();
                    menu.Menu_Description = rdr["MENU_DESCRIPTION"].ToString();
                    modelList.Add(menu);
                }
            }
            con.Close();
            return modelList;
        }
        public List<MenuPagesModel> GetTopMenuPages()
        {
            var con = this.DatabaseConnection();
            var loggedInUser = sessionHandler.GetSessionUser();
            List<MenuPagesModel> modelList = new List<MenuPagesModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select * FROM T_MENU_PAGES mp inner join t_menu_pages_groupmap mpg on mp.Id=mpg.page_id WHERE mp.Status='A' and mpg.GROUP_ID= "+loggedInUser.UserGroupID+" order by mp.PAGE_ORDER asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MenuPagesModel menuPage = new MenuPagesModel();
                    menuPage.Id = Convert.ToInt32(rdr["ID"]);
                    menuPage.Menu_Id = Convert.ToInt32(rdr["MENU_ID"]);
                    menuPage.Page_Name = rdr["PAGE_NAME"].ToString();
                    menuPage.Page_Path = rdr["PAGE_PATH"].ToString();
                    menuPage.Page_Order = Convert.ToInt32(rdr["PAGE_ORDER"]);
                    menuPage.Status = rdr["STATUS"].ToString();
                    menuPage.Hide_Menu = Convert.ToInt32(rdr["HIDE_MENU"]);
                    modelList.Add(menuPage);
                }
            }
            con.Close();
            return modelList;
        }
        public List<MenuModel> GetAllTopMenus()
        {
            var con = this.DatabaseConnection();
            List<MenuModel> modelList = new List<MenuModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select m.* from  t_menu m ORDER BY M.MENU_ORDER ASC";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MenuModel menu = new MenuModel();
                    menu.Menu_Id = Convert.ToInt32(rdr["MENU_ID"]);
                    menu.Menu_Name = rdr["MENU_NAME"].ToString();
                    menu.Menu_Order = rdr["MENU_ORDER"].ToString();
                    menu.Menu_Description = rdr["MENU_DESCRIPTION"].ToString();
                    modelList.Add(menu);
                }
            }
            con.Close();
            return modelList;
        }
        public List<MenuPagesModel> GetAllMenuPages(int menuId=0)
        {
            var con = this.DatabaseConnection();

            List<MenuPagesModel> modelList = new List<MenuPagesModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if(menuId==0)
                cmd.CommandText = "Select * FROM T_MENU_PAGES mp WHERE mp.Status='A' order by mp.PAGE_ORDER asc";
                else
                    cmd.CommandText = "Select * FROM T_MENU_PAGES mp WHERE mp.Status='A' and mp.MENU_ID="+menuId+" order by mp.PAGE_ORDER asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MenuPagesModel menuPage = new MenuPagesModel();
                    menuPage.Id = Convert.ToInt32(rdr["ID"]);
                    menuPage.Menu_Id = Convert.ToInt32(rdr["MENU_ID"]);
                    menuPage.Page_Name = rdr["PAGE_NAME"].ToString();
                    menuPage.Page_Path = rdr["PAGE_PATH"].ToString();
                    menuPage.Page_Order = Convert.ToInt32(rdr["PAGE_ORDER"]);
                    menuPage.Status = rdr["STATUS"].ToString();
                    modelList.Add(menuPage);
                }
            }
            con.Close();
            return modelList;
        }
        public List<MenuPagesModel> GetAssignedMenuPages(int groupId,int menuId)
        {
            var con = this.DatabaseConnection();

            List<MenuPagesModel> modelList = new List<MenuPagesModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select * FROM T_MENU_PAGES mp inner join t_menu_pages_groupmap mpg on mp.Id=mpg.page_id WHERE mp.Status='A' and mpg.GROUP_ID= "+groupId+" and mp.MENU_ID = "+menuId+"  order by mp.PAGE_ORDER asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MenuPagesModel menuPage = new MenuPagesModel();
                    menuPage.Id = Convert.ToInt32(rdr["ID"]);
                    menuPage.Menu_Id = Convert.ToInt32(rdr["MENU_ID"]);
                    menuPage.Page_Name = rdr["PAGE_NAME"].ToString();
                    menuPage.Page_Path = rdr["PAGE_PATH"].ToString();
                    menuPage.Page_Order = Convert.ToInt32(rdr["PAGE_ORDER"]);
                    menuPage.Status = rdr["STATUS"].ToString();
                    modelList.Add(menuPage);
                }
            }
            con.Close();
            return modelList;
        }
        public List<GroupModel> GetGroups()
        {
            var con = this.DatabaseConnection();
            List<GroupModel> groupList = new List<GroupModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select g.* from  t_groups g WHERE g.STATUS='Y' ORDER BY g.GROUP_ID";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    GroupModel grp = new GroupModel();
                    grp.GROUP_ID = Convert.ToInt32(rdr["GROUP_ID"]);
                    grp.GROUP_NAME = rdr["GROUP_NAME"].ToString();
                    grp.GROUP_DESCRIPTION = rdr["DESCRIPTION"].ToString();
                    grp.GROUP_CODE = Convert.ToInt32(rdr["GROUP_ID"]);
                    grp.ISACTIVE = rdr["STATUS"].ToString();
                    groupList.Add(grp);
                }
            }
            con.Close();
            return groupList;
        }
        public GroupModel AddGroup(GroupModel gm)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (gm.GROUP_ID == 0)
                    cmd.CommandText = "INSERT INTO t_groups g (g.ROLE_ID, g.GROUP_ID, g.DESCRIPTION, g.GROUP_NAME, g.STATUS) VALUES ( (select COALESCE(max(pr.ROLE_ID)+1,1) from t_groups pr),(select COALESCE(max(pg.GROUP_ID)+1,1) from t_groups pg), '" + gm.GROUP_DESCRIPTION+ "', '" + gm.GROUP_NAME + "', '" + gm.ISACTIVE + "')";
                else
                    cmd.CommandText = "UPDATE T_GROUPS g SET g.GROUP_NAME = '" + gm.GROUP_NAME+"', g.DESCRIPTION='"+gm.GROUP_DESCRIPTION+"', g.STATUS='"+gm.ISACTIVE+"' WHERE g.GROUP_ID="+gm.GROUP_ID;
                OracleDataReader rdr = cmd.ExecuteReader();
            }
            con.Close();
            return gm;
        }
        public List<UserModel> GetAllUsers(FindUserModel user)
        {
            string whereClause = " 1 = 1 ";
            if (user.DIVISIONID != 0)
                whereClause = whereClause+ " and e.CURRENTDIVISIONCODE =" + user.DIVISIONID;
            if (user.DEPARTMENTID != 0)
                whereClause = whereClause+ " and e.CURRENTDEPARTMENTCODE =" + user.DEPARTMENTID;
            if (user.ZONEID != 0)
                whereClause = whereClause + " and e.CURRENTZONECODE =" + user.ZONEID;
            if (user.BRANCHID != 0)
                whereClause = whereClause + " and e.CURRENTZONECODE =" + user.BRANCHID;
            if (user.EMAIL != "" && user.EMAIL != null)
                whereClause = whereClause + " and e.EMAIL like  %'" + user.EMAIL+"'%";
            if (user.GROUPID != 0)
                whereClause = whereClause + " and r.ROLE_ID =" + user.GROUPID;
            if (user.PPNUMBER != 0)
                whereClause = whereClause + " and e.PPNO =" + user.PPNUMBER;
            if (user.LOGINNAME != 0)
                whereClause = whereClause + " and e.PPNO =" + user.LOGINNAME;

            List<UserModel> userList = new List<UserModel>();
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select  u.USERID, r.group_name, rm.group_id, d.NAME as divName, dep.NAME as DeptName, z.ZONENAME, b.BRANCHNAME, e.* from v_service_employeeinfo e left join t_user u on e.PPNO=u.PPNO left join v_service_division d on e.CURRENTDIVISIONCODE=d.CODE left join v_service_department dep on e.CURRENTDEPARTMENTCODE=dep.ID left join v_service_zones z on e.CURRENTZONECODE=z.ZONECODE left join v_service_branch b on e.CURRENTBRANCHCODE=b.BRANCHCODE left join t_user_maping rm on e.PPNO=rm.ppno left join t_groups r on r.role_id=rm.role_id WHERE "+whereClause+" ORDER BY u.USERID";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserModel um = new UserModel();
                    if (rdr["USERID"].ToString() != null && rdr["USERID"].ToString() != "")
                        um.ID = Convert.ToInt32(rdr["USERID"]);
                    um.PPNumber = rdr["PPNO"].ToString();
                    um.Name = rdr["EMPLOYEEFIRSTNAME"].ToString()+" "+ rdr["EMPLOYEELASTNAME"].ToString();
                    um.Email = rdr["EMAIL"].ToString();
                    if(rdr["CURRENTBRANCHCODE"].ToString()!= null && rdr["CURRENTBRANCHCODE"].ToString() != "")
                    um.UserPostingBranch = Convert.ToInt32(rdr["CURRENTBRANCHCODE"]);
                    if (rdr["CURRENTDEPARTMENTCODE"].ToString() != null && rdr["CURRENTDEPARTMENTCODE"].ToString() != "")
                        um.UserPostingDept = Convert.ToInt32(rdr["CURRENTDEPARTMENTCODE"]);
                    if (rdr["CURRENTZONECODE"].ToString() != null && rdr["CURRENTZONECODE"].ToString() != "")
                        um.UserPostingZone = Convert.ToInt32(rdr["CURRENTZONECODE"]);
                    if (rdr["CURRENTDIVISIONCODE"].ToString() != null && rdr["CURRENTDIVISIONCODE"].ToString() != "")
                        um.UserPostingDiv = Convert.ToInt32(rdr["CURRENTDIVISIONCODE"]);
                    if (rdr["group_id"].ToString() != null && rdr["group_id"].ToString() != "")
                        um.UserGroupID = Convert.ToInt32(rdr["group_id"]);
                    um.DivName= rdr["divName"].ToString();
                    um.DeptName = rdr["DeptName"].ToString();
                    um.ZoneName = rdr["ZONENAME"].ToString();
                    um.BranchName = rdr["BRANCHNAME"].ToString();
                    um.UserRole = rdr["group_name"].ToString();
                    um.UserGroup = rdr["group_name"].ToString();
                    um.IsActive= rdr["STATUSTYPE"].ToString();
                    userList.Add(um);
                }
            }
            con.Close();
            return userList;
            
        }
        public List<AuditEntitiesModel> GetAuditEntities()
        {
            
            List<AuditEntitiesModel> entitiesList = new List<AuditEntitiesModel>();
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM  t_auditee_ent_types et where et.auditable='A'";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditEntitiesModel entity = new AuditEntitiesModel();                   
                    entity.AUTID = Convert.ToInt32(rdr["AUTID"]);
                    entity.ENTITYCODE = rdr["ENTITYCODE"].ToString();
                    entity.ENTITYTYPEDESC = rdr["ENTITYTYPEDESC"].ToString();
                    entity.AUDITABLE = rdr["AUDITABLE"].ToString();
                    entitiesList.Add(entity);
                }
            }
            con.Close();
            return entitiesList;

        }
        public AuditEntitiesModel AddAuditEntity(AuditEntitiesModel am)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO t_auditee_ent_types et ( et.AUTID, et.ENTITYCODE, et.ENTITYTYPEDESC, et.AUDITABLE ) VALUES ( (select COALESCE(max(p.AUTID)+1,1) from t_auditee_ent_types p) , LPAD((select COALESCE(max(p.AUTID)+1,1) from t_auditee_ent_types p),3,0), '" + am.ENTITYTYPEDESC+"', '" + am.AUDITABLE+"') ";
                cmd.ExecuteReader();
               
            }
            con.Close();
            return am;

        }
        public List<AuditSubEntitiesModel> GetAuditSubEntities()
        {

            List<AuditSubEntitiesModel> subEntitiesList = new List<AuditSubEntitiesModel>();
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM  t_subentity se where se.STATUS = 'Y'";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditSubEntitiesModel entity = new AuditSubEntitiesModel();
                    entity.ID = Convert.ToInt32(rdr["ID"]);
                    entity.DIV_ID = Convert.ToInt32(rdr["DIV_ID"]);
                    entity.DEP_ID = Convert.ToInt32(rdr["DEP_ID"]);
                    entity.NAME = rdr["E_NAME"].ToString();
                    entity.STATUS = rdr["STATUS"].ToString();
                    subEntitiesList.Add(entity);
                }
            }
            con.Close();
            return subEntitiesList;

        }
        public UpdateUserModel UpdateUser(UpdateUserModel user)
        {
            var enc_pass = getMd5Hash(user.PASSWORD);
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE t_user SET PASSWORD = '"+ enc_pass + "', ISACTIVE='"+user.ISACTIVE+"' WHERE USERID="+user.USER_ID+" and PPNO='"+user.PPNO+"'";
                cmd.ExecuteReader();
                if(user.ROLE_ID!=0)
                {
                    cmd.CommandText = "Select um.USERID FROM t_user_maping um WHERE um.ROLE_ID=" + user.ROLE_ID + " and um.USERID=" + user.USER_ID;
                    OracleDataReader rdr = cmd.ExecuteReader();
                    bool isAlreadyAdded = false;
                    while (rdr.Read())
                    {
                        if (rdr["USERID"].ToString() != null && rdr["USERID"].ToString() != "")
                            isAlreadyAdded = true;
                    }
                    if (!isAlreadyAdded)
                        cmd.CommandText = "INSERT INTO t_user_maping ( USERID,PPNO,GROUP_ID, ROLE_ID) VALUES ("+user.USER_ID+", '"+user.PPNO+"',"+user.ROLE_ID+", "+user.ROLE_ID+" )";
                    else
                        cmd.CommandText = "UPDATE t_user_maping SET GROUP_ID = " + user.ROLE_ID + ", ROLE_ID=" + user.ROLE_ID + " WHERE USERID=" + user.USER_ID + " and PPNO='" + user.PPNO + "'";
                    cmd.ExecuteReader();
                }
            }
            con.Close();
            user.PASSWORD = "";
            return user;
        }
        public void AddGroupMenuAssignment(int role_id = 0, int menu_id = 0, string page_ids = "")
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select mp.GROUP_MAP_ID FROM T_USER_GROUP_MAP mp WHERE mp.ROLE_ID=" + role_id + " and mp.MENU_ID=" + menu_id;
                OracleDataReader rdr = cmd.ExecuteReader();
                bool isAlreadyAdded = false;
                while (rdr.Read())
                {
                    if (rdr["GROUP_MAP_ID"].ToString() != null && rdr["GROUP_MAP_ID"].ToString() != "")
                        isAlreadyAdded = true;
                }
                if (!isAlreadyAdded)
                {
                    cmd.CommandText = "INSERT INTO T_USER_GROUP_MAP (GROUP_MAP_ID,ROLE_ID,MENU_ID,PAGE_IDS) VALUES ( (select COALESCE(max(p.GROUP_MAP_ID)+1,1) from T_USER_GROUP_MAP p)," + role_id + ", " + menu_id + ", '" + page_ids + "')";
                    cmd.ExecuteReader();
                }
            }
            con.Close();
        }
        public void RemoveGroupMenuAssignment(int role_id = 0, int menu_id = 0)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM T_USER_GROUP_MAP mp WHERE mp.ROLE_ID=" + role_id + " and mp.MENU_ID=" + menu_id;
                cmd.ExecuteReader();
            }
            con.Close();
        }
        public void AddGroupMenuItemsAssignment(int group_id=0, int menu_item_id=0)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select mp.GROUPMAP_ID FROM T_MENU_PAGES_GROUPMAP mp WHERE mp.GROUP_ID=" + group_id+ " and mp.PAGE_ID=" + menu_item_id;
                OracleDataReader rdr = cmd.ExecuteReader();
                bool isAlreadyAdded = false;
                while (rdr.Read())
                {
                    if (rdr["GROUPMAP_ID"].ToString() != null && rdr["GROUPMAP_ID"].ToString() != "")
                        isAlreadyAdded = true;
                }
                if (!isAlreadyAdded)
                {
                    cmd.CommandText = "INSERT INTO T_MENU_PAGES_GROUPMAP (GROUPMAP_ID,GROUP_ID,PAGE_ID) VALUES ( (select COALESCE(max(p.GROUPMAP_ID)+1,1) from T_MENU_PAGES_GROUPMAP p)," + group_id + ", " + menu_item_id + " )";
                    cmd.ExecuteReader();
                }
            }
            con.Close();
        }
        public void RemoveGroupMenuItemsAssignment(int group_id = 0, int menu_item_id = 0)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM  T_MENU_PAGES_GROUPMAP mp WHERE mp.GROUP_ID=" + group_id + " and mp.PAGE_ID=" + menu_item_id;
                cmd.ExecuteReader();
            }
            con.Close();
        }
        public List<AuditZoneModel> GetAuditZones(bool sessionCheck=true)
        {
            var con = this.DatabaseConnection();
            List<AuditZoneModel> AZList = new List<AuditZoneModel>();
            var loggedInUser = sessionHandler.GetSessionUser();
            string query = "";
            if (sessionCheck)
            {
                if (loggedInUser.UserPostingAuditZone != 0)
                    query = query + " and z.ID=" + loggedInUser.UserPostingAuditZone;
               
            }
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select z.* FROM T_auditzone z WHERE 1=1 "+query+" order by z.ZONENAME asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditZoneModel z = new AuditZoneModel();
                    z.ID = Convert.ToInt32(rdr["ID"]);
                    z.ZONECODE = rdr["ZONECODE"].ToString();
                    z.ZONENAME = rdr["ZONENAME"].ToString();
                    z.DESCRIPTION = rdr["DESCRIPTION"].ToString();
                    if (rdr["ISACTIVE"].ToString() == "A")
                        z.ISACTIVE = "Active";
                    else if (rdr["ISACTIVE"].ToString() == "I")
                        z.ISACTIVE = "InActive";
                    else
                        z.ISACTIVE = rdr["ISACTIVE"].ToString();

                    AZList.Add(z);
                }
            }
            con.Close();
            return AZList;
        }
        public List<InspectionUnitsModel> GetInspectionUnits()
        {
            var con = this.DatabaseConnection();
            List<InspectionUnitsModel> ICList = new List<InspectionUnitsModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select z.* FROM T_INS_UNITS z order by z.unit_name asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    InspectionUnitsModel z = new InspectionUnitsModel();
                    z.I_ID = Convert.ToInt32(rdr["I_ID"]);
                    z.I_CODE = rdr["I_CODE"].ToString();
                    z.UNIT_NAME = rdr["UNIT_NAME"].ToString();
                    z.DISCRIPTION = rdr["DISCRIPTION"].ToString();
                    if (rdr["STATUS"].ToString() == "Y")
                        z.STATUS = "Active";
                    else if (rdr["STATUS"].ToString() == "N")
                        z.STATUS = "InActive";
                    else
                        z.STATUS = rdr["ISACTIVE"].ToString();

                    ICList.Add(z);
                }
            }
            con.Close();
            return ICList;
        }
        public List<BranchModel> GetBranches(int zone_code=0,bool sessionCheck=true)
        {
            var con = this.DatabaseConnection();
            List<BranchModel> branchList = new List<BranchModel>();            
            var loggedInUser = sessionHandler.GetSessionUser();
            string query = "";
            if (sessionCheck)
            {
                if (loggedInUser.UserPostingZone != 0)
                    query = query + " and z.ZONEID=" + loggedInUser.UserPostingZone;
                if (loggedInUser.UserPostingBranch != 0)
                    query = query + " and b.ZONEID=" + loggedInUser.UserPostingBranch;
            }

            using (OracleCommand cmd = con.CreateCommand())
            {
                if(zone_code==0)
                    cmd.CommandText = "Select b.*, z.ZONENAME   FROM V_SERVICE_BRANCH b inner join V_SERVICE_ZONES z on b.zoneid=z.zoneid WHERE 1=1 "+query+" order by b.BRANCHNAME asc";
                //cmd.CommandText = "Select b.*, s.DESCRIPTION as BRANCH_SIZE,  z.ZONENAME   FROM V_SERVICE_BRANCH b inner join T_BR_SIZE s on b.BRANCH_SIZE_ID=s.BR_SIZE_ID inner join V_SERVICE_ZONES z on b.zoneid=z.zoneid  order by b.BRANCHNAME asc";
                else
                    cmd.CommandText = "Select b.*,  z.ZONENAME   FROM V_SERVICE_BRANCH b inner join V_SERVICE_ZONES z on b.zoneid=z.zoneid WHERE z.ZONEID=" + zone_code + query+ " order by b.BRANCHNAME asc";
                //cmd.CommandText = "Select b.*, s.DESCRIPTION as BRANCH_SIZE,  z.ZONENAME   FROM V_SERVICE_BRANCH b inner join T_BR_SIZE s on b.BRANCH_SIZE_ID=s.BR_SIZE_ID inner join V_SERVICE_ZONES z on b.zoneid=z.zoneid WHERE z.ZONECODE="+zone_code+" order by b.BRANCHNAME asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BranchModel br = new BranchModel();
                    br.BRANCHID = Convert.ToInt32(rdr["BRANCHID"]);
                    br.ZONEID = Convert.ToInt32(rdr["ZONEID"]);
                    br.BRANCHNAME = rdr["BRANCHNAME"].ToString();
                    br.ZONE_NAME = rdr["ZONENAME"].ToString();
                    br.BRANCHCODE = rdr["BRANCHCODE"].ToString();
                    br.BRANCH_SIZE_ID = 1;//Convert.ToInt32(rdr["BRANCH_SIZE_ID"]);
                    br.DESCRIPTION = rdr["DESCRIPTION"].ToString();
                    br.BRANCH_SIZE = "";//rdr["BRANCH_SIZE"].ToString();
                    if (rdr["ISACTIVE"].ToString() == "Y")
                        br.ISACTIVE = "Active";
                    else if (rdr["ISACTIVE"].ToString() == "N")
                        br.ISACTIVE = "InActive";
                    else
                        br.ISACTIVE = rdr["ISACTIVE"].ToString();

                    branchList.Add(br);
                }
            }
            con.Close();
            return branchList;
        }
        public BranchModel AddBranch(BranchModel br)
        {
            return br;
            /*var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO V_SERVICE_BRANCH b (b.BRANCHID,b.BRANCHCODE, b.BRANCHNAME, b.ZONEID, b.ISACTIVE, b.BRANCH_SIZE_ID) VALUES ( '" + br.BRANCHCODE + "','" + br.BRANCHCODE + "','" + br.BRANCHNAME + "','" + br.ZONEID + "','" + br.ISACTIVE + "','" + br.BRANCH_SIZE_ID + "')";
                OracleDataReader rdr = cmd.ExecuteReader();

            }
            con.Close();
            return br;*/
        }
        public BranchModel UpdateBranch(BranchModel br)
        {
           /* var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE V_SERVICE_BRANCH b SET b.BRANCHCODE='" + br.BRANCHCODE + "', b.BRANCHNAME='" + br.BRANCHNAME + "', b.ZONEID='" + br.ZONEID + "', b.BRANCH_SIZE_ID='" + br.BRANCH_SIZE_ID + "', b.ISACTIVE='" + br.ISACTIVE + "' WHERE b.BRANCHID=" + br.BRANCHID;
                OracleDataReader rdr = cmd.ExecuteReader();

            }
            con.Close();*/
            return br;
        }
        public List<ZoneModel> GetZones(bool sessionCheck=true)
        {
            var con = this.DatabaseConnection();
            List<ZoneModel> zoneList = new List<ZoneModel>();
            var loggedInUser = sessionHandler.GetSessionUser();
            string query = "";
            if (sessionCheck)
            {
                if (loggedInUser.UserPostingZone != 0)
                    query = query + " and z.ZONECODE=" + loggedInUser.UserPostingZone;              
            }
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select z.* FROM V_SERVICE_ZONES z WHERE 1=1 "+query+" order by z.ZONENAME asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ZoneModel z = new ZoneModel();
                    z.ZONEID = Convert.ToInt32(rdr["ZONEID"]);
                    z.ZONECODE = rdr["ZONECODE"].ToString();
                    z.ZONENAME = rdr["ZONENAME"].ToString();
                    z.DESCRIPTION = rdr["DESCRIPTION"].ToString();
                    if (rdr["ISACTIVE"].ToString() == "Y")
                        z.ISACTIVE = "Active";
                    else if (rdr["ISACTIVE"].ToString() == "N")
                        z.ISACTIVE = "InActive";
                    else
                        z.ISACTIVE = rdr["ISACTIVE"].ToString();

                    zoneList.Add(z);
                }
            }
            con.Close();
            return zoneList;
        }
        public List<BranchSizeModel> GetBranchSizes()
        {
            var con = this.DatabaseConnection();
            List<BranchSizeModel> brSizeList = new List<BranchSizeModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select bs.* FROM t_auditee_entities_size_disc bs order by bs.ENTITY_SIZE asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    BranchSizeModel bs = new BranchSizeModel();
                    bs.BR_SIZE_ID = Convert.ToInt32(rdr["ENTITY_SIZE"]);
                    bs.DESCRIPTION = rdr["DESCRIPTION"].ToString();

                    brSizeList.Add(bs);
                }
            }
            con.Close();
            return brSizeList;
        }
        public List<ControlViolationsModel> GetControlViolations()
        {
            var con = this.DatabaseConnection();
            List<ControlViolationsModel> controlViolationList = new List<ControlViolationsModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select v.* FROM t_r_sub_group v WHERE v.gr_id in (1,3) order by v.S_GR_ID asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ControlViolationsModel v = new ControlViolationsModel();
                    v.ID = Convert.ToInt32(rdr["S_GR_ID"]);
                    v.V_NAME = rdr["DESCRIPTION"].ToString();
                    if(rdr["MAX_NUMBER"].ToString()!=null && rdr["MAX_NUMBER"].ToString() != "")
                    v.MAX_NUMBER = Convert.ToInt32(rdr["MAX_NUMBER"]);
                    v.STATUS = "Y";
                    controlViolationList.Add(v);
                }
            }
            con.Close();
            return controlViolationList;
        }
        public ControlViolationsModel AddControlViolation(ControlViolationsModel cv)
        {
            /*var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if(cv.ID==0)
                cmd.CommandText = "INSERT INTO t_r_sub_group cv (cv.ID,cv.V_NAME, cv.MAX_NUMBER) VALUES ( (SELECT COALESCE(max(PP.ID)+1,1) FROM t_control_violation PP), '" + cv.V_NAME + "','" + cv.MAX_NUMBER+"','"+cv.STATUS+"')";
                else
                    cmd.CommandText = "UPDATE t_control_violation cv SET cv.V_NAME = '"+cv.V_NAME+"', cv.MAX_NUMBER='"+cv.MAX_NUMBER+"', cv.STATUS= '"+cv.STATUS+"' WHERE cv.ID="+cv.ID;
                cmd.ExecuteReader();
            }
            con.Close();*/
            return cv;
        }
        public List<DivisionModel> GetDivisions(bool sessionCheck=true)
        {
            var con = this.DatabaseConnection();
            List<DivisionModel> divList = new List<DivisionModel>();
            string query = "";
            /*if (sessionCheck)
            {
                var loggedInUser = sessionHandler.GetSessionUser();
                if (loggedInUser.UserPostingDiv != 0)
                    query = query + " and d.DIVISIONID=" + loggedInUser.UserPostingDiv;
            }*/
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select * from v_service_division d WHERE d.ISACTIVE='Y' "+ query + " order by d.CODE asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DivisionModel div = new DivisionModel();
                    div.DIVISIONID = Convert.ToInt32(rdr["DIVISIONID"]);
                    div.NAME = rdr["NAME"].ToString();
                    div.CODE = rdr["CODE"].ToString();
                    div.DESCRIPTION = rdr["DESCRIPTION"].ToString();
                    if (rdr["ISACTIVE"].ToString() == "Y")
                        div.ISACTIVE = "Active";
                    else if (rdr["ISACTIVE"].ToString() == "N")
                        div.ISACTIVE = "InActive";
                    else
                        div.ISACTIVE = rdr["ISACTIVE"].ToString();
                    divList.Add(div);
                }
            }
            con.Close();
            return divList;
        }
        public DivisionModel AddDivision(DivisionModel div)
        {
            
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO v_Service_Division d (d.ID,d.CODE, d.NAME, d.DESCRIPTION, d.STATUS) VALUES ( '" + div.CODE + "','" + div.CODE+"','"+div.NAME+"','"+div.DESCRIPTION+"','"+div.ISACTIVE+"')";
                OracleDataReader rdr = cmd.ExecuteReader();
               
            }
            con.Close();
            return div;
        }
        public DivisionModel UpdateDivision(DivisionModel div)
        {
            /*
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE v_Service_Division d SET d.CODE='" + div.CODE + "', d.NAME='" + div.NAME + "', d.DESCRIPTION='" + div.DESCRIPTION + "', d.STATUS='" + div.ISACTIVE + "' WHERE d.ID="+div.DIVISIONID; 
                OracleDataReader rdr = cmd.ExecuteReader();

            }
            con.Close();*/
            return div;
        }       
        public List<DepartmentModel> GetDepartments(int div_code=0,bool sessionCheck=true)
        {
            var con = this.DatabaseConnection();
            List<DepartmentModel> deptList = new List<DepartmentModel>();
            var loggedInUser = sessionHandler.GetSessionUser();
            string query = "";
            if (sessionCheck)
            {
                if (loggedInUser.UserPostingDiv != 0)
                    query = query + " and d.DIVISIONID=" + loggedInUser.UserPostingDiv;
                if (loggedInUser.UserPostingDept != 0)
                    query = query + " and d.ID=" + loggedInUser.UserPostingDept;
            }
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (div_code == 0)
                cmd.CommandText = "select d.*, div.NAME as DIV_NAME, mp.AUDITEDBY as AUDITED_BY_DEPID from  v_service_department d inner join t_auditee_entities e on  d.CODE = e.code inner join v_service_division div on d.DIVISIONID=div.DIVISIONID  left join t_auditee_entities_maping mp on mp.CODE=d.CODE and mp.auditedby is not null WHERE e.type_id = 4 and d.ISACTIVE ='Y' " + query + " order by d.CODE asc";
                else
                    cmd.CommandText = "select d.*, div.NAME as DIV_NAME, mp.AUDITEDBY as AUDITED_BY_DEPID from  v_service_department d inner join t_auditee_entities e on  d.CODE = e.code inner join v_service_division div on d.DIVISIONID=div.DIVISIONID  left join t_auditee_entities_maping mp on mp.CODE=d.CODE and mp.auditedby is not null WHERE e.type_id = 4 and d.ISACTIVE ='Y' and d.DIVISIONID= " + div_code +  query + " order by d.CODE asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DepartmentModel dept = new DepartmentModel();
                    dept.ID = Convert.ToInt32(rdr["ID"]);
                    dept.DIV_ID = Convert.ToInt32(rdr["DIVISIONID"]);
                    dept.NAME = rdr["NAME"].ToString();
                    dept.CODE = rdr["CODE"].ToString();
                    if (rdr["ISACTIVE"].ToString() == "Y")
                        dept.STATUS = "Active";
                    else if (rdr["ISACTIVE"].ToString() == "N")
                        dept.STATUS = "InActive";
                    else
                        dept.STATUS = rdr["ISACTIVE"].ToString();
                    dept.DIV_NAME = rdr["DIV_NAME"].ToString();
                    if (rdr["AUDITED_BY_DEPID"].ToString() != null && rdr["AUDITED_BY_DEPID"].ToString() != "")
                    { 
                       // dept.AUDITED_BY_NAME = rdr["ADUTIED_BY"].ToString();
                        dept.AUDITED_BY_DEPID = Convert.ToInt32(rdr["AUDITED_BY_DEPID"]);
                        cmd.CommandText = "Select dep.NAME FROM V_SERVICE_DEPARTMENT dep WHERE dep.ID = "+ dept.AUDITED_BY_DEPID;
                        OracleDataReader rdr2 = cmd.ExecuteReader();
                        while (rdr2.Read())
                        {
                            dept.AUDITED_BY_NAME= rdr2["NAME"].ToString();
                        }
                    }
                    deptList.Add(dept);
                }
            }
            con.Close();
            return deptList;
        }
        public List<SubEntitiesModel> GetSubEntities(int div_code=0, int dept_code=0)
        {
            var con = this.DatabaseConnection();
            List<SubEntitiesModel> entitiesList = new List<SubEntitiesModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (div_code == 0)
                {
                    if (dept_code == 0)
                        cmd.CommandText = "Select s.*, d.NAME as DIV_NAME, dp.NAME as DEPT_NAME FROM T_SUBENTITY s inner join v_service_division d on s.DIV_ID = d.DIVISIONID inner join v_service_department dp on s.DEP_ID=dp.ID WHERE s.STATUS='Y' order by s.NAME asc";
                    else
                        cmd.CommandText = "Select s.*, d.NAME as DIV_NAME, dp.NAME as DEPT_NAME FROM T_SUBENTITY s inner join v_service_division d on s.DIV_ID = d.DIVISIONID inner join v_service_department dp on s.DEP_ID=dp.ID WHERE s.STATUS='Y' and dp.ID=" + dept_code+" order by s.NAME asc";

                }
                else {
                    if (dept_code == 0)
                        cmd.CommandText = "Select s.*, d.NAME as DIV_NAME, dp.NAME as DEPT_NAME FROM T_SUBENTITY s inner join v_service_division d on s.DIV_ID = d.DIVISIONID inner join v_service_department dp on s.DEP_ID=dp.ID WHERE d.DIVISIONID="+div_code+ " and s.STATUS='Y' order by s.NAME asc";
                    else
                        cmd.CommandText = "Select s.*, d.NAME as DIV_NAME, dp.NAME as DEPT_NAME FROM T_SUBENTITY s inner join v_service_division d on s.DIV_ID = d.DIVISIONID inner join v_service_department dp on s.DEP_ID=dp.ID WHERE d.DIVISIONID=" + div_code + " and s.STATUS='Y' and dp.ID=" + dept_code + " order by s.NAME asc";

                }

                  OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SubEntitiesModel entity = new SubEntitiesModel();
                    entity.ID = Convert.ToInt32(rdr["ID"]);
                    entity.DIV_ID = Convert.ToInt32(rdr["DIV_ID"]);
                    entity.DEP_ID = Convert.ToInt32(rdr["DEP_ID"]);
                    entity.NAME = rdr["NAME"].ToString();
                    entity.Division_Name = rdr["DIV_NAME"].ToString();
                    entity.Department_Name = rdr["DEPT_NAME"].ToString();
                    if (rdr["STATUS"].ToString() == "Y")
                        entity.STATUS = "Active";
                    else if (rdr["STATUS"].ToString() == "N")
                        entity.STATUS = "InActive";
                    else
                        entity.STATUS = rdr["STATUS"].ToString();
                    entitiesList.Add(entity);
                }
            }
            con.Close();
            return entitiesList;
        }
        public SubEntitiesModel AddSubEntity(SubEntitiesModel subentity)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO T_SUBENTITY d (d.ID,d.NAME, d.DIV_ID, d.DEP_ID, d.STATUS) VALUES ( (SELECT COALESCE(max(PP.ID)+1,1) FROM T_SUBENTITY PP),'" + subentity.NAME + "','" + subentity.DIV_ID + "','" + subentity.DEP_ID + "','" + subentity.STATUS + "')";
                OracleDataReader rdr = cmd.ExecuteReader();

            }
            con.Close();
            return subentity;
        }
        public SubEntitiesModel UpdateSubEntity(SubEntitiesModel subentity)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE T_SUBENTITY d SET d.NAME = '"+subentity.NAME+"' , d.DIV_ID='"+subentity.DIV_ID+"', d.DEP_ID='"+subentity.DEP_ID+"', d.STATUS='"+subentity.STATUS+"'  WHERE d.ID='"+subentity.ID+"'";
                OracleDataReader rdr = cmd.ExecuteReader();

            }
            con.Close();
            return subentity;
        }
        public DepartmentModel AddDepartment(DepartmentModel dept)
        {
            /*
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO v_Service_Department d (d.ID,d.CODE, d.NAME, d.DIV_ID, d.STATUS) VALUES ( '" + dept.CODE + "','" + dept.CODE + "','" + dept.NAME + "','" + dept.DIV_ID + "','" + dept.STATUS + "')";
                OracleDataReader rdr = cmd.ExecuteReader();

            }
            con.Close();*/
            return dept;
        }
        public DepartmentModel UpdateDepartment(DepartmentModel dept)
        {
            
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE t_auditee_entities_maping  mp SET mp.AUDITEDBY='" + dept.AUDITED_BY_DEPID + "' WHERE mp.CODE=" + dept.CODE;
                OracleDataReader rdr = cmd.ExecuteReader();
            }
            con.Close();
            return dept;
        }
        public List<RiskGroupModel> GetRiskGroup()
        {
            var con = this.DatabaseConnection();
            List<RiskGroupModel> riskgroupList = new List<RiskGroupModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "Select rg.* FROM T_R_GROUP rg order by rg.GR_ID asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RiskGroupModel rgm = new RiskGroupModel();
                    rgm.GR_ID = Convert.ToInt32(rdr["GR_ID"]);
                    rgm.DESCRIPTION = rdr["DESCRIPTION"].ToString();
                    riskgroupList.Add(rgm);
                }
            }
            con.Close();
            return riskgroupList;
        }
        public List<RiskSubGroupModel> GetRiskSubGroup(int group_id)
        {
            var con = this.DatabaseConnection();
            List<RiskSubGroupModel> risksubgroupList = new List<RiskSubGroupModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if(group_id==0)
                cmd.CommandText = "Select rsg.*, rg.DESCRIPTION as GROUP_DESC  FROM T_R_SUB_GROUP rsg inner join T_R_GROUP rg on rsg.GR_ID = rg.GR_ID order by rsg.S_GR_ID asc";
                else
                    cmd.CommandText = "Select rsg.*, rg.DESCRIPTION as GROUP_DESC  FROM T_R_SUB_GROUP rsg inner join T_R_GROUP rg on rsg.GR_ID = rg.GR_ID WHERE rsg.GR_ID ="+group_id+" order by rsg.S_GR_ID asc";


                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RiskSubGroupModel rsgm = new RiskSubGroupModel();
                    rsgm.S_GR_ID = Convert.ToInt32(rdr["S_GR_ID"]);
                    rsgm.GR_ID = Convert.ToInt32(rdr["GR_ID"]);
                    rsgm.DESCRIPTION = rdr["DESCRIPTION"].ToString();
                    rsgm.GROUP_DESC = rdr["GROUP_DESC"].ToString();
                    risksubgroupList.Add(rsgm);
                }
            }
            con.Close();
            return risksubgroupList;
        }
        public List<RiskActivityModel> GetRiskActivities(int Sub_group_id)
        {
            var con = this.DatabaseConnection();
            List<RiskActivityModel> riskActivityList = new List<RiskActivityModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (Sub_group_id == 0) 
                    cmd.CommandText = "Select ra.*, rsg.DESCRIPTION as SUB_GROUP_DESC  FROM T_R_ACTIVITY ra inner join T_R_SUB_GROUP rsg on ra.S_GR_ID = rsg.S_GR_ID order by ra.ACTIVITY_ID asc";
                else
                    cmd.CommandText = "Select ra.*, rsg.DESCRIPTION as SUB_GROUP_DESC  FROM T_R_ACTIVITY ra inner join T_R_SUB_GROUP rsg on ra.S_GR_ID = rsg.S_GR_ID WHERE ra.S_GR_ID = "+Sub_group_id+" order by ra.ACTIVITY_ID asc";

                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RiskActivityModel ram = new RiskActivityModel();
                    ram.S_GR_ID = Convert.ToInt32(rdr["S_GR_ID"]);
                    ram.ACTIVITY_ID = Convert.ToInt32(rdr["ACTIVITY_ID"]);
                    ram.DESCRIPTION = rdr["DESCRIPTION"].ToString();
                    ram.SUB_GROUP_DESC = rdr["SUB_GROUP_DESC"].ToString();
                    riskActivityList.Add(ram);
                }
            }
            con.Close();
            return riskActivityList;
        }
        public List<AuditObservationTemplateModel> GetAuditObservationTemplates(int activity_id)
        {
            var con = this.DatabaseConnection();
            List<AuditObservationTemplateModel> templateList = new List<AuditObservationTemplateModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (activity_id == 0)
                    cmd.CommandText = "Select ob.* FROM T_A_OBS_TEMPLATE ob inner join T_R_ACTIVITY ra on ob.ACTIVITY_ID = ra.ACTIVITY_ID order by ob.TEMP_ID asc";
                else
                    cmd.CommandText = "Select ob.* FROM T_AP_OBS_TEMPLATE ob inner join T_R_ACTIVITY ra on ob.ACTIVITY_ID = ra.ACTIVITY_ID WHERE ra.ACTIVITY_ID = " + activity_id + " order by ob.TEMP_ID asc";

                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditObservationTemplateModel temp = new AuditObservationTemplateModel();
                    temp.TEMP_ID = Convert.ToInt32(rdr["TEMP_ID"]);
                    temp.ACTIVITY_ID = Convert.ToInt32(rdr["ACTIVITY_ID"]);
                    temp.OBS_TEMPLATE = rdr["OBS_TEMPLATE"].ToString();
                    templateList.Add(temp);
                }
            }
            con.Close();
            return templateList;
        }
        public List<AuditEmployeeModel> GetAuditEmployees(int dept_code=0)
        {
            var con = this.DatabaseConnection();
            List<AuditEmployeeModel> empList = new List<AuditEmployeeModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (dept_code == 0)
                    cmd.CommandText = "select e.* from t_audit_emp e order by e.RANKCODE asc";
                else
                    cmd.CommandText = "select e.* from t_audit_emp e WHERE e.DEPARTMENTCODE="+dept_code+" order by e.RANKCODE asc";

                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditEmployeeModel emp = new AuditEmployeeModel();
                    emp.PPNO = Convert.ToInt32(rdr["PPNO"]);
                    emp.DEPARTMENTCODE = Convert.ToInt32(rdr["DEPARTMENTCODE"]);
                    emp.RANKCODE = Convert.ToInt32(rdr["RANKCODE"]);
                    emp.DESIGNATIONCODE = Convert.ToInt32(rdr["DESIGNATIONCODE"]);
                    
                    emp.DEPTARMENT = rdr["DEPTARMENT"].ToString();
                    emp.EMPLOYEEFIRSTNAME = rdr["EMPLOYEEFIRSTNAME"].ToString(); 
                    emp.EMPLOYEELASTNAME = rdr["EMPLOYEELASTNAME"].ToString();
                    emp.CURRENT_RANK = rdr["CURRENT_RANK"].ToString();
                    emp.FUN_DESIGNATION = rdr["FUN_DESIGNATION"].ToString();
                    emp.TYPE = rdr["TYPE"].ToString();
                    empList.Add(emp);
                }
            }
            con.Close();
            return empList;
        }
        public List<TentativePlanModel> GetTentativePlansForFields(bool sessionCheck=true)
        {
           
            var con = this.DatabaseConnection();
            List<TentativePlanModel> tplansList = new List<TentativePlanModel>();
            string query = "";
            if (sessionCheck)
            {

                var loggedInUser = sessionHandler.GetSessionUser();
                if (loggedInUser.UserLocationType == "H")
                {
                    //query = query + " and p.AUDITEDBY=" + loggedInUser.UserPostingDept;
                 }
                else if (loggedInUser.UserLocationType == "B")
                {
                    query = query + " and p.AUDITEDBY=" + loggedInUser.UserPostingBranch;
                   
                }
                else if (loggedInUser.UserLocationType == "Z")
                {
                    if (loggedInUser.UserPostingAuditZone != 0 && loggedInUser.UserPostingAuditZone != null)
                    {
                        query = query + " and p.AUDITEDBY=" + loggedInUser.UserPostingAuditZone;
                       
                    }
                    else
                    {
                        query = query + " and p.AUDITEDBY=" + loggedInUser.UserPostingZone;
                      
                    }
                }

               
            }

            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select p.*,ap.DESCRIPTION as PERIOD_NAME from t_au_plan p inner join t_au_period ap on p.AUDITPERIODID=ap.ID WHERE not EXISTS (select * from t_au_plan_eng e where e.period_id= p.auditperiodid and e.entity_code= p.entity_code and e.entity_id= p.entity_id) "+query+ " order by decode(p.AUDITEE_RISK, 'High', 1, 'Medium', 2, 'Low', 3 ), p.DIVISION_ZONE_NAME asc";

                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TentativePlanModel tplan = new TentativePlanModel();
                    tplan.CRITERIA_ID = Convert.ToInt32(rdr["CRITERIA_ID"]);
                    tplan.AUDIT_PERIOD_ID = Convert.ToInt32(rdr["AUDITPERIODID"]);
                    tplan.AUDIT_ZONE_ID = Convert.ToInt32(rdr["AUDITEDBY"]);
                    tplan.BR_SIZE = rdr["AUDITEE_SIZE"].ToString();
                    tplan.RISK = rdr["AUDITEE_RISK"].ToString();
                    tplan.NO_OF_DAYS = Convert.ToInt32(rdr["NO_OF_DAYS"]);
                    tplan.ENTITY_ID = Convert.ToInt32(rdr["ENTITY_ID"]);
                    tplan.CODE = rdr["ENTITY_CODE"].ToString();
                    tplan.ENTITY_NAME = rdr["AUDITEE_NAME"].ToString();
                    tplan.ZONE_NAME = rdr["DIVISION_ZONE_NAME"].ToString();
                    tplan.FREQUENCY_DESCRIPTION = rdr["FREQUENCY_DISCRIPTION"].ToString();
                    tplan.BR_NAME = rdr["AUDITEE_SIZE"].ToString();
                    tplan.PERIOD_NAME = rdr["PERIOD_NAME"].ToString();
                    tplansList.Add(tplan);
                }
            }
            con.Close();
            return tplansList;
        }
        public String GetAuditOperationalStartDate(int auditPeriodId=0, int entityCode=0)
        {
            string result = "";
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select EXTRACT(year FROM d.audit_enddate) as year, EXTRACT(month FROM d.audit_enddate) as month, EXTRACT(day FROM d.audit_enddate) as day  FROM T_AUDITEE_ENTITIES_AUDIT_DATES d WHERE d.ENTITY_CODE=" + entityCode+ " and d.AUDIT_PERIOD_ID= "+auditPeriodId;
                
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result = rdr["YEAR"].ToString() + "-";
                    result += rdr["MONTH"].ToString() + "-";
                    result += rdr["DAY"].ToString();
                }
            }
            con.Close();
            return result;
        }
        public List<AuditTeamModel> GetAuditTeams(int dept_code = 0)
        {
            var loggedInUser = sessionHandler.GetSessionUser();
            var con = this.DatabaseConnection();
            List<AuditTeamModel> teamList = new List<AuditTeamModel>();
            string where_clause = "";
            string select_clause = "";
            bool checkdeptcode = false;
            if (loggedInUser.UserLocationType == "H")
            {
                where_clause = "inner join V_SERVICE_DEPARTMENT d on t.PLACE_OF_POSTING=d.ID WHERE t.PLACE_OF_POSTING = " + loggedInUser.UserPostingDept;
                select_clause = ", d.NAME as AUDIT_DEPARTMENT ";
                checkdeptcode = true;
            }
            else if (loggedInUser.UserLocationType == "B")
            { 
                where_clause = "inner join V_SERVICE_BRANCH b on t.PLACE_OF_POSTING=b.BRANCHID WHERE t.PLACE_OF_POSTING = " + loggedInUser.UserPostingBranch;
                select_clause = ", b.BRANCHNAME as AUDIT_DEPARTMENT ";
                checkdeptcode = true;
            }
            else if (loggedInUser.UserLocationType == "Z")
            {
                if (loggedInUser.UserPostingAuditZone != 0 && loggedInUser.UserPostingAuditZone != null)
                { 
                    where_clause = "left join V_SERVICE_AUDITZONE az on t.PLACE_OF_POSTING=az.ID WHERE t.PLACE_OF_POSTING = " + loggedInUser.UserPostingAuditZone;
                    select_clause = ", az.ZONENAME as AUDIT_DEPARTMENT ";
                    checkdeptcode = true;
                }
                else
                {
                    where_clause = "left join V_SERVICE_ZONES z on t.PLACE_OF_POSTING=z.ZONEID WHERE t.PLACE_OF_POSTING = " + loggedInUser.UserPostingZone;
                    select_clause = ", z.ZONENAME as AUDIT_DEPARTMENT ";
                    checkdeptcode = true;
                }
            }

            using (OracleCommand cmd = con.CreateCommand())
            {
                if (dept_code != 0 && checkdeptcode == false)
                    cmd.CommandText = "select t.* " + select_clause + " from t_au_team_members t " + where_clause + " and t.PLACE_OF_POSTING=" + dept_code + " order by t.T_CODE asc, t.ISTEAMLEAD desc";
                else
                    cmd.CommandText = "select t.* " + select_clause + " from t_au_team_members t " + where_clause + " order by t.T_CODE asc, t.ISTEAMLEAD desc";
                // cmd.CommandText = "select t.*,tm.*, e.*, t.ID as TEAMID from t_ap_teamconstitute t inner join t_ap_team_members tm on t.id=tm.plan_id inner join t_audit_emp e on tm.teammember_id=e.ppno WHERE t.AUDIT_DEPARTMENT=" + dept_code+ " order by t.ID asc, tm.is_teamlead desc";


                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditTeamModel team = new AuditTeamModel();
                    team.ID = Convert.ToInt32(rdr["T_ID"]);
                    team.CODE = rdr["T_CODE"].ToString();
                    team.NAME = rdr["TEAM_NAME"].ToString();
                    team.AUDIT_DEPARTMENT = Convert.ToInt32(rdr["PLACE_OF_POSTING"]);
                    team.TEAMMEMBER_ID = Convert.ToInt32(rdr["MEMBER_PPNO"]);
                    team.IS_TEAMLEAD = rdr["ISTEAMLEAD"].ToString();
                    team.PLACE_OF_POSTING= rdr["AUDIT_DEPARTMENT"].ToString();
                    team.EMPLOYEENAME = rdr["MEMBER_NAME"].ToString();
                    team.STATUS = rdr["STATUS"].ToString();
                    teamList.Add(team);
                }
            }
            con.Close();
            return teamList;
        }
        public AuditTeamModel AddAuditTeam(AuditTeamModel aTeam)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
               cmd.CommandText = "INSERT INTO T_AU_TEAM_MEMBERS (T_ID, T_CODE, TEAM_NAME, MEMBER_PPNO, MEMBER_NAME, ISTEAMLEAD, PLACE_OF_POSTING, STATUS ) VALUES ( (SELECT COALESCE(max(PP.T_ID)+1,1) FROM T_AU_TEAM_MEMBERS PP), '"+aTeam.CODE+"', '"+aTeam.NAME+"', '"+aTeam.TEAMMEMBER_ID+ "', '"+aTeam.EMPLOYEENAME+"', '"+aTeam.IS_TEAMLEAD+"', '"+aTeam.PLACE_OF_POSTING+"', '"+aTeam.STATUS + "')";

                cmd.ExecuteReader();
               
            }
            con.Close();
            return aTeam;
        }
        public bool DeleteAuditTeam(string T_CODE)
        {
            if (T_CODE != "" && T_CODE != null)
            {
                var con = this.DatabaseConnection();
                using (OracleCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM  T_AU_TEAM_MEMBERS WHERE T_CODE = '" + T_CODE + "'";

                    cmd.ExecuteReader();

                }
                con.Close();
                return true;
            }
            else
                return false;
        }
        public List<AuditPeriodModel> GetAuditPeriods(int dept_code = 0)
        {
            var con = this.DatabaseConnection();
            List<AuditPeriodModel> periodList = new List<AuditPeriodModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (dept_code == 0)
                    cmd.CommandText = "select p.* from T_AU_PERIOD p order by p.ID asc";
                else
                    cmd.CommandText = "select p.* from T_AU_PERIOD p order by p.ID asc";

                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditPeriodModel period = new AuditPeriodModel();
                    period.ID = Convert.ToInt32(rdr["ID"]);
                    period.DESCRIPTION = rdr["DESCRIPTION"].ToString();
                    period.START_DATE = Convert.ToDateTime(rdr["START_DATE"]);
                    period.END_DATE = Convert.ToDateTime(rdr["END_DATE"]);
                    period.STATUS_ID = Convert.ToInt32(rdr["STATUS_ID"]);
                    periodList.Add(period);
                }
            }
            con.Close();
            return periodList;
        }
        public bool AddAuditPeriod(AuditPeriodModel periodModel)
        {
            bool result = false;
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select ID from t_au_period p where (to_date('" + periodModel.START_DATE + "', 'dd/mm/yyyy') <= p.start_date and p.start_date <= to_date('" + periodModel.END_DATE + "', 'dd/mm/yyyy HH:MI:SS AM') and to_date('" + periodModel.END_DATE + "', 'dd/mm/yyyy HH:MI:SS AM') <= p.end_date) OR (p.start_date <= to_date('" + periodModel.START_DATE + "', 'dd/mm/yyyy HH:MI:SS AM') and to_date('" + periodModel.END_DATE + "', 'dd/mm/yyyy HH:MI:SS AM') <= p.end_date) or (p.start_date <= to_date('" + periodModel.START_DATE + "', 'dd/mm/yyyy HH:MI:SS AM') and to_date('" + periodModel.START_DATE + "', 'dd/mm/yyyy HH:MI:SS AM') <= p.end_date  and  p.end_date <= to_date('" + periodModel.END_DATE + "', 'dd/mm/yyyy HH:MI:SS AM'))   or (to_date('" + periodModel.START_DATE + "', 'dd/mm/yyyy HH:MI:SS AM') <=p.start_date and p.end_date <= to_date('" + periodModel.END_DATE + "', 'dd/mm/yyyy HH:MI:SS AM'))";
                OracleDataReader rdr = cmd.ExecuteReader();
                bool periodExists = false;
                while (rdr.Read())
                {
                    if (rdr["ID"].ToString() != "" && rdr["ID"].ToString() != null)
                        periodExists = true;
                }
                if (!periodExists) {
                    cmd.CommandText = "insert into T_AU_PERIOD p (p.ID, p.AUDITPERIODID, p.DESCRIPTION,p.START_DATE,p.END_DATE,p.STATUS_ID) VALUES ( (SELECT COALESCE(max(PP.ID)+1,1) FROM T_AU_PERIOD PP),(SELECT COALESCE(max(PP.ID)+1,1) FROM T_AU_PERIOD PP),'" + periodModel.DESCRIPTION + "', TO_DATE('" + periodModel.START_DATE + "','dd/mm/yyyy HH:MI:SS AM'),TO_DATE('" + periodModel.END_DATE + "','dd/mm/yyyy HH:MI:SS AM'), " + periodModel.STATUS_ID + ")";
                    cmd.ExecuteReader();
                    result = true;
                }
                else
                    result = false;
            }
            con.Close();
            return result;
        }
        public AuditPlanModel AddAuditPlan(AuditPlanModel plan)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "insert into T_AU_PLAN p (p.AUDITPERIOD_ID,p.AUDIT_CONDUCTBY_DEPT,p.NO_OF_DAYS_AUDIT,p.AUDITZONE_ID, p.BRANCH_ID, p.DIVISION_ID,p.DEPARTMENT_ID,p.RISK_LEVEL_ID,p.BRANCH_SIZE_ID,p.PLAN_STATUS_ID,p.SUB_ENTITY_ID) VALUES ( " + plan.AUDITPERIOD_ID + ","+plan.AUDIT_CONDUCTBY_DEPT + ", " + plan.NO_OF_DAYS_AUDIT + ", "+plan.AUDITZONE_ID + ","+plan.BRANCH_ID+","+plan.DIVISION_ID+","+plan.DEPARTMENT_ID+","+plan.RISK_LEVEL_ID+","+plan.BRANCH_SIZE_ID+","+plan.PLAN_STATUS_ID+ ", "+plan.SUB_ENTITY_ID+")";
                OracleDataReader rdr = cmd.ExecuteReader();
            }
            con.Close();
            return plan;
        }
        public AuditEngagementPlanModel AddAuditEngagementPlan(AuditEngagementPlanModel ePlan)
        {
            var loggedInUser = sessionHandler.GetSessionUser();
            ePlan.CREATED_ON = System.DateTime.Now;
            int createdbyId = loggedInUser.ID;
            int placeofposting = 0;
            if (loggedInUser.UserLocationType == "H")
                placeofposting = Convert.ToInt32(loggedInUser.UserPostingDept);
            else if (loggedInUser.UserLocationType == "B")
                placeofposting = Convert.ToInt32(loggedInUser.UserPostingBranch);
            else if (loggedInUser.UserLocationType == "Z")
            {
                if (loggedInUser.UserPostingAuditZone != 0 && loggedInUser.UserPostingAuditZone != null)
                    placeofposting = Convert.ToInt32(loggedInUser.UserPostingAuditZone);
                else
                    placeofposting = Convert.ToInt32(loggedInUser.UserPostingZone);
               
            }
            ePlan.CREATEDBY = Convert.ToInt32(loggedInUser.PPNumber);
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "insert into T_AU_PLAN_ENG p (p.ENG_ID,p.PERIOD_ID,p.ENTITY_TYPE,p.AUDIT_ZONEID, p.AUDIT_STARTDATE, p.AUDIT_ENDDATE,p.CREATEDBY,p.CREATED_ON,p.TEAM_NAME,p.STATUS,p.TEAM_ID, p.ENTITY_ID, p.ENTITY_CODE) VALUES ( (SELECT COALESCE(max(PP.ENG_ID)+1,1) FROM T_AU_PLAN_ENG PP), " + ePlan.PERIOD_ID + "," + ePlan.ENTITY_TYPE + ", " + ePlan.AUDIT_ZONEID + ", to_date('" + ePlan.AUDIT_STARTDATE + "','dd/mm/yyyy HH:MI:SS AM'), to_date('" + ePlan.AUDIT_ENDDATE + "','dd/mm/yyyy HH:MI:SS AM'),'" + ePlan.CREATEDBY+ "',to_date('" + ePlan.CREATED_ON + "','dd/mm/yyyy HH:MI:SS AM'),'" + ePlan.TEAM_NAME + "'," + ePlan.STATUS + "," + ePlan.TEAM_ID + ", (select ae.ENTITY_ID from t_auditee_entities ae WHERE ae.Code='"+ ePlan.ENTITY_CODE + "')," + ePlan.ENTITY_CODE+")";
                cmd.ExecuteReader();

                cmd.CommandText = "insert into t_au_plan_eng_log l (l.ID,l.E_ID, l.STATUS_ID,l.CREATEDBY_ID, l.CREATED_ON, l.REMARKS) VALUES ( (SELECT COALESCE(max(ll.ID)+1,1) FROM t_au_plan_eng_log ll), (SELECT max(lp.ENG_ID) FROM t_au_plan_eng lp)," + ePlan.STATUS + "," + createdbyId + ", to_date('" + ePlan.CREATED_ON + "','dd/mm/yyyy HH:MI:SS AM'), 'NEW ENGAGEMENT PLAN CREATED')";
                cmd.ExecuteReader();

                cmd.CommandText = "Select ID from T_AU_AUDIT_TEAMS WHERE ENG_ID= (SELECT COALESCE(max(ll.ID)+1,1) FROM t_au_plan_eng_log ll) and TEAM_ID=" + ePlan.TEAM_ID;
                OracleDataReader ardr = cmd.ExecuteReader();
                bool teamentry = false;
                while (ardr.Read())
                {
                    if (ardr["ID"].ToString() != "" && ardr["ID"].ToString() != null)
                        teamentry = true;
                }
                if(!teamentry)
                {
                    cmd.CommandText = "insert into T_AU_AUDIT_TEAMS t (t.ID,t.ENG_ID, t.TEAM_ID, t.T_NAME, t.PLACE_OF_POSTING, t.STATUS) VALUES ( (SELECT COALESCE(max(ll.ID)+1,1) FROM t_au_plan_eng_log ll), (SELECT max(lp.ENG_ID) FROM t_au_plan_eng lp)," + ePlan.TEAM_ID + ",'" + ePlan.TEAM_NAME + "', " + placeofposting + ",1)";
                    cmd.ExecuteReader();
                }
                   
                cmd.CommandText = "select tmm.member_ppno from T_AU_TEAM_MEMBERS tmm where tmm.t_code = ( select tm.t_code from T_AU_TEAM_MEMBERS tm where tm.t_id =" + ePlan.TEAM_ID+")";
                int sequence_no = 1;
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if(rdr["member_ppno"].ToString()!="" && rdr["member_ppno"].ToString() !=null)
                    {
                        string member_pp = rdr["member_ppno"].ToString();
                        cmd.CommandText = "insert into T_AU_AUDIT_TEAM_TASKLIST t (t.ID,t.ENG_PLAN_ID, t.TEAM_ID, t.SEQUENCE_NO, t.TEAMMEMBER_PPNO, t.ENTITY_ID, t.ENTITY_CODE , t.ENTITY_NAME , t.AUDIT_START_DATE , t.AUDIT_END_DATE, t.STATUS_ID, t.ISACTIVE ) VALUES ( (SELECT COALESCE(max(ll.ID)+1,1) FROM T_AU_AUDIT_TEAM_TASKLIST ll), (SELECT max(lp.ENG_ID) FROM t_au_plan_eng lp)," + ePlan.TEAM_ID + "," + sequence_no + ",'" + member_pp + "', (select ae.ENTITY_ID from t_auditee_entities ae WHERE ae.Code='" + ePlan.ENTITY_CODE + "')," + ePlan.ENTITY_CODE + ",(select ae.NAME from t_auditee_entities ae WHERE ae.Code='" + ePlan.ENTITY_CODE + "'), to_date('" + ePlan.AUDIT_STARTDATE + "','dd/mm/yyyy HH:MI:SS AM'), to_date('" + ePlan.AUDIT_ENDDATE + "','dd/mm/yyyy HH:MI:SS AM'), 1,'Y')";
                        cmd.ExecuteReader();
                    }
                }
            }
            con.Close();
            return ePlan;
        }
        public List<AuditPlanModel> GetAuditPlan(int period_id = 0)
        {
            var con = this.DatabaseConnection();
            List<AuditPlanModel> planList = new List<AuditPlanModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (period_id == 0)
                    cmd.CommandText = "select p.*,d.Name as DIVISION_NAME,dp.Name as DEPARTMENT_NAME, b.branchname as BRANCH_NAME, az.ZONENAME as AUDITZONE_NAME from T_AU_PLAN p left join v_Service_Division d on p.division_id = d.DIVISIONID left join v_Service_Department dp on p.department_id = dp.ID left join V_SERVICE_BRANCH b on p.Branch_Id = b.BRANCHID left join V_SERVICE_ZONES az on p.auditzone_id = az.ZONEID order by p.PLAN_ID asc";
                else
                    cmd.CommandText = "select p.*,d.Name as DIVISION_NAME,dp.Name as DEPARTMENT_NAME, b.branchname as BRANCH_NAME, az.ZONENAME as AUDITZONE_NAME from T_AU_PLAN p left join v_Service_Division d on p.division_id = d.DIVISIONID left join v_Service_Department dp on p.department_id = dp.ID left join V_SERVICE_BRANCH b on p.Branch_Id = b.BRANCHID left join V_SERVICE_ZONES az on p.auditzone_id = az.ZONEID where p.auditperiod_id=" + period_id+ " order by p.PLAN_ID asc";

                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditPlanModel plan = new AuditPlanModel();
                    plan.PLAN_ID = Convert.ToInt32(rdr["PLAN_ID"]);
                    plan.AUDITPERIOD_ID = Convert.ToInt32(rdr["AUDITPERIOD_ID"]);
                    if (rdr["NO_OF_DAYS_AUDIT"].ToString() != null && rdr["NO_OF_DAYS_AUDIT"].ToString() != "")
                        plan.NO_OF_DAYS_AUDIT = Convert.ToInt32(rdr["NO_OF_DAYS_AUDIT"]);
                    if (rdr["AUDITZONE_ID"].ToString() != null && rdr["AUDITZONE_ID"].ToString() != "")
                        plan.AUDITZONE_ID = Convert.ToInt32(rdr["AUDITZONE_ID"]);
                    if (rdr["BRANCH_ID"].ToString() != null && rdr["BRANCH_ID"].ToString() != "")
                        plan.BRANCH_ID = Convert.ToInt32(rdr["BRANCH_ID"]);
                    if (rdr["DIVISION_ID"].ToString() != null && rdr["DIVISION_ID"].ToString() != "")
                        plan.DIVISION_ID = Convert.ToInt32(rdr["DIVISION_ID"]);
                    if (rdr["DEPARTMENT_ID"].ToString() != null && rdr["DEPARTMENT_ID"].ToString() != "")
                        plan.DEPARTMENT_ID = Convert.ToInt32(rdr["DEPARTMENT_ID"]);
                   if (rdr["PLAN_STATUS_ID"].ToString() != null && rdr["PLAN_STATUS_ID"].ToString() != "")
                        plan.PLAN_STATUS_ID = Convert.ToInt32(rdr["PLAN_STATUS_ID"]);
                    if (rdr["BRANCH_SIZE_ID"].ToString() != null && rdr["BRANCH_SIZE_ID"].ToString() != "")
                        plan.BRANCH_SIZE_ID = Convert.ToInt32(rdr["BRANCH_SIZE_ID"]);
                    if (rdr["RISK_LEVEL_ID"].ToString() != null && rdr["RISK_LEVEL_ID"].ToString() != "")
                        plan.RISK_LEVEL_ID = Convert.ToInt32(rdr["RISK_LEVEL_ID"]);
                    if (rdr["SUB_ENTITY_ID"].ToString() != null && rdr["SUB_ENTITY_ID"].ToString() != "")
                        plan.SUB_ENTITY_ID = Convert.ToInt32(rdr["SUB_ENTITY_ID"]);
                    plan.DEPARTMENT_NAME = rdr["DEPARTMENT_NAME"].ToString();
                    plan.BRANCH_NAME = rdr["BRANCH_NAME"].ToString();
                    plan.DIVISION_NAME = rdr["DIVISION_NAME"].ToString();
                    plan.AUDITZONE_NAME = rdr["AUDITZONE_NAME"].ToString();
                    planList.Add(plan);
                }
            }
            con.Close();
            return planList;
        }
        public List<RiskProcessDefinition> GetRiskProcessDefinition()
        {
            var con = this.DatabaseConnection();
            List<RiskProcessDefinition> pdetails = new List<RiskProcessDefinition>();
            using (OracleCommand cmd = con.CreateCommand())
            {
              cmd.CommandText = "select * from t_r_m_process pd order by pd.P_ID";

                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RiskProcessDefinition proc = new RiskProcessDefinition();
                    proc.P_ID = Convert.ToInt32(rdr["P_ID"]);
                    if (rdr["RISK_ID"].ToString() != null && rdr["RISK_ID"].ToString() != "")
                        proc.RISK_ID = Convert.ToInt32(rdr["RISK_ID"]);
                    proc.P_NAME = rdr["P_NAME"].ToString();
                    pdetails.Add(proc);
                }
            }
            con.Close();
            return pdetails;
        }
        public List<RiskProcessDetails> GetRiskProcessDetails(int procId=0)
        {
            var con = this.DatabaseConnection();
            List<RiskProcessDetails> riskProcList = new List<RiskProcessDetails>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if(procId==0)
                    cmd.CommandText = "select * from t_r_m_process_sub pd order by pd.p_id asc";
                else
                    cmd.CommandText = "select * from t_r_m_process_sub pd where pd.p_id = "+procId+" order by pd.P_ID,pd.ID asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RiskProcessDetails pdetail = new RiskProcessDetails();
                    pdetail.ID = Convert.ToInt32(rdr["ID"]);
                    pdetail.P_ID = Convert.ToInt32(rdr["P_ID"]);
                    pdetail.TITLE = rdr["TITLE"].ToString();
                    pdetail.ACTIVE = rdr["ACTIVE"].ToString();
                    riskProcList.Add(pdetail);
                }
            }
            con.Close();
            return riskProcList;
        }
        public List<RiskProcessTransactions> GetRiskProcessTransactions(int procDetailId = 0, int transactionId=0)
        {
            var con = this.DatabaseConnection();
            List<RiskProcessTransactions> riskTransList = new List<RiskProcessTransactions>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (procDetailId == 0)
                {
                    if(transactionId==0)
                    cmd.CommandText = "select pt.*,pd.TITLE, p.P_NAME, vc.DESCRIPTION as V_NAME from t_r_m_process_transaction pt inner join t_r_m_process_sub pd on pt.PD_ID=pd.ID inner join t_r_m_process p on pd.P_ID = p.P_ID inner join t_r_sub_group vc on vc.S_GR_ID=pt.V_ID  order by pt.id asc"; 
                    else
                        cmd.CommandText = "select pt.*,pd.TITLE, p.P_NAME, vc.DESCRIPTION as V_NAME from t_r_m_process_transaction pt inner join t_r_m_process_sub pd on pt.PD_ID=pd.ID inner join t_r_m_process p on pd.P_ID = p.P_ID inner join t_r_sub_group vc on vc.S_GR_ID=pt.V_ID WHERE pt.ID=" + transactionId + " order by pt.id asc";
                }
                else
                {
                    if (transactionId == 0) 
                        cmd.CommandText = "select pt.*,pd.TITLE, p.P_NAME, vc.DESCRIPTION as V_NAME from  t_r_m_process_transaction pt inner join t_r_m_process_sub pd on pt.PD_ID=pd.ID inner join t_r_m_process p on pd.P_ID = p.P_ID inner join t_r_sub_group vc on vc.S_GR_ID=pt.V_ID where pt.pd_id = " + procDetailId + " order by pt.Id asc";
                    else
                        cmd.CommandText = "select pt.*,pd.TITLE, p.P_NAME, vc.DESCRIPTION as V_NAME from t_r_m_process_transaction pt inner join t_r_m_process_sub pd on pt.PD_ID=pd.ID inner join t_r_m_process p on pd.P_ID = p.P_ID inner join t_r_sub_group vc on vc.S_GR_ID=pt.V_ID where pt.ID=" + transactionId+" pt.pd_id = " + procDetailId + " order by pt.Id asc";

                }
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        RiskProcessTransactions pTran = new RiskProcessTransactions();
                        pTran.ID = Convert.ToInt32(rdr["ID"]);
                        pTran.PD_ID = Convert.ToInt32(rdr["PD_ID"]);
                        pTran.V_ID = Convert.ToInt32(rdr["V_ID"]);
                    if (rdr["DIV_ID"].ToString() != null && rdr["DIV_ID"].ToString() != "")
                            pTran.DIV_ID = Convert.ToInt32(rdr["DIV_ID"]);
                        if (rdr["DIV_NAME"].ToString() != null && rdr["DIV_NAME"].ToString() != "")
                            pTran.DIV_NAME = rdr["DIV_NAME"].ToString();
                        if (rdr["DESCRIPTION"].ToString() != null && rdr["DESCRIPTION"].ToString() != "")
                            pTran.DESCRIPTION = rdr["DESCRIPTION"].ToString();
                        if (rdr["CONTROL_OWNER"].ToString() != null && rdr["CONTROL_OWNER"].ToString() != "")
                            pTran.CONTROL_OWNER = rdr["CONTROL_OWNER"].ToString();
                        if (rdr["RISK_MAX_NUMBER"].ToString() != null && rdr["RISK_MAX_NUMBER"].ToString() != "")
                            pTran.RISK_MAX_NUMBER = Convert.ToInt32(rdr["RISK_MAX_NUMBER"]);
                        pTran.ACTION = rdr["ACTION"].ToString();
                    pTran.RISK_WEIGHTAGE = Convert.ToInt32(rdr["RISK_WEIGHTAGE"]);
                    pTran.SUB_PROCESS_NAME = rdr["TITLE"].ToString();
                    pTran.PROCESS_NAME = rdr["P_NAME"].ToString();
                    pTran.VIOLATION_NAME = rdr["V_NAME"].ToString();
                    riskTransList.Add(pTran);
                    }
                }
            con.Close();
            return riskTransList;
        }
        public List<RiskProcessTransactions> GetRiskProcessTransactionsWithStatus(int[] statusId)
        {
            var con = this.DatabaseConnection();
            List<RiskProcessTransactions> riskTransList = new List<RiskProcessTransactions>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (statusId.Length == 0)
                cmd.CommandText = "select pt.*, pd.TITLE, p.P_NAME, s.status from t_r_m_process_transaction pt inner join t_r_m_process_sub pd on pt.PD_ID = pd.ID inner join t_r_m_process p on pd.ID = p.P_ID inner join t_r_m_process_transaction_status_mapping sm on pt.id = sm.T_ID inner join t_r_m_process_transaction_status s on s.ID = sm.STATUS_ID order by pt.id asc";
                else
                    cmd.CommandText = "select pt.*, pd.TITLE, p.P_NAME, s.status from t_r_m_process_transaction pt inner join t_r_m_process_sub pd on pt.PD_ID = pd.ID inner join t_r_m_process p on pd.ID = p.P_ID inner join t_r_m_process_transaction_status_mapping sm on pt.id = sm.T_ID inner join t_r_m_process_transaction_status s on s.ID = sm.STATUS_ID and s.ID IN (" + string.Join(",", statusId) + ") order by pt.id asc";


                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RiskProcessTransactions pTran = new RiskProcessTransactions();
                    pTran.ID = Convert.ToInt32(rdr["ID"]);
                    pTran.PD_ID = Convert.ToInt32(rdr["PD_ID"]);
                    if (rdr["DIV_ID"].ToString() != null && rdr["DIV_ID"].ToString() != "")
                        pTran.DIV_ID = Convert.ToInt32(rdr["DIV_ID"]);
                    if (rdr["DIV_NAME"].ToString() != null && rdr["DIV_NAME"].ToString() != "")
                        pTran.DIV_NAME = rdr["DIV_NAME"].ToString();
                    if (rdr["DESCRIPTION"].ToString() != null && rdr["DESCRIPTION"].ToString() != "")
                        pTran.DESCRIPTION = rdr["DESCRIPTION"].ToString();
                    if (rdr["CONTROL_OWNER"].ToString() != null && rdr["CONTROL_OWNER"].ToString() != "")
                        pTran.CONTROL_OWNER = rdr["CONTROL_OWNER"].ToString();
                    if (rdr["RISK_MAX_NUMBER"].ToString() != null && rdr["RISK_MAX_NUMBER"].ToString() != "")
                        pTran.RISK_MAX_NUMBER = Convert.ToInt32(rdr["RISK_MAX_NUMBER"]);
                    pTran.ACTION = rdr["ACTION"].ToString();
                    pTran.RISK_WEIGHTAGE = Convert.ToInt32(rdr["RISK_WEIGHTAGE"]);
                    pTran.SUB_PROCESS_NAME = rdr["TITLE"].ToString();
                    pTran.PROCESS_NAME = rdr["P_NAME"].ToString();
                    pTran.PROCESS_STATUS = rdr["STATUS"].ToString();
                    riskTransList.Add(pTran);
                }
            }
            con.Close();
            return riskTransList;
        }
        public RiskProcessTransactions GetRiskProcessTransactionLastStatus(RiskProcessTransactions tr)
        {
            var con = this.DatabaseConnection();
           using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select comments from t_r_m_process_transaction_log l where l.t_id="+ tr.ID+ " order by l.created_on desc FETCH NEXT 1 ROWS ONLY";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tr.PROCESS_COMMENTS = rdr["comments"].ToString();
                }
            }
            con.Close();
            return tr;
        }
        public RiskProcessDefinition AddRiskProcess(RiskProcessDefinition proc)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "insert into t_r_m_process p (p.P_ID,p.P_NAME,p.RISK_ID) VALUES ( (select COALESCE(max(pp.P_ID)+1,1) from t_r_m_process pp),'" + proc.P_NAME + "','"+proc.RISK_ID+"')";
                OracleDataReader rdr = cmd.ExecuteReader();
            }
            con.Close();
            return proc;
        }
        public RiskProcessDetails AddRiskSubProcess(RiskProcessDetails subProc)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "insert into t_r_m_process_sub p (p.ID,p.P_ID,p.TITLE,p.ACTIVE) VALUES ( (select COALESCE(max(pp.ID)+1,1) from t_r_m_process_sub pp)," + subProc.P_ID + ",'" + subProc.TITLE + "','Y')";
                OracleDataReader rdr = cmd.ExecuteReader();
            }
            con.Close();
            return subProc;
        }
        public RiskProcessTransactions AddRiskSubProcessTransaction(RiskProcessTransactions trans)
        {
            var con = this.DatabaseConnection();
            var loggedInUser = sessionHandler.GetSessionUser();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "insert into t_r_m_process_transaction p (p.ID,p.V_ID, p.PD_ID,p.DESCRIPTION,p.CONTROL_OWNER,p.DIV_ID,p.DIV_NAME,p.ACTION,p.RISK_WEIGHTAGE,p.RISK_MAX_NUMBER) VALUES ( (select COALESCE(max(pp.ID)+1,1) from t_r_m_process_transaction pp)," + trans.V_ID + "," + trans.PD_ID + ",'" + trans.DESCRIPTION + "','" + trans.CONTROL_OWNER + "','" + trans.DIV_ID + "','" + trans.DIV_NAME + "','" + trans.ACTION + "','" + trans.RISK_WEIGHTAGE + "','" + trans.RISK_MAX_NUMBER + "')";
                OracleDataReader rdr = cmd.ExecuteReader();
                cmd.CommandText = "insert into t_r_m_process_transaction_log p (p.ID,p.T_ID,p.STATUS_ID,p.USER_ID,p.COMMENTS) VALUES ( (select COALESCE(max(pp.ID)+1,1) from t_r_m_process_transaction_log pp), (select max(tp.ID) from t_r_m_process_transaction tp) ,'1',"+ loggedInUser.ID+ ",'New Transaction Added')";
                cmd.ExecuteReader();
                cmd.CommandText = "insert into t_r_m_process_transaction_status_mapping p (p.ID,p.T_ID,p.STATUS_ID) VALUES ( (select COALESCE(max(pp.ID)+1,1) from t_r_m_process_transaction_status_mapping pp), (select max(tp.ID) from t_r_m_process_transaction tp) ,'1')";
                cmd.ExecuteReader();

            }
            con.Close();
            return trans;
        }
        public bool RecommendProcessTransactionByReviewer(int T_ID, string COMMENTS)
        {
            var con = this.DatabaseConnection();
            var loggedInUser = sessionHandler.GetSessionUser();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = " Update t_r_m_process_transaction_status_mapping tm SET tm.STATUS_ID = 3 WHERE tm.T_ID=" + T_ID;
                OracleDataReader rdr = cmd.ExecuteReader();
                cmd.CommandText = "insert into t_r_m_process_transaction_log p (p.ID,p.T_ID,p.STATUS_ID,p.USER_ID,p.COMMENTS) VALUES ( (select COALESCE(max(pp.ID)+1,1) from t_r_m_process_transaction_log pp), "+T_ID+" ,'3'," + loggedInUser.ID + ",'"+COMMENTS+"')";
                cmd.ExecuteReader();
            }
            con.Close();
            return true;
        }
        public bool RefferedBackProcessTransactionByReviewer(int T_ID, string COMMENTS)
        {
            var con = this.DatabaseConnection();
            var loggedInUser = sessionHandler.GetSessionUser();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = " Update t_r_m_process_transaction_status_mapping tm SET tm.STATUS_ID = 2 WHERE tm.T_ID=" + T_ID;
                OracleDataReader rdr = cmd.ExecuteReader();
                cmd.CommandText = "insert into t_r_m_process_transaction_log p (p.ID,p.T_ID,p.STATUS_ID,p.USER_ID,p.COMMENTS) VALUES ( (select COALESCE(max(pp.ID)+1,1) from t_r_m_process_transaction_log pp), " + T_ID + " ,'2'," + loggedInUser.ID + ",'" + COMMENTS + "')";
                cmd.ExecuteReader();
            }
            con.Close();
            return true;
        }
        public bool RecommendProcessTransactionByAuthorizer(int T_ID, string COMMENTS)
        {
            var con = this.DatabaseConnection();
            var loggedInUser = sessionHandler.GetSessionUser();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = " Update t_r_m_process_transaction_status_mapping tm SET tm.STATUS_ID = 5 WHERE tm.T_ID=" + T_ID;
                OracleDataReader rdr = cmd.ExecuteReader();
                cmd.CommandText = "insert into t_r_m_process_transaction_log p (p.ID,p.T_ID,p.STATUS_ID,p.USER_ID,p.COMMENTS) VALUES ( (select COALESCE(max(pp.ID)+1,1) from t_r_m_process_transaction_log pp), " + T_ID + " ,'5'," + loggedInUser.ID + ",'" + COMMENTS + "')";
                cmd.ExecuteReader();
            }
            con.Close();
            return true;
        }
        public bool RefferedBackProcessTransactionByAuthorizer(int T_ID, string COMMENTS)
        {
            var con = this.DatabaseConnection();
            var loggedInUser = sessionHandler.GetSessionUser();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = " Update t_r_m_process_transaction_status_mapping tm SET tm.STATUS_ID = 4 WHERE tm.T_ID=" + T_ID;
                OracleDataReader rdr = cmd.ExecuteReader();
                cmd.CommandText = "insert into t_r_m_process_transaction_log p (p.ID,p.T_ID,p.STATUS_ID,p.USER_ID,p.COMMENTS) VALUES ( (select COALESCE(max(pp.ID)+1,1) from t_r_m_process_transaction_log pp), " + T_ID + " ,'4'," + loggedInUser.ID + ",'" + COMMENTS + "')";
                cmd.ExecuteReader();
            }
            con.Close();
            return true;
        }
        public List<AuditFrequencyModel> GetAuditFrequencies()
        {
            var con = this.DatabaseConnection();
            List<AuditFrequencyModel> freqList = new List<AuditFrequencyModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {

                cmd.CommandText = "select * from T_AUDIT_FREQUENCY F WHERE F.STATUS='Y' order by F.ID";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditFrequencyModel freq = new AuditFrequencyModel();
                    freq.ID = Convert.ToInt32(rdr["ID"]);
                    freq.FREQUENCY_ID = Convert.ToInt32(rdr["FREQUENCY_ID"]);
                    freq.FREQUENCY_DISCRIPTION = rdr["FREQUENCY_DISCRIPTION"].ToString();
                    freq.STATUS = rdr["STATUS"].ToString();
                    freqList.Add(freq);
                }
            }
            con.Close();
            return freqList;
        }
        public List<RiskModel> GetRisks()
        {
            var con = this.DatabaseConnection();
            List<RiskModel> riskList = new List<RiskModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
             
                cmd.CommandText = "select * from T_RISK R order by R.R_ID";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    RiskModel risk = new RiskModel();
                    risk.R_ID = Convert.ToInt32(rdr["R_ID"]);
                    risk.DESCRIPTION = rdr["DESCRIPTION"].ToString();
                    riskList.Add(risk);
                }
            }
            con.Close();
            return riskList;
        }
        public List<AuditCriteriaModel> GetRefferedBackAuditCriterias()
        {
            var con = this.DatabaseConnection();
            List<AuditCriteriaModel> criteriaList = new List<AuditCriteriaModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select ac.* , p.DESCRIPTION as PERIOD ,et.entitytypedesc as ENTITY, r.description as RISK, f.frequency_discription as FREQUENCY, s.description as BRSIZE from t_audit_criteria ac inner join t_au_period p on ac.auditperiodid=p.id inner join t_auditee_ent_types et on ac.entity_id=et.autid and et.auditable='A' inner join t_risk r on ac.risk_id=r.r_id inner join t_audit_frequency f on ac.frequency_id=f.frequency_id left join t_auditee_entities_size_disc s on ac.size_id=s.entity_size WHERE ac.APPROVAL_STATUS=2";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditCriteriaModel acr = new AuditCriteriaModel();
                    acr.ID = Convert.ToInt32(rdr["ID"]);
                    acr.ENTITY_ID = Convert.ToInt32(rdr["ENTITY_ID"]);
                    if (rdr["SIZE_ID"].ToString() != null && rdr["SIZE_ID"].ToString() != "")
                        acr.SIZE_ID = Convert.ToInt32(rdr["SIZE_ID"]);
                    acr.RISK_ID = Convert.ToInt32(rdr["RISK_ID"]);
                    acr.FREQUENCY_ID = Convert.ToInt32(rdr["FREQUENCY_ID"]);
                    acr.NO_OF_DAYS = Convert.ToInt32(rdr["NO_OF_DAYS"]);
                    acr.APPROVAL_STATUS = Convert.ToInt32(rdr["APPROVAL_STATUS"]);
                    acr.AUDITPERIODID = Convert.ToInt32(rdr["AUDITPERIODID"]);
                    acr.PERIOD = rdr["PERIOD"].ToString(); 
                    acr.ENTITY = rdr["ENTITY"].ToString();
                    acr.FREQUENCY = rdr["FREQUENCY"].ToString();
                    acr.SIZE = rdr["BRSIZE"].ToString();
                    acr.RISK = rdr["RISK"].ToString();
                    acr.VISIT = rdr["VISIT"].ToString();
                    acr.COMMENTS = this.GetAuditCriteriaLogLastStatus(acr.ID);
                    criteriaList.Add(acr);
                }
            }
            con.Close();
            return criteriaList;
        }
        public List<AuditCriteriaModel> GetAuditCriteriasToAuthorize()
        {
            var con = this.DatabaseConnection();
            List<AuditCriteriaModel> criteriaList = new List<AuditCriteriaModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select ac.*, p.DESCRIPTION as PERIOD ,et.entitytypedesc as ENTITY, r.description as RISK, f.frequency_discription as FREQUENCY, s.description as BRSIZE from t_audit_criteria ac inner join t_au_period p on ac.auditperiodid=p.id inner join t_auditee_ent_types et on ac.entity_id=et.autid and et.auditable='A' inner join t_risk r on ac.risk_id=r.r_id inner join t_audit_frequency f on ac.frequency_id=f.frequency_id left join t_auditee_entities_size_disc s on ac.size_id=s.entity_size WHERE ac.APPROVAL_STATUS IN (1,3)";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditCriteriaModel acr = new AuditCriteriaModel();
                    acr.ID = Convert.ToInt32(rdr["ID"]);
                    acr.ENTITY_ID = Convert.ToInt32(rdr["ENTITY_ID"]);
                    if(rdr["SIZE_ID"].ToString()!=null && rdr["SIZE_ID"].ToString()!="")
                        acr.SIZE_ID = Convert.ToInt32(rdr["SIZE_ID"]);
                    acr.RISK_ID = Convert.ToInt32(rdr["RISK_ID"]);
                    acr.FREQUENCY_ID = Convert.ToInt32(rdr["FREQUENCY_ID"]);
                    acr.NO_OF_DAYS = Convert.ToInt32(rdr["NO_OF_DAYS"]);
                    acr.APPROVAL_STATUS = Convert.ToInt32(rdr["APPROVAL_STATUS"]);
                    acr.AUDITPERIODID = Convert.ToInt32(rdr["AUDITPERIODID"]);
                    acr.PERIOD = rdr["PERIOD"].ToString();
                    acr.ENTITY = rdr["ENTITY"].ToString();
                    acr.FREQUENCY = rdr["FREQUENCY"].ToString();
                    acr.SIZE = rdr["BRSIZE"].ToString();
                    acr.RISK = rdr["RISK"].ToString();
                    acr.VISIT = rdr["VISIT"].ToString();
                    acr.COMMENTS = this.GetAuditCriteriaLogLastStatus(acr.ID);
                    criteriaList.Add(acr);
                }
            }
            con.Close();
            return criteriaList;
        }
        public bool AddAuditCriteria(AddAuditCriteriaModel acm)
        {
            bool isAlreadyAdded = false; 
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {                
                cmd.CommandText = "SELECT a.ID FROM T_AUDIT_CRITERIA a WHERE  a.ENTITY_ID ="+acm.ENTITY_ID+" and a.SIZE_ID="+acm.SIZE_ID+" and a.RISK_ID="+acm.RISK_ID;
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr["ID"].ToString() != "" && rdr["ID"].ToString() != null)
                        isAlreadyAdded = true;
                }
                if (!isAlreadyAdded)
                {
                    cmd.CommandText = "INSERT INTO T_AUDIT_CRITERIA a (a.ID, a.ENTITY_ID, a.SIZE_ID,a.RISK_ID, a.FREQUENCY_ID,a.NO_OF_DAYS,a.VISIT,a.APPROVAL_STATUS,a.AUDITPERIODID ) VALUES ( (select COALESCE(max(acc.ID)+1,1) from T_AUDIT_CRITERIA acc) ,'" + acm.ENTITY_ID + "','" + acm.SIZE_ID + "','" + acm.RISK_ID + "','" + acm.FREQUENCY_ID + "','" + acm.NO_OF_DAYS + "','" + acm.VISIT + "','" + acm.APPROVAL_STATUS + "','" + acm.AUDITPERIODID + "' )";
                    cmd.ExecuteReader();
                    AuditCriteriaLogModel alog = new AuditCriteriaLogModel();
                    alog.ID = 0;
                    alog.C_ID = 0;
                    alog.STATUS_ID = 1;
                    alog.REMARKS = "AUDIT CRITERIA CREATED";
                    var loggedInUser = sessionHandler.GetSessionUser();
                    alog.CREATEDBY_ID = loggedInUser.ID;
                    alog.CREATED_ON = DateTime.Now;
                    alog.UPDATED_BY = Convert.ToInt32(loggedInUser.PPNumber);
                    alog.LAST_UPDATED_ON = DateTime.Now;
                    cmd.CommandText = "INSERT INTO T_AUDIT_CRITERIA_LOG al (al.ID, al.C_ID, al.STATUS_ID,al.CREATEDBY_ID , al.CREATED_ON, al.REMARKS, al.UPDATED_BY, al.LAST_UPDATED_ON ) VALUES ( (select COALESCE(max(acc.ID)+1,1) from T_AUDIT_CRITERIA_LOG acc) , (select max(acc1.ID) from T_AUDIT_CRITERIA acc1),'" + alog.STATUS_ID + "','" + alog.CREATEDBY_ID + "',to_date('" + alog.CREATED_ON + "','dd/mm/yyyy HH:MI:SS AM'),'" + alog.REMARKS + "','" + alog.UPDATED_BY + "',to_date('" + alog.LAST_UPDATED_ON + "','dd/mm/yyyy HH:MI:SS AM'))";
                    cmd.ExecuteReader();
                }
            }
            con.Close();
            return !isAlreadyAdded;
        }
        public bool UpdateAuditCriteria(AddAuditCriteriaModel acm, string COMMENTS)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE T_AUDIT_CRITERIA a  SET a.ENTITY_ID='"+acm.ENTITY_ID+ "' , a.SIZE_ID='" + acm.SIZE_ID + "' ,a.RISK_ID ='" + acm.RISK_ID + "', a.FREQUENCY_ID ='" + acm.FREQUENCY_ID + "',a.NO_OF_DAYS ='" + acm.NO_OF_DAYS + "',a.VISIT ='" + acm.VISIT + "',a.APPROVAL_STATUS ='" + acm.APPROVAL_STATUS + "',a.AUDITPERIODID ='" + acm.AUDITPERIODID + "' WHERE a.ID= '"+acm.ID+"'";
                cmd.ExecuteReader();
                AuditCriteriaLogModel alog = new AuditCriteriaLogModel();
                alog.ID = 0;
                alog.C_ID = acm.ID;
                alog.STATUS_ID = 3;
                alog.REMARKS = COMMENTS;
                var loggedInUser = sessionHandler.GetSessionUser();
                alog.CREATEDBY_ID = loggedInUser.ID;
                alog.CREATED_ON = DateTime.Now;
                alog.UPDATED_BY = Convert.ToInt32(loggedInUser.PPNumber);
                alog.LAST_UPDATED_ON = DateTime.Now;
                cmd.CommandText = "INSERT INTO T_AUDIT_CRITERIA_LOG al (al.ID, al.C_ID, al.STATUS_ID,al.CREATEDBY_ID , al.CREATED_ON, al.REMARKS, al.UPDATED_BY, al.LAST_UPDATED_ON ) VALUES ( (select COALESCE(max(acc.ID)+1,1) from T_AUDIT_CRITERIA_LOG acc) , (select max(acc1.ID) from T_AUDIT_CRITERIA acc1),'" + alog.STATUS_ID + "','" + alog.CREATEDBY_ID + "',to_date('" + alog.CREATED_ON + "','dd/mm/yyyy HH:MI:SS AM'),'" + alog.REMARKS + "','" + alog.UPDATED_BY + "',to_date('" + alog.LAST_UPDATED_ON + "','dd/mm/yyyy HH:MI:SS AM'))";
                cmd.ExecuteReader();
            }
            con.Close();
            return true;
        }
        public bool SetAuditCriteriaStatusReferredBack(int ID)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE T_AUDIT_CRITERIA a SET a.APPROVAL_STATUS=2 WHERE a.ID = "+ID;
                cmd.ExecuteReader();
                AuditCriteriaLogModel alog = new AuditCriteriaLogModel();
                alog.ID = 0;
                alog.C_ID = ID;
                alog.STATUS_ID = 2;
                alog.REMARKS = "REFERRED BACK";
                var loggedInUser = sessionHandler.GetSessionUser();
                alog.CREATEDBY_ID = loggedInUser.ID;
                alog.CREATED_ON = DateTime.Now;
                alog.UPDATED_BY = Convert.ToInt32(loggedInUser.PPNumber);
                alog.LAST_UPDATED_ON = DateTime.Now;
                cmd.CommandText = "INSERT INTO T_AUDIT_CRITERIA_LOG al (al.ID, al.C_ID, al.STATUS_ID,al.CREATEDBY_ID , al.CREATED_ON, al.REMARKS, al.UPDATED_BY, al.LAST_UPDATED_ON ) VALUES ( (select COALESCE(max(acc.ID)+1,1) from T_AUDIT_CRITERIA_LOG acc) , '" + alog.C_ID+"','" + alog.STATUS_ID + "','" + alog.CREATEDBY_ID + "',to_date('" + alog.CREATED_ON + "','dd/mm/yyyy HH:MI:SS AM'),'" + alog.REMARKS + "','" + alog.UPDATED_BY + "',to_date('" + alog.LAST_UPDATED_ON + "','dd/mm/yyyy HH:MI:SS AM'))";
                cmd.ExecuteReader();
            }
            con.Close();
            return true;
        }
        public bool SetAuditCriteriaStatusApprove(int ID)
        {
            var con = this.DatabaseConnection();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "UPDATE T_AUDIT_CRITERIA a SET a.APPROVAL_STATUS=4 WHERE a.ID = " + ID;
                cmd.ExecuteReader();
                AuditCriteriaLogModel alog = new AuditCriteriaLogModel();
                alog.ID = 0;
                alog.C_ID = ID;
                alog.STATUS_ID = 4;
                alog.REMARKS = "APPROVED";
                var loggedInUser = sessionHandler.GetSessionUser();
                alog.CREATEDBY_ID = loggedInUser.ID;
                alog.CREATED_ON = DateTime.Now;
                alog.UPDATED_BY = Convert.ToInt32(loggedInUser.PPNumber);
                alog.LAST_UPDATED_ON = DateTime.Now;
                cmd.CommandText = "INSERT INTO T_AUDIT_CRITERIA_LOG al (al.ID, al.C_ID, al.STATUS_ID,al.CREATEDBY_ID , al.CREATED_ON, al.REMARKS, al.UPDATED_BY, al.LAST_UPDATED_ON ) VALUES ( (select COALESCE(max(acc.ID)+1,1) from T_AUDIT_CRITERIA_LOG acc) , '" + alog.C_ID + "','" + alog.STATUS_ID + "','" + alog.CREATEDBY_ID + "',to_date('" + alog.CREATED_ON + "','dd/mm/yyyy HH:MI:SS AM'),'" + alog.REMARKS + "','" + alog.UPDATED_BY + "',to_date('" + alog.LAST_UPDATED_ON + "','dd/mm/yyyy HH:MI:SS AM'))";
                cmd.ExecuteReader();
                cmd.CommandText = "INSERT INTO T_AU_PLAN ( CRITERIA_ID, AUDITPERIODID, AUDITEDBY, ENTITY_ID, ENTITY_CODE, AUDITEE_NAME, AUDITEE_RISK, AUDITEE_SIZE, NO_OF_DAYS, FREQUENCY_DISCRIPTION) select a.id, a.auditperiodid, e.auditby_id, e.entity_id, e.code, e.name, r.description as Risk, s.description as Entity_size, a.no_of_days, f.frequency_discription as frequency from t_auditee_entities      e, t_au_period   p, t_auditee_entities_risk er, t_auditee_entities_size es, t_audit_criteria        a, t_risk_status r, t_auditee_entities_size_disc     s, t_audit_frequency       f where a.entity_id = e.type_id       and e.entity_id = er.entity_id       and a.auditperiodid=p.auditperiodid       and er.risk_rating = a.risk_id and a.auditperiodid = er.audit_period_id and er.risk_rating = r.r_id and e.entity_id = es.entity_id and a.size_id = es.entity_size and es.entity_size = s.entity_size and a.frequency_id = f.frequency_id    and a.approval_status=4 and p.status_id=1";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   

                }

            }
            con.Close();
            EmailConfiguration email = new EmailConfiguration();
            email.ConfigEmail();
            return true;
        }
        public string GetAuditCriteriaLogLastStatus(int Id)
        {
            var con = this.DatabaseConnection();
            string remarks = "";
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select remarks from T_AUDIT_CRITERIA_LOG l where l.c_id=" + Id + " order by l.CREATED_ON desc FETCH NEXT 1 ROWS ONLY";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    remarks = rdr["remarks"].ToString();
                }
            }
            con.Close();
            return remarks;
        }
        public List<AuditVoilationcatModel> GetAuditVoilationcats()
        {
            var con = this.DatabaseConnection();
            List<AuditVoilationcatModel> voilationList = new List<AuditVoilationcatModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {

                cmd.CommandText = "select * from t_control_violation V order by V.ID";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditVoilationcatModel voilationcat = new AuditVoilationcatModel();
                    voilationcat.ID = Convert.ToInt32(rdr["ID"]);
                    voilationcat.V_NAME = rdr["V_Name"].ToString();
                    voilationcat.MAX_NUMBER = Convert.ToInt32(rdr["MAX_Number"]);
                    voilationcat.STATUS = rdr["Status"].ToString();
                    voilationList.Add(voilationcat);
                }
            }
            con.Close();
            return voilationList;
        }
        public List<AuditSubVoilationcatModel> GetVoilationSubGroup(int group_id)
        {
            var con = this.DatabaseConnection();
            List<AuditSubVoilationcatModel> voilationsubgroupList = new List<AuditSubVoilationcatModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (group_id == 0)
                    cmd.CommandText = "select * from t_control_violation_sub S order by S.ID";
                else


                    cmd.CommandText = "select * from t_control_violation_sub S where s.p_id= " + group_id + "  order by s.p_ID, s.ID asc";

                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditSubVoilationcatModel vsgm = new AuditSubVoilationcatModel();
                    vsgm.ID = Convert.ToInt32(rdr["ID"]);
                    vsgm.V_ID = Convert.ToInt32(rdr["V_ID"]);
                    vsgm.SUB_V_NAME = rdr["SUB_V_NAME"].ToString();
                    vsgm.RISK_ID = rdr["RISK_ID"].ToString();
                    vsgm.STATUS = rdr["STATUS"].ToString();

                    voilationsubgroupList.Add(vsgm);
                }
            }
            con.Close();
            return voilationsubgroupList;
        }
        public List<TaskListModel> GetTaskList()
        {
            var con = this.DatabaseConnection();
            List<TaskListModel> tasklist = new List<TaskListModel>();
            var loggedInUser=sessionHandler.GetSessionUser();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select t.*, (select ss.description from T_AU_AUDIT_TEAM_TASKLIST_STATUS ss where ss.status_id=(t.status_id+1)) as ENG_NEXT_STATUS, ta.T_NAME, ts.DESCRIPTION as ENG_STATUS from T_AU_AUDIT_TEAM_TASKLIST t inner join T_AU_AUDIT_TEAMS ta on t.TEAM_ID=ta.TEAM_ID and t.eng_plan_id=ta.eng_id inner join T_AU_AUDIT_TEAM_TASKLIST_STATUS ts on t.STATUS_ID = ts.STATUS_ID   WHERE t.teammember_ppno = " + loggedInUser.PPNumber+ " order by t.SEQUENCE_NO";

                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    TaskListModel tlist = new TaskListModel();
                    tlist.ID= Convert.ToInt32(rdr["ID"]);
                    tlist.ENG_PLAN_ID = Convert.ToInt32(rdr["ENG_PLAN_ID"]);
                    tlist.TEAM_ID = Convert.ToInt32(rdr["TEAM_ID"]);
                    tlist.SEQUENCE_NO = Convert.ToInt32(rdr["SEQUENCE_NO"]);
                    tlist.TEAMMEMBER_PPNO = Convert.ToInt32(rdr["TEAMMEMBER_PPNO"]);
                    tlist.ENTITY_ID = Convert.ToInt32(rdr["ENTITY_ID"]);
                    tlist.ENTITY_CODE = Convert.ToInt32(rdr["ENTITY_CODE"]);
                    tlist.ENTITY_NAME = rdr["ENTITY_NAME"].ToString();
                    //tlist.TEAMMEMBER_PPNO = Convert.ToInt32(loggedInUser.PPNumber);
                    tlist.TEAM_NAME = rdr["T_NAME"].ToString();
                    tlist.EMP_NAME = loggedInUser.Name.ToString();
                    tlist.AUDIT_START_DATE = Convert.ToDateTime(rdr["AUDIT_START_DATE"]);
                    tlist.AUDIT_END_DATE = Convert.ToDateTime(rdr["AUDIT_END_DATE"]);
                    tlist.STATUS_ID = Convert.ToInt32(rdr["STATUS_ID"]);
                    tlist.ENG_STATUS = rdr["ENG_STATUS"].ToString();
                    tlist.ENG_NEXT_STATUS = rdr["ENG_NEXT_STATUS"].ToString();
                    tlist.ISACTIVE = rdr["ISACTIVE"].ToString();
                    tasklist.Add(tlist);
                }
            }
            con.Close();
            return tasklist;
        }
        public JoiningModel GetJoiningDetails(int engId=0)
        {
            var con = this.DatabaseConnection();
            JoiningModel jm = new JoiningModel();
            List<JoiningTeamModel> tjlist = new List<JoiningTeamModel>();
            var loggedInUser = sessionHandler.GetSessionUser();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select t.team_id, tm.member_name,tm.member_ppno, tm.team_name as TEAM_NAME, t.entity_id, t.entity_code, t.entity_name, t.audit_start_date, t.audit_end_date, rt.description as RISK, st.description as ENT_SIZE ,p.description as AUDIT_PERIOD, tm.isteamlead from t_au_audit_team_tasklist t inner join t_au_plan_eng pe    on t.eng_plan_id = pe.eng_id    inner join t_au_period p on pe.period_id=p.auditperiodid    inner join t_au_team_members tm on t.teammember_ppno=tm.member_ppno    inner join t_auditee_entities_risk r on t.entity_id=r.entity_id    inner join t_risk rt on r.risk_rating=rt.r_id    inner join t_auditee_entities_size s on t.entity_id=s.entity_id    inner join t_auditee_entities_size_disc st on s.entity_size=st.entity_size where t.eng_plan_id = " + engId;
               
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    jm.ENG_PLAN_ID = engId;
                    jm.ENTITY_ID = Convert.ToInt32(rdr["ENTITY_ID"]);
                    jm.ENTITY_CODE = Convert.ToInt32(rdr["ENTITY_CODE"]);
                    jm.ENTITY_NAME = rdr["ENTITY_NAME"].ToString();
                    jm.STATUS = "";
                    jm.RISK= rdr["RISK"].ToString();
                    jm.SIZE = rdr["ENT_SIZE"].ToString();
                    jm.START_DATE = Convert.ToDateTime(rdr["AUDIT_START_DATE"]);
                    jm.END_DATE = Convert.ToDateTime(rdr["AUDIT_END_DATE"]);
                    jm.AUDIT_PERIOD= rdr["AUDIT_PERIOD"].ToString();
                    jm.TEAM_NAME= rdr["TEAM_NAME"].ToString();
                    JoiningTeamModel tm = new JoiningTeamModel();
                    tm.EMP_NAME= rdr["MEMBER_NAME"].ToString();
                    tm.PP_NO = Convert.ToInt32(rdr["MEMBER_PPNO"]);
                    tm.IS_TEAM_LEAD = rdr["ISTEAMLEAD"].ToString();
                    tjlist.Add(tm);
                    jm.TEAM_DETAILS = tjlist;
                }
            }
            con.Close();
            return jm;
        }
        public bool AddJoiningReport(AddJoiningModel jm)
        {
            var con = this.DatabaseConnection();
            var loggedInUser = sessionHandler.GetSessionUser();
            jm.ENTEREDBY =Convert.ToInt32(loggedInUser.PPNumber);
            jm.ENTEREDDATE = System.DateTime.Now;
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = cmd.CommandText = "INSERT INTO T_AU_AUDIT_JOINING al (al.ID, al.ENG_PLAN_ID, al.TEAM_MEM_PPNO,al.JOINING_DATE , al.ENTEREDBY, al.ENTEREDDATE, al.COMPLETION_DATE ) VALUES ( (select COALESCE(max(acc.ID)+1,1) from T_AU_AUDIT_JOINING acc) , '" + jm.ENG_PLAN_ID + "','" + jm.TEAM_MEM_PPNO + "',to_date('" + jm.JOINING_DATE + "','dd/mm/yyyy HH:MI:SS AM'),'" + jm.ENTEREDBY + "',to_date('" + jm.ENTEREDDATE + "','dd/mm/yyyy HH:MI:SS AM'), to_date('" + jm.COMPLETION_DATE + "','dd/mm/yyyy HH:MI:SS AM'))";
                cmd.ExecuteReader();
                cmd.CommandText = cmd.CommandText = "UPDATE T_AU_AUDIT_TEAM_TASKLIST SET STATUS_ID= (select COALESCE(acc.STATUS_ID+1,1) from T_AU_AUDIT_TEAM_TASKLIST acc WHERE acc.ENG_PLAN_ID=" + jm.ENG_PLAN_ID + " and acc.TEAMMEMBER_PPNO= " + jm.TEAM_MEM_PPNO+") WHERE ENG_PLAN_ID="+jm.ENG_PLAN_ID+ " and TEAMMEMBER_PPNO= "+jm.TEAM_MEM_PPNO;
                cmd.ExecuteReader();

            }
            con.Close();
            return true;
        }
        public List<AuditChecklistModel> GetAuditChecklist()
        {
            var con = this.DatabaseConnection();
            List<AuditChecklistModel> list = new List<AuditChecklistModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select t.*, e.entitytypedesc as ENTITY_TYPE_NAME from t_audit_checklist t inner join t_auditee_ent_types e on t.entity_type=e.autid where t.STATUS='Y' order by t.t_id asc";

                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditChecklistModel chk = new AuditChecklistModel();
                    chk.T_ID = Convert.ToInt32(rdr["T_ID"]);
                    chk.HEADING = rdr["HEADING"].ToString();
                    chk.ENTITY_TYPE = Convert.ToInt32(rdr["ENTITY_TYPE"]);
                    chk.ENTITY_TYPE_NAME = rdr["ENTITY_TYPE_NAME"].ToString();
                    chk.STATUS = rdr["STATUS"].ToString();
                    list.Add(chk);
                }
            }
            con.Close();
            return list;
        }
        public List<AuditChecklistSubModel> GetAuditChecklistSub(int t_id=0, int eng_id=0)
        {
            var con = this.DatabaseConnection();
            List<AuditChecklistSubModel> list = new List<AuditChecklistSubModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if(t_id==0)
                cmd.CommandText = "select t.*, p.heading as T_NAME, e.entitytypedesc as ENTITY_TYPE_NAME  from t_audit_checklist_sub t inner join t_audit_checklist p on p.t_id=t.t_id inner join t_auditee_ent_types e on t.entity_type=e.autid where t.STATUS='Y' order by t.s_id asc";
                else
                    cmd.CommandText = "select t.*, p.heading as T_NAME, e.entitytypedesc as ENTITY_TYPE_NAME from t_audit_checklist_sub t inner join t_audit_checklist p on p.t_id=t.t_id inner join t_auditee_ent_types e on t.entity_type=e.autid where t.STATUS='Y' and t.t_id=" + t_id+ " order by t.s_id asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditChecklistSubModel chk = new AuditChecklistSubModel();
                    chk.S_ID = Convert.ToInt32(rdr["S_ID"]); 
                    chk.T_ID = Convert.ToInt32(rdr["T_ID"]);
                    chk.T_NAME = rdr["T_NAME"].ToString();
                    chk.HEADING = rdr["HEADING"].ToString();
                    chk.ENTITY_TYPE = Convert.ToInt32(rdr["ENTITY_TYPE"]);
                    chk.ENTITY_TYPE_NAME = rdr["ENTITY_TYPE_NAME"].ToString();
                    chk.STATUS = "Pending";
                    if (eng_id != 0)
                    {
                        cmd.CommandText = "select os.statusname from t_au_observation o inner join t_au_observation_status os on o.status=os.statusid where o.subchecklist_id=" + chk.S_ID +" and o.engplanid="+eng_id;
                        OracleDataReader rdr2 = cmd.ExecuteReader();
                        while (rdr2.Read())
                        {
                            if(rdr2["statusname"].ToString()!="" && rdr2["statusname"].ToString() != null)
                            { chk.STATUS = rdr2["statusname"].ToString(); }
                            else
                            {
                                chk.STATUS = "Pending";
                            }
                        }                           
                    }
                    
                    list.Add(chk);
                }
            }
            con.Close();
            return list;
        }
        public List<AuditChecklistDetailsModel> GetAuditChecklistDetails(int s_id = 0)
        {
            var con = this.DatabaseConnection();
            List<AuditChecklistDetailsModel> list = new List<AuditChecklistDetailsModel>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                if (s_id == 0)
                    cmd.CommandText = "select t.*, p.heading as S_NAME, s.description as V_NAME, r.description as RISK from t_audit_checklist_details t inner join t_audit_checklist_sub p on p.s_id=t.s_id inner join t_r_sub_group s on s.s_gr_id=t.v_id inner join t_risk r on r.r_id=t.risk_id where t.STATUS='Y' order by t.id asc";
                else
                    cmd.CommandText = "select t.*, p.heading as S_NAME, s.description as V_NAME, r.description as RISK from t_audit_checklist_details t inner join t_audit_checklist_sub p on p.s_id=t.s_id inner join t_r_sub_group s on s.s_gr_id=t.v_id inner join t_risk r on r.r_id=t.risk_id where t.STATUS='Y' and t.s_id=" + s_id+ " order by t.id asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AuditChecklistDetailsModel chk = new AuditChecklistDetailsModel();
                    chk.ID = Convert.ToInt32(rdr["ID"]);
                    chk.S_ID = Convert.ToInt32(rdr["S_ID"]);
                    chk.S_NAME = rdr["S_NAME"].ToString();
                    chk.V_ID = Convert.ToInt32(rdr["V_ID"]);
                    chk.V_NAME = rdr["V_NAME"].ToString();
                    chk.HEADING = rdr["HEADING"].ToString();
                    chk.RISK_ID = Convert.ToInt32(rdr["RISK_ID"]);
                    chk.RISK = rdr["RISK"].ToString();
                    if (rdr["ROLE_RESP_ID"].ToString() != null && rdr["ROLE_RESP_ID"].ToString() != "")
                    {
                        chk.ROLE_RESP_ID = Convert.ToInt32(rdr["ROLE_RESP_ID"]);
                       // chk.ROLE_RESP = rdr["ROLE_RESP"].ToString();
                    }
                    if (rdr["PROCESS_OWNER_ID"].ToString() != null && rdr["PROCESS_OWNER_ID"].ToString() != "")
                    {
                        chk.PROCESS_OWNER_ID = Convert.ToInt32(rdr["PROCESS_OWNER_ID"]);
                       // chk.PROCESS_OWNER = rdr["PROCESS_OWNER"].ToString();

                    }
                    chk.STATUS = rdr["STATUS"].ToString();
                    list.Add(chk);
                }
            }
            con.Close();
            return list;
        }
        public bool SaveAuditObservation(ObservationModel ob)
        {
            var con = this.DatabaseConnection();
            var loggedInUser = sessionHandler.GetSessionUser();
            ob.ENTEREDBY = Convert.ToInt32(loggedInUser.PPNumber);
            ob.ENTEREDDATE = System.DateTime.Now;
            ob.MEMO_DATE = System.DateTime.Now;
            ob.RESPONSIBILITY_ASSIGNED = "(select cd.role_resp_id from t_audit_checklist_details cd where cd.id="+ob.SUBCHECKLIST_ID+")";
            String RiskModelQuery = "(select cd.v_id from t_audit_checklist_details cd where cd.id=" + ob.SUBCHECKLIST_ID + ")";
            String MemoNumberQuery = "(select COALESCE(max(ob.memo_number)+1,1) from t_au_observation ob where ob.engplanid=" + ob.ENGPLANID+ " and ob.subchecklist_id=" + ob.SUBCHECKLIST_ID+")";
            String ReplyByQuery = "(select pe.entity_code from t_au_plan_eng pe where pe.eng_id= "+ob.ENGPLANID+")";
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO T_AU_OBSERVATION o (o.ID, o.ENGPLANID, o.STATUS, o.ENTEREDBY, o.ENTEREDDATE, o.REPLYBY, o.REPLYDATE, o.MEMO_DATE, o.SEVERITY, o.MEMO_NUMBER, o.RESPONSIBILITY_ASSIGNED, o.RISKMODEL_ID, o.SUBCHECKLIST_ID ) VALUES ( (select COALESCE(max(acc.ID)+1,1) from T_AU_OBSERVATION acc) , '" + ob.ENGPLANID + "','" + ob.STATUS + "','" + ob.ENTEREDBY + "',to_date('" + ob.ENTEREDDATE + "','dd/mm/yyyy HH:MI:SS AM')," + ReplyByQuery + ",to_date('" + ob.REPLYDATE + "','dd/mm/yyyy HH:MI:SS AM'), to_date('" + ob.MEMO_DATE + "','dd/mm/yyyy HH:MI:SS AM'), " + RiskModelQuery + "," + MemoNumberQuery + "," + ob.RESPONSIBILITY_ASSIGNED + " ," + RiskModelQuery + ",'" + ob.SUBCHECKLIST_ID + "')";
                cmd.ExecuteReader();
                cmd.CommandText = "INSERT INTO T_AU_OBSERVATION_TEXT ot (ot.ID, ot.OBSERVATSION_ID, ot.TEXT, ot.ENTEREDBY, ot.ENTEREDDATE ) VALUES ( (select COALESCE(max(acc.ID)+1,1) from T_AU_OBSERVATION_TEXT acc) , (select max(o.ID) from T_AU_OBSERVATION o) ,  '" + ob.OBSERVATION_TEXT + "','" + ob.ENTEREDBY + "',to_date('" + ob.ENTEREDDATE + "','dd/mm/yyyy HH:MI:SS AM'))";
                cmd.ExecuteReader();
                cmd.CommandText = "INSERT INTO T_AU_OBSERVATION_ASSIGNEDTO ot (ot.ID, ot.OBS_ID, ot.OBS_TEXT_ID, ot.ASSIGNEDTO_ROLE, ot.ASSIGNEDBY, ot.ASSIGNED_DATE, ot.IS_ACTIVE, ot.REPLIED ) VALUES ( (select COALESCE(max(acc.ID)+1,1) from T_AU_OBSERVATION_TEXT acc) , (select max(o.ID) from T_AU_OBSERVATION o), (select max(tt.ID) from T_AU_OBSERVATION_TEXT tt), " + ReplyByQuery + ",'" + ob.ENTEREDBY + "',to_date('" + ob.ENTEREDDATE + "','dd/mm/yyyy HH:MI:SS AM'),'Y','N')";
                cmd.ExecuteReader();
                String ObsId = "(SELECT MAX(ID) FROM T_AU_OBSERVATION)";
                cmd.CommandText = "UPDATE T_AU_OBSERVATION SET STATUS=2 WHERE ID = " + ObsId;
                cmd.ExecuteReader();
            }
            con.Close();
            return true;
        }
        public List<AssignedObservations> GetAssignedObservations(int s_id = 0)
        {
            var con = this.DatabaseConnection();
            var loggedInUser = sessionHandler.GetSessionUser();
            string query = "";
            if (loggedInUser.UserLocationType == "H")
                query = query + " and t.ASSIGNEDTO_ROLE=" + loggedInUser.UserPostingDept;
            else if (loggedInUser.UserLocationType == "B")
                query = query + " and t.ASSIGNEDTO_ROLE=" + loggedInUser.UserPostingBranch;
            else if (loggedInUser.UserLocationType == "Z")
            {
                if (loggedInUser.UserPostingAuditZone != 0 && loggedInUser.UserPostingAuditZone != null)
                    query = query + " and t.ASSIGNEDTO_ROLE=" + loggedInUser.UserPostingAuditZone;
                else
                    query = query + " and t.ASSIGNEDTO_ROLE=" + loggedInUser.UserPostingZone;
            }
            List<AssignedObservations> list = new List<AssignedObservations>();
            using (OracleCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "select o.Memo_Date, o.replydate, t.* , ot.text as OBSERVATION_TEXT, ot.text_plain as OBSERVATION_TEXT_PLAIN,  s.statusname as STATUS, e.name AS ENTITY_NAME, pe.audit_startdate as AUDIT_STARTDATE, pe.audit_enddate as AUDIT_ENDDATE  from t_au_observation_assignedto t inner join t_au_observation o on o.id=t.obs_id inner join t_au_observation_text ot on ot.id=t.obs_text_id inner join t_au_observation_status s on o.status=s.statusid inner join t_auditee_entities e on e.code=t.assignedto_role inner join t_au_plan_eng pe on pe.entity_id=e.entity_id WHERE 1=1  " + query+"  order by t.OBS_ID asc";
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    AssignedObservations chk = new AssignedObservations();
                    chk.ID = Convert.ToInt32(rdr["ID"]);
                    chk.OBS_ID = Convert.ToInt32(rdr["OBS_ID"]);
                    chk.OBS_TEXT_ID = Convert.ToInt32(rdr["OBS_TEXT_ID"]);
                    chk.ASSIGNEDTO_ROLE = Convert.ToInt32(rdr["ASSIGNEDTO_ROLE"]);
                    chk.ASSIGNEDBY = Convert.ToInt32(rdr["ASSIGNEDBY"]);
                    chk.ASSIGNED_DATE = Convert.ToDateTime(rdr["ASSIGNED_DATE"]);
                    //chk.LASTUPDATEDBY = Convert.ToInt32(rdr["LASTUPDATEDBY"]);
                    //chk.LASTUPDATEDDATE = Convert.ToDateTime(rdr["LASTUPDATEDDATE"]);
                    chk.IS_ACTIVE = rdr["IS_ACTIVE"].ToString();
                    chk.REPLIED = rdr["REPLIED"].ToString();
                    chk.OBSERVATION_TEXT = rdr["OBSERVATION_TEXT"].ToString();
                    chk.STATUS = rdr["STATUS"].ToString();
                    chk.ENTITY_NAME = rdr["ENTITY_NAME"].ToString();
                    chk.MEMO_DATE = rdr["MEMO_DATE"].ToString();
                    chk.MEMO_REPLY_DATE = rdr["REPLYDATE"].ToString();
                    list.Add(chk);
                }
            }
            con.Close();
            return list;
        }
    }
}