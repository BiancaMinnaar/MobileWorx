using System;
using System.Threading.Tasks;
using HiRes.Base;
using HiRes.Interface.Service;
using HiRes.Interface.Repository;
using HiRes.Implementation.ViewModel;

namespace HiRes.Implementation.Repository
{
    public class WelcomeTwoRepository : ProjectBaseRepository, IWelcomeTwoRepository
    {
        IWelcomeTwoService _Service;

        public WelcomeTwoRepository(IMasterRepository masterRepository, IWelcomeTwoService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task WelcomeTwo(WelcomeTwoViewModel model, Action completeAction)
        {
            await _Service.WelcomeTwo(model);
            completeAction();
        }
    }
}