using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Interfaces
{
    public interface IUserDao
    {
        bool AddUser(User user);
        List<User> GetAllUsers();
    }
}
