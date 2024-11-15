using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIDaltonismoDB.Model
{
    public class Patient
    {
        public virtual string DNI { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual DateOnly BirthDate { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
    }
}
