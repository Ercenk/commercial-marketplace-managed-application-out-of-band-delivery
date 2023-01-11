using Microsoft.EntityFrameworkCore;
using NotificationListener.Models;

namespace NotificationListener.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DeployedApp> DeployedApplications { get; set; }

        public async Task AddOrUpdate(DeployedApp app)
        {
            if (this.DeployedApplications.Any(a => a.ApplicationId == app.ApplicationId && a.EventTime == app.EventTime && a.ProvisioningState == app.ProvisioningState))
            {
                return;
            }

            await this.DeployedApplications.AddAsync(app);
            await this.SaveChangesAsync();
        }
    }
}
