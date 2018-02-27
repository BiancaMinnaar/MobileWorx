using System;
namespace CorePCL
{
    public interface ICrypto
    {
        string GetCryptoString(string stringToEncrypt);
    }
}
