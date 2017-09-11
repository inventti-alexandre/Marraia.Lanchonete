using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using SimpleInjector.Lifestyles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SimpleInjector;
using Infra.IoC;
using App.WebApi.Middleware;
using Application;
using Application.Interfaces;
using Infra.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;

using Infra.Repositorio;
using Dominio.Interfaces;

namespace App.WebApi
{
    public class Startup
    {
        private readonly Container container = ContainerFactory.Container;
        private IConfigurationRoot _config;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            IntegrateSimpleInjector(services);
        }

        private void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();

            _config = builder.Build();


            #region configuração de container ioc

            InitializeContainer(app);

            // Registro dos middlewares
            container.Register<ErrorHandlerMiddleware>();

            container.Verify();

            #endregion

            // Aplica os middlewares
            app.Use((c, next) => container.GetInstance<ErrorHandlerMiddleware>().Invoke(c, next));


            // Aplica o MVC
            app.UseMvcWithDefaultRoute();
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Services (Presentation)
            //container.Register<IUserService, UserService>(Lifestyle.Scoped);

            // Registro das interfaces do sistema:
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<ILancheAppService,LancheAppService>(Lifestyle.Scoped);
            container.Register<IIngredienteAppService, IngredienteAppService>(Lifestyle.Scoped);
            container.Register<ICardapioAppService, CardapioAppService>(Lifestyle.Scoped);
            container.Register<IPedidoAppService, PedidoAppService>(Lifestyle.Scoped);

            // Repositories
            container.Register<IClienteRepositorio, ClienteRepositorio>(Lifestyle.Scoped);
            container.Register<ILancheRepositorio, LancheRepositorio>(Lifestyle.Scoped);
            container.Register<IIngredienteRepositorio, IngredienteRepositorio>(Lifestyle.Scoped);
            container.Register<ICardapioRepositorio, CardapioRepositorio>(Lifestyle.Scoped);
            container.Register<IPedidoRepositorio, PedidoRepositorio>(Lifestyle.Scoped);

            //DbContexts
            //TODO: Verificar se está sendo realizado o dispose.
            container.Register<LanchoneteContext>(() =>
            {
                var options = new DbContextOptionsBuilder<LanchoneteContext>();
                options.UseSqlServer(Configuration.GetConnectionString("Desafio"));
                return new LanchoneteContext(options.Options);
            }, Lifestyle.Scoped);

            // Registro de todos os event handlers

            // Cross-wire ASP.NET services (if any). For instance:
            container.CrossWire<ILoggerFactory>(app);
        }
    }
}
