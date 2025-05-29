using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;

namespace PND_WEB.ViewComponents
{
    public class HblProfitFooterViewComponent: ViewComponent
    {
        private readonly DataContext _context;
        public HblProfitFooterViewComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string hblId)
        {
            var chargeBuy = await _context.TblHblCharges
                .Where(c => c.HblId == hblId && c.SupplierId != null && c.Checked == true)
                .ToListAsync();
            var chargeSell = await _context.TblHblCharges
                .Where(c => c.HblId == hblId && c.CustomerId != null && c.Checked == true)
                .ToListAsync();

            float totalBuyUSD = chargeBuy.Sum(c => (c.SerPrice ?? 0) * (c.SerQuantity ?? 0) * (c.ExchangeRate ?? 1) * (1 + (c.SerVat ?? 0) / 100) + (c.MVat ?? 0));
            float totalSellUSD = chargeSell.Sum(c => (c.SerPrice ?? 0) * (c.SerQuantity ?? 0) * (c.ExchangeRate ?? 1) * (1 + (c.SerVat ?? 0) / 100) + (c.MVat ?? 0));
            float profitUSD = totalSellUSD - totalBuyUSD;
            // VND

            float totalBuyVND = totalBuyUSD * 23000; // Assuming 1 USD = 23,000 VND
            float totalSellVND = totalSellUSD * 23000; // Assuming 1 USD = 23,000 VND
            float profitVND = profitUSD * 23000; // Assuming 1 USD = 23,000 VND

            (float TotalBuyUSD, float TotalSellUSD, float ProfitUSD, float TotalBuyVND, float TotalSellVND, float ProfitVND) data = (
                TotalBuyUSD: totalBuyUSD,
                TotalSellUSD: totalSellUSD,
                ProfitUSD: profitUSD,
                TotalBuyVND: totalBuyVND,
                TotalSellVND: totalSellVND,
                ProfitVND: profitVND
            );

            return View(data);
          



        }
    }
}
