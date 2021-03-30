using System.Collections.Generic;
using ApiTest.Models;

namespace ApiTest.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);

        
    }
}
