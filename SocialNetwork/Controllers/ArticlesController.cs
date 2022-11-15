using System.Security.Claims;
using Core.Dto;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers;

[ApiController]
[Route("[controller]")]
public class ArticlesController: Controller
{
    private readonly IArticlesHandler _articlesHandler;

    public ArticlesController(IArticlesHandler articlesHandler)
    {
        _articlesHandler = articlesHandler;
    }
    
    private string Email => User.FindFirstValue(ClaimTypes.Name);
    
    [Authorize]
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] NewArticleDto request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _articlesHandler.CreateArticleAsync(request, Email, cancellationToken);
            return result.Match();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return Problem(detail: ex.Message);
        }
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery] ArticlesQuery query, CancellationToken cancellationToken)
    {
        // var response = await _articlesHandler.GetArticlesAsync(query, Username, false, cancellationToken);
        // var result = ArticlesMapper.MapFromArticles(response);
        // return result;

        return null;
    }
}