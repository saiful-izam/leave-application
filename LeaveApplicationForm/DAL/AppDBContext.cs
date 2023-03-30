using LeaveApplicationForm.VO;
using Microsoft.EntityFrameworkCore;

namespace LeaveApplicationForm.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<LeaveFormVO> LeaveForms { get; set; }
    }
}
