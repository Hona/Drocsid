using DrocsidLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrocsidTesting
{
    [TestClass]
    public class Formatting
    {
        private User _user = new User {Name = "Test Name123"};
        [TestMethod]
        public void ApplyMessageFormattingTest()
        {
            var expectedFormattedMessage = "0test";
            var message = "test";
            Assert.AreEqual(Helper.ApplySendFormat(MessageType.Message, _user, message), expectedFormattedMessage);
        }

        [TestMethod]
        public void ApplyCommandFormattingTest()
        {
            var expectedFormattedCommand = "1shutdown /h";
            var command = "shutdown /h";
            Assert.AreEqual(Helper.ApplySendFormat(MessageType.Command, _user, command), expectedFormattedCommand);
        }
    }
}