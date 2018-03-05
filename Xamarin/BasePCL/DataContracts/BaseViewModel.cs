using Newtonsoft.Json;

namespace CorePCL
{
    public abstract class BaseViewModel
    {
        public string SerializeObject()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
