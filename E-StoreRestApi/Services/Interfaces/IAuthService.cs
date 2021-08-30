using System.Threading;
using System.Threading.Tasks;
using E_StoreRestApi.Messages.Request.User;
using E_StoreRestApi.Messages.Response.User;

namespace E_StoreRestApi.Services
{
    public interface IAuthService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
        Task<LogInResponse> LogInAsync(LogInRequest request, CancellationToken cancellationToken = default);
    }
}
