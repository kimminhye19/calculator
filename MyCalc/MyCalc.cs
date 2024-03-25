using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalc
{
    public partial class MyCalc : Form
    {
        public MyCalc()
        {
            InitializeComponent();

            this.bnt_C_Click(this.bnt_C, null);
        }

        /// <summary>
        /// 숫자버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnt_number_Click(object sender, EventArgs e)
        {
            Button _Button;

            _Button = (Button)sender;

            if (this.Operation != string.Empty && this.SecondValue == decimal.MinValue || txt_Result.Text == "0")
            {
                this.txt_Result.Text = string.Empty;
            }

            this.txt_Result.Text += _Button.Text;
            this.SecondValue = decimal.Parse(this.txt_Result.Text);
        }

        /// <summary>
        /// 소수점 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnt_Point_Click(object sender, EventArgs e)
        {
            if (txt_Result.Text != string.Empty) // 숫자가 있어야만 "."이 출력된다.
                if (txt_Result.Text.Contains("."))
                    return;
                else
                    txt_Result.Text += ".";

            //Button _Button;

            //_Button = (Button)sender;

            //if (!this.txt_Result.Text.Contains("."))
            //    this.txt_Result.Text += _Button.Text;
        }

        private decimal FirstValue;
        private decimal SecondValue;
        private string Operation;

        /// <summary>
        /// Operation 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnt_Operation_Click(object sender, EventArgs e)
        {
            Button _Button;

            if (this.txt_Result.Text == string.Empty)
                return;

            _Button = (Button)sender;

            this.Operation = _Button.Text;

            this.FirstValue = decimal.Parse(this.txt_Result.Text);
            this.SecondValue = decimal.MinValue;

            //this.txt_Result.Text = string.Empty;
        }

        /// <summary>
        /// Equal 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnt_Equal_Click(object sender, EventArgs e)
        {
            if (this.FirstValue == decimal.MinValue)
                return;

            if (this.Operation == string.Empty)
                return;

            if (this.txt_Result.Text == string.Empty)
                return;

            if (this.SecondValue == decimal.MinValue)
                this.SecondValue = decimal.Parse(this.txt_Result.Text);

            switch (this.Operation)
            {
                case "+":
                    this.FirstValue = this.FirstValue + this.SecondValue;
                    break;
                case "-":
                    this.FirstValue = this.FirstValue - this.SecondValue;
                    break;
                case "*":
                    this.FirstValue = this.FirstValue * this.SecondValue;
                    break;
                case "/":
                    if (this.SecondValue == 0)
                        return;

                    this.FirstValue = this.FirstValue / this.SecondValue;
                    break;
            }
            this.txt_Result.Text = this.FirstValue.ToString();
        }

        /// <summary>
        /// Clear 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnt_C_Click(object sender, EventArgs e)
        {
            this.FirstValue = decimal.MinValue;
            this.Operation = string.Empty;
            this.SecondValue = decimal.MinValue;
            this.txt_Result.Text = string.Empty;
        }

        /// <summary>
        /// Back 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bnt_Back_Click(object sender, EventArgs e)
        {
            if (this.txt_Result.Text == string.Empty)
                return;

            this.txt_Result.Text = this.txt_Result.Text.Substring(0, this.txt_Result.Text.Length - 1);
        }

        private void btnChange(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            Double a = (Double.Parse(txt_Result.Text));
            Double b = (a * -1);
            txt_Result.Text = Convert.ToString(b); // 양수음수 바꾸기
        }

        private void ClearClick(object sender, EventArgs e)
        {
            Button clear = (Button)sender;
            txt_Result.Text = string.Empty; // 전부 지우기
        }
    }
}