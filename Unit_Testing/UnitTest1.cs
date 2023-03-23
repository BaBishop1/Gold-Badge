namespace Gold_Badge;

[TestClass]
public class Gold_Badge
{
    [TestClass]
    public class DriversTesting
    {
        [TestMethod]
        public void TestMethod1()
        {
            Drivers driver = new Drivers();
            driver.FirstName = "Brayden";

            string expected = "Brayden";
            string actual = driver.FirstName;

            Assert.AreEqual(expected, actual);
        }
    }
    [TestClass]
    public class Drivers_RepoTests
    {
        private Drivers_Repo? _repo = new Drivers_Repo();
        private Drivers? _driver;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new Drivers_Repo();
            _driver = new Drivers("First Name", "Last Name", 123, "address", "email", 123);
            _repo.AddDriverToList(_driver);
        }
        [TestMethod]
        public void AddDriverToList_ShouldGetNotNull()
        {
            Drivers driver = new Drivers();
            driver.IdNumber = 123;
            Drivers_Repo drivers_Repo = new Drivers_Repo();
            drivers_Repo.AddDriverToList(driver);
            Drivers driverId = drivers_Repo.GetDriverById(driver.IdNumber);
            Assert.IsNotNull(driverId);
        }
        [TestMethod]
        public void GetDriverById_ShouldGetNotNull()
        {
            Drivers Id = _repo.GetDriverById(123);

            Assert.IsNotNull(Id);
        }
        [TestMethod]
        public void GetDriverByName_ShouldGetNotNull()
        {
            Drivers name = _repo.GetDriverByName("First Name", "Last Name");

            Assert.IsNotNull(name);
        }
        [TestMethod]
        public void UpdateDriverList_ShouldReturnTrue()
        {
            Drivers newDriver = new Drivers("First Name", "Last Name", 321, "address", "email", 321);
            bool updateResult = _repo.UpdateDriverList(123, newDriver);

            Assert.IsTrue(updateResult);
        }
        [TestMethod]
        public void RemoveDriverFromList_ShouldGetNull()
        {
            Drivers newDriver = new Drivers("First Name", "Last Name", 321, "address", "email", 321);
            bool driver = _repo.RemoveDriverFromList(newDriver.IdNumber);

            Assert.IsFalse(driver);
        }
    }

}