using System;
namespace CorePCL
{
    public class NetworkCallEventArgs : EventArgs
    {
        public bool IsNetworkCallSuccess { get; set; }
        public bool CanResponseDeserialise { get; set; }
        public string NetworkCallMessage { get; set; }
        public string NetworkResponseContent { get; set; }
        public int ObjectID { get; set; }
        public byte[] RawBytes { get; set; }

        public Exception Exception { get; set; }
        public string ErrorStackTrace 
        { 
            get { return Exception.StackTrace; } 
        }
        public string ErrorMessage 
        { 
            get { return Exception.Message; }
        }

        public NetworkCallEventArgs(bool isSuccessfull, string networkCallMessage, bool canResponseDeserialise = false)
        {
            IsNetworkCallSuccess = isSuccessfull;
            NetworkCallMessage = networkCallMessage;
            CanResponseDeserialise = canResponseDeserialise;
        }
    }
}
