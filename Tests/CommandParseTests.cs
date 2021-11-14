using CastleHillGamingPets;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CommandParseTests
    {
        [Test]
        public void TestParseNull()
        {
            Assert.Throws<ArgumentNullException>(() => Command.ParseFromInput(null));
        }

        [Test]
        public void TestParseEmpty()
        {
            Assert.Throws<ArgumentException>(() => Command.ParseFromInput(""));
        }

        [Test]
        public void TestParseNoArgs()
        {
            var cmd = Command.ParseFromInput("test");
            Assert.AreEqual("test", cmd.Name);
            Assert.AreEqual(0, cmd.ArgCount);
            Assert.Null(cmd.GetArg(0));
        }

        [Test]
        public void TestParse1Arg()
        {
            var cmd = Command.ParseFromInput("test arg");
            Assert.AreEqual("test", cmd.Name);
            Assert.AreEqual(1, cmd.ArgCount);
            Assert.AreEqual("arg", cmd.GetArg(0));
            Assert.Null(cmd.GetArg(1));
        }

        [Test]
        public void TestParse2Args()
        {
            var cmd = Command.ParseFromInput("test arg gra");
            Assert.AreEqual("test", cmd.Name);
            Assert.AreEqual(2, cmd.ArgCount);
            Assert.AreEqual("arg", cmd.GetArg(0));
            Assert.AreEqual("gra", cmd.GetArg(1));
            Assert.Null(cmd.GetArg(2));
        }
    }
}
