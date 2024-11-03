﻿using Scanner.Application.Interactor;

while (true)
{
    try
    {
        await new RegularHiScoreInteractor().Execute();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
        Thread.Sleep(60000);
    }
}