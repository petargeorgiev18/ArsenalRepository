using System;

namespace CompanyFormular_02._06
{
    public class SoleTrader : Company
    {
        private string ownerName;
        private double initialCapital;
        private double currentCapital;

        public string OwnerName
        {
            get => ownerName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Името на собственика не може да е празно.");
                }
                ownerName = value;
            }
        }

        public double InitialCapital
        {
            get => initialCapital;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Първоначалният капитал не може да е отрицателен.");
                }
                initialCapital = value;
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

        public SoleTrader(string name, string establishmentDate, string bulstat,
                          string ownerName, double initialCapital, double currentCapital)
            : base(name, establishmentDate, bulstat)
        {
            OwnerName = ownerName;
            InitialCapital = initialCapital;
            CurrentCapital = currentCapital;
        }

        public double CalculateIncomeTax()
        {
            double profit = CurrentCapital - InitialCapital;
            return profit > 0 ? profit * 0.15 : 0;
        }
    }
}
