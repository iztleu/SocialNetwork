using Core.Entities;

namespace Core.Dto;

public record NewArticleDto(string Title, string Description, string Body);

public record ArticlesResponseDto(List<Article> Articles, int ArticlesCount);

public record ArticlesQuery(string? authorId, int Limit = 20, int Offset = 0);