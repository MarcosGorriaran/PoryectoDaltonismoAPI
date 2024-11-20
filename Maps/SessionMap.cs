using APIDaltonismoDB.Model;
using FluentNHibernate.Mapping;

namespace APIDaltonismoDB.Maps
{
    public class SessionMap : ClassMap<Session>
    {
        const string TableName = "Sessiones";
        public SessionMap() 
        {
            Table(TableName);

            Id(ses => ses.SessionID).Column("ID");
            Map(ses => ses.DateGame).Column("DateGame");
            Map(ses => ses.ColorBlindType).Column("ColorBlindType");
            References(ses => ses.player).Column("Player");
        }
    }
}
