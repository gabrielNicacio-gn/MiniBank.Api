
using Microsoft.AspNetCore.Mvc;
using MiniBank.Api.ResultsCustomizer.DTOs;
using System.Net;

namespace MiniBank.Api.ResultsCustomizer
{
    public class ResultForUserSearch
    {
        public OutputDataGetUsers? Data { get; private set; }
        public ProblemDetails? Error { get; private set; }
        public bool Sucess { get; private set; }

        public ResultForUserSearch(OutputDataGetUsers returnData)
        {
            Sucess = true;
            Data = returnData;
            Error = null;
        }
        public ResultForUserSearch(ProblemDetails error)
        {
            Sucess = false;
            Data = null;
            Error = error;
        }
    }
}
