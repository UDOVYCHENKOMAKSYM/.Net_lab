using Lab3;

namespace Lab3Tests
{
    [TestClass]
    public sealed class ToolManagerTest
    {
        [TestMethod]
        public void GetTotalWeightOfToolsNeedingMaintenance_CalculatesCorrectSum()
        {
            // 1. Молоток (NeedsMaintenance = true, вага = 1.5)
            // 2. Дриль (NeedsMaintenance = true, вага = 2.5)
            // 3. Дриль у нормі (NeedsMaintenance = false, вага = 3.0)
            var manager = new ToolManager();

            var hammerNeedingService = new Hammer("Тестовий молоток", 1.5, 100, HandleMaterial.Wood, initialWear: 60.0);
            var drillNeedingService = new Drill("Тестовий дриль 1", 2.5, 100, ChuckType.Keyless, initialWear: 70.0);
            var freshDrill = new Drill("Тестовий дриль 2", 3.0, 100, ChuckType.Keyed, initialWear: 10.0);

            manager.Tools.Add(hammerNeedingService);
            manager.Tools.Add(drillNeedingService);
            manager.Tools.Add(freshDrill);
            double totalWeight = manager.GetTotalWeightOfToolsNeedingMaintenance();

            //  1.5 + 2.5 = 4.0
            Assert.AreEqual(4.0, totalWeight, 0.001, "Загальна вага інструментів, що потребують обслуговування, розрахована коректно.");
        }

        [TestMethod]
        public void GetTotalWeightOfToolsNeedingMaintenance_WhenNoToolsNeedMaintenance_ReturnsZero()
        {
            // Жоден інструмент не потребує обслуговування (знос < 50%)
            var manager = new ToolManager();
            manager.Tools.Add(new Hammer("Молоток", 2.0, 100, HandleMaterial.Metal, initialWear: 10.0));
            manager.Tools.Add(new Drill("Дриль", 3.5, 100, ChuckType.Keyed, initialWear: 20.0));

            double totalWeight = manager.GetTotalWeightOfToolsNeedingMaintenance();

            Assert.AreEqual(0.0, totalWeight, 0.001, "Якщо жоден інструмент не потребує обслуговування, вага має бути 0.0.");
        }

        [TestMethod]
        public void GetTotalWeightOfToolsNeedingMaintenance_WhenEmptyList_ReturnsZero()
        {
            // Порожній список інструментів
            var manager = new ToolManager();
            double totalWeight = manager.GetTotalWeightOfToolsNeedingMaintenance();
            Assert.AreEqual(0.0, totalWeight, 0.001, "Для порожнього списку вага має бути 0.0.");
        }

        [TestMethod]
        public void GetTotalWeightOfToolsNeedingMaintenance_WhenToolsIsNull_ReturnsZero()
        {
            // Випадок, якщо властивості Tools присвоєно null
            var manager = new ToolManager
            {
                Tools = null
            };

            double totalWeight = manager.GetTotalWeightOfToolsNeedingMaintenance();

            Assert.AreEqual(0.0, totalWeight, 0.001, "Якщо Tools дорівнює null, метод має повертати 0.0 без помилки.");
        }
        [TestMethod]
        public void GetTotalWeightOfToolsNeedingMaintenance_WhenToolsAreBroken_DoesNotCountThem()
        {
            // 1. Молоток зі зносом рівно 100% (зламаний, вага = 1.5)
            // 2. Дриль зі зносом понад 100% (зламаний, вага = 2.5)
            // 3. Дриль, що потребує обслуговування (знос 60%, вага = 3.0)
            var manager = new ToolManager();

            manager.Tools.Add(new Hammer("Зламаний молоток", 1.5, 100, HandleMaterial.Wood, initialWear: 100.0));
            manager.Tools.Add(new Drill("Зламаний дриль", 2.5, 100, ChuckType.Keyless, initialWear: 150.0));
            manager.Tools.Add(new Drill("Дриль на обслуговування", 3.0, 100, ChuckType.Keyed, initialWear: 60.0));

            double totalWeight = manager.GetTotalWeightOfToolsNeedingMaintenance();

            // рахується лише третій інструмент (3.0), зламані (знос >= 100%) не враховуються
            Assert.AreEqual(3.0, totalWeight, 0.001, "Зламані інструменти (знос >= 100%) не повинні враховуватися в загальній вазі.");
        }
    }
}

