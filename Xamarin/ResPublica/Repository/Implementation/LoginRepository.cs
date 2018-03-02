using System;
using System.Threading.Tasks;
using HiRes.Interface.Service;
using HiRes.Interface.Repository;
using HiRes.Implementation.ViewModel;
using HiRes.Base;
using System.Windows.Input;

namespace HiRes.Implementation.Repository
{
    public class LoginRepository : ProjectBaseRepository, ILoginRepository
    {
        ILoginService _Service;

        public LoginRepository(IMasterRepository masterRepository, ILoginService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Login(LoginViewModel model, Action completeAction)
        {
            await _Service.Login(model);
            completeAction();
        }


		public void RegisterView()
        {
            _MasterRepo.PushRegister();
        }

    }
}