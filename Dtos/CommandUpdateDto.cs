using System.ComponentModel.DataAnnotations;

namespace ApiTest.Dtos
{
    public class CommandUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }      

    }
}