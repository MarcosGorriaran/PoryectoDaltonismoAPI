using APIDaltonismoDB.Model;
using APIDaltonismoDB.Model.DTO;
using cat.itb.M6UF2EA3.connections;
using ColorBlindProyect_Api;
using Microsoft.AspNetCore.Cors;

namespace APIDaltonismoDB.Controllers
{
    [EnableCors(Program.CORSPolicyName)]
    public class PatientController : IDisposable
    {
        private ResponseDTO _response;
        private NHibernate.ISession _dbSession;

        public PatientController()
        {
            _response = new ResponseDTO();
            _dbSession = SessionFactoryCloudzt.Open<Patient>();
        }
        
        public void Dispose()
        {
            _dbSession.Close();
        }
    }
}
