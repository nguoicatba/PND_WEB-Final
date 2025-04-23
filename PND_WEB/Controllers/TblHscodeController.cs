using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Text;
using PND_WEB.Models;
using X.PagedList;
using X.PagedList.Extensions;
using PND_WEB.Data;
namespace Demo_HScode.Controllers;

public class TblHscodeController : Controller
{
    private readonly ILogger<TblHscodeController> _logger;
    private readonly DataContext testingContext;
    public TblHscodeController(ILogger<TblHscodeController> logger,DataContext context)
    {
        _logger = logger;
        testingContext = context;
    }

    //public IActionResult Index(int? page)
    //{
    //    int pageNumber = page ?? 1;
    //    int pageSize = 20;

    //    IPagedList<TblHscode> tc = testingContext.TblHscodes
    //        .AsEnumerable()
    //        .Select(h => new TblHscode
    //        {
    //            Id = h.Id,
    //            HsCode = h.HsCode.All(char.IsDigit) ? h.HsCode : "",
    //            MoTaHangHoaV = Cutstring(h.MoTaHangHoaV),
    //            MoTaHangHoaE = Cutstring(h.MoTaHangHoaE),
    //        })
    //        .ToPagedList(pageNumber, pageSize);

    //    return View(tc);
    //}
    public IActionResult Index(int? page)
    {
        int pageNumber = page ?? 1;
        int pageSize = 20;

       
        var pagedRawData = testingContext.TblHscodes
            .OrderBy(h => h.Id)  
            .ToPagedList(pageNumber, pageSize);

     
        var mappedList = pagedRawData
            .AsEnumerable()
            .Select(h => new TblHscode
            {
                Id = h.Id,
                HsCode = !string.IsNullOrEmpty(h.HsCode) && h.HsCode.All(char.IsDigit) ? h.HsCode : "",
                MoTaHangHoaV = Cutstring(h.MoTaHangHoaV ?? string.Empty),
                MoTaHangHoaE = Cutstring(h.MoTaHangHoaE ?? string.Empty),
                DonViTinh = h.DonViTinh,
                ChinhSachHangHoa = h.ChinhSachHangHoa,
            }).ToList();

        
        var data = new StaticPagedList<TblHscode>(mappedList, pagedRawData.GetMetaData());

     
        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            return Json(new
            {
                data = data.Select(x => new
                {
                    x.Id,
                    x.HsCode,
                    x.MoTaHangHoaV,
                    x.MoTaHangHoaE,
                    x.DonViTinh,
                    x.ChinhSachHangHoa

                }),
                hasNextPage = data.HasNextPage
            });
        }

        return View(data);

    }

    public IActionResult Search(string s, int? page, string matchType)
    {
        s = RemoveVietnameseAccents(s);
        Console.WriteLine($"Tìm kiếm: {s}");

        int pageNumber = page ?? 1;
        int pageSize = 100;
        string searchTerm = $"\"{s}\"";
        var results = new List<TblHscode>().ToPagedList(pageNumber, pageSize);

        if (!string.IsNullOrEmpty(s))
        {
            if (s.All(char.IsDigit))
            {
                results = testingContext.TblHscodes
                .FromSqlRaw("SELECT * FROM tbl_Hscode WHERE HS_CODE LIKE '%' + {0} + '%'", s)
                .ToList()
                .Select(h => new TblHscode
                {
                    Id = h.Id,
                    HsCode = !string.IsNullOrEmpty(h.HsCode) && h.HsCode.All(char.IsDigit) ? h.HsCode : "",
                    MoTaHangHoaV = Cutstring(h.MoTaHangHoaV),
                    MoTaHangHoaE = Cutstring(h.MoTaHangHoaE),
                    DonViTinh = h.DonViTinh,
                    ChinhSachHangHoa = h.ChinhSachHangHoa,
                })
                .ToPagedList(pageNumber, pageSize);
            }
            else if (matchType == "exact")
            {
                results = testingContext.TblHscodes
                .FromSqlRaw("SELECT * FROM tbl_Hscode WHERE CONTAINS(Mo_ta_khong_dau, @p0) OR CONTAINS(Mo_ta_hang_hoaE, @p0) OR CONTAINS(Ghi_chu_khong_dau, @p0)", searchTerm)
                .ToList()
                .Select(h => new TblHscode
                {
                    Id = h.Id,
                    HsCode = !string.IsNullOrEmpty(h.HsCode) && h.HsCode.All(char.IsDigit) ? h.HsCode : "",
                    MoTaHangHoaV = Cutstring(h.MoTaHangHoaV),
                    MoTaHangHoaE = Cutstring(h.MoTaHangHoaE),
                    DonViTinh = h.DonViTinh,
                    ChinhSachHangHoa = h.ChinhSachHangHoa,
                })
                .ToPagedList(pageNumber, pageSize);
            }
            else if (matchType == "suggest")
            {
                results = testingContext.TblHscodes
                .FromSqlRaw("SELECT * FROM tbl_Hscode WHERE FREETEXT(Mo_ta_khong_dau, @p0) OR FREETEXT(Mo_ta_hang_hoaE, @p0)", searchTerm)
                .ToList()
                .Select(h => new TblHscode
                {
                    Id = h.Id,
                    HsCode = !string.IsNullOrEmpty(h.HsCode) && h.HsCode.All(char.IsDigit) ? h.HsCode : "",
                    MoTaHangHoaV = Cutstring(h.MoTaHangHoaV),
                    MoTaHangHoaE = Cutstring(h.MoTaHangHoaE),
                    DonViTinh = h.DonViTinh,
                    ChinhSachHangHoa = h.ChinhSachHangHoa,

                })
                .ToPagedList(pageNumber, pageSize);
            }

        }

        ViewBag.SearchTerm = s;
        ViewBag.MatchType = matchType;

        return View("Index", results);
    }
    public IActionResult Details(int id)
    {
        var hscode = testingContext.TblHscodes.FirstOrDefault(h => h.Id == id);
        Console.WriteLine($"ID: {id}");
        hscode.HsCode = Hs_process(hscode.HsCode);
        if (hscode == null)
        {
            return NotFound();
        }
        return View(hscode);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var hscode = testingContext.TblHscodes.FirstOrDefault(x => x.Id == id);
        if (hscode == null)
        {
            return NotFound();
        }

        return View(hscode);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, TblHscode updatedHscode)
    {
        if (!ModelState.IsValid)
        {
            return View(updatedHscode);
        }

        var existingHscode = testingContext.TblHscodes.FirstOrDefault(h => h.Id == id);
        if (existingHscode == null)
        {
            return NotFound();
        }

        testingContext.Entry(existingHscode).CurrentValues.SetValues(updatedHscode);
        existingHscode.GhiChuKhongDau = RemoveVietnameseAccents(updatedHscode.GhiChu);

        try
        {
            testingContext.SaveChanges();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!testingContext.TblHscodes.Any(e => e.Id == updatedHscode.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToAction(nameof(Index));
    }

    public string Cutstring(string s)
    {
        if (string.IsNullOrEmpty(s)) return "";
        int maxLen = 0, maxStart = -1, currentLen = 0, currentStart = -1;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ' ') continue;
            if (s[i] == '-')
            {
                if (currentLen == 0) currentStart = i;
                currentLen++;
            }
            else
            {
                if (currentLen > maxLen)
                {
                    maxLen = currentLen;
                    maxStart = currentStart;
                }
                currentLen = 0;
            }
        }
        if (currentLen > maxLen)
        {
            maxLen = currentLen;
            maxStart = currentStart;
        }

        if (maxStart != -1) return s.Substring(maxStart);

        int colonIndex = s.IndexOf(":");
        if (colonIndex != -1 && colonIndex + 1 < s.Length)
        {
            return s.Substring(colonIndex + 1);
        }

        return s;
    }
    public string Hs_process(string s)
    {
        if (s.All(char.IsDigit))
        {
            return s;
        }
        else
        {
            return "";
        }
    }
    public string RemoveVietnameseAccents(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        string normalized = text.Normalize(NormalizationForm.FormD);
        Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
        string withoutDiacritics = regex.Replace(normalized, "");

        return withoutDiacritics.Replace('Đ', 'D').Replace('đ', 'd');
    }

 
}
