using Humanizer;
using PND_WEB.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.ViewModels
{
    public class HblJobViewModel
    {
        public string?Job_Id { get; set; }
        public List<TblHbl> Hbls { get; set; }

   
     
    }
}
