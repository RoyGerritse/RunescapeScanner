using Scanner.Application.Interactor;

var running = true;
while (running)
{
    try
    {
        running = await new RegularPlayerNamesInteractor().Execute();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Thread.Sleep(60000);
    }
}