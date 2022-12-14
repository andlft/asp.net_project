using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;

namespace proiect.Repositories.DatabaseRepository
{
    public class UserRepository : GenericRepository.GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) : base(context)
        {
            
        }

        public User FindByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email == email);
        }

        public IEnumerable<User> GetAdmins()
        {
            return _table.Where(x => x.RoleName == Models.Enums.Roles.Admin).ToList();
        }

        public User GetUserWithInclude(Guid id)
        {
            return _table.Include(x => x.Address).FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetAllWithInclude()
        {
            return _table.Include(x => x.Address).Include(x => x.Orders).ToList();
        }

        public IEnumerable<User> GetEmployees()
        {
            return _table.Where(x => x.RoleName == Models.Enums.Roles.Employee).ToList();
        }
    }
}
