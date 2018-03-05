using System;
using System.Threading.Tasks;
using HiRes.Base;
using HiRes.Interface.Service;
using HiRes.Interface.Repository;
using HiRes.Implementation.ViewModel;

namespace HiRes.Implementation.Repository
{
    public class WelcomeThreeRepository : ProjectBaseRepository, IWelcomeThreeRepository
    {
        IWelcomeThreeService _Service;

        public WelcomeThreeRepository(IMasterRepository masterRepository, IWelcomeThreeService service)
            : base(masterRepository)
        {
            _Service = service;
        }

        public async Task WelcomeThree(WelcomeThreeViewModel model, Action completeAction)
        {
            await _Service.WelcomeThree(model);
            completeAction();
        }
    }
}