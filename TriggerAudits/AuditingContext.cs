using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriggerAudits.Domain;

namespace TriggerAudits
{
    internal class AuditingContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            options.UseNpgsql("server=localhost;port=5432;uid=root;pwd=admin;database=trigger_audits;");
        }

        public int SaveChanges(string user)
        {
            int r = 0;

            using (var tsx = Database.BeginTransaction())
            {
                Database.ExecuteSqlInterpolated($"SELECT set_config('triggeraudit.user', {user}, true)");

                r = SaveChanges();

                tsx.Commit();
            }

            return r;
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
