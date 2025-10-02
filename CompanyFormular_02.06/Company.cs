namespace CompanyFormular_02._06
{
    public class Company
    {
        private string name;
        private string establishmentDate;
        private string bulstat;

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Името на фирмата не може да е празно.");
                }
                name = value;
            }
        }

        public string EstablishmentDate
        {
            get => establishmentDate;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Дата на създаване не може да е празна.");
                }
                establishmentDate = value;
            }
        }

        public string Bulstat
        {
            get => bulstat;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Булстатът не може да е празен.");
                }
                if (value.Length != 10)
                {
                    throw new ArgumentException("Булстатът трябва да съдържа точно 10 знака.");
                }
                bulstat = value;
            }
        }

        public Company(string name, string establishmentDate, string bulstat)
        {
            Name = name;
            EstablishmentDate = establishmentDate;
            Bulstat = bulstat;
        }

        public virtual double CalculateProfit()
        {
            return 0.0; 
        }
    }
}
