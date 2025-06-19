namespace GenerateurDeMotsDePasseConsoleV2;

internal static class UtilitaireConsole
{
    internal static int DemanderEntierDansIntervalle(string message, int min, int max) // Choix nombre utilisateur
    {
        while (true)
        {
            EcrireEnCouleur($"\r\n{message} ({min}-{max}) : ", ConsoleColor.Blue, true);
            string saisie = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(saisie, out int nombre) && nombre >= min && nombre <= max)
                return nombre;
        }
    }

    internal static bool DemanderOuiNon(string message)
    {
        EcrireEnCouleur(message, ConsoleColor.Blue, true);
        string saisie = Console.ReadLine() ?? string.Empty;

        return saisie.Equals("o", StringComparison.OrdinalIgnoreCase);
    }

    internal static string DemanderRejouer() // Choix nombre non converti
    {
        while (true)
        {
            Console.WriteLine();
            EcrireEnCouleur("Souhaitez-vous générer un nouveau mot de passe ?", ConsoleColor.Blue, false);
            EcrireEnCouleur("1. Oui, avec les mêmes critères", ConsoleColor.Blue, false);
            EcrireEnCouleur("2. Oui, avec de nouveaux critères", ConsoleColor.Blue, false);
            EcrireEnCouleur("3. Non, quitter l'application", ConsoleColor.Blue, false);
            EcrireEnCouleur("Choix_____________________________________: ", ConsoleColor.Blue, true);

            string saisie = Console.ReadLine() ?? string.Empty;

            if (saisie == "1" || saisie == "2" || saisie == "3")
                return saisie;
        }
    }

    internal static void EcrireEnCouleur(string texte, ConsoleColor couleur, bool memeLigne)
    {
        ConsoleColor couleurOriginale = Console.ForegroundColor;
        Console.ForegroundColor = couleur;

        if (memeLigne)
            Console.Write(texte);
        else
            Console.WriteLine(texte);

        Console.ForegroundColor = couleurOriginale;
    }

    internal static void ColorerConsole()
    {
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Clear();

        EcrireEnCouleur($"{DateTime.Now:d}", ConsoleColor.Red, false);
    }
}