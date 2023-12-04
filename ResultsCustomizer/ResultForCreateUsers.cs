using Microsoft.AspNetCore.Mvc;
using MiniBank.Api.ResultsCustomizer.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MiniBank.Api.ResultsCostumizer
{
    public class ResultForCreateUsers
    {
        public bool Sucess { get; private set; }
        public OutputDataCreateUsers? Data { get; private set; }
        public ProblemDetails? Error { get; private set; }

        public ResultForCreateUsers(OutputDataCreateUsers data)
        {
            Sucess = true;
            Data = data;
            Error = null;
        }
        public ResultForCreateUsers(ProblemDetails error)
        {
            Sucess = false;
            Data = null;
            Error = error;
        }
    }
}
