using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MamitoWebAPI.Models
{
    public class Response
    {
        bool Sucess { get; set; }
        string Message { get; set; }

        public Response() { }
        public Response(bool _sucess, string _message) {
            Sucess = _sucess;
            Message = _message;
        }

        public Response BadRequest(string? _message) {
            Response response = new Response( false, _message==null ? "Bad Request": _message );
            return response;
        }

        public Response NotFound(string? _message)
        {
            Response response = new Response(false, _message == null ? "Not Found" : _message);
            return response;
        }

        public Response OK(string? _message)
        {
            Response response = new Response(true, _message == null ? "Sucess" : _message);
            return response;
        }

        public Response error(string? _message) {
            Response response = new Response(false, _message == null ? "Internal error" : _message);
            return response;
        }
    }
}
