using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultyWindows
{
    public partial class ProductForm : Form
    {
        public Product ProductInForm { get; set; }
        public ProductForm(Product product,string nameOfButton="OK",bool isEnable=true)
        {
            InitializeComponent();
            ProductInForm = product;
            countyComboBox.Items.AddRange(new string[] { "Ukraine", "Russia","Poland","Belgium", "Bulgaria", "Canada", "China", "Denmark", "Italy","Japan", "Netherlands", "Norway", "Spain" });
            if (product.Name != "No name")
            {
                nameTextBox.Text = ProductInForm.Name;
                countyComboBox.SelectedItem = ProductInForm.Country;
                priceNumericUpDown.Value = Convert.ToDecimal(ProductInForm.Price);
                quantityNumericUpDown.Value = Convert.ToDecimal(ProductInForm.Quantity);
                discountNumericUpDown.Value = Convert.ToDecimal(ProductInForm.Discount);
            }
            okButton.Text = nameOfButton;
            nameTextBox.Enabled = isEnable;
            countyComboBox.Enabled = isEnable;
            priceNumericUpDown.Enabled = isEnable;
            quantityNumericUpDown.Enabled = isEnable;
            discountNumericUpDown.Enabled = isEnable;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Invalid name.");
                return;
            }
            
            ProductInForm.Name = nameTextBox.Text;
            if (countyComboBox.SelectedItem == null)
            {
                MessageBox.Show("Invalid country.");
                return;
            }
            ProductInForm.Country = countyComboBox.SelectedItem.ToString();
            ProductInForm.Price =Convert.ToDouble(priceNumericUpDown.Value);
            ProductInForm.Quantity = Convert.ToInt32(quantityNumericUpDown.Value);
            ProductInForm.Discount = Convert.ToInt32(discountNumericUpDown.Value);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

       
    }
}
