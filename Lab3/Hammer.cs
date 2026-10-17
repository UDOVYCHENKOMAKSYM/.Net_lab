using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public enum HandleMaterial
    {
        Wood,       // Дерево (базовий знос, factor = 1.0)
        Plastic,    // Пластик (крихкіший, factor = 1.8)
        Fiberglass  // Фіберглас / Склопластик (найміцніший, factor = 0.6)
    }
    public class Hammer : Tool
    {
        public HandleMaterial HandleMaterial { get; set; }

        public Hammer(string purpose, double weight, int serviceLife, HandleMaterial handleMaterial, double initialWear = 0)
            : base(purpose, weight, serviceLife, initialWear)
        {
            HandleMaterial = handleMaterial;
        }

        public override string Use()
        {
            if (IsBroken)
            {
                return "Молоток зламано! (Знос: " + CurrentWear.ToString("F1") + "%)";
            }

            double factor = HandleMaterial switch
            {
                HandleMaterial.Plastic => 1.8,
                HandleMaterial.Wood => 1.0,
                HandleMaterial.Fiberglass => 0.6,
                _ => 1.0
            };

            AddWear(1.0, factor);

            string status = NeedsMaintenance ? " (потребує ремонту)" : "";
            return "Удар молотком. Знос: " + CurrentWear.ToString("F1") + "%" + status;
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
