using System;
using System.Threading.Tasks;
using HiRes.Base;
using HiRes.Interface.Service;
using HiRes.Interface.Repository;
using HiRes.Implementation.ViewModel;

namespace HiRes.Implementation.Repository
{
    public class WelcomeRepository : ProjectBaseRepository, IWelcomeRepository
    {
        IWelcomeService _Service;

        public WelcomeRepository(IMasterRepository masterRepository, IWelcomeService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task Welcome(WelcomeViewModel model, Action completeAction)
        {
            await _Service.Welcome(model);
            completeAction();
        }
    }
}