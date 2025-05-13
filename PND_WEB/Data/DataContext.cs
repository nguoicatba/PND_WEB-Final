using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PND_WEB.Models;

namespace PND_WEB.Data
{
    public class DataContext :IdentityDbContext<AppUserModel>

    {
      

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    

        public DbSet<Agent> Agents { get; set; }

        public DbSet<AgentAction> AgentActions { get; set; }

        public DbSet<BlType> BlTypes { get; set; }

        public DbSet<Carrier> Carriers { get; set; }

        public DbSet<CarrierAction> CarrierActions { get; set; }

        public DbSet<Cport> Cports { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Fee> Fees { get; set; }

        public DbSet<GoodsType> GoodsTypes { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }

        public DbSet<Kindofpackage> Kindofpackages { get; set; }
        public DbSet<Mode> Modes { get; set; }

        public DbSet<Quotation> Quotations { get; set; }

        public DbSet<QuotationsCharge> QuotationsCharges { get; set; }

        public DbSet<Sourse> Sourses { get; set; }

        public DbSet<TblCharge> TblCharges { get; set; }

        public DbSet<TblCnee> TblCnees { get; set; }

        public DbSet<TblCneeAdd> TblCneeAdds { get; set; }

        public DbSet<TblConth> TblConths { get; set; }

        public DbSet<TblCustomer> TblCustomers { get; set; }

        public DbSet<TblHbl> TblHbls { get; set; }

        public DbSet<TblHscode> TblHscodes { get; set; }

        public DbSet<TblInvoice> TblInvoices { get; set; }

        public DbSet<TblJob> TblJobs { get; set; }

        public DbSet<TblShipper> TblShippers { get; set; }

        public DbSet<TblSupplier> TblSuppliers { get; set; }

        public DbSet<TblSupplierAction> TblSupplierActions { get; set; }

        public DbSet<TblTutt> TblTutts { get; set; }

        public DbSet<TblTuttPhi> TblTuttsPhi { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<ApplicationClaim> Claims { get; set; }

        public DbSet<JobUser> JobUser { get; set; }






    }
}
