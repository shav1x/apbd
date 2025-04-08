using User.MinimalApi.Data;

namespace User.MinimalApi.Handlers;

public static class UserHandlers
{
    public static IResult GetAllUsers()
    {
        return Results.Ok(UsersRepository.Users);
    }

    public static IResult GetUserById(int id)
    {
        var user = UsersRepository.Users.FirstOrDefault(u => u.Id == id);
        if (user == null)
            return Results.NotFound();
        return Results.Ok(user);
    }
}
