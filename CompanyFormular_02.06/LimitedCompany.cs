using System;

namespace CompanyFormular_02._06
{
    public class LimitedCompany : Company
    {
        private string registrationNumber;
        private double currentCapital;

        private const double InitialCapital = 2.0;

        public string RegistrationNumber
        {
            get => registrationNumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Номерът на учредителния акт не може да е празен.");
                registrationNumber = value;
            }
        }

        public double CurrentCapital
        {
            get => currentCapital;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Актуалният капитал не може да е отрицателен.");
                }
                currentCapital = value;
            }
        }

        public LimitedCompany(string name, string establishmentDate, string bulstat,
                              string registrationNumber, double currentCapital)
            : base(name, establishmentDate, bulstat)
        {
            RegistrationNumber = registrationNumber;
            CurrentCapital = currentCapital;
        }

        public double CalculateIncomeTax()
        {
            double profit = CurrentCapital - InitialCapital;
            return profit > 0 ? profit * 0.10 : 0;
        }
    }
}
