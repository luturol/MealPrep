using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealPrep.Utils
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

        public static bool ValidateEmptyString(string value)
        {
            return (value == null || value.Length == 0) ? false : true;
        }

        public static bool ValidateNumber(string value)
        {
            var regex = new Regex(@"^-*[0-9,\.]+$");
            return regex.IsMatch(value);
        }

        public static double By3Rule(double value1, double value2, double value3)
        {
            // x - value1
            // value2 = value3
            return (value1 * value2) / value3;
        }
    }
}
