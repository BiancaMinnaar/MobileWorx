using System;
using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Repository
{
    public interface IWelcomeTwoRepository
    {
        Task WelcomeTwo(WelcomeTwoViewModel model, Action completeAction);
    }
}
