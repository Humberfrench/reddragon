
using RedDragon.Repository.Context;

namespace RedDragon.Repository.Interfaces
{
    public interface IContextManager
    {
        RedDragonContext GetContext();
        string GetConnectionString { get; }
    }
}