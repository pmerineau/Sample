using System.ComponentModel.DataAnnotations;

namespace Sample.Repo.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public Client()
        {

        }
    }
}
