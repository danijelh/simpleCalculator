using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kalkulator
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        #region varijable

        //private bool noviUnos = true, unosOperand2 = false;
        //private double operand1, operand2;
        //private byte mathOperacija = 0;

        bool plus = false;
        bool minus = false;
        bool mnozi = false;
        bool dijeli = false;
        bool potencija = false;
        bool korijen = false;


        bool provjera = false;

        #endregion




        private void bttnNumClick(object sender, EventArgs e)
        {
            if (this.textBox.Text != "0")
                this.textBox.Text += ((Button)sender).Text;
            else
                this.textBox.Text = ((Button)sender).Text;
        }

        #region tipkeklik

        private void formMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                case Keys.D0:
                this.bttnNumClick(this.buttonNum0, new EventArgs());
                this.buttonNum0.Focus();
                e.Handled = true;
                break;

                case Keys.NumPad1:
                case Keys.D1:
                    this.bttnNumClick(this.buttonNum1, new EventArgs());
                    this.buttonNum1.Focus();
                e.Handled = true;
                break;

                case Keys.NumPad2:
                case Keys.D2:
                    this.bttnNumClick(this.buttonNum2, new EventArgs());
                    this.buttonNum2.Focus();
                e.Handled = true;
                break;

                case Keys.NumPad3:
                case Keys.D3:
                    this.bttnNumClick(this.buttonNum3, new EventArgs());
                    this.buttonNum3.Focus();
                e.Handled = true;
                break;

                case Keys.NumPad4:
                case Keys.D4:
                    this.bttnNumClick(this.buttonNum4, new EventArgs());
                    this.buttonNum4.Focus();
                e.Handled = true;
                break;

                case Keys.NumPad5:
                case Keys.D5:
                    this.bttnNumClick(this.buttonNum5, new EventArgs());
                    this.buttonNum5.Focus();
                e.Handled = true;
                break;

                case Keys.NumPad6:
                case Keys.D6:
                    this.bttnNumClick(this.buttonNum6, new EventArgs());
                    this.buttonNum6.Focus();
                e.Handled = true;
                break;

                case Keys.NumPad7:
                case Keys.D7:
                    this.bttnNumClick(this.buttonNum7, new EventArgs());
                    this.buttonNum7.Focus();
                e.Handled = true;
                break;

                case Keys.NumPad8:
                case Keys.D8:
                    this.bttnNumClick(this.buttonNum8, new EventArgs());
                    this.buttonNum8.Focus();
                e.Handled = true;
                break;

                case Keys.NumPad9:
                case Keys.D9:
                    this.bttnNumClick(this.buttonNum9, new EventArgs());
                    this.buttonNum9.Focus();
                e.Handled = true;
                break;

            case Keys.Decimal:
            case Keys.Oemcomma:
            case Keys.OemPeriod:
                this.buttonDecTocka_Click(this.buttonDecTocka, new EventArgs());
                this.buttonDecTocka.Focus();
                e.Handled = true;
                break;

            case Keys.Back:
                this.buttonBrisi_Click(this.buttonBrisi, new EventArgs());
                this.buttonBrisi.Focus();
                e.Handled = true;
                break;

            case Keys.Delete:
                this.buttonC_Click(this.buttonBrisi, new EventArgs());
                this.buttonBrisi.Focus();
                e.Handled = true;
                break;

             case Keys.Add:
                 buttonPlus.PerformClick();
                 break;

             case Keys.Subtract:
                 buttonMinus.PerformClick();
                 break;

             case Keys.Divide:
                 buttonDijeli.PerformClick();
                 break;

             case Keys.Multiply:
                 buttonMnozi.PerformClick();
                 break;

                case Keys.R:
                 buttonIzracunaj.PerformClick();
                 break;


            }
            
            
        }

        #endregion


        private void buttonDecTocka_Click(object sender, EventArgs e)
        {
            if (this.textBox.Text.Contains(",") == false)
                this.textBox.Text += ",";
        }

        private void buttonPredznak_Click(object sender, EventArgs e)
        {
            if (this.textBox.Text != "0")
            {
                if (this.textBox.Text.Contains("-") == true)
                {
                    this.textBox.Text =
                    this.textBox.Text.Remove(0, 1);
                }
                else
                {
                    this.textBox.Text = "-" + this.textBox.Text;
                }
            }
        }

        private void buttonBrisi_Click(object sender, EventArgs e)
        {
            if (this.textBox.Text != "0")
            {
                this.textBox.Text = this.textBox.Text
                .Remove(this.textBox.Text.Length - 1);
                if (this.textBox.Text.Length == 0 ||
                this.textBox.Text == "-")
                    this.textBox.Text = "0";
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox.Text = "0";
            plus = minus = dijeli = mnozi = provjera = false;
        }


        private void bttnMathOperacija(object sender, EventArgs e)
        {
            //if (this.unosOperand2 == false)
            //    double.TryParse(this.textBox.Text, out this.operand1);
            //else this.buttonIzracunaj_Click(sender, e);
            //switch (((Button)sender).Text)
            //{
            //    case "+":
            //        this.mathOperacija = 1;
            //        break;
            //    case "-":
            //        this.mathOperacija = 2;
            //        break;
            //    case "*":
            //        this.mathOperacija = 3;
            //        break;
            //    case "/":
            //        this.mathOperacija = 4;
            //        break;
            //}
            //this.noviUnos = true;
            //this.unosOperand2 = true;
        }

        private void buttonIzracunaj_Click(object sender, EventArgs e)
        {
            provjera = true;

            if (plus)
            {
                try
                {
                    decimal rezultat = Convert.ToDecimal(textBox.Tag) + Convert.ToDecimal(textBox.Text);
                    textBox.Text = rezultat.ToString();
                    plus = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pogreška kod raèunanja!\nGreška: " + ex.Message.ToString());
                    buttonCE.PerformClick();
                }
            }

            if (minus)
            {
                try
                {
                    decimal rezultat = Convert.ToDecimal(textBox.Tag) - Convert.ToDecimal(textBox.Text);
                    textBox.Text = rezultat.ToString();
                    minus = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pogreška kod raèunanja!\nGreška: " + ex.Message.ToString());
                    buttonCE.PerformClick();
                }
            }

            if (mnozi)
            {
                try
                {
                    decimal rezultat = Convert.ToDecimal(textBox.Tag) * Convert.ToDecimal(textBox.Text);
                    textBox.Text = rezultat.ToString();
                    mnozi = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pogreška kod raèunanja!\nGreška: " + ex.Message.ToString());
                    buttonCE.PerformClick();
                }
            }

            if (dijeli)
            {
                try
                {
                    decimal rezultat = Convert.ToDecimal(textBox.Tag) / Convert.ToDecimal(textBox.Text);
                    textBox.Text = rezultat.ToString();
                    dijeli = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pogreška kod raèunanja!\nGreška: " + ex.Message.ToString());
                    buttonCE.PerformClick();
                }
            }

            if (potencija)
            {
                try
                {
                    double rezultat = Math.Pow(Convert.ToDouble(textBox.Tag), Convert.ToDouble(textBox.Text));
                    textBox.Text = rezultat.ToString();
                    potencija = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pogreška kod raèunanja!\nGreška: " + ex.Message.ToString());
                    buttonCE.PerformClick();
                }
            }

            if (korijen)
            {
                try
                {
                    double temp = 1.0 / Convert.ToDouble(textBox.Text);
                    double rezultat = Math.Pow(Convert.ToDouble(textBox.Tag), temp); 
                    textBox.Text = rezultat.ToString();
                    korijen = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pogreška kod raèunanja!\nGreška: " + ex.Message.ToString());
                }

            }


            //if (this.noviUnos == false)
            //    double.TryParse(this.textBox.Text, out this.operand2);
            //switch (this.mathOperacija)
            //{
            //    case 1:
            //        this.operand1 = this.operand1 + this.operand2;
            //        break;
            //    case 2:
            //        this.operand1 = this.operand1 - this.operand2;
            //        break;
            //    case 3:
            //        this.operand1 = this.operand1 * this.operand2;
            //        break;
            //    case 4:
            //        this.operand1 = this.operand1 / this.operand2;
            //        break;
            //}
            //this.textBox.Text = this.operand1.ToString();
            //this.noviUnos = true;
            //this.unosOperand2 = false;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBox.Text = "0";
            plus = minus = dijeli = mnozi = provjera = potencija = korijen = false;

            //this.mathOperacija = 0;
            //this.operand1 = 0;
            //this.operand2 = 0;
            //this.textBox.Text = "0";
            //this.noviUnos = true;
        }

        #region tipkeklik

        private void buttonNum0_Click(object sender, EventArgs e)
        {
            if(textBox.Text == "0")
                return;
            else
                textBox.Text += "0";
        }



        private void buttonNum1_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0" || provjera)
            {
                textBox.Clear();
                textBox.Text += "1";
                provjera = false;
            }
            else
                textBox.Text += "1";
            
            
        }

        private void buttonNum2_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0"  || provjera)
            {
                textBox.Clear();
                textBox.Text += "2";
                provjera = false;
            }
            else
                textBox.Text += "2";
        }

        private void buttonNum3_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0" || provjera)
            {
                textBox.Clear();
                textBox.Text += "3";
                provjera = false;
            }
            else
                textBox.Text += "3";
        }

        private void buttonNum4_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0" || provjera)
            {
                textBox.Clear();
                textBox.Text += "4";
                provjera = false;
            }
            else
                textBox.Text += "4";
        }

        private void buttonNum5_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0" || provjera)
            {
                textBox.Clear();
                textBox.Text += "5";
                provjera = false;
            }
            else
                textBox.Text += "5";
        }

        private void buttonNum6_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0" || provjera)
            {
                textBox.Clear();
                textBox.Text += "6";
                provjera = false;
            }
            else
            textBox.Text += "6";
        }

        private void buttonNum7_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0" || provjera)
            {
                textBox.Clear();
                textBox.Text += "7";
                provjera = false;
            }
            else
            textBox.Text += "7";
        }

        private void buttonNum8_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0" || provjera)
            {
                textBox.Clear();
                textBox.Text += "8";
                provjera = false;
            }
            else
            textBox.Text += "8";
        }

        private void buttonNum9_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0" || provjera)
            {
                textBox.Clear();
                textBox.Text += "9";
                provjera = false;
            }
            else
            textBox.Text += "9";
        }

        #endregion

        #region operacije;

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0")
                return;
            else 
            {
                plus = true;
                textBox.Tag = textBox.Text;
                textBox.Text = "";
            }
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0")
                return;
            else
            {
                minus = true;
                textBox.Tag = textBox.Text;
                textBox.Text = "";
            }
        }

        private void buttonMnozi_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0")
                return;
            else
            {
                mnozi = true;
                textBox.Tag = textBox.Text;
                textBox.Text = "";
            }
        }

        private void buttonDijeli_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0")
                return;
            else
            {
                dijeli = true;
                textBox.Tag = textBox.Text;
                textBox.Text = "";
            }
        }

        #endregion

        private void buttonSinus_Click(object sender, EventArgs e)
        {
            if (checkBoxArcus.Checked == false)
            {
                double rad = Convert.ToDouble(textBox.Text);
                rad = rad * (Math.PI / 180);
                double stupnjevi = Math.Sin(rad);
                textBox.Text = stupnjevi.ToString();
            }
            else if (checkBoxArcus.Checked == true)
            {
                double rad = Convert.ToDouble(textBox.Text);
                rad = Math.Asin(rad);
                double stupnjevi = rad * (180 / Math.PI);
                textBox.Text = stupnjevi.ToString();
            }
        
        }

        private void buttonCosinus_Click(object sender, EventArgs e)
        {
            if (checkBoxArcus.Checked == false)
            {
                double rad = Convert.ToDouble(textBox.Text);
                rad = rad * (Math.PI / 180);
                double stupnjevi = Math.Cos(rad);
                textBox.Text = stupnjevi.ToString();
            }

            if (checkBoxArcus.Checked == true)
            {
                double rad = Convert.ToDouble(textBox.Text);
                rad = Math.Acos(rad);
                double stupnjevi = rad * (180 / Math.PI);
                textBox.Text = stupnjevi.ToString();
            }

        }


        private void buttonTangens_Click(object sender, EventArgs e)
        {

            if (checkBoxArcus.Checked == false)
            {
                double rad = Convert.ToDouble(textBox.Text);
                rad = rad * (Math.PI / 180);
                double stupnjevi = Math.Tan(rad);
                textBox.Text = stupnjevi.ToString();
            }
            if (checkBoxArcus.Checked == true)
            {
                double rad = Convert.ToDouble(textBox.Text);
                rad = Math.Atan(rad);
                double stupnjevi = rad * (180 / Math.PI);
                textBox.Text = stupnjevi.ToString();
            }
        }

        private void checkBoxArcus_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxArcus.Checked == true)
            {
                buttonSinus.Text = "Arc Sin";
                buttonCosinus.Text = "Arc Cos";
                buttonTangens.Text = "Arc Tan";
            }
            else if (checkBoxArcus.Checked == false)
            {
                buttonSinus.Text = "Sin";
                buttonCosinus.Text = "Cos";
                buttonTangens.Text = "Tan";
            }
        }

        private void buttonPi_Click(object sender, EventArgs e)
        {
            textBox.Text = Math.PI.ToString();
        }

        private void buttonFaktorijela_Click(object sender, EventArgs e)
        {
            int faktorijel = 1;

            for (int i = 1; i <= Convert.ToDouble(textBox.Text); i++)
            {
                faktorijel = faktorijel * i;
            }
            textBox.Text = faktorijel.ToString();
        }

        private void buttonKvadrat_Click(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString(Math.Pow(Convert.ToDouble(textBox.Text), 2));
        }

        private void buttonKub_Click(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString(Math.Pow(Convert.ToDouble(textBox.Text), 3));
        }

        private void buttonXN_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0")
                return;
            else
            {
                potencija = true;
                textBox.Tag = textBox.Text;
                textBox.Text = "";
            }
        }

        private void buttonPot2_Click(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString(Math.Pow(2, Convert.ToDouble(textBox.Text)));
        }

        private void buttonKorijen_Click(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(textBox.Text)));
        }

        private void buttonKorijenX_Click(object sender, EventArgs e)
        {
            if (textBox.Text == "0")
                return;
            else
            {
                korijen = true;
                textBox.Tag = textBox.Text;
                textBox.Text = "";
            }

            

        }

        private void buttonLog_Click(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString( Math.Log10(Convert.ToDouble(textBox.Text)));
        }

        private void buttonLn_Click(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString(Math.Log(Convert.ToDouble(textBox.Text)));
        }

        private void buttonEX_Click(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString(Math.Pow(Math.E, Convert.ToDouble(textBox.Text)));
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString(Math.E);
        }

        private void button10X_Click(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString(Math.Pow(10, Convert.ToDouble(textBox.Text)));
        }

        private void buttonRazlomak_Click(object sender, EventArgs e)
        {
            textBox.Text = Convert.ToString(1.0 / Convert.ToDouble(textBox.Text));
        }

        private void buttonMS1_Click(object sender, EventArgs e)
        {
            textBoxM1.Text = textBox.Text;
            textBoxM1.BackColor = Color.Lime;
        }

        private void buttonMR1_Click(object sender, EventArgs e)
        {
            textBox.Text = textBoxM1.Text;
        }

        private void buttonMS2_Click(object sender, EventArgs e)
        {
            textBoxM2.Text = textBox.Text;
            textBoxM2.BackColor = Color.Lime;
        }

        private void buttonMR2_Click(object sender, EventArgs e)
        {
            textBox.Text = textBoxM2.Text;
        }

        private void buttonMS3_Click(object sender, EventArgs e)
        {
            textBoxM3.Text = textBox.Text;
            textBoxM3.BackColor = Color.Lime;
        }

        private void buttonMR3_Click(object sender, EventArgs e)
        {
            textBox.Text = textBoxM3.Text;
        }

        private void buttonMS4_Click(object sender, EventArgs e)
        {
            textBoxM4.Text = textBox.Text;
            textBoxM4.BackColor = Color.Lime;
        }

        private void buttonMR4_Click(object sender, EventArgs e)
        {
            textBox.Text = textBoxM4.Text;
        }

        private void buttonMS5_Click(object sender, EventArgs e)
        {
            textBoxM5.Text = textBox.Text;
            textBoxM5.BackColor = Color.Lime;
        }

        private void buttonMR5_Click(object sender, EventArgs e)
        {
            textBox.Text = textBoxM5.Text;
        }

        private void buttonBrisiMemoriju_Click(object sender, EventArgs e)
        {
            textBoxM1.BackColor = Color.Firebrick;
            textBoxM2.BackColor = Color.Firebrick;
            textBoxM3.BackColor = Color.Firebrick;
            textBoxM4.BackColor = Color.Firebrick;
            textBoxM5.BackColor = Color.Firebrick;
            textBoxM1.Clear();
            textBoxM2.Clear();
            textBoxM3.Clear();
            textBoxM4.Clear();
            textBoxM5.Clear();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            
        }

        

        

        
        


        
    }
}