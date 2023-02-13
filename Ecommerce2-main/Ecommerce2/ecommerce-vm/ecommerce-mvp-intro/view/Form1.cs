using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using csharp_oop_ecommerce_basic.model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Http.Headers;

namespace csharp_oop_ecommerce_basic
{
    public partial class Form1 : Form
    {
        private Cart carr;

        public Form1()
        {
            InitializeComponent();
            carr = EcommerceFactory.getSampleCart();

            setHeaderCarrView();
            updateCarrView();
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    Product  p = new elettronico(EcommerceFactory.getProductID(), textBoxName.Text, textBoxManifacturer.Text, textBoxDescription.Text, float.Parse(textBoxPrice.Text), "pippo");
                    carr.Add(p);
                    label5.Text = Convert.ToString(carr.getTotale())+" €";
                    label6.Text = Convert.ToString(carr.getTotale_S()) + " €";
                }
                if (comboBox1.SelectedIndex == 0)
                {
                    Product p = new Alimentari(EcommerceFactory.getProductID(), textBoxName.Text, textBoxManifacturer.Text, textBoxDescription.Text, float.Parse(textBoxPrice.Text), null,dateTimePicker1.Value);
                    carr.Add(p);
                    label5.Text = Convert.ToString(carr.getTotale()) + " €";
                    label6.Text = Convert.ToString(carr.getTotale_S()) + " €";
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    Product p = new Penne(EcommerceFactory.getProductID(), textBoxName.Text, textBoxManifacturer.Text, textBoxDescription.Text, float.Parse(textBoxPrice.Text),textBox1.Text);
                    carr.Add(p);
                    label5.Text = Convert.ToString(carr.getTotale()) + " €";
                    label6.Text = Convert.ToString(carr.getTotale_S()) + " €";
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    Product p = new fogli(EcommerceFactory.getProductID(), textBoxName.Text, textBoxManifacturer.Text, textBoxDescription.Text, float.Parse(textBoxPrice.Text), textBox1.Text);
                    carr.Add(p);
                    label5.Text = Convert.ToString(carr.getTotale()) + " €";
                    label6.Text = Convert.ToString(carr.getTotale_S()) + " €";
                }

                updateCarrView();
                

            } catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {

            Product p = new elettronico(labelID.Text, textBoxName.Text, textBoxManifacturer.Text, textBoxDescription.Text, float.Parse(textBoxPrice.Text),"pippo");
            if(carr.IndexOf(p)<0)
            {
                MessageBox.Show("ID prodotto non valido");
                return;
            }

            carr.Modify(p);
            updateCarrView();

        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Product p = new elettronico(labelID.Text, textBoxName.Text, textBoxManifacturer.Text, textBoxDescription.Text, float.Parse(textBoxPrice.Text),"pippo");
            if (carr.IndexOf(p) < 0)
            {
                MessageBox.Show("Invalid ID");
                return;
            }

            carr.Remove(p);
            updateCarrView();
        }


        public ListViewItem GetFocusedItem()
        {

            if (list.FocusedItem == null) return null;
            int listIndex = list.FocusedItem.Index;
            return list.Items[listIndex];
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListViewItem i = GetFocusedItem();

            if (i == null) return;

            ShowCurrentItemOnLabels(i);

        }

        public Product GetProductFromItem(ListViewItem item)
        { 
            Product p = new elettronico(item.SubItems[0].Text);
            
            int i = carr.IndexOf(p);
            if (i >= 0)
                return carr.Products[i];
            else
                return null;
        }

        public void ShowCurrentItemOnLabels(ListViewItem i)
        {

            Product p = GetProductFromItem(i);
            if(p== null) return;

            labelID.Text=p.Id;
            textBoxName.Text = p.Name;
            textBoxDescription.Text = p.Description;
            textBoxManifacturer.Text = p.Manufacturer;
            textBoxPrice.Text = ""+p.Price;

        }


        private void setHeaderCarrView()
        {
            list.View = View.Details;
            list.FullRowSelect = true;
            string[] intestazione = new string[] { "ID", "NOME", "PRODUTTORE", "DESCRIZIONE", "PREZZO" };

            for (int i = 0; i < intestazione.Length; i++)
            {
                list.Columns.Add(intestazione[i]);
            }
        }

        private void updateCarrView()
        {

            list.Items.Clear();
            list.View = View.Details;
            list.FullRowSelect = true;

            foreach(Product p in carr.Products)
            {   
                 ListViewItem item = new ListViewItem(p.Id);
                 item.SubItems.Add(p.Name);
                  item.SubItems.Add(p.Manufacturer);
                    item.SubItems.Add(p.Description);
                    item.SubItems.Add("" + p.getScontato());
                    list.Items.Add(item);
                
            }

            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            list.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                textBox1.Hide();
                label3.Hide();
                dateTimePicker1.Show();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Hide();
                label3.Hide();
                dateTimePicker1.Hide();
            } 
            if (comboBox1.SelectedIndex == 2)
            {
                textBox1.Show();
                label3.Text = "funzionamento";
                label3.Show();
                dateTimePicker1.Hide();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                textBox1.Show();
                label3.Text="grammatura";
                label3.Show();
                dateTimePicker1.Hide();
            }
           
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
