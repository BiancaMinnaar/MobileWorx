using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace ResPublica.Droid.Injection
{
    public interface IJsonSerializer : ISerializer, IDeserializer
    {
    }
}
