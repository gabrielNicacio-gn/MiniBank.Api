using Microsoft.AspNetCore.Mvc;

namespace MiniBank.Api.ResultsCustomizer
{
    public class ResultForDeleteUsers
    {
        public bool Sucess { get; set; }
        public ProblemDetails? Error { get; set; }

        public ResultForDeleteUsers(ProblemDetails error)
        {
            Sucess = false;
            Error = error;
        }
        public ResultForDeleteUsers()
        {
           Sucess = true;
           Error = null;
        }
    }
}
