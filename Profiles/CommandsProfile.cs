using AutoMapper;
using ApiTest.Models;
using ApiTest.Dtos;

namespace ApiTest.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
        }   
    }
}