using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class JobStatisticsViewModel
    {
        [Display(Name = "Từ ngày")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FromDate { get; set; }

        [Display(Name = "Đến ngày")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ToDate { get; set; }

        [Display(Name = "Tổng số job")]
        public int TotalJobs { get; set; }

        [Display(Name = "Trung bình số HBL/Job")]
        public double AverageHblsPerJob { get; set; }

        public List<JobStatsByMode> JobsByMode { get; set; }
        public List<JobStatsByGoodsType> JobsByGoodsType { get; set; }
        public List<JobStatsByAgent> JobsByAgent { get; set; }
        public List<JobStatsByCarrier> JobsByCarrier { get; set; }
        public List<JobStatsByPort> JobsByPol { get; set; }
        public List<JobStatsByPort> JobsByPod { get; set; }
        public List<JobStatsByMonth> JobsByMonth { get; set; }
        public List<JobDetailViewModel> RecentJobs { get; set; }
    }

    public class JobStatsByMode
    {
        public string Mode { get; set; }
        public int Count { get; set; }
    }

    public class JobStatsByGoodsType
    {
        public string GoodsType { get; set; }
        public int Count { get; set; }
    }

    public class JobStatsByAgent
    {
        public string AgentName { get; set; }
        public int Count { get; set; }
    }

    public class JobStatsByCarrier
    {
        public string CarrierName { get; set; }
        public int Count { get; set; }
    }

    public class JobStatsByPort
    {
        public string PortName { get; set; }
        public int Count { get; set; }
    }

    public class JobStatsByMonth
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Count { get; set; }
    }

    public class JobDetailViewModel
    {
        public string JobId { get; set; }
        public DateTime JobDate { get; set; }
        public string Mode { get; set; }
        public string GoodsType { get; set; }
        public string AgentName { get; set; }
        public string CarrierName { get; set; }
        public string Pol { get; set; }
        public string Pod { get; set; }
        public DateTime Etd { get; set; }
        public DateTime Eta { get; set; }
        public int HblCount { get; set; }
    }
} 