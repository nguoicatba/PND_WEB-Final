using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Data;
using PND_WEB.Services;
using PND_WEB.ViewModels;

namespace PND_WEB.Controllers
{
    public class Test : Controller
    {

        private readonly ILogger<Test> _logger;
        private readonly DataContext _context;
        private readonly IViewRenderService _viewRenderService;
        private readonly IConverter _converter;

        public Test(ILogger<Test> logger, DataContext context, IConverter converter, IViewRenderService viewRenderService)
        {
            _logger = logger;
            _context = context;
            _converter = converter;
            _viewRenderService = viewRenderService;
        }
        public IActionResult Index()
        {
            return View();
        }


        //fff
        //ExportPDF
        public async Task<IActionResult> ExportPDFDN(string id)
        {

            //sửa dữ liệu
            var debitnote = await _context.Quotations
                                          .Include(q => q.QuotationsCharges)
                                          .FirstOrDefaultAsync(q => q.QuotationId == id);

            if (debitnote == null)
                return NotFound();

            var viewModel = new QuotationsEditDeleteDetailController
            {
                Quotation = debitnote,
                QuotationsCharges = debitnote.QuotationsCharges.ToList()
            };

            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFDebitNote", viewModel);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,
                    Margins = new MarginSettings()
                    {
                        Top = 10,
                        Bottom = 10,
                        Left = 10,
                        Right = 10
                    }

                },
                Objects = {
                    new ObjectSettings()
                    {

                        HtmlContent = htmlContent
                    }
                }
            };

            var file = _converter.Convert(doc);
            Response.Headers.Add("Content-Disposition", "inline; filename=quotation.pdf");
            return File(file, "application/pdf");
        }

        public async Task<IActionResult> ExportPDFDO(string id)
        {

            //sửa dữ liệu
            var debitnote = await _context.Quotations
                                          .Include(q => q.QuotationsCharges)
                                          .FirstOrDefaultAsync(q => q.QuotationId == id);

            if (debitnote == null)
                return NotFound();

            var viewModel = new QuotationsEditDeleteDetailController
            {
                Quotation = debitnote,
                QuotationsCharges = debitnote.QuotationsCharges.ToList()
            };

            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFDeliveryOrder", viewModel);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait,


                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent
                    }
                }
            };

            var file = _converter.Convert(doc);
            Response.Headers.Add("Content-Disposition", "inline; filename=quotation.pdf");
            return File(file, "application/pdf");
        }

        public async Task<IActionResult> ExportPDFAN(string id)
        {

            //sửa dữ liệu
            var debitnote = await _context.Quotations
                                          .Include(q => q.QuotationsCharges)
                                          .FirstOrDefaultAsync(q => q.QuotationId == id);

            if (debitnote == null)
                return NotFound();

            var viewModel = new QuotationsEditDeleteDetailController
            {
                Quotation = debitnote,
                QuotationsCharges = debitnote.QuotationsCharges.ToList()
            };

            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFArrivalNote", viewModel);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent
                    }
                }
            };

            var file = _converter.Convert(doc);
            Response.Headers.Add("Content-Disposition", "inline; filename=quotation.pdf");
            return File(file, "application/pdf");
        }


        public async Task<IActionResult> ExportPDFMBL(string id)
        {

            //sửa dữ liệu
            var debitnote = await _context.Quotations
                                          .Include(q => q.QuotationsCharges)
                                          .FirstOrDefaultAsync(q => q.QuotationId == id);

            if (debitnote == null)
                return NotFound();

            var viewModel = new QuotationsEditDeleteDetailController
            {
                Quotation = debitnote,
                QuotationsCharges = debitnote.QuotationsCharges.ToList()
            };

            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFMBL", viewModel);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent
                    }
                }
            };

            var file = _converter.Convert(doc);
            Response.Headers.Add("Content-Disposition", "inline; filename=quotation.pdf");
            return File(file, "application/pdf");
        }



        public async Task<IActionResult> ExportPDFSI(string id)
        {

            //sửa dữ liệu
            var debitnote = await _context.Quotations
                                          .Include(q => q.QuotationsCharges)
                                          .FirstOrDefaultAsync(q => q.QuotationId == id);

            if (debitnote == null)
                return NotFound();

            var viewModel = new QuotationsEditDeleteDetailController
            {
                Quotation = debitnote,
                QuotationsCharges = debitnote.QuotationsCharges.ToList()
            };

            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFShippingInstruction", viewModel);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent
                    }
                }
            };

            var file = _converter.Convert(doc);
            Response.Headers.Add("Content-Disposition", "inline; filename=quotation.pdf");
            return File(file, "application/pdf");
        }




        public async Task<IActionResult> ExportPDFQuotationsSign(string id)
        {
            var quotation = await _context.Quotations
                                          .Include(q => q.QuotationsCharges)
                                          .FirstOrDefaultAsync(q => q.QuotationId == id);

            if (quotation == null)
                return NotFound();

            var viewModel = new QuotationsEditDeleteDetailController
            {
                Quotation = quotation,
                QuotationsCharges = quotation.QuotationsCharges.ToList()
            };

            string htmlContent = await _viewRenderService.RenderViewToStringAsync("ExportPDFQuotationsSign", viewModel);

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings()
                    {
                        HtmlContent = htmlContent
                    }
                }
            };

            var file = _converter.Convert(doc);
            Response.Headers.Add("Content-Disposition", "inline; filename=quotation.pdf");
            return File(file, "application/pdf");
        }
    }
}
