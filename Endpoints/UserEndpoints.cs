using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MiniBank.Api.Models;
using MiniBank.Api.Services;
using MiniBank.Api.ViewModel;
using Swashbuckle.AspNetCore.Annotations;

namespace MiniBank.Api.Endpoints
{
    public static class UserEndpoints
    {
        public static void StartUserEndpoints(this WebApplication app)
        {
            var routeGroup = app.MapGroup("/user");

            routeGroup.MapGet("/Get-All", async (UserServices _services) =>
            {
                var list = await _services.GetUsersAsync();
                return Results.Ok(list);

            });

            routeGroup.MapPost("/Create-Users",async (DataEntryToCreateUser dataEntry,UserServices _services) =>
            {
                var userCreated = await _services.CreateUserAsync(dataEntry);
                if(userCreated.Sucess) 
                {
                    return Results.Ok(userCreated.Data);
                }
                var problem = new ProblemDetails 
                {
                    Title = "Já Existe",
                    Detail = userCreated.ErrorMessage,
                    Status = (int)HttpStatusCode.BadRequest,
                };
                return Results.BadRequest(problem);
            });
            routeGroup.MapGet("/Get-by-{id}",async(Guid id,UserServices _services) =>
            {
                var user = await _services.GetUsersByIdAsync(id);
                if (user.Sucess)
                    return Results.Ok(user.Data);
                var problem = new ProblemDetails 
                {
                    Title = "Não Encontrado",
                    Detail = user.ErrorMessage,
                    Status = (int)HttpStatusCode.NotFound,
                };
                return Results.NotFound(problem);
            });

        }
    }
}
