using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models
{
    [Table("Job_User")]
    public class JobUser
    {
        [Key]
        public int Id { get; set; } 
        public string Job_ID { get; set; }
      
       public string User_ID {get; set; }

       
       public string ? Description { get; set; }
      public DateTime? CreateDate { get; set; } = DateTime.Now;

    }
}
