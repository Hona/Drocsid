using DrocsidLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrocsidTesting
{
    [TestClass]
    public class Conversion
    {
        [TestMethod]
        public void IntToMessageTypeTest()
        {
            var type = MessageType.Message;
            var typeValue = 0;
            Assert.AreEqual(type, (MessageType) typeValue);

            type = MessageType.Command;
            typeValue = 1;
            Assert.AreEqual(type, (MessageType) typeValue);
        }

        [TestMethod]
        public void MessageTypeToIntTest()
        {
            var type = MessageType.Message;
            var typeValue = 0;
            Assert.AreEqual(typeValue, (int) type);

            type = MessageType.Command;
            typeValue = 1;
            Assert.AreEqual(typeValue, (int) type);
        }
    }
}