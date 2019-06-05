using CotizacionesPersonalesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CotizacionesPersonalesApi.Services
{
    public interface IUserService
    {
        Task<(bool Succeeded, string ErrorMessage)> CreateUserAsync(RegisterForm form);

        Task<PagedResults<User>> GetUsersAsync(
            PagingOptions pagingOptions,
            SortOptions<User, UserEntity> sortOptions,
            SearchOptions<User, UserEntity> searchOptions);

        Task<Guid?> GetUserIdAsync(ClaimsPrincipal principal);

        Task<User> GetUserAsync(ClaimsPrincipal user);

    }
}
