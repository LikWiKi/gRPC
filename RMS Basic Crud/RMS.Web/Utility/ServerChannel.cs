using Grpc.Net.Client;

namespace RMS.Web.Utility
{
    public class ServerChannel
    {
        public GrpcChannel Initial()
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5010");
            return channel;
        }
    }
}
