using Microsoft.AspNetCore.Mvc;
using PND_WEB.Data;

namespace PND_WEB.ViewComponents
{
    public class JobDetailsHeaderViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public JobDetailsHeaderViewComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string Title, string SubTitle, string Job_ID)
        {
            bool isLocked = IsLocked(Job_ID);
            (string Title, string SubTitle, string Job_ID, bool isLocked) data = (Title, SubTitle, Job_ID,isLocked);
            return View(data);
        }

        public bool IsLocked(string Job_ID)
        {
            var job = _context.TblJobs.FirstOrDefault(j => j.JobId == Job_ID);
            if (job != null)
            {
                return job.JobStatus;
            }
            return false;
        }
    }
}
