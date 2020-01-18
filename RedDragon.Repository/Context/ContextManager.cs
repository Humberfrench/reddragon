using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using RedDragon.Repository.Interfaces;

namespace RedDragon.Repository.Context
{
    public class ContextManager : IContextManager
    {
        private const string CONTEXT_KEY = "ContextManager.Context";
        private readonly IHttpContextAccessor context;
        private readonly IConfiguration configuration;

        public ContextManager(IHttpContextAccessor context, 
                              IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public string GetConnectionString => configuration.GetConnectionString("RedDragonContext");

        public RedDragonContext GetContext()
        {
            if (context.HttpContext == null)
                return new RedDragonContext();

            if (context.HttpContext.Items[CONTEXT_KEY] == null)
            {
                context.HttpContext.Items[CONTEXT_KEY] = new RedDragonContext();
            }

            return context.HttpContext.Items[CONTEXT_KEY] as RedDragonContext;
        }
    }
}