﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class invoiceTotalForm : Form
    {
        public invoiceTotalForm()
        {
            InitializeComponent();
        }

        private void invoiceTotalForm_Load(object sender, EventArgs e)
        {
            ResetSubTotalMethod();
        }

        private void ResetSubTotalMethod()
        {
            subTotalTextBox.Focus();
            subTotalTextBox.Text = "0";
            subTotalTextBox.SelectAll();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// CalculateButton Event Handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            CalculateTotal();

        }


        /// <summary>
        /// Calculating total after discount 0.1%
        /// </summary>
        private void CalculateTotal()
        {
            const double DiscountPercent = 0.1;
            double SubTotal;
            double DiscountAmount;
            double Total;
            try
            {
                SubTotal = Convert.ToDouble(subTotalTextBox);
                DiscountAmount = SubTotal * DiscountPercent;
                Total = SubTotal - DiscountAmount;


                discountAmountTextBox.Text = DiscountAmount.ToString("C2");
                totalTextBox.Text = Total.ToString("C2");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid Data Entered", "Input Error");
                Debug.WriteLine(exception.Message);
                subTotalTextBox.Focus();
                subTotalTextBox.SelectAll();
                ResetSubTotalMethod();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
