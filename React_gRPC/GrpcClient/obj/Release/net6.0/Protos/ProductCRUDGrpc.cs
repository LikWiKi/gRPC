// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/ProductCRUD.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcServiceApp {
  public static partial class ProductCRUD
  {
    static readonly string __ServiceName = "ProductgRPC.ProductCRUD";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServiceApp.Empty> __Marshaller_ProductgRPC_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServiceApp.Empty.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServiceApp.Products> __Marshaller_ProductgRPC_Products = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServiceApp.Products.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServiceApp.ProductFilter> __Marshaller_ProductgRPC_ProductFilter = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServiceApp.ProductFilter.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcServiceApp.Product> __Marshaller_ProductgRPC_Product = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcServiceApp.Product.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServiceApp.Empty, global::GrpcServiceApp.Products> __Method_GetAll = new grpc::Method<global::GrpcServiceApp.Empty, global::GrpcServiceApp.Products>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetAll",
        __Marshaller_ProductgRPC_Empty,
        __Marshaller_ProductgRPC_Products);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServiceApp.ProductFilter, global::GrpcServiceApp.Product> __Method_GetById = new grpc::Method<global::GrpcServiceApp.ProductFilter, global::GrpcServiceApp.Product>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetById",
        __Marshaller_ProductgRPC_ProductFilter,
        __Marshaller_ProductgRPC_Product);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServiceApp.Product, global::GrpcServiceApp.Empty> __Method_Create = new grpc::Method<global::GrpcServiceApp.Product, global::GrpcServiceApp.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Create",
        __Marshaller_ProductgRPC_Product,
        __Marshaller_ProductgRPC_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServiceApp.Product, global::GrpcServiceApp.Empty> __Method_Update = new grpc::Method<global::GrpcServiceApp.Product, global::GrpcServiceApp.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Update",
        __Marshaller_ProductgRPC_Product,
        __Marshaller_ProductgRPC_Empty);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcServiceApp.ProductFilter, global::GrpcServiceApp.Empty> __Method_Delete = new grpc::Method<global::GrpcServiceApp.ProductFilter, global::GrpcServiceApp.Empty>(
        grpc::MethodType.Unary,
        __ServiceName,
        "Delete",
        __Marshaller_ProductgRPC_ProductFilter,
        __Marshaller_ProductgRPC_Empty);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcServiceApp.ProductCRUDReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for ProductCRUD</summary>
    public partial class ProductCRUDClient : grpc::ClientBase<ProductCRUDClient>
    {
      /// <summary>Creates a new client for ProductCRUD</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ProductCRUDClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ProductCRUD that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public ProductCRUDClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ProductCRUDClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected ProductCRUDClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcServiceApp.Products GetAll(global::GrpcServiceApp.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAll(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcServiceApp.Products GetAll(global::GrpcServiceApp.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetAll, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcServiceApp.Products> GetAllAsync(global::GrpcServiceApp.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetAllAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcServiceApp.Products> GetAllAsync(global::GrpcServiceApp.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetAll, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcServiceApp.Product GetById(global::GrpcServiceApp.ProductFilter request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetById(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcServiceApp.Product GetById(global::GrpcServiceApp.ProductFilter request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetById, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcServiceApp.Product> GetByIdAsync(global::GrpcServiceApp.ProductFilter request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetByIdAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcServiceApp.Product> GetByIdAsync(global::GrpcServiceApp.ProductFilter request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetById, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcServiceApp.Empty Create(global::GrpcServiceApp.Product request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Create(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcServiceApp.Empty Create(global::GrpcServiceApp.Product request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Create, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcServiceApp.Empty> CreateAsync(global::GrpcServiceApp.Product request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcServiceApp.Empty> CreateAsync(global::GrpcServiceApp.Product request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Create, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcServiceApp.Empty Update(global::GrpcServiceApp.Product request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Update(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcServiceApp.Empty Update(global::GrpcServiceApp.Product request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Update, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcServiceApp.Empty> UpdateAsync(global::GrpcServiceApp.Product request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcServiceApp.Empty> UpdateAsync(global::GrpcServiceApp.Product request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Update, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcServiceApp.Empty Delete(global::GrpcServiceApp.ProductFilter request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return Delete(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::GrpcServiceApp.Empty Delete(global::GrpcServiceApp.ProductFilter request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_Delete, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcServiceApp.Empty> DeleteAsync(global::GrpcServiceApp.ProductFilter request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return DeleteAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::GrpcServiceApp.Empty> DeleteAsync(global::GrpcServiceApp.ProductFilter request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_Delete, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override ProductCRUDClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ProductCRUDClient(configuration);
      }
    }

  }
}
#endregion