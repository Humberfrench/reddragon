using Microsoft.AspNetCore.Http;
using RedDragon.Repository.Interfaces;

namespace RedDragon.Repository.Context
{
    public class ContextManager : IContextManager
    {
        private const string CONTEXT_KEY = "ContextManager.Context";
        private readonly IHttpContextAccessor context;

        public ContextManager(IHttpContextAccessor context)
        {
            this.context = context;
        }

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