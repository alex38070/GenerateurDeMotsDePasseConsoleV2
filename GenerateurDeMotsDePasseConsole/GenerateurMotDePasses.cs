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
        string _choixUtilisateur;
        Critere _critere;
        UtilitairesConsole.AffichageDate();

        do
        {
            int longueur = UtilitairesConsole.DemanderLongueur(4, 40); // Choix nombre utilisateur
            _critere = Critere.DemanderChoixType(longueur);

            do
            {
                AffichageMdp(GenererMotDePasseEtRetourListMelanger(_critere));
                UtilitairesConsole.ListChoixRejouer();

                _choixUtilisateur = UtilitairesConsole.DemanderRejouer();

            } while (_choixUtilisateur == "1");

        } while (_choixUtilisateur != "3");

        Console.WriteLine("\r\nMerci au revoir");
    }

    private List<string> GenererMotDePasseEtRetourListMelanger(Critere critere)
    {
        Random _random = new();
        List<string> _listMotDePasseBrut = [];
        List<List<string>> _listMotDePasseParent = [];

        if (critere.AjoutMajuscule)
        {
            _listMotDePasseBrut.Add(lettreMajuscule[_random.Next(lettreMajuscule.Count)]);
            _listMotDePasseParent.Add(lettreMajuscule);
        }

        if (critere.AjoutMinuscule)
        {
            _listMotDePasseBrut.Add(lettreMinuscule[_random.Next(lettreMinuscule.Count)]);
            _listMotDePasseParent.Add(lettreMinuscule);
        }

        if (critere.AjoutChiffre)
        {
            _listMotDePasseBrut.Add(chiffre[_random.Next(chiffre.Count)]);
            _listMotDePasseParent.Add(chiffre);
        }

        if (critere.AjoutSymbole)
        {
            _listMotDePasseBrut.Add(symbole[_random.Next(symbole.Count)]);
            _listMotDePasseParent.Add(symbole);
        }

        do
        {
            List<string> choixList = _listMotDePasseParent[_random.Next(_listMotDePasseParent.Count)];

            string element = choixList[_random.Next(choixList.Count)];

            _listMotDePasseBrut.Add(element);

        } while (_listMotDePasseBrut.Count < critere.Longueur);

        IOrderedEnumerable<string> motDePasseMelanger = _listMotDePasseBrut.OrderBy(item => Random.Shared.Next());

        return _listMotDePasseBrut;
    }

    private static void AffichageMdp(List<string> motDePasseMelanger)
    {
        UtilitairesConsole.WriteColor("\r\nLe mot de passe généré est________________: ", ConsoleColor.Blue, true);

        foreach (string CaractereMdp in motDePasseMelanger)
            Console.Write(CaractereMdp);

        motDePasseMelanger.Clear();
    }

}
