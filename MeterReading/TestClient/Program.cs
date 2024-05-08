// See https://aka.ms/new-console-template for more information

using TestClient;
using TestClient.Properties;

for(;;)
{
    Console.Write(Resources.Introduction);

    var selection = Console.ReadKey().KeyChar;

    if (selection == '3')
    {
        break;
    }

    var test = TestFactory.CreateTest(selection);
    if (test != null)
    {
        await test.Run();
    }
}