using DrocsidLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrocsidTesting
{
    [TestClass]
    public class Formatting
    {
        [TestMethod]
        public void ApplyMessageFormattingTest()
        {
            var expectedFormattedMessage = "0test";
            var message = "test";
            Assert.AreEqual(Helper.ApplySendFormat(MessageType.Message, message), expectedFormattedMessage);
        }

        [TestMethod]
        public void ApplyCommandFormattingTest()
        {
            var expectedFormattedCommand = "1shutdown /h";
            var command = "shutdown /h";
            Assert.AreEqual(Helper.ApplySendFormat(MessageType.Command, command), expectedFormattedCommand);
        }
    }
}