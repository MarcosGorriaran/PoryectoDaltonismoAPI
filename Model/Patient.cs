using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIDaltonismoDB.Model
{
    public class Patient
    {
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateOnly BirthDate { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
