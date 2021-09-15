using HN.Management.Engine.Data;
using HN.Management.Engine.Repositories.Interfaces;
using HN.ManagementEngine.Models;

namespace HN.Management.Engine.Repositories
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            
        }
    }
}
