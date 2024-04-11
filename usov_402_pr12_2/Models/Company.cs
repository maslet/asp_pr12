using System.ComponentModel.DataAnnotations;

namespace usov_402_pr12_2.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
