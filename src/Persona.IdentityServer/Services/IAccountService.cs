using System.Threading.Tasks;

namespace Persona.IdentityServer.Services
{
    public interface IAccountService<T>
    {
        Task<bool> ValidateCredentialsAsync(T user, string password);

        Task<T> FindByUsernameAsync(string username);
    }
}
