using EntityFrameworkCoreLibrary.Data;

namespace EntityFrameworkCoreLibrary.Classes;

public class CreateOperations
{
    public static async Task<(bool success, Exception exception)> NewExampleDatabase()
    {

        try
        {
            await using var context = new ExampleContext();
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            return (true, null);

        }
        catch (Exception e)
        {

            return (false, e);

        }
    }
}