using System;
using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Repository
{
    public interface IWelcomeThreeRepository
    {
        Task WelcomeThree(WelcomeThreeViewModel model, Action completeAction);
    }
}
