 
using MiniBank.Api.ResultsCustomizer.DTOs;
using System.Net;

namespace MiniBank.Api.ResultsCustomizer
{
    public class ResultForUserSearch
    {
        public OutputDataGetUsers? Data { get; private set; }
        public string? ErrorMessage { get; private set; }
        public bool Sucess { get; private set; }

        public ResultForUserSearch(OutputDataGetUsers returnData)
        {
            Sucess = true;
            Data = returnData;
            ErrorMessage = null;
        }
        public ResultForUserSearch(string errorMessage)
        {
            Sucess = false;
            Data = null;
            ErrorMessage = errorMessage;
        }
    }
}
