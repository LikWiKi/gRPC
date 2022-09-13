using ProtoBuf.Grpc;
using Shared.Data;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace GrpcServer.Contracts
{

    [DataContract]
    public class ProductRequest
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public float Price { get; set; }
    }


    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Task<List<ProductRequest>> GetAll();
    }
}
