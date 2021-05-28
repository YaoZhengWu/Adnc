﻿using Adnc.WebApi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using SkyApm.Diagnostics.CAP;
using SkyApm.Utilities.DependencyInjection;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 统一注册Adnc.Webpi通用服务
        /// </summary>
        /// <typeparam name="TPermissionHandler"></typeparam>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <param name="environment"></param>
        /// <param name="serviceInfo"></param>
        /// <param name="completedExecute"></param>
        /// <returns></returns>
        public static IServiceCollection AddAdncServices<TPermissionHandler>(this IServiceCollection services
            , IConfiguration configuration
            , IWebHostEnvironment environment
            , ServiceInfo serviceInfo
            , Action<SharedServicesRegistration> completedExecute = null)
            where TPermissionHandler : PermissionHandler
        {
            services.AddSingleton(serviceInfo);
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddSkyApmExtensions().AddCap();

            var _srvRegistration = new SharedServicesRegistration(configuration, services, environment, serviceInfo);
            _srvRegistration.Configure();
            _srvRegistration.AddControllers();
            _srvRegistration.AddJWTAuthentication();
            _srvRegistration.AddAuthorization<TPermissionHandler>();
            _srvRegistration.AddCors();
            _srvRegistration.AddHealthChecks();
            _srvRegistration.AddEfCoreContext();
            _srvRegistration.AddMongoContext();
            _srvRegistration.AddSwaggerGen();

            completedExecute?.Invoke(_srvRegistration);

            return services;
        }
    }
}