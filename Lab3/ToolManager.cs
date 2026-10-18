using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class ToolManager
    {
        public List<Tool> Tools { get; set; } = new List<Tool>();

        public double GetTotalWeightOfToolsNeedingMaintenance()
        {
            if (Tools == null) return 0.0;
            double totalWeight = 0;

            foreach (var tool in Tools)
            {
                if (tool.NeedsMaintenance)
                {
                    totalWeight += tool.Weight;
                }
            }

            return totalWeight;
        }
    }
}
