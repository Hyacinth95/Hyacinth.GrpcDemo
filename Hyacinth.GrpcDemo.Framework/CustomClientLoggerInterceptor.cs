using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;
using System;

namespace Hyacinth.GrpcDemo.Framework
{
    public class CustomClientLoggerInterceptor : Interceptor
    {
        private readonly ILogger<CustomClientLoggerInterceptor> _logger;

        public CustomClientLoggerInterceptor(ILogger<CustomClientLoggerInterceptor> logger)
        {
            _logger = logger;
        }

        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
            TRequest request,
            ClientInterceptorContext<TRequest, TResponse> context,
            AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            this.LogAOP(context.Method);
            return continuation(request, context);
        }

        private void LogAOP<TRequest, TResposne>(Method<TRequest, TResposne> method)
            where TRequest : class
            where TResposne : class
        {
            Console.WriteLine("*********************AsyncUnaryCallAOP开始*********************");
            Console.WriteLine($"{method.Name}---{method.FullName}---{method.ServiceName}");
            Console.WriteLine($"Type: {method.Type}, Request: {typeof(TRequest)}, Response: {typeof(TResposne)}");
            Console.WriteLine("*********************AsyncUnaryCallAOP结束*********************");
        }
    }
}
