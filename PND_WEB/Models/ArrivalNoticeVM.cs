namespace PND_WEB.Models
{
    public class ArrivalNoticeVM
    {
        public string ?HBL_ID { get; set; }

        public string ?Job_ID { get; set; }

        public string? Goods_Type { get; set; }

        public string ?MBL { get; set; }

        public string? HBL { get; set; }

        public string? POL { get; set; }

        public string? POD { get; set; }

        public string ? PODel { get; set; }

        public string? Shipper { get; set; }

        public string? CNEE { get; set; }

        public string? Transport { get; set; }

        public required DateTime ETA { get; set; }

        public string? BL_Type { get; set; }

        public List<TblConth> tblConths { get; set; } = new List<TblConth>();   

    }
}
