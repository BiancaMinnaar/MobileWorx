using System;
using System.Threading.Tasks;
using HiRes.Base;
using HiRes.Interface.Service;
using HiRes.Interface.Repository;
using HiRes.Implementation.ViewModel;

namespace HiRes.Implementation.Repository
{
    public class WelcomeOneRepository : ProjectBaseRepository, IWelcomeOneRepository
    {
        IWelcomeOneService _Service;

        public WelcomeOneRepository(IMasterRepository masterRepository, IWelcomeOneService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task WelcomeOne(WelcomeOneViewModel model, Action completeAction)
        {
            await _Service.WelcomeOne(model);
            completeAction();
        }
    }
}