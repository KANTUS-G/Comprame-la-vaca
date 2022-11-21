
using COmpamelaVacaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COmpamelaVacaAPI.Data.Repositorios
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetDetails(int id);
        Task<bool> InsertUser(User user);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);

    }
}
