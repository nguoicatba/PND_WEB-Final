using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class HblJobViewModel
    {
        public string?Job_Id { get; set; }
        public List<TblHbl> Hbls { get; set; }
    }
}
