using System.ComponentModel.DataAnnotations;

namespace homework_api.Models
{
    public class Values
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}