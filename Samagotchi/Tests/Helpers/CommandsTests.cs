using System.Collections.Generic;
using NUnit.Framework;
using Samagotchi.App.Commands;
using Samagotchi.App.Helpers;

namespace Samagotchi.Tests.Helpers
{
    [TestFixture]
    public class WhenACommandIsEntered : ICommand
    {
        private Commands _commands;

        [OneTimeSetUp]
        public void SetUp()
        {
            _commands = new Commands();
            _commands.Add("feed", this);
            _commands.Add("water", this);
            _commands.Add("clean", this);
            _commands.Add("play", this);
        }

        [TestCase("feed")]
        [TestCase("water")]
        [TestCase("clean")]
        [TestCase("play")]
        public void ThenItChecksThatItIsValid(string command)
        {
            Assert.That(_commands.IsValid(command), Is.True);
        }

        [TestCase("something random")]
        [TestCase("")]
        public void ThenItChecksThatItIsNotValid(string command)
        {
            Assert.That(_commands.IsValid(command), Is.False);
        }

        public void Do(IList<string> args)
        {
            throw new System.NotImplementedException();
        }
    }

    [TestFixture]
    public class WhenACommandIdParsed : ICommand
    {
        private CommandParser _commandParser;
        private Commands _commands;

        [SetUp]
        public void SetUp()
        {
            _commands = new Commands();
            _commandParser = new CommandParser(_commands);
            _commands.Add("feed", this);
            _commands.Add("water", this);
            _commands.Add("clean", this);
            _commands.Add("play", this);
        }

        [TestCase("Feed")]
        [TestCase("feed")]
        [TestCase("Water")]
        [TestCase("water")]
        [TestCase("Clean")]
        [TestCase("clean")]
        [TestCase("Play")]
        [TestCase("play")]
        [TestCase("play games")]
        public void ThenItChecksThatItIsValid(string input)
        {
            var command = _commandParser.From(input);
            Assert.That(_commands.IsValid(command.Action), Is.True);
        }

        [TestCase("something random")]
        [TestCase("")]
        public void ThenItChecksThatItIsNotValid(string input)
        {
            var command = _commandParser.From(input);
            Assert.That(_commands.IsValid(command.Action), Is.False);
        }

        [TestCase("", false)]
        [TestCase("action", true)]
        [TestCase("action args", true)]
        public void ThenItHasAction(string input, bool hasAction)
        {
            var subject = new CommandParser(new Commands());
            subject.From(input);
            Assert.That(subject.HasAction(), Is.EqualTo(hasAction));
        }

        [TestCase("play games", 1)]
        [TestCase("play games test", 2)]
        [TestCase("play", 0)]
        public void ThenItHasArgs(string input, int argsCount)
        {
            var command = _commandParser.From(input);
            Assert.That(command.Args.Count, Is.EqualTo(argsCount));
        }

        public void Do(IList<string> args)
        {
            throw new System.NotImplementedException();
        }
    }
}
