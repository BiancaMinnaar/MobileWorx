using System;

namespace CorePCL
{
    public enum ParameterTypeEnum
    {
        ValueParameter,
        FileParameter,
        HeaderParameter,
        IdParameter
    }
    public class ParameterTypedValue
    {
        public object ParameterValue { get; set; }
        public ParameterTypeEnum ParameterType { get; set; }



   //     Func<string, object, RestRequest, IRestRequest> _AddFunction;
   //     string _ParameterName;
   //     object _ParameterValue;


   //     public IRestRequest AddParameter(string parameterName, object partameterValue, RestRequest req)
   //     {
   //         return req.AddParameter(parameterName, partameterValue);
   //     }

   //     public IRestRequest AddFile(string parameterName, object partameterValue, RestRequest req)
   //     {
			//return req.AddFile(parameterName, (byte[])partameterValue, "cFile");
        //}

        ////ss.AddTypeAddition((name, value, req) => AddParameter(name, value, req));
        //public RequestAdditionType(Func<string, object, RestRequest, IRestRequest> addType, string parameterName, object parameterValue)
        //{
        //    _AddFunction = addType;
        //    _ParameterName = parameterName;
        //    _ParameterValue = parameterValue;
        //}

        //public IRestRequest ExecuteTypeAddition(RestRequest request)
        //{
        //    return _AddFunction(_ParameterName, _ParameterValue, request);
        //}


    }
}
