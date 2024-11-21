using APIDaltonismoDB.Model;
using APIDaltonismoDB.Model.DTO;
using cat.itb.M6UF2EA3.connections;
using cat.itb.M6UF2Pr;
using ColorBlindProyect_Api;
using KillerRobot_Api.Utils;
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
        [HttpPost("CheckLogin")]
        public ResponseDTO CheckLogin([FromBody] Patient patient)
        {
            try
            {
                Patient checkPatient = _dbSession.SelectById(patient.DNI);
                string recPlayerPass = Hasher.SHA256Hashing(patient.Password);
                _response.IsSuccess = recPlayerPass == checkPatient.Password;
                if (!_response.IsSuccess)
                {
                    _response.Message = "Incorrect login, check user and password";
                }
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPost("AddPatient")]
        public ResponseDTO AddPatient(Patient patient) 
        {
            try
            {
                _dbSession.Insert(patient);
                
            }catch(Exception ex) 
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost("GetPatientSessions")]
        public ResponseDTO GetPatientSessions(Patient patient)
        {
            try
            {
                CRUD<Session> sessionDB = new CRUD<Session>();
                sessionDB.SelectAll().Where(ses=>ses.player.DNI==patient.DNI);
            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
