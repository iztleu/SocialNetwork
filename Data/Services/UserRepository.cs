using Dapper;
using System.Data;
using Core.Entities;
using Core.Services.Interfaces;
using MySql.Data.MySqlClient;


namespace Data.Services;

public class UserRepository: IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(string constr)
    {
        _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
    }
    
    public async Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        using IDbConnection db = new MySqlConnection(_connectionString);
        //var sqlQuery = "INSERT INTO users (name, password, email) VALUES(@Username, @Password, @Email)";
        const string query = "INSERT INTO users (email, age, password, name, surname, floor, interests, city) " +
                                "VALUES (@email, @age, @password, @name, @surname, @floor, @interests, @city);";
        await db.ExecuteAsync( new CommandDefinition(query, user, cancellationToken: cancellationToken));
        //await db.ExecuteAsync(query, user);
    }

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        using IDbConnection db = new MySqlConnection(_connectionString);
        const string query = "SELECT * FROM users WHERE email = @email";
        return await db.QueryFirstOrDefaultAsync<User>(
            new CommandDefinition(query, new {email}, cancellationToken: cancellationToken)
            );
    }

    public async Task<int> UpdateAsync(User user, CancellationToken cancellationToken)
    {
        using IDbConnection db = new MySqlConnection(_connectionString);
        
        const string query = @"UPDATE users SET 
           name=@Name, surname=@Surname, age=@Age, floor=@Floor, interests=@Interests, city=@City, image=@Image
           Where email = @email";
        
        return await db.ExecuteAsync( new CommandDefinition(query, user, cancellationToken: cancellationToken));
        
        // return await db.ExecuteAsync(sql:@"UPDATE users SET 
        //                              name=@Name, surname=@Surname, age=@Age, floor=@Floor, interests=@Interests, city=@City, image=@Image
        //                              Where email = @email", user);
    }
}