﻿using AIS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;


namespace AIS.Controllers
{
    public class ApiCallsController : Controller
    {
        private readonly ILogger<ApiCallsController> _logger;
        private readonly TopMenus tm = new TopMenus();
        private readonly DBConnection dBConnection = new DBConnection();
        private readonly SessionHandler sessionHandler = new SessionHandler();

        public ApiCallsController(ILogger<ApiCallsController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public BranchModel branch_add(BranchModel br)
        {
            if (br.ISACTIVE == "Active")
                br.ISACTIVE = "Y";
            else if (br.ISACTIVE == "InActive")
                br.ISACTIVE = "N";

            if (br.BRANCHID == 0)
                br = dBConnection.AddBranch(br);
            else
                br = dBConnection.UpdateBranch(br);
            return br;
        }
      
        [HttpPost]
        public DivisionModel division_add(DivisionModel div)
        {
            if (div.ISACTIVE == "Active")
                div.ISACTIVE = "Y";
            else if (div.ISACTIVE == "InActive")
                div.ISACTIVE = "N";
           
            if (div.DIVISIONID == 0)
                div=dBConnection.AddDivision(div);
            else
                div=dBConnection.UpdateDivision(div);
            return div;
        }
      
        [HttpPost]
        public DepartmentModel department_add(DepartmentModel dept)
        {
            if (dept.STATUS == "Active")
                dept.STATUS = "A";
            else if (dept.STATUS == "InActive")
                dept.STATUS = "I";

            if (dept.ID == 0)
                dept = dBConnection.AddDepartment(dept);
            else
                dept = dBConnection.UpdateDepartment(dept);
            return dept;
        }
        
        [HttpPost]
        public ControlViolationsModel add_control_violation(ControlViolationsModel cv)
        {
            return dBConnection.AddControlViolation(cv);
        }
     
        [HttpPost]
        public List<DepartmentModel> get_departments(int div_id)
        {
            return dBConnection.GetDepartments(div_id,false);
        }
        [HttpPost]
        public List<SubEntitiesModel> get_sub_entities(int div_id=0,int dept_id=0)
        {
            return dBConnection.GetSubEntities(div_id,dept_id);
        }
        [HttpPost]
        public SubEntitiesModel add_sub_entity(SubEntitiesModel entity)
        {
            if (entity.STATUS == "Active")
                entity.STATUS = "Y";
            else
                entity.STATUS = "N";
            if(entity.ID==0)
                return dBConnection.AddSubEntity(entity);
            else
                return dBConnection.UpdateSubEntity(entity);
        }
        [HttpPost]
        public List<RiskProcessDetails> process_details(int ProcessId)
        {
            return dBConnection.GetRiskProcessDetails(ProcessId);
        }
        [HttpPost]
        public List<RiskProcessTransactions> process_transactions(int ProcessDetailId=0, int transactionId = 0)
        {
            return dBConnection.GetRiskProcessTransactions(ProcessDetailId, transactionId);
        }
        [HttpPost]
        public RiskProcessDefinition process_add(RiskProcessDefinition proc)
        {
            return dBConnection.AddRiskProcess(proc);            
        }
        [HttpPost]
        public RiskProcessDetails sub_process_add(RiskProcessDetails subProc)
        {
            return dBConnection.AddRiskSubProcess(subProc);
        }
        [HttpPost]
        public RiskProcessTransactions sub_process_transaction_add(RiskProcessTransactions tran)
        {
            return dBConnection.AddRiskSubProcessTransaction(tran);
        }
        [HttpPost]
        public bool recommend_process_transaction_by_reviewer(int T_ID, string COMMENTS)
        {
            return dBConnection.RecommendProcessTransactionByReviewer(T_ID,COMMENTS);
        }
        public bool reffered_back_process_transaction_by_reviewer(int T_ID, string COMMENTS)
        {
            return dBConnection.RefferedBackProcessTransactionByReviewer(T_ID, COMMENTS);
        }
        [HttpPost]
        public bool recommend_process_transaction_by_authorizer(int T_ID, string COMMENTS)
        {
            return dBConnection.RecommendProcessTransactionByAuthorizer(T_ID, COMMENTS);
        }
        [HttpPost]
        public bool reffered_back_process_transaction_by_authorizer(int T_ID, string COMMENTS)
        {
            return dBConnection.RefferedBackProcessTransactionByAuthorizer(T_ID, COMMENTS);
        }

        [HttpPost]
        public List<AuditChecklistSubModel> sub_checklist(int T_ID, int ENG_ID)
        {
            return dBConnection.GetAuditChecklistSub(T_ID,ENG_ID);
        }
        [HttpPost]
        public List<AuditChecklistDetailsModel> checklist_details(int S_ID)
        {
            return dBConnection.GetAuditChecklistDetails(S_ID);
        }
        [HttpPost]
        public bool save_observations(List<ListObservationModel> LIST_OBS, int ENG_ID, int S_ID )
        {
            foreach(ListObservationModel m in LIST_OBS)
            {
                ObservationModel ob = new ObservationModel();
                ob.SUBCHECKLIST_ID = S_ID;
                ob.ENGPLANID = ENG_ID;
                ob.REPLYDATE = DateTime.Today.AddDays(m.DAYS);
                ob.OBSERVATION_TEXT = m.MEMO;
                ob.STATUS = 1;
                dBConnection.SaveAuditObservation(ob);
            }
            return true;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}