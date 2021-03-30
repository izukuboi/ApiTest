using System.Collections.Generic;
using ApiTest.Data;
using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    // api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandController : ControllerBase 
    {
        private readonly ICommanderRepo _repo;
        public CommandController(ICommanderRepo repo)
        {
            _repo = repo;  
        }
        

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repo.GetAllCommands();

            return Ok(commandItems);
        }
        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = _repo.GetCommandById(id);
            
            return Ok(command);
        }
    }
}