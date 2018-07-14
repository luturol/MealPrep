using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealPrep.Controller;
using MealPrep.Model;
using MealPrep.Useful;

namespace MealPrep.View
{
    public partial class ucAddVitamin : UserControl
    {
        private VitaminController controller;
        private Vitamin vitamin;

        public ucAddVitamin(VitaminController controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        public ucAddVitamin(VitaminController controller, Vitamin vitamin)
        {
            this.controller = controller;
            this.vitamin = vitamin;
            InitializeComponent();
            Initialize();
        }


        private void Initialize()
        {
            if (vitamin != null)
            {
                lblVitaminIDValue.Text = vitamin.VitaminID.ToString();
                lblVitaminLabelText.Visible = true;
                txtVitaminName.Text = vitamin.Name;
            }
            else
            {
                lblVitaminIDValue.Visible = false;
                lblVitaminLabelText.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UsefulAlgorithms.ValidateEmptyString(txtVitaminName.Text))
                {
                    if (controller.AddVitamin(new Vitamin() { Name = txtVitaminName.Text });)
                {
                        MessageBox.Show("Vitamin add with success.", "New Vitamin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vitamin add with success.", "New Vitamin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
