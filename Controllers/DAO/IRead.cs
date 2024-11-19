namespace APIDaltonismoDB.Controllers.DAO
{
    public interface IRead<Model>
    {
        public void Get<IDValueType>(IDValueType id);
        public void Get();
    }
}
