using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIS.Models
{
    public class CAUOMAssignmentAIRModel
    {        
        public int ID { get; set; }
        public string OM_NO { get; set; }
        public string PARA_NO { get; set; }
        public string CONTENTS_OF_OM { get; set; }
        public string OM_REPLY { get; set; }
        public int STATUS { get; set; }
        public int DIV_ID { get; set; }
        public string STATUS_DES { get; set; }
        public string KEY { get; set; }
    }
}