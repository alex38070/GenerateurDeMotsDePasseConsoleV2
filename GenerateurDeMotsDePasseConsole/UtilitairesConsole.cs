namespace GenerateurDeMotsDePasseConsoleV2;

internal static class UtilitairesConsole
{
    internal static int DemanderLongueur(int min, int max) // Choix nombre utilisateur
    {
        while (true)
        {
            Console.Write($"Longueur du mot de passe souhaitée ({min}-{max}) : ");
            string saisie = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(saisie, out int nombre) && nombre >= min && nombre <= max)
                return nombre;
        }
    }

    internal static string DemanderRejouer() // Choix nombre non converti
    {
        while (true)
        {
            string saisie = Console.ReadLine() ?? string.Empty;

            if (saisie != "1" || saisie != "2" || saisie != "3")
                return saisie;
        }
    }

    internal static bool DemanderOuiNon(string message)
    {
        Console.Write($"\r\n{message}");
        if (Console.ReadLine() == "o")
            return true;
        else return false;
    }
}