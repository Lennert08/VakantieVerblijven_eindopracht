using VakantieVerblijven.DatalLoader.VakantieVerblijven;

DataLoader dataLoader = new DataLoader();

do
{
    try
    {
        Console.WriteLine("Wil je alle data toevogen [1] of verwijderen [2]");
        string keuze = Console.ReadLine();
        int keuzeInt = Convert.ToInt32(keuze);

        if (keuzeInt == 1)
        {
            dataLoader.ImportData();
        }
        else if (keuzeInt == 2)
        {
            dataLoader.DeleteAllData();
        }
        Console.ReadKey();
        Console.Clear();
    } catch (Exception e)
    {
        Console.WriteLine("Foutieve invoer");
        Console.ReadKey();
        Console.Clear();
    }

} while (true);




