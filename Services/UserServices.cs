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

        public void ValidationTransaction(User user,decimal value)
        {
            if (user.UserType == Enums.UserType.MERCHAN)
                throw new InvalidOperationException("Esse tipo de usuário não tem autorização para realizar uma transação");
            if (user.Balance < value) 
                throw new InvalidOperationException();
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
            var error = new ProblemDetails
            {
                Title = "Não Existe",
                Type = "Registro Inexistente",
                Detail = "Esse usuário não foi encontrado",
                Status = (int)HttpStatusCode.NotFound
            };
            return new ResultForUserSearch(error);
        }
        public async Task<ResultForUserSearch> GetUserByDocumentAsync(string Document) 
        {
            var user = await _userRepository.GetUserByDocument(Document);
            if(user is not null)
            {
                var userView = new OutputDataGetUsers(user.Id,user.FirstName,user.LastName,user.Document,user.Email,user.Balance,user.UserType);
                var result = new ResultForUserSearch(userView);
                return result;
            }
            var error = new ProblemDetails 
            {
                Title = "Não Existe",
                Type = "Registro Inexistente",
                Detail = "Esse usuário não foi encontrado",
                Status = (int)HttpStatusCode.NotFound
            };
            return new ResultForUserSearch(error);
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
            var error = new ProblemDetails
            {
                Title = "Já Existe",
                Type = "Registro já existente",
                Detail = "Já existe um usuário com esse email ou documento",
                Status = (int)HttpStatusCode.BadRequest
            };
            return new ResultForCreateUsers(error);
        }
        public async Task<ResultForUpdateUsers> UpdateUserAsync(Guid id,DataEntryToUpdateUser dataEntry) 
        {
           var sucess = await _userRepository.UpdateUser(id,dataEntry);
            if (sucess)
            {
                return new ResultForUpdateUsers();
            }
            var error = new ProblemDetails
            {
                Title = "Impossibilidade de atualização",
                Type = "Falha",
                Detail = "Não foi possível atualizar os dados",
                Status = (int)HttpStatusCode.BadRequest
            };
            return new ResultForUpdateUsers(error);
        }
        public async Task<ResultForDeleteUsers> DeleteUserAsync(Guid id)
        {
           var deleteUser = await _userRepository.DeleteUser(id);
           if (deleteUser)
           {
                return new ResultForDeleteUsers();
           }
            var error = new ProblemDetails
            {
                Title = "Não Encontrado",
                Type = "Falha",
                Status = (int)HttpStatusCode.NotFound,
                Detail = "Este usuário não foi encontrado, logo não pode ser deletado"
            };
           return new ResultForDeleteUsers(error);
        }
    }
}
