using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MiniBank.Api.Models;
using MiniBank.Api.Repository;
using MiniBank.Api.ResultsCostumizer;
using MiniBank.Api.ResultsCustomizer;
using MiniBank.Api.ResultsCustomizer.DTOs;
using MiniBank.Api.ViewModel;
using System.Net;

namespace MiniBank.Api.Services
{
    public class UserServices
    {
        private readonly UserRepository _userRepository;
        public UserServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Validation(Guid id, decimal balance)
        {
            var user = _userRepository.GetUsersByIdAsync(id);

            if(user.Result.UserType == Enums.UserType.COMMOM) 
            {

            }
        }
        public async Task<IQueryable<User>> GetUsersAsync()
        {
            return await _userRepository.GetAllUserAsync();
        }
        public async Task<ResultForUserSearch> GetUsersByIdAsync(Guid id)
        {
            var user = await _userRepository.GetUsersByIdAsync(id);
            if (user is not null)
            {
                var userView = new OutputDataGetUsers(user.Id, user.FirstName, user.LastName, user.Document, user.Email, user.Balance, user.UserType);
                var userResult = new ResultForUserSearch(userView);
                return userResult;
            }
            return new ResultForUserSearch("Usuario não encontrado");
        }

        public async Task<ResultForCreateUsers> CreateUserAsync(DataEntryToCreateUser dataEntry)
        {
            var newUser = new User(dataEntry.FirstName, dataEntry.LastName, dataEntry.Document, dataEntry.Email, dataEntry.Password, dataEntry.TheUserType);
            var sucess = await _userRepository.CreateUser(newUser);
            if (sucess)
            {
                var result = new OutputDataCreateUsers(newUser.Id, newUser.FirstName, newUser.LastName, newUser.Document, newUser.Email, newUser.Balance, newUser.UserType);
                return new ResultForCreateUsers(result);
            }
            return new ResultForCreateUsers("Já existe um usuário com esse email ou documento");
        }
    }
}
