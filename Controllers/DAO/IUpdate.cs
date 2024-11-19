namespace APIDaltonismoDB.Controllers.DAO
{
    public interface IUpdate<Model>
    {
        public void Update(Model info);
        public void Update(IEnumerator<Model> infoList);
    }
}
