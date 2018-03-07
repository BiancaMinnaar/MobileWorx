using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace ResPublica.iOS.Injection
{
    public interface IJsonSerializer : ISerializer, IDeserializer
    {
    }
}
