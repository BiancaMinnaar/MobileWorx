using System;
using System.Threading.Tasks;
using HiRes.Implementation.ViewModel;

namespace HiRes.Interface.Repository
{
    public interface IRegisterRepository
    {
        Task Register(RegisterViewModel model, Action completeAction);
    }
}
