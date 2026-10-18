using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public enum ChuckType
    {
        Keyless, // Швидкозатискний
        Keyed    // Ключовий
    }
    public class Drill : Tool
    {
        // Поле за варіантом: Тип патрона
        public ChuckType ChuckType { get; }

        public Drill(string purpose, double weight, int serviceLife, ChuckType chuckType, double initialWear = 0)
            : base(purpose, weight, serviceLife, initialWear)
        {
            ChuckType = chuckType;
        }

        // Метод розрахувати швидкість свердління
        public virtual double CalculateDrillingSpeed()
        {
            if (IsBroken)
            {
                return 0.0;
            }

            double baseSpeed = ChuckType switch
            {
                ChuckType.Keyless => 2800.0, 
                ChuckType.Keyed => 2200.0, 
                _ => 2000.0
            };

            double wearFactor = 1.0 - (CurrentWear / 200.0);

            return baseSpeed * wearFactor;
        }

        public override string Use()
        {
            if (IsBroken)
            {
                return "Дриль зламано! Свердління неможливе.";
            }

            double factor = ChuckType == ChuckType.Keyless ? 1.2 : 1.0;
            AddWear(factor);

            double currentSpeed = CalculateDrillingSpeed();
            return "Свердління виконано. Поточна швидкість: " + currentSpeed.ToString("F0") + " об/хв. Знос: " + CurrentWear.ToString("F1") + "%";
        }

        public override string Sharpen()
        {
            if (IsBroken)
            {
                return "Дриль зламано, обслуговування патрона неможливе.";
            }

            if (NeedsMaintenance)
            {
                CurrentWear = Math.Max(0, CurrentWear - 5.0);
                return "Патрон змащено та обслужено. Знос: " + CurrentWear.ToString("F1") + "%";
            }

            return "Дриль у нормі, обслуговування патрона не потрібне.";
        }
    }
}

