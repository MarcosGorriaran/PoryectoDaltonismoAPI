namespace APIDaltonismoDB.Model
{
    public class Session
    {
        public virtual string SessionID { get; set; }
        public virtual string ColorBlindType { get; set; }
        public virtual DateTime DateGame { get; set; }
        public virtual Patient player { get; set; }
    }
}
