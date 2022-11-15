using Core.Dto;
using Core.Entities;
using LanguageExt.Common;

namespace Core.Services.Interfaces;

public interface IArticlesHandler
{
    public Task<Result<Article>> CreateArticleAsync(
        NewArticleDto newArticle, string email, CancellationToken cancellationToken);
    
    public Task<Result<ArticlesResponseDto>> GetArticlesAsync(ArticlesQuery query, string email, bool isFeed,
        CancellationToken cancellationToken);
}