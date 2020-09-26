using Microsoft.EntityFrameworkCore;
using NsigVerificationAPI.Models;

namespace NsigVerificationAPI.Data
{
    public class NsigVerificationAPIContext: DbContext
    {
        public NsigVerificationAPIContext(DbContextOptions<NsigVerificationAPIContext> opt) : base(opt)
        {

        }

        public DbSet<Certificate> Certificates { get; set; }
    }
}
