
using MiniBank.Api.DTOs.UsersDTOs;
using MiniBank.Api.Models;
using MiniBank.Api.Repository;

namespace MiniBank.Api.Services
{
    public class UserServices
    {
        private readonly UserRepository _userRepository;
        public UserServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void ValidationTransaction(User userSender,decimal value)
        {
            if (userSender.UserType == Enums.UserType.MERCHAN)
                throw new InvalidOperationException("Esse usuário não tem permissão para realizar uma transação");
            if (userSender.Balance < value)
                throw new InvalidOperationException("Valor excede ao valor de saldo do usuário");
        }
        public async Task IncreaseBalance(User user, decimal value)
        {
            var balanceUser = user.Balance += value;
            await _userRepository.UpdateBalance(user.Id, balanceUser);
        }
        public async Task DecreaseBalance(User user, decimal value)
        {
            var balanceUser = user.Balance -= value;
            await _userRepository.UpdateBalance(user.Id, balanceUser);
        }

        public async Task<IQueryable<User>> GetUsersAsync()
        {
            return await _userRepository.GetAllUserAsync();
        }
        public async Task<User?> GetUsersByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUsersByIdAsync(id);
            if (user is not null)
            {
                return user;
            }
            throw new ArgumentNullException("Esse Id não corresponde a nenhum usuário existente");
        }
       
        public async Task<User?> GetUserByDocumentAsync(string Document) 
        {
            var user = await _userRepository.GetUserByDocument(Document);
            if(user is not null)
            {
                return user;
            }
            throw new ArgumentNullException("Esse Documento não corresponde a nenhum usuário existente");
        }
       
        public async Task<CreateUsersViewModel> CreateUserAsync(CreateUserInputModel dataEntry)
        {
            var newUser = new User(dataEntry.FirstName, dataEntry.LastName, dataEntry.Document, dataEntry.Email, dataEntry.Password, dataEntry.TheUserType);
            var sucess = await _userRepository.CreateUser(newUser);
            if (sucess)
            {
                var result = new CreateUsersViewModel(newUser.Id, newUser.FirstName, newUser.LastName, newUser.Document, newUser.Email, newUser.Balance, newUser.UserType);
                return result;
            }
            throw new InvalidOperationException("Já existe um usuário com esse email ou documento");
        }
        public async Task UpdateUserAsync(Guid id,UpdateUserInputModel dataEntry) 
        {
           var sucess = await _userRepository.UpdateUser(id,dataEntry);
            if (!sucess)
            {
                throw new InvalidOperationException("Não foi possível atualizar os dados desse usuário");
            }
        }
        public async Task DeleteUserAsync(Guid id)
        {
           var deleteUser = await _userRepository.DeleteUser(id);
           if (!deleteUser)
           {
                throw new InvalidOperationException("Não foi possível deletar esse usuário");
           }
        }
    }
}
