namespace GenerateurDeMotsDePasseConsoleV2;

internal static class UtilitairesConsole
{
    internal static int DemanderLongueur(int min, int max) // Choix nombre utilisateur
    {
        while (true)
        {
            WriteColor($"Longueur du mot de passe souhaitée ({min}-{max}) : ", ConsoleColor.Cyan, true);
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
        WriteColor(message, ConsoleColor.Cyan, true);
        string saisie = Console.ReadLine() ?? string.Empty;

        return (saisie == "o" || saisie == "O") ? true : false;
    }

    internal static void WriteColor(string texte, ConsoleColor couleur, bool retourne)
    {
        ConsoleColor couleurOriginale = Console.ForegroundColor;
        Console.ForegroundColor = couleur;

        if (retourne)
            Console.Write(texte);
        else Console.WriteLine(texte);

        Console.ForegroundColor = couleurOriginale;
    }

    internal static void ListChoixRejouer()
    {
        Console.WriteLine();
        UtilitairesConsole.WriteColor("\r\nSouhaitez-vous générer un nouveau mot de passe ?\r\n", ConsoleColor.Cyan, true);
        UtilitairesConsole.WriteColor("1. Oui, avec les mêmes critères", ConsoleColor.Cyan, false);
        UtilitairesConsole.WriteColor("2. Oui, avec de nouveaux critères", ConsoleColor.Cyan, false);
        UtilitairesConsole.WriteColor("3. Non, quitter l'application", ConsoleColor.Cyan, false);
        UtilitairesConsole.WriteColor("\r\nChoix_____________________________________: ", ConsoleColor.Cyan, true);

    }
}