using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealPrep.Login.Controller;

namespace MealPrep.Login.View
{
    public partial class ucLoginPage : UserControl
    {
        private UserController userController;

        public ucLoginPage()
        {
            this.userController = userController;
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            panelLogin.Controls.Add(new ucLogin());
            panelAddUser.Controls.Add(new ucAddUser(userController));
        }
    }
}
