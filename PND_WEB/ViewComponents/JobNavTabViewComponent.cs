using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;

namespace PND_WEB.ViewComponents
{
    public class JobNavTabViewComponent : ViewComponent
    {
        private readonly DataContext _context;

        public JobNavTabViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string Job_ID, string userName)
        {
            bool hasPermission = false;
            
            // Check if user is the creator of the job
            var job = await _context.TblJobs
                .FirstOrDefaultAsync(j => j.JobId == Job_ID);
                
            if (job != null && job.JobOwner == userName)
            {
                hasPermission = true;
            }

          

            (string Job_ID, string userName, bool hasPermission) data = (Job_ID, userName, hasPermission);
            return View(data);
        }
    }
} 