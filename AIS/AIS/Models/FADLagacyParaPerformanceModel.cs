using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIS.Models
{
    public class FADLagacyParaPerformanceModel
    {
        public string Audit_Zone { get; set; }
        public string Total_Paras { get; set; }
        public string Setteled_Para { get; set; }
        public string Unsetteled_Para { get; set; }
        public string Ratio { get; set; }

    }
}
