using APIDaltonismoDB.Model.DTO;
using APIDaltonismoDB.Model;
using cat.itb.M6UF2Pr;
using Microsoft.AspNetCore.Mvc;

namespace APIDaltonismoDB.Controllers
{
    public class SessionAPIController
    {
        private ResponseDTO _response;
        private CRUD<Session> _dbSession;
        const string WrongLogin = "Incorrect login, check user and password";

        public SessionAPIController()
        {
            _response = new ResponseDTO();
            _dbSession = new CRUD<Session>();
        }

        [HttpGet("GetScores")]
        public ResponseDTO GetScores()
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
    }
}
