namespace CompanyFormular_02._06
{
    public partial class Form1 : Form
    {
        private List<Company> companies = new List<Company>();
        public Form1()
        {
            InitializeComponent();
            radioButton1.CheckedChanged += RadioButtons_CheckedChanged;
            radioButton2.CheckedChanged += RadioButtons_CheckedChanged;
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            UpdateLabels();
        }
        private void RadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLabels();
        }
        private void UpdateLabels()
        {
            if (radioButton1.Checked)
            {
                groupBox2.Text = "ЕТ";
                label4.Text = "Име на собственика";
                label5.Visible = true;
                textBox5.Visible = true;
            }
            else
            {
                groupBox2.Text = "ЕООД";
                label4.Text = "Номер на учредителен акт";
                label5.Visible = false;
                textBox5.Visible = false;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text.Trim();
                string date = textBox2.Text.Trim();
                string bulstat = textBox3.Text.Trim();
                string field4 = textBox4.Text.Trim();
                string currentCapitalStr = textBox6.Text.Trim();
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(date) ||
                    string.IsNullOrWhiteSpace(bulstat) || string.IsNullOrWhiteSpace(field4) ||
                    string.IsNullOrWhiteSpace(currentCapitalStr))
                {
                    MessageBox.Show("Моля, попълнете всички задължителни полета.");
                    return;
                }
                double currentCapital = double.Parse(currentCapitalStr);
                Company company;
                if (radioButton1.Checked)
                {
                    string initialCapitalStr = textBox5.Text.Trim();
                    if (string.IsNullOrWhiteSpace(initialCapitalStr))
                    {
                        MessageBox.Show("Моля, въведете първоначален капитал за ЕТ.");
                        return;
                    }

                    double initialCapital = double.Parse(initialCapitalStr);
                    company = new SoleTrader(name, date, bulstat, field4, initialCapital, currentCapital);
                }
                else
                {
                    company = new LimitedCompany(name, date, bulstat, field4, currentCapital);
                }
                companies.Add(company);
                MessageBox.Show("Фирмата е добавена успешно!");
                ClearInputs();
            }
            catch (FormatException)
            {
                MessageBox.Show("Моля, въведете валидни стойности за капитал.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Грешка: " + ex.Message);
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var company in companies)
            {
                double netProfit = company.CalculateProfit();
                listBox1.Items.Add($"{company.Bulstat} {company.Name} {netProfit:F2} лв.");
            }
        }
        private void ClearInputs()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
    }
}
