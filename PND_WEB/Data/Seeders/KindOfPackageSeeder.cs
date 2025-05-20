using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;

namespace PND_WEB.Data.Seeders
{
    public class KindOfPackageSeeder
    {
        public static async Task SeedAsync(DataContext _context)
        {
            if (!await _context.Kindofpackages.AnyAsync())
            {

                await _context.Kindofpackages.AddRangeAsync(
                    new Kindofpackage { Code = "BA", PackageName = "Barrels", PackagesDescription = "" },
                    new Kindofpackage { Code = "BE", PackageName = "Bundles", PackagesDescription = "" },
                    new Kindofpackage { Code = "BG", PackageName = "Bags", PackagesDescription = "" },
                    new Kindofpackage { Code = "BK", PackageName = "Baskets", PackagesDescription = "" },
                    new Kindofpackage { Code = "BL", PackageName = "Bales,compressed", PackagesDescription = "" },
                    new Kindofpackage { Code = "BN", PackageName = "Bales,non-compressed", PackagesDescription = "" },
                    new Kindofpackage { Code = "BR", PackageName = "Bars", PackagesDescription = "" },
                    new Kindofpackage { Code = "BX", PackageName = "Boxes", PackagesDescription = "" },
                    new Kindofpackage { Code = "CA", PackageName = "Cans, rectangular", PackagesDescription = "" },
                    new Kindofpackage { Code = "CG", PackageName = "Cages", PackagesDescription = "" },
                    new Kindofpackage { Code = "CK", PackageName = "Casks", PackagesDescription = "" },
                    new Kindofpackage { Code = "CL", PackageName = "Coils", PackagesDescription = "" },
                    new Kindofpackage { Code = "CN", PackageName = "Containers", PackagesDescription = "" },
                    new Kindofpackage { Code = "CO", PackageName = "Carboy, non-protected", PackagesDescription = "" },
                    new Kindofpackage { Code = "CP", PackageName = "Carboy, protected", PackagesDescription = "" },
                    new Kindofpackage { Code = "CR", PackageName = "Crates", PackagesDescription = "" },
                    new Kindofpackage { Code = "CS", PackageName = "Cases", PackagesDescription = "" },
                    new Kindofpackage { Code = "CT", PackageName = "Cartons", PackagesDescription = "" },
                    new Kindofpackage { Code = "CX", PackageName = "Cans, cylindrical", PackagesDescription = "" },
                    new Kindofpackage { Code = "CY", PackageName = "Cylinders", PackagesDescription = "" },
                    new Kindofpackage { Code = "DR", PackageName = "Drums", PackagesDescription = "" },
                    new Kindofpackage { Code = "KG", PackageName = "Kegs", PackagesDescription = "" },
                    new Kindofpackage { Code = "LG", PackageName = "Logs", PackagesDescription = "" },
                    new Kindofpackage { Code = "LZ", PackageName = "Logs, in bundle/bunch/truss", PackagesDescription = "" },
                    new Kindofpackage { Code = "MST", PackageName = "MST", PackagesDescription = "" },
                    new Kindofpackage { Code = "MT", PackageName = "Mats", PackagesDescription = "" },
                    new Kindofpackage { Code = "NE", PackageName = "Unpacked  or unpackaged", PackagesDescription = "" },
                    new Kindofpackage { Code = "NT", PackageName = "Nets", PackagesDescription = "" }

                );
                await _context.SaveChangesAsync();
            }



        }
    }
}
