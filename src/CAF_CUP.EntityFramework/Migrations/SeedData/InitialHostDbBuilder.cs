using CAF_CUP.EntityFramework;
using EntityFramework.DynamicFilters;

namespace CAF_CUP.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly CAF_CUPDbContext _context;

        public InitialHostDbBuilder(CAF_CUPDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
