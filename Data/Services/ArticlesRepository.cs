using System.Data;
using Core.Dto;
using Core.Entities;
using Core.Services.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace Data.Services;

public class ArticlesRepository: IArticlesRepository
{
    private readonly string _connectionString;

    public ArticlesRepository(string constr)
    {
        _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
    }
    
    public async Task AddArticleAsync(Article article, CancellationToken cancellationToken)
    {
        using IDbConnection db = new MySqlConnection(_connectionString);
        const string query = "INSERT INTO article (id, title, description, body, createdat, updatedat, authorid) " +
                             "VALUES (@id, @title, @description, @body, @createdat, @updatedat, @authorid );";
        await db.ExecuteAsync( new CommandDefinition(query, article, cancellationToken: cancellationToken));
    }

    public async Task<ArticlesResponseDto> GetArticlesAsync(ArticlesQuery query, string email, bool isFeed, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}