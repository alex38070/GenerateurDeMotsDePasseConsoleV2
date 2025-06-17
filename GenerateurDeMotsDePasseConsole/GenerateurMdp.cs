namespace GenerateurDeMotsDePasseConsoleV2;
internal class GenerateurMdp
{
    private readonly Data _data = new(); // readonly impossible de la modifier.
    private readonly Random _random = new(); // readonly impossible de la modifier.

    internal void Lancer()
    {
        Console.BackgroundColor = ConsoleColor.Cyan;
        DateTime dat = DateTime.Now;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("{0:d}\n", dat);

        string _choixUtilisateur;
        List<string> _listMotDePasseBrut = [];

        do
        {
            int longueur = UtilitairesConsole.DemanderLongueur(4, 40); // Choix nombre utilisateur
            bool ajoutMajuscule;
            bool ajoutMinuscule;
            bool ajoutChiffre;
            bool ajoutSymbole;
            do
            {
                ajoutMajuscule = UtilitairesConsole.DemanderOuiNon("Inclure des lettres majuscules ?____(o/n) : ");
                ajoutMinuscule = UtilitairesConsole.DemanderOuiNon("Inclure des lettres minuscules ?____(o/n) : ");
                ajoutChiffre = UtilitairesConsole.DemanderOuiNon("Inclure des chiffres ?______________(o/n) : ");
                ajoutSymbole = UtilitairesConsole.DemanderOuiNon("Inclure des symboles ?______________(o/n) : ");

            } while (ajoutMajuscule == false && ajoutMinuscule == false && ajoutChiffre == false && ajoutSymbole == false);

            Critere _critere = new(longueur, ajoutMajuscule, ajoutMinuscule, ajoutChiffre, ajoutSymbole);
            AjoutPremierElement(_random, _critere, _listMotDePasseBrut);
            AjoutDuReste(_critere, _random, _listMotDePasseBrut);
            MelangerMdp(_listMotDePasseBrut);
            AffichageMdp(_listMotDePasseBrut);

            do
            {
                Console.WriteLine();
                UtilitairesConsole.WriteColor("\r\nSouhaitez-vous générer un nouveau mot de passe ?\r\n", ConsoleColor.Blue, true);
                UtilitairesConsole.WriteColor("1. Oui, avec les mêmes critères", ConsoleColor.Blue, false);
                UtilitairesConsole.WriteColor("2. Oui, avec de nouveaux critères", ConsoleColor.Blue, false);
                UtilitairesConsole.WriteColor("3. Non, quitter l'application", ConsoleColor.Blue, false);

                UtilitairesConsole.WriteColor("\r\nChoix_____________________________________: ", ConsoleColor.Blue, true);
                _choixUtilisateur = UtilitairesConsole.DemanderRejouer();

                if (_choixUtilisateur == "1")
                {
                    AjoutPremierElement(_random, _critere, _listMotDePasseBrut);
                    AjoutDuReste(_critere, _random, _listMotDePasseBrut);
                    MelangerMdp(_listMotDePasseBrut);
                    AffichageMdp(_listMotDePasseBrut);
                }

            } while (_choixUtilisateur == "1");

        } while (_choixUtilisateur == "2");

        Console.WriteLine("\r\nMerci au revoir");
    }

    private List<string> AjoutPremierElement(Random _random, Critere critere, List<string> _listMotDePasseBrut)
    {

        if (critere.AjoutMajuscule)
            _listMotDePasseBrut.Add(_data.lettreMajuscule[_random.Next(_data.lettreMajuscule.Count)]);

        if (critere.AjoutMinuscule)
            _listMotDePasseBrut.Add(_data.lettreMinuscule[_random.Next(_data.lettreMinuscule.Count)]);

        if (critere.AjoutChiffre)
            _listMotDePasseBrut.Add(_data.chiffre[_random.Next(_data.chiffre.Count)]);

        if (critere.AjoutSymbole)
            _listMotDePasseBrut.Add(_data.symbole[_random.Next(_data.symbole.Count)]);

        return _listMotDePasseBrut;
    }

    private List<string> AjoutDuReste(Critere critere, Random _random, List<string> _listMotDePasseBrut)
    {
        List<List<string>> _listMotDePasseParent = [];

        if (critere.AjoutMajuscule)
            _listMotDePasseParent.Add(_data.lettreMajuscule);

        if (critere.AjoutMinuscule)
            _listMotDePasseParent.Add(_data.lettreMinuscule);

        if (critere.AjoutChiffre)
            _listMotDePasseParent.Add(_data.chiffre);

        if (critere.AjoutSymbole)
            _listMotDePasseParent.Add(_data.symbole);

        do
        {
            List<string> choixList = _listMotDePasseParent[_random.Next(_listMotDePasseParent.Count)];

            string element = choixList[_random.Next(choixList.Count)];

            _listMotDePasseBrut.Add(element);

        } while (_listMotDePasseBrut.Count < critere.Longueur);

        return _listMotDePasseBrut;
    }

    private static void MelangerMdp(List<string> MotDePasseAMixer)
    {
        IOrderedEnumerable<string> motDePasseMelanger = MotDePasseAMixer.OrderBy(item => Random.Shared.Next());
    }

    private static void AffichageMdp(List<string> motDePasseMelanger)
    {
        UtilitairesConsole.WriteColor("\r\nLe mot de passe généré est________________: ", ConsoleColor.Blue, true);

        foreach (string CaractereMdp in motDePasseMelanger)
            Console.Write(CaractereMdp);

        motDePasseMelanger.Clear();
    }
}