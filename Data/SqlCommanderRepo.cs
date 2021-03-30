using System.Collections.Generic;
using ApiTest.Models;
using ApiTest.DaTa;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiTest.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public   IEnumerable<Command> GetAllCommands()
        {
            var commands =  _context.Commands.ToList();
            return commands;
        }

        public Command GetCommandById(int id)
        {
            var command = _context.Commands.FirstOrDefault(c => c.Id == id);
            return command;
        }
    }
}