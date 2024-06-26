using Mattodo.Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Mattodo.Api.Tests.Integration;

public class TodoTaskApiFactory : WebApplicationFactory<IApiMarker>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(collection =>
        {
            collection.RemoveAll(typeof(IDbConnectionFactory));
            collection.AddSingleton<IDbConnectionFactory>(_ =>
                new SqliteConnectionFactory("DataSource=file:inmem?mode=memory&cache=shared"));
        });
    }
}