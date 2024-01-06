using MiniBank.Api.DTOs;
using MiniBank.Api.Models;
using MiniBank.Api.Repository;
using MiniBank.Api.DTOs.TransactionsDTOs;
using Transaction = MiniBank.Api.Models.Transaction;

namespace MiniBank.Api.Services
{
    public class TransactionServices
    {
        private readonly TransactionRepository _transactionRepository;
        private readonly UserServices _userServices;
        public TransactionServices(TransactionRepository transactionRepository,UserServices userServices) 
        {
            _transactionRepository = transactionRepository;
            _userServices = userServices;
        }
      
        public async Task<CreateTransactionViewModel> CreateTransaction(CreateTransactionInputModel createTransaction)
        {
            User? userSender = await _userServices.GetUsersByIdAsync(createTransaction.IdSender);
            User? userReceiver = await _userServices.GetUsersByIdAsync(createTransaction.IdReceiver);
            if (userSender is not null && userReceiver is not null)
            {
                _userServices.ValidationTransaction(userSender, createTransaction.Value);

                var transaction = new Transaction(userSender, userReceiver, createTransaction.Value);
                await _transactionRepository.CreateTransaction(transaction);
                await _userServices.IncreaseBalance(userReceiver, createTransaction.Value);
                await _userServices.DecreaseBalance(userSender, createTransaction.Value);

                var output = new CreateTransactionViewModel(transaction.Id, transaction.SenderId, userSender.FirstName + " " + userSender.LastName, transaction.ReceiverId, userReceiver.FirstName + " " + userReceiver.LastName, transaction.Value, transaction.TransactionDateAndTime.ToString("T"),transaction.TransactionDateAndTime.ToString("d"));
                return output;
            }
            throw new ArgumentNullException("Esse(s) usuário(s) não existem");
        }
        public async Task<IQueryable<GetTransactionViewModel>> GetTransactionsByUser(Guid id)
        {
            var transactions = await _transactionRepository.SearchTransactionsReceivedByAUser(id);
            var transactionView = new List<GetTransactionViewModel>();
            foreach (var transaction in transactions)
            {
                User? userSender = await _userServices.GetUsersByIdAsync(transaction.SenderId);
                User? userReceiver = await _userServices.GetUsersByIdAsync(transaction.ReceiverId);
                if (userSender is not null && userReceiver is not null)
                {

                   var transactionViewModel = new GetTransactionViewModel
                    (
                        transaction.Id,
                        transaction.SenderId,
                        userSender.FirstName + " " + userSender.LastName,
                        transaction.ReceiverId,
                        userReceiver.FirstName + " " + userReceiver.LastName,
                        transaction.Value,
                        transaction.TransactionDateAndTime.ToString("T"),
                        transaction.TransactionDateAndTime.ToString("d")
                     );
                    transactionView.Add( transactionViewModel);
                }
                
            }
            return transactionView.AsQueryable();
        }
    }
}
