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
            var routeGroup = app.MapGroup("/user").WithTags("Usuários");

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
                return Results.BadRequest(userCreated.Error);
            });
            routeGroup.MapGet("/Get-by-{id}",async(Guid id,UserServices _services) =>
            {
                var user = await _services.GetUsersByIdAsync(id);
                if (user.Sucess)
                    return Results.Ok(user.Data);
                return Results.NotFound(user.Error);
            });
            routeGroup.MapGet("/Get-by-document", async (string document,UserServices _services) =>
            {
                var user = await _services.GetUserByDocumentAsync(document);
                if(user.Sucess)
                    return Results.Ok(user.Data);
                return Results.NotFound(user.Error);
            });
            routeGroup.MapPut("/Update-user",async(Guid id,DataEntryToUpdateUser dataEntry,UserServices _services) =>
            {
                var user = await _services.UpdateUserAsync(id,dataEntry);
                if (user.Sucess)
                    return Results.NoContent();
                return Results.BadRequest(user.Error);
            });
            routeGroup.MapDelete("",async (Guid id, UserServices _services) =>
            {
                var userDelete = await _services.DeleteUserAsync(id);
                if (userDelete.Sucess)
                    return Results.NoContent();
                return Results.NotFound(userDelete.Error);
            });

        }
    }
}
