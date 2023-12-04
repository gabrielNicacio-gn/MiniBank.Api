using Microsoft.AspNetCore.Mvc;

namespace MiniBank.Api.ResultsCustomizer
{
    public class ResultForUpdateUsers
    {
        public bool Sucess { get; set; }
        public ProblemDetails? Error { get; set; }

        public ResultForUpdateUsers()
        {
            Sucess = true;
            Error = null;
        }
        public ResultForUpdateUsers(ProblemDetails error)
        {
            Sucess = false;
            Error = error;
        }
    }
}
