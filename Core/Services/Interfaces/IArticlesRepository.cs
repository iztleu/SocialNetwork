using Core.Dto;
using Core.Entities;

namespace Core.Services.Interfaces;

public interface IArticlesRepository
{
    public Task AddArticleAsync(Article article, CancellationToken cancellationToken);
    
    public Task<ArticlesResponseDto> GetArticlesAsync(ArticlesQuery articlesQuery, string email, bool isFeed, CancellationToken cancellationToken);
}