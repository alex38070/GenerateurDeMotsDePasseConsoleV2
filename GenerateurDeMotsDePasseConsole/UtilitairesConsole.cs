namespace GenerateurDeMotsDePasseConsoleV2;

internal static class UtilitairesConsole
{
    // TODO : Tu peux t'inspirer de DemanderOuiNon et améliorer cette méthode pour qu'elle soit plus générique dans son nom et dans son algo
    internal static int DemanderLongueur(int min, int max) // Choix nombre utilisateur
    {
        while (true)
        {
            WriteColor($"\r\nLongueur du mot de passe souhaitée ({min}-{max}) : ", ConsoleColor.Blue, true);
            string saisie = Console.ReadLine() ?? string.Empty;

            if (int.TryParse(saisie, out int nombre) && nombre >= min && nombre <= max)
                return nombre;
        }
    }

    internal static bool DemanderOuiNon(string message)
    {
        WriteColor(message, ConsoleColor.Blue, true);
        string saisie = Console.ReadLine() ?? string.Empty;

        // TODO : Tu peux retirer le || comment faire ?
        return (saisie == "o" || saisie == "O");
    }

    internal static void ListChoixRejouer()
    {
        Console.WriteLine();
        WriteColor("Souhaitez-vous générer un nouveau mot de passe ?", ConsoleColor.Blue, true);
        WriteColor("1. Oui, avec les mêmes critères", ConsoleColor.Blue, false);
        WriteColor("2. Oui, avec de nouveaux critères", ConsoleColor.Blue, false);
        WriteColor("3. Non, quitter l'application", ConsoleColor.Blue, false);
        WriteColor("Choix_____________________________________: ", ConsoleColor.Blue, true);
    }

    internal static string DemanderRejouer() // Choix nombre non converti
    {
        while (true)
        {
            string saisie = Console.ReadLine() ?? string.Empty;

            // TODO : Il y a une anomalie ici, à ton avis laquelle ? Comment corriger ?
            if (saisie != "1" || saisie != "2" || saisie != "3")
                return saisie;
        }
    }

    internal static void WriteColor(string texte, ConsoleColor couleur, bool retourLigne)
    {
        ConsoleColor couleurOriginale = Console.ForegroundColor;
        Console.ForegroundColor = couleur;

        // TODO : Que faire dans le cas d'une condition simple ?
        if (retourLigne)
            Console.Write(texte);
        else Console.WriteLine(texte);

        Console.ForegroundColor = couleurOriginale;
    }

    // TODO : Tu n'exploites pas la méthode faite pour cela, WriteColor()
    internal static void AffichageDate()
    {
        DateTime date = DateTime.Now;
        Console.BackgroundColor = ConsoleColor.Cyan;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0:d}", date);
    }
}