using System.Threading.Tasks;
using Discord.WebSocket;
using MALRewriteBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace MALRewriteBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly DiscordSocketClient _client;

        public UsersController(DiscordSocketClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get(ulong id)
        {
            var user = await _client.Rest.GetUserAsync(id);

            return new User
            {
                Id = user.Id,
                Username = user.Username,
                Avatar = user.GetAvatarUrl()
            };
        }
    }
}