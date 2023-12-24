using MiniBank.Api.DTOs;
using MiniBank.Api.DTOs.TransactionsDTOs;
using MiniBank.Api.Errors;
using MiniBank.Api.Services;
using System.Net;

namespace MiniBank.Api.Endpoints
{
    public static class TransactionsEndpoints
    {
        public static void StartTransactionsEndpoints(this WebApplication app)
        {
            var routeGroup = app.MapGroup("/user").WithTags("Transações");

            routeGroup.MapGet("/trasações-por-usuário", async (Guid id,  TransactionServices _services) => 
            {
                var transactions = await _services.GetTransactionsByUser(id);
                return Results.Ok(transactions);
            });
            
            routeGroup.MapPost("/transação-criar",async (CreateTransactionInputModel data,TransactionServices _services)=> 
            {
                try 
                { 
                   var transaction =  await _services.CreateTransaction(data);
                   return Results.Ok(transaction);
                }
                catch (InvalidOperationException ex)
                {
                    var error = new ErrorsResults(ex.Message, HttpStatusCode.BadRequest, "Bad Request");
                    return Results.BadRequest(error);
                }
                catch (ArgumentNullException ex)
                {
                    var error = new ErrorsResults(ex.Message, HttpStatusCode.BadRequest, "Bad Request");
                    return Results.BadRequest(error);
                }
            });

        }
    }
}
