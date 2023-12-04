namespace MiniBank.Api.Endpoints
{
    public static class TransactionsEndpoints
    {
        public static void StartTransactionsEndpoints(this WebApplication app)
        {
            var routeGroup = app.MapGroup("/user").WithTags("Transações");
            routeGroup.MapGet("",()=> "Hello");
        }
    }
}
