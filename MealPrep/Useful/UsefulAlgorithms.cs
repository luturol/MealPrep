using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealPrep.Utiles
{
    public class UsefulAlgorithms
    {
        public static void AdjustFormSize(Form form)
        {
            form.AutoSize = true;
            foreach (Control c in form.Controls)
            {
                if (c is UserControl)
                {
                    form.Width = form.Width + (c.Left + c.Width - form.Width) + 10;
                    form.Height = form.Height + (c.Top + c.Height - form.Height) + 50;
                    form.MinimumSize = new System.Drawing.Size(form.Width, form.Height);
                    form.MaximumSize = new System.Drawing.Size(form.Width, form.Height);
                }
            }
        }
    }
}
