using Lab3;

namespace Lab3Tests
{
    [TestClass]
    public sealed class DrillTest
    {
        // Тестування успішної ініціалізації об'єкта.
        [TestMethod]
        public void Constructor_WithValidData_InitializesCorrectly()
        {
            string purpose = "Ударний";
            double weight = 2.5;
            int serviceLife = 100;
            ChuckType chuckType = ChuckType.Keyless;

            var drill = new Drill(purpose, weight, serviceLife, chuckType);

            Assert.AreEqual(purpose, drill.Purpose, "Призначення повинно бути ініціалізоване коректно.");
            Assert.AreEqual(weight, drill.Weight, "Вага повинна бути ініціалізована коректно.");
            Assert.AreEqual(serviceLife, drill.ServiceLife, "Термін служби повинен бути ініціалізований коректно.");
            Assert.AreEqual(chuckType, drill.ChuckType, "Тип патрона повинен бути ініціалізований коректно.");
            Assert.AreEqual(0.0, drill.CurrentWear, "Початковий знос повинен дорівнювати 0.");
        }

        // Тестування конструктора з невалідним призначенням.
        [TestMethod]
        public void Constructor_WithEmptyOrWhitespacePurpose_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Drill("", 2.5, 100, ChuckType.Keyless));
            Assert.Throws<ArgumentException>(() => new Drill("   ", 2.5, 100, ChuckType.Keyless));
        }

        // Тестування конструктора з невалідною вагою.
        [TestMethod]
        public void Constructor_WithNegativeOrZeroWeight_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Drill("Ударний", -1.0, 100, ChuckType.Keyless));
            Assert.Throws<ArgumentException>(() => new Drill("Ударний", 0.0, 100, ChuckType.Keyless));
        }

        // Тестування конструктора з невалідним терміном служби.
        [TestMethod]
        public void Constructor_WithNegativeOrZeroServiceLife_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new Drill("Ударний", 2.5, -10, ChuckType.Keyless));
            Assert.Throws<ArgumentException>(() => new Drill("Ударний", 2.5, 0, ChuckType.Keyless));
        }

        // Тестування конструктора з від'ємним початковим зносом.
        [TestMethod]
        public void Constructor_WithNegativeInitialWear_SetsWearToZero()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: -10.0);

            Assert.AreEqual(0.0, drill.CurrentWear, 0.001, "Від'ємний початковий знос повинен перетворюватися на 0.");
        }

        // Тестування меж станів NeedsMaintenance та IsBroken.
        [TestMethod]
        public void WearBoundaries_SetCorrectState()
        {
            var justBelow50 = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 49.9);
            var exactly50 = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 50.0);
            var justBelow100 = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 99.9);
            var exactly100 = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 100.0);

            Assert.IsFalse(justBelow50.NeedsMaintenance, "При зносі 49.9% обслуговування ще не потрібне.");
            Assert.IsTrue(exactly50.NeedsMaintenance, "При зносі 50% обслуговування вже потрібне.");
            Assert.IsTrue(justBelow100.NeedsMaintenance, "При зносі 99.9% обслуговування потрібне.");
            Assert.IsFalse(justBelow100.IsBroken, "При зносі 99.9% дриль ще не зламаний.");
            Assert.IsTrue(exactly100.IsBroken, "При зносі 100% дриль зламаний.");
            Assert.IsFalse(exactly100.NeedsMaintenance, "Зламаний дриль не вважається таким, що потребує обслуговування.");
        }

        // Тестування швидкості нового дриля зі швидкозатискним патроном.
        [TestMethod]
        public void CalculateDrillingSpeed_NewKeylessDrill_ReturnsBaseSpeed()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 0);

            double speed = drill.CalculateDrillingSpeed();

            Assert.AreEqual(2800.0, speed, 0.001, "Базова швидкість для Keyless має бути 2800.");
        }

        // Тестування швидкості нового дриля з ключовим патроном.
        [TestMethod]
        public void CalculateDrillingSpeed_NewKeyedDrill_ReturnsBaseSpeed()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyed, initialWear: 0);

            double speed = drill.CalculateDrillingSpeed();

            Assert.AreEqual(2200.0, speed, 0.001, "Базова швидкість для Keyed має бути 2200.");
        }

        // Тестування зниження швидкості через знос.
        [TestMethod]
        public void CalculateDrillingSpeed_WithWear_ReducesSpeed()
        {
            // wearFactor = 1.0 - (50 / 200.0) = 0.75
            // Keyless: 2800 * 0.75 = 2100; Keyed: 2200 * 0.75 = 1650
            var keyless = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 50.0);
            var keyed = new Drill("Тестовий", 2.5, 100, ChuckType.Keyed, initialWear: 50.0);

            Assert.AreEqual(2100.0, keyless.CalculateDrillingSpeed(), 0.001, "Швидкість Keyless зі зносом 50% розрахована некоректно.");
            Assert.AreEqual(1650.0, keyed.CalculateDrillingSpeed(), 0.001, "Швидкість Keyed зі зносом 50% розрахована некоректно.");
        }

        // Тестування швидкості зламаного дриля.
        [TestMethod]
        public void CalculateDrillingSpeed_WhenBroken_ReturnsZero()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 100.0);

            double speed = drill.CalculateDrillingSpeed();

            Assert.IsTrue(drill.IsBroken);
            Assert.AreEqual(0.0, speed, 0.001, "Зламаний дриль не повинен свердлити.");
        }

        // Тестування розрахунку зносу для швидкозатискного патрона.
        [TestMethod]
        public void Use_KeylessChuck_IncreasesWearCorrectly()
        {
            // Для Keyless factor = 1.2; Знос: (100 / 100) * 1.2 = 1.2%
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless);

            string result = drill.Use();

            Assert.AreEqual(1.2, drill.CurrentWear, 0.001, "Знос після використання Keyless розраховано некоректно.");
            StringAssert.Contains(result, "Свердління виконано", "Повідомлення про використання сформовано некоректно.");
        }

        // Тестування розрахунку зносу для ключового патрона.
        [TestMethod]
        public void Use_KeyedChuck_IncreasesWearCorrectly()
        {
            // Для Keyed factor = 1.0; Знос: (100 / 100) * 1.0 = 1.0%
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyed);

            string result = drill.Use();

            Assert.AreEqual(1.0, drill.CurrentWear, 0.001, "Знос після використання Keyed розраховано некоректно.");
            StringAssert.Contains(result, "Свердління виконано", "Повідомлення про використання сформовано некоректно.");
        }

        // Тестування впливу терміну служби на знос.
        [TestMethod]
        public void Use_WithShorterServiceLife_IncreasesWearFaster()
        {
            // ServiceLife = 50, Keyed: (100 / 50) * 1.0 = 2.0%
            var drill = new Drill("Тестовий", 2.5, 50, ChuckType.Keyed);

            drill.Use();

            Assert.AreEqual(2.0, drill.CurrentWear, 0.001, "Знос повинен залежати від терміну служби.");
        }

        // Тестування накопичення зносу при кількох використаннях.
        [TestMethod]
        public void Use_Repeatedly_AccumulatesWear()
        {
            // 5 * 1.2 = 6.0%
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless);

            for (int i = 0; i < 5; i++)
            {
                drill.Use();
            }

            Assert.AreEqual(6.0, drill.CurrentWear, 0.001, "Знос повинен накопичуватися.");
        }

        // Тестування настання стану обслуговування (NeedsMaintenance).
        [TestMethod]
        public void Use_WhenWearExceeds50Percent_SetsNeedsMaintenance()
        {
            // Початковий знос 49.0% + 1.2% = 50.2%
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 49.0);

            drill.Use();

            Assert.IsTrue(drill.NeedsMaintenance, "Властивість NeedsMaintenance повинна повертати true при зносі >= 50%.");
            Assert.IsFalse(drill.IsBroken, "Властивість IsBroken повинна повертати false при зносі < 100%.");
        }

        // Тестування настання поломки (IsBroken).
        [TestMethod]
        public void Use_WhenWearReaches100Percent_SetsIsBroken()
        {
            // Початковий знос 99.0% + 1.0% = 100.0%
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyed, initialWear: 99.0);

            drill.Use();

            Assert.IsTrue(drill.IsBroken, "Властивість IsBroken повинна повертати true при зносі >= 100%.");
            Assert.IsFalse(drill.NeedsMaintenance, "Зламаний дриль не повинен потребувати обслуговування.");
        }

        // Тестування використання зламаного дриля.
        [TestMethod]
        public void Use_WhenIsBroken_DoesNotIncreaseWear()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 100.0);

            string result = drill.Use();

            Assert.AreEqual(100.0, drill.CurrentWear, 0.001, "Знос зламаного дриля не повинен змінюватися.");
            StringAssert.Contains(result, "зламано", "Повідомлення про неможливість використання сформовано некоректно.");
        }

        // Тестування успішного ремонту.
        [TestMethod]
        public void Repair_WhenNeedsMaintenance_ResetsWearToZero()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 60.0);

            string result = drill.Repair();

            Assert.AreEqual(0.0, drill.CurrentWear, 0.001, "Ремонт повинен скидати знос до 0%.");
            Assert.IsFalse(drill.NeedsMaintenance, "Після ремонту NeedsMaintenance має бути false.");
            StringAssert.Contains(result, "відремонтовано", "Повідомлення про ремонт сформовано некоректно.");
        }

        // Тестування ремонту на межі стану обслуговування.
        [TestMethod]
        public void Repair_WhenWearIsExactly50_ResetsWearToZero()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 50.0);

            drill.Repair();

            Assert.AreEqual(0.0, drill.CurrentWear, 0.001, "При зносі 50% ремонт уже повинен бути можливий.");
        }

        // Тестування відновлення швидкості після ремонту.
        [TestMethod]
        public void Repair_RestoresBaseDrillingSpeed()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 60.0);

            drill.Repair();

            Assert.AreEqual(2800.0, drill.CalculateDrillingSpeed(), 0.001, "Після ремонту швидкість має відновитися до базової.");
        }

        // Тестування ремонту у разі поломки (IsBroken).
        [TestMethod]
        public void Repair_WhenIsBroken_DoesNotResetWear()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 100.0);

            string result = drill.Repair();

            Assert.AreEqual(100.0, drill.CurrentWear, 0.001, "Знос зламаного інструмента не повинен змінюватися.");
            StringAssert.Contains(result, "зламано", "Повідомлення про заблокований ремонт сформовано некоректно.");
        }

        // Тестування ремонту, коли дриль у нормі.
        [TestMethod]
        public void Repair_WhenNoMaintenanceNeeded_DoesNotChangeWear()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 20.0);

            string result = drill.Repair();

            Assert.AreEqual(20.0, drill.CurrentWear, 0.001, "Знос дриля у нормі не повинен змінюватися.");
            StringAssert.Contains(result, "не потрібен", "Повідомлення про відсутність потреби в ремонті сформовано некоректно.");
        }

        // Тестування методу Sharpen коли потрібне обслуговування.
        [TestMethod]
        public void Sharpen_WhenNeedsMaintenance_ReducesWear()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 60.0);

            string result = drill.Sharpen();

            Assert.AreEqual(55.0, drill.CurrentWear, 0.001, "Обслуговування патрона має зменшувати знос на 5%.");
            StringAssert.Contains(result, "Патрон", "Повідомлення про обслуговування сформовано некоректно.");
        }

        // Тестування методу Sharpen на межі стану обслуговування.
        [TestMethod]
        public void Sharpen_WhenWearIsExactly50_ReducesWearAndClearsMaintenance()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 50.0);

            drill.Sharpen();

            Assert.AreEqual(45.0, drill.CurrentWear, 0.001, "При зносі 50% обслуговування вже повинно зменшувати знос.");
            Assert.IsFalse(drill.NeedsMaintenance, "Після обслуговування NeedsMaintenance має бути false.");
        }

        // Тестування методу Sharpen коли дриль у нормі.
        [TestMethod]
        public void Sharpen_WhenNormalState_DoesNotChangeWear()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 10.0);

            string result = drill.Sharpen();

            Assert.AreEqual(10.0, drill.CurrentWear, 0.001, "Знос не повинен змінюватися.");
            StringAssert.Contains(result, "у нормі", "Повідомлення про відсутність потреби обслуговування сформовано некоректно.");
        }

        // Тестування методу Sharpen коли дриль зламано.
        [TestMethod]
        public void Sharpen_WhenIsBroken_DoesNotChangeWear()
        {
            var drill = new Drill("Тестовий", 2.5, 100, ChuckType.Keyless, initialWear: 100.0);

            string result = drill.Sharpen();

            Assert.AreEqual(100.0, drill.CurrentWear, 0.001, "Знос зламаного дриля не повинен змінюватися.");
            StringAssert.Contains(result, "зламано", "Повідомлення про неможливість обслуговування сформовано некоректно.");
        }
    }
}
