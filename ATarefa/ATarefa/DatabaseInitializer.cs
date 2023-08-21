using Microsoft.EntityFrameworkCore;
using Persistencia.Context;

namespace ATarefa
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase(IApplicationBuilder app)
        {
			try
			{
                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<MyContext>();
                    context.Database.Migrate(); // Executa as migrações
                }
            }
			catch (Exception)
			{

				
			}
        }

    }
}
