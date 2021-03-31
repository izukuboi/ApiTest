using System.Collections.Generic;
using ApiTest.Data;
using ApiTest.Models;
using Microsoft.AspNetCore.Mvc;
using ApiTest.Dtos;
using ApiTest.Profiles;
using AutoMapper;
using System;
using Microsoft.AspNetCore.JsonPatch;

namespace ApiTest.Controllers
{
    // api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandController : ControllerBase 
    {
        private readonly ICommanderRepo _repo;
        private readonly IMapper _mapper;
        //private readonly CommandReadDto _commandDto;
        //private readonly CommandsProfile _commandProfile;
        public CommandController(ICommanderRepo repo, IMapper mapper )
        {
            _repo = repo;  
            _mapper = mapper;
            //_commandDto = dto;
            //_commandProfile = profile;
        }
        

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repo.GetAllCommands();
        
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        //GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _repo.GetCommandById(id);
        
            if (command != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(command));
            }
            return NotFound();
        }
        // POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            //Console.WriteLine(command);
            var command = _mapper.Map<Command>(commandCreateDto);
            
            _repo.CreateCommand(command);

            

            if (_repo.saveChanges()){
                var commandReadDto = _mapper.Map<CommandReadDto>(command);  
                return CreatedAtAction(nameof(GetCommandById), new { id = commandReadDto.Id}, commandReadDto);
                //return Ok(_mapper.Map<CommandReadDto>(realCommand));
            }
            return BadRequest();
            //return Ok(command);
        }
        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult<CommandReadDto> EditCommand(int id, CommandUpdateDto commandUpdateDto)
        {   
            if(commandUpdateDto.Id != id)
            return NotFound();

            var command = _mapper.Map<Command>(commandUpdateDto);

            _repo.UpdateCommand(command);
            
            if (_repo.saveChanges())
            {
                //var commandReadDto = _mapper.Map<CommandReadDto>(command);
                return  NoContent();
            }
            return BadRequest();

        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult<CommandReadDto> PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var command = _repo.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<CommandUpdateDto>(command);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            _mapper.Map(commandToPatch, command);

            if(_repo.saveChanges())  
            {
                return NoContent();
            } 
            return BadRequest();

        }
    }
}