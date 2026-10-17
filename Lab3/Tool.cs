using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public abstract class Tool
    {
        private string purpose;
        private double weight;
        private int serviceLife;
        private double currentWear;

        public string Purpose
        {
            get => purpose;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Призначення не може бути порожнім.", nameof(value));
                purpose = value;
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Вага повинна бути додатнім числом.", nameof(value));
                weight = value;
            }
        }

        public int ServiceLife
        {
            get => serviceLife;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Термін служби повинен бути більшим за 0.", nameof(value));
                serviceLife = value;
            }
        }

        public double CurrentWear
        {
            get => currentWear;
            protected set
            {
                if (value < 0)
                {
                    currentWear = 0;
                }
                else
                {
                    currentWear = value;
                }
            }
        }

        public bool NeedsMaintenance => CurrentWear >= 50.0 && CurrentWear < 100.0;

        public bool IsBroken => CurrentWear >= 100.0;

        protected Tool(string purpose, double weight, int serviceLife, double initialWear = 0)
        {
            Purpose = purpose;
            Weight = weight;
            ServiceLife = serviceLife;
            CurrentWear = initialWear;
        }

        protected void AddWear(double baseLoad, double factor)
        {
            if (IsBroken) return;

            double wearIncrement = (baseLoad / ServiceLife) * 100.0 * factor;
            CurrentWear += wearIncrement;
        }

        public virtual string Repair()
        {
            if (IsBroken)
            {
                return "Інструмент зламано (знос " + CurrentWear.ToString("F1") + "%). Ремонт неможливий.";
            }

            if (NeedsMaintenance)
            {
                CurrentWear = 0;
                return "Інструмент відремонтовано. Знос: 0%";
            }

            return "Ремонт не потрібен. Знос: " + CurrentWear.ToString("F1") + "%";
        }

        public abstract string Use();
        public abstract string Sharpen();
    }
}
