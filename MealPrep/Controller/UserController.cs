using MealPrep.Repository;
using MealPrep.Interfaces;
using MealPrep.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealPrep.Properties;

namespace MealPrep.Controller
{
    public class UserController
    {        
        private IUserDao dao;        

        public UserController(IUserDao dao)
        {
            this.dao = dao;
        }
        
        public bool AddUser(User user)
        {
            if (!UserExists(user))
            {
                return dao.AddUser(user);
            }
            else
            {
                throw new Exception(Resources.ErrorUserAlreadyExist);
            }
        }

        public bool UserExists(User user)
        {
            if (GetAllUsers().Exists(u => u.Name == user.Name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateLogin(User user)
        {
            if(GetAllUsers().Exists(u => u.Name == user.Name && u.Password == user.Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return dao.GetAllUsers();
        }
        
    }
}
