using APIDaltonismoDB.Model;
using APIDaltonismoDB.Model.DTO;
using cat.itb.M6UF2Pr;
using ColorBlindProyect_Api;
using KillerRobot_Api.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace APIDaltonismoDB.Controllers
{
    [EnableCors(Program.CORSPolicyName)]
    public class PatientAPIController : Controller
    {
        private ResponseDTO _response;
        private CRUD<Patient> _dbSession;
        const string WrongLogin = "Incorrect login, check user and password";

        public PatientAPIController()
        {
            _response = new ResponseDTO();
            _dbSession = new CRUD<Patient>();
        }
        public bool CheckLogin(Patient patient,out Patient searchedPatient)
        {
            searchedPatient = _dbSession.SelectById(patient.DNI);
            string recPlayerPass = Hasher.SHA256Hashing(patient.Password);
            return (searchedPatient.Password == recPlayerPass);
        }
        [HttpPost("CheckLogin")]
        public ResponseDTO RequestLogin([FromBody] Patient patient)
        {
            try
            {
                Patient checkPatient = _dbSession.SelectById(patient.DNI);
                string recPlayerPass = Hasher.SHA256Hashing(patient.Password);
                _response.IsSuccess = recPlayerPass == checkPatient.Password;
                if (!_response.IsSuccess)
                {
                    _response.Message = WrongLogin;
                }
                else
                {
                    checkPatient.Password = null;
                    _response.Data = checkPatient;
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
        public ResponseDTO AddPatient([FromBody] Patient patient) 
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
        public ResponseDTO GetPatientSessions([FromBody] Patient patient)
        {
            try
            {
                
                if (CheckLogin(patient,out _))
                {
                    CRUD<Session> sessionDB = new CRUD<Session>();
                    Session[] patientSessions = sessionDB.SelectAll().Where(ses => ses.player.DNI == patient.DNI).ToArray();
                    _response.Data = patientSessions;
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = WrongLogin;
                }
                
            }catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost("DeletePatient")]
        public ResponseDTO DeletePatient([FromBody] Patient patient)
        {
            try
            {
                
                if (CheckLogin(patient,out Patient searchedPatient))
                {
                    _dbSession.Delete(searchedPatient);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = WrongLogin;
                }
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost("UpdatePatientPassword")]
        public ResponseDTO UpdatePatient([FromBody]ChangePassword updateInfo)
        {
            try
            {
                Patient checkInfo = new Patient() { DNI=updateInfo.DNI,Password = updateInfo.Password};
                if (CheckLogin(checkInfo, out Patient searchedPatient))
                {
                    searchedPatient.Name = updateInfo.Name;
                    searchedPatient.Password = updateInfo.newPassword;
                    searchedPatient.BirthDate = updateInfo.BirthDate;
                    searchedPatient.City = updateInfo.City;
                    searchedPatient.Country = updateInfo.Country;
                    _dbSession.Update(searchedPatient);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = WrongLogin;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
        [HttpPost("UpdatePatient")]
        public ResponseDTO UpdatePatient([FromBody] Patient updateInfo)
        {
            try
            {
                if (CheckLogin(updateInfo, out Patient searchedPatient))
                {
                    searchedPatient.Name = updateInfo.Name;
                    searchedPatient.Password = updateInfo.Password;
                    searchedPatient.BirthDate = updateInfo.BirthDate;
                    searchedPatient.City = updateInfo.City;
                    searchedPatient.Country = updateInfo.Country;
                    _dbSession.Update(searchedPatient);
                }
                else
                {
                    _response.IsSuccess = false;
                    _response.Message = WrongLogin;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
