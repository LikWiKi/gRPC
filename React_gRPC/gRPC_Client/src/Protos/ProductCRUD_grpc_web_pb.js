/**
 * @fileoverview gRPC-Web generated client stub for ProductgRPC
 * @enhanceable
 * @public
 */

// GENERATED CODE -- DO NOT EDIT!


/* eslint-disable */
// @ts-nocheck



const grpc = {};
grpc.web = require('grpc-web');


var google_protobuf_timestamp_pb = require('google-protobuf/google/protobuf/timestamp_pb.js')
const proto = {};
proto.ProductgRPC = require('./ProductCRUD_pb.js');

/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?grpc.web.ClientOptions} options
 * @constructor
 * @struct
 * @final
 */
proto.ProductgRPC.ProductCRUDClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options.format = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?grpc.web.ClientOptions} options
 * @constructor
 * @struct
 * @final
 */
proto.ProductgRPC.ProductCRUDPromiseClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options.format = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.ProductgRPC.Empty,
 *   !proto.ProductgRPC.Products>}
 */
const methodDescriptor_ProductCRUD_GetAll = new grpc.web.MethodDescriptor(
  '/ProductgRPC.ProductCRUD/GetAll',
  grpc.web.MethodType.UNARY,
  proto.ProductgRPC.Empty,
  proto.ProductgRPC.Products,
  /**
   * @param {!proto.ProductgRPC.Empty} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.ProductgRPC.Products.deserializeBinary
);


/**
 * @param {!proto.ProductgRPC.Empty} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.RpcError, ?proto.ProductgRPC.Products)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.ProductgRPC.Products>|undefined}
 *     The XHR Node Readable Stream
 */
proto.ProductgRPC.ProductCRUDClient.prototype.getAll =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/ProductgRPC.ProductCRUD/GetAll',
      request,
      metadata || {},
      methodDescriptor_ProductCRUD_GetAll,
      callback);
};


/**
 * @param {!proto.ProductgRPC.Empty} request The
 *     request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.ProductgRPC.Products>}
 *     Promise that resolves to the response
 */
proto.ProductgRPC.ProductCRUDPromiseClient.prototype.getAll =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/ProductgRPC.ProductCRUD/GetAll',
      request,
      metadata || {},
      methodDescriptor_ProductCRUD_GetAll);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.ProductgRPC.ProductFilter,
 *   !proto.ProductgRPC.Product>}
 */
const methodDescriptor_ProductCRUD_GetById = new grpc.web.MethodDescriptor(
  '/ProductgRPC.ProductCRUD/GetById',
  grpc.web.MethodType.UNARY,
  proto.ProductgRPC.ProductFilter,
  proto.ProductgRPC.Product,
  /**
   * @param {!proto.ProductgRPC.ProductFilter} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.ProductgRPC.Product.deserializeBinary
);


/**
 * @param {!proto.ProductgRPC.ProductFilter} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.RpcError, ?proto.ProductgRPC.Product)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.ProductgRPC.Product>|undefined}
 *     The XHR Node Readable Stream
 */
proto.ProductgRPC.ProductCRUDClient.prototype.getById =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/ProductgRPC.ProductCRUD/GetById',
      request,
      metadata || {},
      methodDescriptor_ProductCRUD_GetById,
      callback);
};


/**
 * @param {!proto.ProductgRPC.ProductFilter} request The
 *     request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.ProductgRPC.Product>}
 *     Promise that resolves to the response
 */
proto.ProductgRPC.ProductCRUDPromiseClient.prototype.getById =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/ProductgRPC.ProductCRUD/GetById',
      request,
      metadata || {},
      methodDescriptor_ProductCRUD_GetById);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.ProductgRPC.Product,
 *   !proto.ProductgRPC.Empty>}
 */
const methodDescriptor_ProductCRUD_Create = new grpc.web.MethodDescriptor(
  '/ProductgRPC.ProductCRUD/Create',
  grpc.web.MethodType.UNARY,
  proto.ProductgRPC.Product,
  proto.ProductgRPC.Empty,
  /**
   * @param {!proto.ProductgRPC.Product} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.ProductgRPC.Empty.deserializeBinary
);


/**
 * @param {!proto.ProductgRPC.Product} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.RpcError, ?proto.ProductgRPC.Empty)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.ProductgRPC.Empty>|undefined}
 *     The XHR Node Readable Stream
 */
proto.ProductgRPC.ProductCRUDClient.prototype.create =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/ProductgRPC.ProductCRUD/Create',
      request,
      metadata || {},
      methodDescriptor_ProductCRUD_Create,
      callback);
};


/**
 * @param {!proto.ProductgRPC.Product} request The
 *     request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.ProductgRPC.Empty>}
 *     Promise that resolves to the response
 */
proto.ProductgRPC.ProductCRUDPromiseClient.prototype.create =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/ProductgRPC.ProductCRUD/Create',
      request,
      metadata || {},
      methodDescriptor_ProductCRUD_Create);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.ProductgRPC.Product,
 *   !proto.ProductgRPC.Empty>}
 */
const methodDescriptor_ProductCRUD_Update = new grpc.web.MethodDescriptor(
  '/ProductgRPC.ProductCRUD/Update',
  grpc.web.MethodType.UNARY,
  proto.ProductgRPC.Product,
  proto.ProductgRPC.Empty,
  /**
   * @param {!proto.ProductgRPC.Product} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.ProductgRPC.Empty.deserializeBinary
);


/**
 * @param {!proto.ProductgRPC.Product} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.RpcError, ?proto.ProductgRPC.Empty)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.ProductgRPC.Empty>|undefined}
 *     The XHR Node Readable Stream
 */
proto.ProductgRPC.ProductCRUDClient.prototype.update =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/ProductgRPC.ProductCRUD/Update',
      request,
      metadata || {},
      methodDescriptor_ProductCRUD_Update,
      callback);
};


/**
 * @param {!proto.ProductgRPC.Product} request The
 *     request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.ProductgRPC.Empty>}
 *     Promise that resolves to the response
 */
proto.ProductgRPC.ProductCRUDPromiseClient.prototype.update =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/ProductgRPC.ProductCRUD/Update',
      request,
      metadata || {},
      methodDescriptor_ProductCRUD_Update);
};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.ProductgRPC.ProductFilter,
 *   !proto.ProductgRPC.Empty>}
 */
const methodDescriptor_ProductCRUD_Delete = new grpc.web.MethodDescriptor(
  '/ProductgRPC.ProductCRUD/Delete',
  grpc.web.MethodType.UNARY,
  proto.ProductgRPC.ProductFilter,
  proto.ProductgRPC.Empty,
  /**
   * @param {!proto.ProductgRPC.ProductFilter} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.ProductgRPC.Empty.deserializeBinary
);


/**
 * @param {!proto.ProductgRPC.ProductFilter} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.RpcError, ?proto.ProductgRPC.Empty)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.ProductgRPC.Empty>|undefined}
 *     The XHR Node Readable Stream
 */
proto.ProductgRPC.ProductCRUDClient.prototype.delete =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/ProductgRPC.ProductCRUD/Delete',
      request,
      metadata || {},
      methodDescriptor_ProductCRUD_Delete,
      callback);
};


/**
 * @param {!proto.ProductgRPC.ProductFilter} request The
 *     request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.ProductgRPC.Empty>}
 *     Promise that resolves to the response
 */
proto.ProductgRPC.ProductCRUDPromiseClient.prototype.delete =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/ProductgRPC.ProductCRUD/Delete',
      request,
      metadata || {},
      methodDescriptor_ProductCRUD_Delete);
};


module.exports = proto.ProductgRPC;

