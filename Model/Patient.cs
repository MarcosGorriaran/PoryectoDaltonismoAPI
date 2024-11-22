using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIDaltonismoDB.Model
{
    public class Patient
    {
        public virtual string DNI { get; set; }
        public virtual string Name { get; set; } = string.Empty;
        public virtual string Password { get; set; } = string.Empty;
        public virtual DateTime BirthDate { get; set; } = new DateTime();
        public virtual string City { get; set; } = string.Empty;
        public virtual string Country { get; set; } = string.Empty;
    }
}
