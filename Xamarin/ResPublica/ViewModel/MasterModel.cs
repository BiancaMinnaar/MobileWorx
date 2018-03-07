using HiRes.ViewModel.ReturnModel;

namespace HiRes.ViewModel
{
    public class MasterModel
    {
        public bool Authenticated { get; set; }
        public UserModel User { get; set; }
        public LoginResponseUser AuthUser {get;set;}
    }
}
