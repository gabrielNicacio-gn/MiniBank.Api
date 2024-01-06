using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MiniBank.Api.DTOs.UsersDTOs;
using MiniBank.Api.Errors;
using MiniBank.Api.Models;

using MiniBank.Api.Services;
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
            
            routeGroup.MapPost("/Create-Users",async (CreateUserInputModel dataEntry,UserServices _services) =>
            {
                try
                {
                    var userCreated = await _services.CreateUserAsync(dataEntry);
                    return Results.Ok(userCreated);
                }
                catch (InvalidOperationException ex)
                {
                    var erro = new ErrorsResults(ex.Message,HttpStatusCode.Conflict,"Conflit");
                    return Results.Conflict(erro);
                }
            });

            routeGroup.MapGet("/Get-by-{id}",async(Guid id,UserServices _services) =>
            {
                try
                {
                    var user = await _services.GetUsersByIdAsync(id);
                    var userView = new GetUsersViewModel(user.Id,user.FirstName,user.LastName,user.Document,user.Email,user.Balance,user.UserType);
                    return Results.Ok(userView);
                }
                catch(ArgumentNullException ex)
                {
                    var error = new ErrorsResults(ex.Message,HttpStatusCode.BadRequest,"Bad Request");
                    return Results.BadRequest(error);
                }
            });
            
            routeGroup.MapGet("/Get-by-document", async (string document,UserServices _services) =>
            {
                try
                {
                    var user = await _services.GetUserByDocumentAsync(document);
                    var userView = new GetUsersViewModel(user.Id, user.FirstName, user.LastName, user.Document, user.Email, user.Balance, user.UserType);
                    return Results.Ok(userView);
                }
                catch (ArgumentNullException ex)
                {
                    var error = new ErrorsResults(ex.Message, HttpStatusCode.BadRequest, "Bad Request");
                    return Results.BadRequest(error);
                }
            });
            
            routeGroup.MapPut("/Update-user",async(Guid id,UpdateUserInputModel dataEntry,UserServices _services) =>
            {
                try
                {
                    await _services.UpdateUserAsync(id, dataEntry);
                    return Results.NoContent();
                }
                catch (InvalidOperationException ex)
                {
                    var error = new ErrorsResults(ex.Message,HttpStatusCode.BadRequest,"Bad Request");
                    return Results.BadRequest(error);
                }
            });
            routeGroup.MapDelete("",async (Guid id, UserServices _services) =>
            {
                try
                {
                    await _services.DeleteUserAsync(id);
                    return Results.NoContent();

                }
                catch(InvalidOperationException ex)
                {
                    var error = new ErrorsResults(ex.Message, HttpStatusCode.BadRequest, "Bad Request");
                    return Results.BadRequest(error);
                }
            });
            
        }
    }
}
