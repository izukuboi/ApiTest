using ApiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.DaTa
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) :   base(opt)
        {
            
        }

        public DbSet<Command> Commands { get; set; }   
    }
    
}