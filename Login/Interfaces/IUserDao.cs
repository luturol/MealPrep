using MealPrep.Login.Model;
using System.Collections.Generic;

namespace MealPrep.Login.Interfaces
{
    public interface IUserDao
    {
        bool AddUser(User user);
        List<User> GetAllUsers();
    }
}
