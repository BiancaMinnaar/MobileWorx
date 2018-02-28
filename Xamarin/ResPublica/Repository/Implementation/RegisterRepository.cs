using System;
using System.Threading.Tasks;
using ResPublica.Base;
using ResPublica.Implementation.ViewModel;
using ResPublica.Interface.Repository;
using ResPublica.Interface.Service;

namespace ResPublica.Implementation.Repository
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