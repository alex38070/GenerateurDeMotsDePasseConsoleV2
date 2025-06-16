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

    internal static string DemanderString() // Choix nombre non converti
    {
        while (true)
        {
            string saisie = Console.ReadLine() ?? string.Empty;

            if (saisie != "1" || saisie != "2" || saisie != "3")
                return saisie;
        }
    }

    internal static int NombreAleatoire(int min, int max) // Nombre aleatoire entre min et max
    {
        return Random.Shared.Next(min, max);
    }

    internal static bool ChoixAjoutMajuscule()
    {
        Console.Write("\r\nInclure des lettres majuscules ? (o/n) : ");
        if (Console.ReadLine() == "o")
            return true;
        else return false;
    }
    internal static bool ChoixAjoutMinuscule()
    {
        Console.Write("Inclure des lettres minuscules ? (o/n) : ");
        if (Console.ReadLine() == "o")
            return true;
        else return false;
    }
    internal static bool ChoixAjoutchiffres()
    {
        Console.Write("Inclure des chiffres ? (o/n) : ");
        if (Console.ReadLine() == "o")
            return true;
        else return false;
    }
    internal static bool ChoixAjoutSymbole(bool ajoutMajuscule, bool ajoutMinuscule, bool ajoutNombre)
    {
        if (ajoutMajuscule != true && ajoutMinuscule != true && ajoutNombre != true)
            return true;

        Console.Write("Inclure des symboles ? (o/n) : ");
        if (Console.ReadLine() == "o")
            return true;

        else return false;
    }
}