using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;

namespace PND_WEB.ViewComponents
{
    public class HblNavTabViewComponent : ViewComponent
    {
        private readonly DataContext _context;


        public HblNavTabViewComponent(DataContext context)
        {
            _context = context;

        }
        public async Task<IViewComponentResult> InvokeAsync(string HBL_ID)
        {
            bool isLGT = await IsJobLGT(HBL_ID);
            (string HBL_ID, bool isLGT) data = (HBL_ID,isLGT);
            return View(data);
        }

        public async Task<bool> IsJobLGT(string HBL_ID)
        {
            var hbl = await _context.TblHbls
                .FirstOrDefaultAsync(h => h.Hbl == HBL_ID);
            var job = await _context.TblJobs
                .FirstOrDefaultAsync(j => j.JobId == hbl.RequestId);
            return job.GoodsType == "LGT";
        }
    }
}
