using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MiniBank.Api.Errors
{
    public class ErrorsResults : ProblemDetails
    {
        public string Error { get; set; }

        public ErrorsResults(string error, HttpStatusCode http, string type)
        {
            Title = http switch
            {
                HttpStatusCode.BadRequest => "Um ou mais erros ocorreram",
                HttpStatusCode.InternalServerError => "Erro interno no servidor",
                _ => "Um erro aconteceu"
            };
            Type = type;
            Status = (int)http;
            Error = error;
        }
    }
}
