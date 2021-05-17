using BL;
using BL.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class ScheduleTests
    {
        [TestMethod]
        public void Create()
        {
            var schedule = new Schedule();
            schedule.Start();

            Assert.AreNotEqual(0, Select.Lessons().Count);
        }
    }
}