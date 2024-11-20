using APIDaltonismoDB.Model;
using APIDaltonismoDB.Model.DTO;
using cat.itb.M6UF2EA3.connections;
using cat.itb.M6UF2Pr;
using ColorBlindProyect_Api;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Media;

namespace APIDaltonismoDB.Controllers
{
    [EnableCors(Program.CORSPolicyName)]
    public class PatientAPIController : Controller
    {
        private ResponseDTO _response;
        private CRUD<Patient> _dbSession;

        public PatientAPIController()
        {
            _response = new ResponseDTO();
            _dbSession = new CRUD<Patient>();
        }
        [HttpGet("GetPatients")]
        public ResponseDTO GetPatients()
        {
            try
            {
                _response.Data = _dbSession.SelectAll();
            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost("CheckLogin")]
        public ResponseDTO CheckLogin([FromBody] Patient patient)
        {
            try
            {
                Patient checkPatient = _dbSession.SelectById(patient.DNI);

            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

    }
}
