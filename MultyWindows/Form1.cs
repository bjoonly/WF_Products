using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace MultyWindows
{
    public partial class Form1 : Form
    {
        private List<Product> products;
        public int Count { get; set; } = 1;
        public Form1()
        {
            InitializeComponent();
            products = new List<Product>(5);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            ProductForm productForm = new ProductForm(product, "Add");
            if (productForm.ShowDialog() == DialogResult.OK)
            {
                products.Add(product);
                productsListBox.Items.Add(String.Format("{0,-15}\t{1,-15}\t{2,-4} pc.\t{3,-4} uah", product.Name, product.Country, product.Quantity, product.Price));
                Count++;
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (productsListBox.SelectedItem != null)
            {
                Product product = products[productsListBox.SelectedIndex];
                ProductForm productForm = new ProductForm(product, "Edit");
                if (productForm.ShowDialog() == DialogResult.OK)
                {

                    products[productsListBox.SelectedIndex] = product;
                    productsListBox.Items[productsListBox.SelectedIndex] = String.Format("{0,-15}\t{1,-15}\t{2,-4} pc.\t{3,-4} uah", product.Name, product.Country, product.Quantity, product.Price);
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (productsListBox.SelectedItem != null)
            {
                products.RemoveAt(productsListBox.SelectedIndex);
                productsListBox.Items.RemoveAt(productsListBox.SelectedIndex);
            }
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            if (productsListBox.SelectedItem != null)
            {
                Product product = products[productsListBox.SelectedIndex];
                ProductForm productForm = new ProductForm(product, "OK", false);
                productForm.ShowDialog();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (var item in products)
                    {
                        sw.WriteLine(item);
                    }
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    products.Clear();
                    Product product = new Product();

                    while ((product.Name = sr.ReadLine()) != null)
                    {
                       
                        product.Price = int.Parse(sr.ReadLine());
                        product.Quantity = int.Parse(sr.ReadLine());
                        product.Country = sr.ReadLine();
                        product.Discount = int.Parse(sr.ReadLine());
                        products.Add(product);
                        product = new Product();                       

                    }
                }
            }
            productsListBox.Items.Clear();
            foreach (var product in products)
            {
                productsListBox.Items.Add(String.Format("{0,-15}\t{1,-15}\t{2,-4} pc.\t{3,-4} uah", product.Name, product.Country,product.Quantity, product.Price));
            }
           

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}

