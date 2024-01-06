using MiniBank.Api.Repository;
using MiniBank.Api.DTOs;
using MiniBank.Api.DTOs.DepositeDTOs;
using MiniBank.Api.Models;

namespace MiniBank.Api.Services
{
    public class DepositeServices
    {
        public readonly DepositeRepository _depositeRepository;
        public readonly UserServices _userServices;
        public DepositeServices(UserServices userServices,DepositeRepository depositeRepository)
        {
            _userServices = userServices;
            _depositeRepository = depositeRepository;
        }

        public async Task<CreateDepositeViewModel> CreateDeposite(Guid id,CreateDepositeInputModel create)
        {
            User? user = await _userServices.GetUsersByIdAsync(id);
            if(user is not null)
            {
                var newDeposite = new Deposite(user, create.Value);
                await _depositeRepository.CreateDeposite(newDeposite);
                await _userServices.IncreaseBalance(user,create.Value);
                return new CreateDepositeViewModel(newDeposite.Id,user.Id,user.FirstName + " " + user.LastName,newDeposite.Value,newDeposite.DepositeDateAndTime.ToString("T"),newDeposite.DepositeDateAndTime.ToString("d"));
            }
            throw new ArgumentNullException("Não foi possível realizar o depósito, esse usuário não existe");
        }
        public async Task<IQueryable<GetDepositeViewModel>> GetDeposite(Guid id)
        {
            var listDeposite = await _depositeRepository.GetDepositesAsync(id);
            var listViewDeposite = new List<GetDepositeViewModel>();
            foreach (var deposite in listDeposite)
            {
                User? user = await _userServices.GetUsersByIdAsync(deposite.UserId);
                if (user is not null)
                {
                    var listView = new GetDepositeViewModel
                    (
                        deposite.Id,
                        user.Id,
                        user.FirstName + " " + user.LastName,
                        deposite.Value,
                        deposite.DepositeDateAndTime.ToString("T"),
                        deposite.DepositeDateAndTime.ToString("d")
                    );
                    listViewDeposite.Add(listView);
                }
            }
            return listViewDeposite.AsQueryable();
        }
    }
}
