using System;
using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Repository
{
    public interface IWelcomeOneRepository
    {
        Task WelcomeOne(WelcomeOneViewModel model, Action completeAction);
    }
}
