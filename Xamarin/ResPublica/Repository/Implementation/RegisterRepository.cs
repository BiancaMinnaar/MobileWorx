using System;
using System.Threading.Tasks;
using HiRes.Base;
using HiRes.Implementation.ViewModel;
using HiRes.Interface.Repository;
using HiRes.Interface.Service;

namespace HiRes.Implementation.Repository
{
    public class RegisterRepository : ProjectBaseRepository, IRegisterRepository
    {
        IRegisterService _Service;

        public RegisterRepository(IMasterRepository masterRepository, IRegisterService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Register(RegisterViewModel model, Action completeAction)
        {
            await _Service.Register(model);
            completeAction();
        }
    }
}