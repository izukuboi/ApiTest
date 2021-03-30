using System.Collections.Generic;
//using Apitest.DaTa;
using ApiTest.Models;

namespace ApiTest.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id = 0, HowTo = "boil a", Line = "Boil water", Platform = "Kettle & Pan"},
                new Command{Id = 1, HowTo = "cut bread", Line = "get a knife", Platform = "knife and chopping board"},
                new Command{Id = 2, HowTo = "Make tea", Line = "Place teabag", Platform = "Kettle & Cup"}

            };
            return commands;
            
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id = 0, HowTo = "boil a", Line = "Boil water", Platform = "Kettle & Pan"};
        }
    }
}