using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AIS.Models
{
    public class FADNewParaPerformanceModel
    {
        public string Audit_Zone { get; set; }
        public string Total_Paras { get; set; }
        public string Setteled_Para { get; set; }
        public string Unsetteled_Para { get; set; }
        public string Ratio { get; set; }
        public string R1 { get; set; }
        public string R2 { get; set; }
        public string R3 { get; set; }

    }
}
