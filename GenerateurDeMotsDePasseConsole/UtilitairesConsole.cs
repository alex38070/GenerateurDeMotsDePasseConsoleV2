namespace GenerateurDeMotsDePasseConsoleV2;

internal static class UtilitairesConsole
{
    internal static int DemanderLongueur(int min, int max) // Choix nombre utilisateur
    {
        bool Juste;
        int nombre;
        do
        {
            Console.Write($"Longueur du mot de passe souhaitée ({min}-{max}) : ");
            Console.ForegroundColor = ConsoleColor.Red;
            string saisie = Console.ReadLine() ?? string.Empty;
            Console.ForegroundColor = ConsoleColor.Blue;

            Juste = (int.TryParse(saisie, out nombre) && nombre >= min && nombre <= max);

        } while (!Juste);
        return nombre;

        //while (true)
        //{
        //    Console.Write($"Longueur du mot de passe souhaitée ({min}-{max}) : ");
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    string saisie = Console.ReadLine() ?? string.Empty;
        //    Console.ForegroundColor = ConsoleColor.Blue;

        //    if (int.TryParse(saisie, out int nombre) && nombre >= min && nombre <= max)
        //        return nombre;
        //}
    }

    internal static string DemanderRejouer() // Choix nombre non converti
    {
        bool estJuste;
        string saisie;
        do
        {
            Console.ForegroundColor = ConsoleColor.Red;

            saisie = Console.ReadLine() ?? string.Empty;
            estJuste = (saisie != "1" || saisie != "2" || saisie != "3");

            Console.ForegroundColor = ConsoleColor.Blue;

        } while (!estJuste);
        return saisie;

        //while (true)
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    string saisie = Console.ReadLine() ?? string.Empty;
        //    Console.ForegroundColor = ConsoleColor.Blue;

        //    if (saisie != "1" || saisie != "2" || saisie != "3")
        //        return saisie;
        //}
    }

    internal static bool DemanderOuiNon(string message)
    {
        Console.Write(message);
        Console.ForegroundColor = ConsoleColor.Red;

        if (Console.ReadLine() == "o")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            return true;
        }

        Console.ForegroundColor = ConsoleColor.Blue;
        return false;

    }
}