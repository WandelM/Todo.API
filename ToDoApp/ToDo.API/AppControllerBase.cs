using Microsoft.AspNetCore.Mvc;
using ToDo.API.Services;

namespace ToDo.API
{
    public class AppControllerBase: ControllerBase
    {
        internal int GetAuthorizedUserId()
        {
            return int.Parse(User.Claims.First(c => c.Type == ClaimNames.UserId).Value);
        }
    }
}
