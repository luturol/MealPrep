using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPrep.Login.Model
{
    public class User
    {
        private String name;
        private String password;

        public User(String name, String password)
        {
            this.name = name;
            this.password = password;
        }

        public String Name { get => this.name; }

        public String Password { get => this.password; }
    }
}
