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
        private const String MESSAGE_VITAMIN_ADD_WITH_SUCCESS = "Vitamin add with success.";
        private const String ERROR_NECESSARY_TO_FULL_FILL_NAME = "Error! Necessary to fill the name field.";
       

        public ucAddVitamin(VitaminController controller)
        {
            this.controller = controller;
            InitializeComponent();
            Initialize();
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
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            if (!bwProcessVitamin.IsBusy)
                bwProcessVitamin.RunWorkerAsync();

            gcVitamins.ReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (UsefulAlgorithms.ValidateEmptyString(txtVitaminName.Text))
                {
                    if (controller.AddVitamin(new Vitamin() { Name = txtVitaminName.Text }))
                    {
                        PopulateGrid();
                        MessageBox.Show(MESSAGE_VITAMIN_ADD_WITH_SUCCESS, TitleFactory.GetTitle(this.GetType()), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    throw new Exception(ERROR_NECESSARY_TO_FULL_FILL_NAME);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TitleFactory.GetTitle(this.GetType()), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bwProcessVitamin_DoWork(object sender, DoWorkEventArgs e)
        {
            FormAuxiliary progressBar = new FormAuxiliary(new ucProgressBar());
            progressBar.Show();
            Action action = () => gcVitamins.DataSource = controller.GetTableAllVitamins();
            gcVitamins.Invoke(action);
            progressBar.Close();
        }


    }
}
