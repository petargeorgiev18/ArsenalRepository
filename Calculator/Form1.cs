using System;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private string currentOperation = "";
        private double resultValue = 0;
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();

            // Attach button click handlers
            button1.Click += Digit_Click;
            button2.Click += Digit_Click;
            button3.Click += Digit_Click;
            button4.Click += Digit_Click;
            button5.Click += Digit_Click;
            button6.Click += Digit_Click;
            button7.Click += Digit_Click;
            button8.Click += Digit_Click;
            button9.Click += Digit_Click;
            button10.Click += Digit_Click;

            button11.Click += Operator_Click; // +
            button12.Click += Operator_Click; // -
            button13.Click += Operator_Click; // *
            button14.Click += Operator_Click; // /

            button15.Click += BtnClear_Click; // C
            button16.Click += BtnEqual_Click; // =            
        }

        private void Digit_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (textBox1.Text == "0" || isOperationPerformed)
                textBox1.Text = "";

            isOperationPerformed = false;
            textBox1.Text += button.Text;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (double.TryParse(textBox1.Text, out resultValue))
            {
                currentOperation = button.Text;
                isOperationPerformed = true;
            }
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            double secondValue;
            if (double.TryParse(textBox1.Text, out secondValue))
            {
                switch (currentOperation)
                {
                    case "+":
                        textBox1.Text = (resultValue + secondValue).ToString();
                        break;
                    case "-":
                        textBox1.Text = (resultValue - secondValue).ToString();
                        break;
                    case "*":
                        textBox1.Text = (resultValue * secondValue).ToString();
                        break;
                    case "/":
                        if (secondValue != 0)
                            textBox1.Text = (resultValue / secondValue).ToString();
                        else
                            textBox1.Text = "Cannot divide by zero";
                        break;
                }
            }

            resultValue = 0;
            currentOperation = "";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            resultValue = 0;
            currentOperation = "";
            isOperationPerformed = false;
        }
    }
}
