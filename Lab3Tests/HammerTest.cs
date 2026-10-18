using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;

namespace Lab3Tests
{
    [TestClass]
    public sealed class HammerTests
    {
        // Тестування успішної ініціалізації об'єкта.
        [TestMethod]
        public void Constructor_WithValidData_InitializesCorrectly()
        {
            string purpose = "Будівельний";
            double weight = 1.5;
            int serviceLife = 10;
            HandleMaterial material = HandleMaterial.Wood;

            var hammer = new Hammer(purpose, weight, serviceLife, material);

            Assert.AreEqual(purpose, hammer.Purpose, "Призначення повинно бути ініціалізоване коректно.");
            Assert.AreEqual(weight, hammer.Weight, "Вага повинна бути ініціалізована коректно.");
            Assert.AreEqual(serviceLife, hammer.ServiceLife, "Термін служби повинен бути ініціалізований коректно.");
            Assert.AreEqual(material, hammer.HandleMaterial, "Матеріал ручки повинен бути ініціалізований коректно.");
            Assert.AreEqual(0, hammer.CurrentWear, "Початковий знос повинен дорівнювати 0.");
        }

        // Тестування конструктора з невалідним призначенням.
        [TestMethod]
        public void Constructor_WithNullOrEmptyPurpose_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Hammer("", 1.5, 10, HandleMaterial.Wood));
        }

        // Тестування конструктора з невалідною вагою.
        [TestMethod]
        public void Constructor_WithNegativeOrZeroWeight_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Hammer("Будівельний", -1.0, 10, HandleMaterial.Wood));
        }

        // Тестування розрахунку зносу при використанні.
        [TestMethod]
        public void Use_IncreasesWearCorrectly()
        {
            // Пластикова ручка має factor = 1.8
            // Знос: (100 / 10) * 1.8 = 18.0%
            var hammer = new Hammer("Тестовий", 1.0, 10, HandleMaterial.Plastic);

            string result = hammer.Use();

            Assert.AreEqual(18.0, hammer.CurrentWear, 0.001, "Знос після використання розраховано некоректно.");
            StringAssert.Contains(result, "Удар молотком", "Повідомлення про використання сформовано некоректно.");
        }

        // Тестування настання стану обслуговування (NeedsMaintenance).
        [TestMethod]
        public void Use_WhenWearExceeds50Percent_SetsNeedsMaintenance()
        {
            // Початковий знос 40.0% + 18.0% = 58.0%
            var hammer = new Hammer("Тестовий", 1.0, 10, HandleMaterial.Plastic, 40.0);

            hammer.Use();

            Assert.IsTrue(hammer.NeedsMaintenance, "Властивість NeedsMaintenance повинна повертати true при зносі >= 50%.");
            Assert.IsFalse(hammer.IsBroken, "Властивість IsBroken повинна повертати false при зносі < 100%.");
        }

        // Тестування успішного ремонту.
        [TestMethod]
        public void Repair_WhenNeedsMaintenance_ResetsWearToZero()
        {
            var hammer = new Hammer("Тестовий", 1.0, 10, HandleMaterial.Wood, 60.0);

            string result = hammer.Repair();

            Assert.AreEqual(0, hammer.CurrentWear, "Ремонт повинен скидати знос до 0%.");
            Assert.IsFalse(hammer.NeedsMaintenance, "Після ремонту NeedsMaintenance має бути false.");
            StringAssert.Contains(result, "відремонтовано", "Повідомлення про ремонт сформовано некоректно.");
        }

        // Тестування ремонту у разі поломки (IsBroken).
        [TestMethod]
        public void Repair_WhenIsBroken_DoesNotResetWear()
        {
            var hammer = new Hammer("Тестовий", 1.0, 10, HandleMaterial.Wood, 100.0);

            string result = hammer.Repair();

            Assert.AreEqual(100.0, hammer.CurrentWear, "Знос зламаного інструмента не повинен змінюватися.");
            StringAssert.Contains(result, "зламано", "Повідомлення про заблокований ремонт сформовано некоректно.");
        }

        // Тестування методу Sharpen коли потрібен ремонт.
        [TestMethod]
        public void Sharpen_WhenNeedsMaintenance_ReducesWear()
        {
            var hammer = new Hammer("Тестовий", 1.0, 10, HandleMaterial.Wood, 60.0);

            string result = hammer.Sharpen();

            Assert.AreEqual(55.0, hammer.CurrentWear, 0.001, "Заточування/профілактика має зменшувати знос на 5%.");
            StringAssert.Contains(result, "Бойок зачищено", "Повідомлення про заточування сформовано некоректно.");
        }

        // Тестування методу Sharpen коли молоток у нормі.
        [TestMethod]
        public void Sharpen_WhenNormalState_DoesNotChangeWear()
        {
            var hammer = new Hammer("Тестовий", 1.0, 10, HandleMaterial.Wood, 10.0);

            string result = hammer.Sharpen();

            Assert.AreEqual(10.0, hammer.CurrentWear, "Знос не повинен змінюватися.");
            StringAssert.Contains(result, "у нормі", "Повідомлення про відсутність потреби заточування сформовано некоректно.");
        }

        // Тестування методу Sharpen коли молоток зламано.
        [TestMethod]
        public void Sharpen_WhenIsBroken_DoesNotChangeWear()
        {
            var hammer = new Hammer("Тестовий", 1.0, 10, HandleMaterial.Wood, 100.0);

            string result = hammer.Sharpen();

            Assert.AreEqual(100.0, hammer.CurrentWear, "Знос зламаного молотка не повинен змінюватися.");
            StringAssert.Contains(result, "зламано", "Повідомлення про неможливість заточування сформовано некоректно.");
        }

        // Тестування перевірки стану для робочого молотка.
        [TestMethod]
        public void CheckWear_WhenWorkingStatus_ReturnsWorkingString()
        {
            var hammer = new Hammer("Тестовий", 1.0, 10, HandleMaterial.Wood, 10.0);

            string result = hammer.CheckWear();

            StringAssert.Contains(result, "У робочому стані", "Повідомлення про робочий стан сформовано некоректно.");
        }

        // Тестування перевірки стану, коли молоток потребує ремонту.
        [TestMethod]
        public void CheckWear_WhenNeedsMaintenance_ReturnsMaintenanceString()
        {
            var hammer = new Hammer("Тестовий", 1.0, 10, HandleMaterial.Wood, 60.0);

            string result = hammer.CheckWear();

            StringAssert.Contains(result, "Потребує ремонту", "Повідомлення про потребу ремонту сформовано некоректно.");
        }

        // Тестування перевірки стану для зламаного молотка.
        [TestMethod]
        public void CheckWear_WhenIsBroken_ReturnsBrokenString()
        {
            var hammer = new Hammer("Тестовий", 1.0, 10, HandleMaterial.Wood, 100.0);

            string result = hammer.CheckWear();

            StringAssert.Contains(result, "Зламано", "Повідомлення про поломку сформовано некоректно.");
        }
    }

}
