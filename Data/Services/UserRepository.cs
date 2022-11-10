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
    
    public async Task AddUserAsync(User user)
    {
        using IDbConnection db = new MySqlConnection(_connectionString);
        //var sqlQuery = "INSERT INTO users (name, password, email) VALUES(@Username, @Password, @Email)";
        var sqlQuery = "INSERT INTO users (email, age, password, name, surname, floor, interests, city) " +
                       "VALUES (@email, @age, @password, @name, @surname, @floor, @interests, @city);";
        await db.ExecuteAsync(sqlQuery, user);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        using IDbConnection db = new MySqlConnection(_connectionString);
        return await db.QueryFirstOrDefaultAsync<User>("SELECT * FROM users WHERE email = @email", new {email});
    }
}