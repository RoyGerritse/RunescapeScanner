using Scanner.Application.Interactor;

while (true)
{
    try
    {
        await new PlayerNameScannerInteractor().Execute();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Thread.Sleep(60000);
    }
}