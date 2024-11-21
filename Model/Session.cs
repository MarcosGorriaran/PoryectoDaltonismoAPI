using System.Text.Json.Serialization;

namespace APIDaltonismoDB.Model
{
    public class Session
    {
        public virtual string SessionID { get; set; }
        public virtual string ColorBlindType { get; set; }
        [JsonIgnore]
        public virtual DateTime DateGame { get; set; }
        public virtual Patient player { get; set; }
    }
}
