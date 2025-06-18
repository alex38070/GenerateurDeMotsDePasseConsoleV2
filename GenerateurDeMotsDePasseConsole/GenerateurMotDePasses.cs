namespace GenerateurDeMotsDePasseConsoleV2;
internal class GenerateurMotDePasses
{
    private readonly Random _random = new(); // readonly impossible de la modifier.

    internal List<string> lettreMinuscule = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"];

    internal List<string> lettreMajuscule = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];

    internal List<string> chiffre = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

    internal List<string> symbole = ["/", "!", "+", "?", "&", "$", "<", "=", ">"];

    internal void GenererMotDePasse()
    {
        Critere _critere;

        string choixUtilisateur;
        UtilitairesConsole.AffichageDate();

        do
        {
            int longueur = UtilitairesConsole.DemanderLongueur(4, 40); // Choix nombre utilisateur
            _critere = Critere.DemanderChoixType(longueur);

            do
            {
                AffichageMdp(GenererMotDePasseEtRetourListMelanger(_critere));
                UtilitairesConsole.ListChoixRejouer();

                choixUtilisateur = UtilitairesConsole.DemanderRejouer();

            } while (choixUtilisateur == "1");

        } while (choixUtilisateur != "3");

        Console.WriteLine("\r\nMerci au revoir");
    }

    private List<string> GenererMotDePasseEtRetourListMelanger(Critere _critere)
    {
        Random _random = new();
        List<string> listMotDePasseBrut = [];
        List<List<string>> listMotDePasseParent = [];

        if (_critere.AjoutMajuscule)
        {
            listMotDePasseBrut.Add(lettreMajuscule[_random.Next(lettreMajuscule.Count)]);
            listMotDePasseParent.Add(lettreMajuscule);
        }

        if (_critere.AjoutMinuscule)
        {
            listMotDePasseBrut.Add(lettreMinuscule[_random.Next(lettreMinuscule.Count)]);
            listMotDePasseParent.Add(lettreMinuscule);
        }

        if (_critere.AjoutChiffre)
        {
            listMotDePasseBrut.Add(chiffre[_random.Next(chiffre.Count)]);
            listMotDePasseParent.Add(chiffre);
        }

        if (_critere.AjoutSymbole)
        {
            listMotDePasseBrut.Add(symbole[_random.Next(symbole.Count)]);
            listMotDePasseParent.Add(symbole);
        }

        do
        {
            List<string> choixList = listMotDePasseParent[_random.Next(listMotDePasseParent.Count)];
            string element = choixList[_random.Next(choixList.Count)];
            listMotDePasseBrut.Add(element);

        } while (listMotDePasseBrut.Count < _critere.Longueur);

        IOrderedEnumerable<string> motDePasseMelanger = listMotDePasseBrut.OrderBy(item => Random.Shared.Next());

        return listMotDePasseBrut;
    }

    private static void AffichageMdp(List<string> motDePasseMelanger)
    {
        UtilitairesConsole.WriteColor("\r\nLe mot de passe généré est________________: ", ConsoleColor.Blue, true);

        foreach (string CaractereMdp in motDePasseMelanger)
            Console.Write(CaractereMdp);

        motDePasseMelanger.Clear();
    }
}