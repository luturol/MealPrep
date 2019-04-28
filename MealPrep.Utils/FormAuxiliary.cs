using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealPrep.Utils
{
    public partial class FormAuxiliary : Form
    {
        private UserControl userControl;

        public FormAuxiliary(UserControl userControl)
        {
            this.userControl = userControl;
            InitializeComponent();
            this.Controls.Add(userControl);
            UsefulAlgorithms.AdjustFormSize(this);
            this.Text = TitleFactory.GetTitle(userControl.GetType());
        }
    }
}
