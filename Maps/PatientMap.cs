using APIDaltonismoDB.Model;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace APIDaltonismoDB.Maps
{
    public class PatientMap : ClassMap<Patient>
    {
        const string TableName = "Pacientes";
        public PatientMap() 
        {
            Table(TableName);

            Id(pat => pat.DNI).Column("DNI");
            Map(pat => pat.Name).Column("Name");
            Map(pat => pat.Password).Column("Password");
            Map(pat => pat.BirthDate).Column("BirthDate");
            Map(pat => pat.City).Column("City");
            Map(pat => pat.Country).Column("Country");
        }
    }
}
