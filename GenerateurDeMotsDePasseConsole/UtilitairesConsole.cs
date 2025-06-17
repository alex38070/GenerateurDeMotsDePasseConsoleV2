namespace GenerateurDeMotsDePasseConsoleV2;

internal static class UtilitairesConsole
{
    internal static int DemanderLongueur(int min, int max) // Choix nombre utilisateur
    {
        while (true)
        {
            WriteColor($"Longueur du mot de passe souhaitée ({min}-{max}) : ", ConsoleColor.Blue, true);
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
        WriteColor(message, ConsoleColor.Blue, true);

        return Console.ReadLine() == "o" ? true : false;
    }

    internal static void WriteColor(string texte, ConsoleColor couleur, bool retourne)
    {
        if (retourne == true)
        {
            ConsoleColor couleurOriginale = Console.ForegroundColor;
            Console.ForegroundColor = couleur;
            Console.Write(texte);
            Console.ForegroundColor = couleurOriginale;
        }
        if (retourne == false)
        {
            ConsoleColor couleurOriginale = Console.ForegroundColor;
            Console.ForegroundColor = couleur;
            Console.WriteLine(texte);
            Console.ForegroundColor = couleurOriginale;
        }
    }
}