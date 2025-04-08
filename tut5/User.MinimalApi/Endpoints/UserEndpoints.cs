using User.MinimalApi.Data;
using User.MinimalApi.Handlers;

namespace User.MinimalApi.Endpoints;

public static class UserEndpoints
{
    public static RouteGroupBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/users");
        group.MapGet("", () => UserHandlers.GetAllUsers);
        group.MapGet("{id:int}", () => UserHandlers.GetUserById);

        return group;
    }
}
