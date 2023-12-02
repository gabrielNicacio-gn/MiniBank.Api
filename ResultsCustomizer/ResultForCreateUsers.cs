using MiniBank.Api.ResultsCustomizer.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MiniBank.Api.ResultsCostumizer
{
    public class ResultForCreateUsers
    {
        public bool Sucess { get; private set; }
        public OutputDataCreateUsers? Data { get; private set; }
        public string? ErrorMessage { get; private set; }

        public ResultForCreateUsers(OutputDataCreateUsers data)
        {
            Sucess = true;
            Data = data;
            ErrorMessage = null;
        }
        public ResultForCreateUsers(string errorMessage)
        {
            Sucess = false;
            Data = null;
            ErrorMessage = errorMessage;
        }
    }
}
