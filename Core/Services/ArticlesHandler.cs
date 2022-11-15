using Core.Dto;
using Core.Entities;
using Core.Services.Interfaces;
using LanguageExt.Common;

namespace Core.Services;

public class ArticlesHandler: IArticlesHandler
{
    private readonly IUserRepository _userRepository;
    private readonly IArticlesRepository _articleRepository;

    public ArticlesHandler(IArticlesRepository articleRepository, IUserRepository userRepository)
    {
        _articleRepository = articleRepository;
        _userRepository = userRepository;
    }
    
    public async Task<Result<Article>> CreateArticleAsync(NewArticleDto newArticle, string email, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(email, cancellationToken);
        
        if (user == null)
        {
            return new Result<Article>(new ArgumentNullException("user not found"));
        }
        
        var article = new Article(
                newArticle.Title,
                newArticle.Description,
                newArticle.Body
            ) { Id = Guid.NewGuid(),  AuthorId = user.Id };
        
        await _articleRepository.AddArticleAsync(article, cancellationToken);

        return article;
    }

    public async Task<Result<ArticlesResponseDto>> GetArticlesAsync(ArticlesQuery query, string email, bool isFeed, CancellationToken cancellationToken)
    {
        return await _articleRepository.GetArticlesAsync(query, email, false, cancellationToken);
    }
}