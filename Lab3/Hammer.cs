using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public enum HandleMaterial
    {
        Wood,       // Дерево (базовий знос, factor = 1.0)
        Plastic,    // Пластик (крихкіший, factor = 1.8)
        Metal  // Метал (найміцніший, factor = 0.7)
    }
    public class Hammer : Tool
    {
        public HandleMaterial HandleMaterial { get; }

        public Hammer(string purpose, double weight, int serviceLife, HandleMaterial handleMaterial, double initialWear = 0)
            : base(purpose, weight, serviceLife, initialWear)
        {
            HandleMaterial = handleMaterial;
        }

        public override string Use()
        {
            if (IsBroken)
            {
                return "Молоток зламано! Використання неможливе.";
            }

            // Визначаємо коефіцієнт залежно від матеріалу ручки
            double factor = HandleMaterial switch
            {
                HandleMaterial.Wood => 1.0,
                HandleMaterial.Plastic => 1.8,
                HandleMaterial.Metal => 0.7,
                _ => 1.0
            };

            AddWear(factor);

            return "Удар молотком. Знос: " + CurrentWear.ToString("F1") + "%";
        }

        public override string Sharpen()
        {
            if (IsBroken)
            {
                return "Молоток зламано, заточування неможливе.";
            }

            if (NeedsMaintenance)
            {
                CurrentWear = Math.Max(0, CurrentWear - 5.0);
                return "Бойок зачищено. Знос: " + CurrentWear.ToString("F1") + "%";
            }

            return "Молоток у нормі, заточування не потрібне.";
        }

        public string CheckWear()
        {
            if (IsBroken)
            {
                return "Зламано. Знос: " + CurrentWear.ToString("F1") + "%";
            }

            if (NeedsMaintenance)
            {
                return "Потребує ремонту. Знос: " + CurrentWear.ToString("F1") + "%";
            }

            return "У робочому стані. Знос: " + CurrentWear.ToString("F1") + "%";
        }
    }
}
