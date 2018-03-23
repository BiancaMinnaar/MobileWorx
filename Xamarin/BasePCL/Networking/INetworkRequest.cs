using CorePCL;

namespace BasePCL.Networking
{
    public interface INetworkRequest
    {
        void AddParameter(string name, object value);
        void AddFile(string name, byte[] value, string fileName);
        void AddHeader(string name, string value);
        void AddJsonBody(BaseViewModel body);
    }
}
