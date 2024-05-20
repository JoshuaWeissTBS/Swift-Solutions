using Microsoft.AspNetCore.Mvc;
using PopNGo.Models;
using PopNGo.DAL.Abstract;
using PopNGo.DAL.Concrete;

using Microsoft.AspNetCore.Identity;
using PopNGo.Areas.Identity.Data;
using PopNGo.Models.DTO;
using PopNGo.ExtensionMethods;
using PopNGo.Services;

namespace PopNGo.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RecommendationsApiController : Controller
{
    private readonly ILogger<RecommendationsApiController> _logger;
    private readonly IConfiguration _configuration;
    private readonly IPgUserRepository _pgUserRepository;
    private readonly UserManager<PopNGoUser> _userManager;
    private readonly IOpenAiService _openAiService;

    public RecommendationsApiController(
        IPgUserRepository pgUserRepository,
        UserManager<PopNGoUser> userManager,
        ILogger<RecommendationsApiController> logger,
        IConfiguration configuration,
        IOpenAiService openAiService
    )
    {
        _logger = logger;
        _configuration = configuration;
        _pgUserRepository = pgUserRepository;
        _userManager = userManager;
        _openAiService = openAiService;
    }

    [HttpGet("RecommendedEvents")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PopNGo.Models.Event>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<PopNGo.Models.Event>>> RecommendedEvents(string tag)
    {
        PopNGoUser user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }

        PgUser pgUser = _pgUserRepository.GetPgUserFromIdentityId(user.Id);
        if (pgUser == null)
        {
            return Unauthorized();
        }

        string relevantWord = await _openAiService.FindMostRelevantWordFromString("Bup ayy yuh");
        return Ok();
    }
}
