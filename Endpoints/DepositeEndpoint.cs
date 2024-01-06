
using MiniBank.Api.DTOs.DepositeDTOs;
using MiniBank.Api.Errors;
using MiniBank.Api.Services;
using System.Net;

namespace MiniBank.Api.Endpoints
{
    public static class DepositeEndpoint 
    {
        public static void StartDepositeEndpoints(this WebApplication app)
        {
            var route = app.MapGroup("/depositos").WithTags("Depósitos");

            route.MapPost("/criar-deposito", async (Guid id, CreateDepositeInputModel input,DepositeServices _services) => 
            {
                try
                {
                    var deposite = await _services.CreateDeposite(id,input);
                    return Results.Ok(deposite);
                }
                catch (ArgumentNullException ex)
                {
                    var errors = new ErrorsResults(ex.Message, HttpStatusCode.BadRequest,"Bad Request");
                    return Results.BadRequest(errors);
                }
            });
            route.MapGet("/{id}/listar-depositos-por-usuario", async (Guid id, DepositeServices _services) =>
            {
                var listDeposites = await _services.GetDeposite(id);
                return Results.Ok(listDeposites);
            });
        }
    }
}
