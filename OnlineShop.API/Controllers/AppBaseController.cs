using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.API.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class AppBaseController : ControllerBase
    {
    }
}
