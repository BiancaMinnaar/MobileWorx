using System;
using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Repository
{
    public interface IWelcomeRepository
    {
        Task Welcome(WelcomeViewModel model, Action completeAction);
    }
}
