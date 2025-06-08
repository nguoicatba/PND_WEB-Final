using System.ComponentModel.DataAnnotations;
using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class ProfitReportViewModel
    {
        [Display(Name = "HBL")]
        public TblHbl Hbl { get; set; }

        [Display(Name = "Job/MBL")]
        public TblJob Job { get; set; }

        [Display(Name = "Total Buy")]
        public float TotalBuy { get; set; }

        [Display(Name = "Total Sell")]
        public float TotalSell { get; set; }

        [Display(Name = "Profit")]
        public float Profit { get; set; }
    }

    public class ProfitReportFilterModel
    {
        [Display(Name = "Từ ngày")]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; } = DateTime.Now.AddMonths(-1);

        [Display(Name = "Đến ngày")]
        [DataType(DataType.Date)]
        public DateTime ToDate { get; set; } = DateTime.Now;
    }
} 