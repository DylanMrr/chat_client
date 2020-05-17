using ClientChat_1.Managers;
using ClientChat_1.Messages;
using ClientChat_1.Network;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    public class Tests
    {

        [Test]
        public void JsonSerializing_LoginMessage_String()
        {
            string message = "{\"Login\":\"vasya\",\"Password\":\"ivanov\"}";
            string reqMessage = new JsonDecoder().Serialize(new AuthMessage { Login = "vasya", Password = "ivanov" });
            Assert.AreEqual(message, reqMessage);
        }

        [Test]
        public void JsonSerializing_LoginMessageEmptyPassword_String()
        {
            string message = "{\"Login\":\"vasya\",\"Password\":null}";
            string reqMessage = new JsonDecoder().Serialize(new AuthMessage { Login = "vasya"});
            Assert.AreEqual(message, reqMessage);
        }

        [Test]
        public void JsonSerializing_LoginMessageEmpty_String()
        {
            string message = "{\"Login\":null,\"Password\":null}";
            string reqMessage = new JsonDecoder().Serialize(new AuthMessage());
            Assert.AreEqual(message, reqMessage);
        }

        [Test]
        public void SendMessage_ServerUnavailable_Fail()
        {
            Assert.DoesNotThrow(() => Task.Run(() =>
            {
                new NetworkManager().Login(
                  new AuthMessage
                  {
                      Login = "va",
                      Password = "pas"
                  });
            }));

        }
    }
}