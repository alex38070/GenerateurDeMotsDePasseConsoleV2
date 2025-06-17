namespace GenerateurDeMotsDePasseConsoleV2;
internal class GenerateurMdp
{
    private readonly Data _data = new(); // readonly impossible de la modifier.
    private readonly Random _random = new(); // readonly impossible de la modifier.
    private readonly List<string> _listMotDePasseBrut = [];

    public void Lancer()
    {
        GenerateurDeMotDePasse();
    }

    private void GenerateurDeMotDePasse()
    {
        bool ajoutMajuscule = false;
        bool ajoutMinuscule = false;
        bool ajoutChiffre = false;
        bool ajoutSymbole = false;
        string _choixUtilisateur = string.Empty;

        int longueur = UtilitairesConsole.DemanderLongueur(4, 40); // Choix nombre utilisateur

        do
        {
            ajoutMajuscule = UtilitairesConsole.DemanderOuiNon("Inclure des lettres majuscules ? (o/n) : ");
            ajoutMinuscule = UtilitairesConsole.DemanderOuiNon("Inclure des lettres minuscules ? (o/n) : ");
            ajoutChiffre = UtilitairesConsole.DemanderOuiNon("     Inclure des chiffres ?      (o/n) : ");
            ajoutSymbole = UtilitairesConsole.DemanderOuiNon("     Inclure des symboles ?      (o/n) : ");

            //Console.WriteLine(ajoutMajuscule);
            //Console.WriteLine(ajoutMinuscule);
            //Console.WriteLine(ajoutChiffre);
            //Console.WriteLine(ajoutSymbole);

        } while (ajoutMajuscule == false && ajoutMinuscule == false && ajoutChiffre == false && ajoutSymbole == false);
        Critere critere = new(longueur, ajoutMajuscule, ajoutMinuscule, ajoutChiffre, ajoutSymbole);

        do
        {
            AjoutPremierElement(_random, critere, _listMotDePasseBrut);
            AjoutDuReste(critere, _random);
            MelangerMdp(_listMotDePasseBrut);
            AffichageMdp(_listMotDePasseBrut);

            do
            {
                Console.WriteLine();
                Console.WriteLine("\r\nSouhaitez-vous générer un nouveau mot de passe ?\r\n");
                Console.WriteLine("1. Oui, avec les mêmes critères");
                Console.WriteLine("2. Oui, avec de nouveaux critères");
                Console.WriteLine("3. Non, quitter l'application");

                Console.Write("\r\nChoix : ");
                _choixUtilisateur = UtilitairesConsole.DemanderRejouer();

                if (_choixUtilisateur == "1")
                {
                    AjoutPremierElement(_random, critere, _listMotDePasseBrut);
                    AjoutDuReste(critere, _random);
                    MelangerMdp(_listMotDePasseBrut);
                    AffichageMdp(_listMotDePasseBrut);
                }

            } while (_choixUtilisateur == "1");

        } while (_choixUtilisateur == "2");
        Console.WriteLine("\r\nMerci au revoir");
    }

    private List<string> AjoutPremierElement(Random random, Critere critere, List<string> _listMotDePasseBrut)
    {
        if (critere.AjoutMajuscule)
            _listMotDePasseBrut.Add(_data.LettreMajuscule[_random.Next(1, _data.LettreMajuscule.Count())]);

        if (critere.AjoutMinuscule)
            _listMotDePasseBrut.Add(_data.LettreMinuscule[_random.Next(1, _data.LettreMinuscule.Count())]);

        if (critere.AjoutChiffre)
            _listMotDePasseBrut.Add(_data.Nombres[_random.Next(1, _data.Nombres.Count())]);

        if (critere.AjoutSymbole)
            _listMotDePasseBrut.Add(_data.Symbole[_random.Next(1, _data.Symbole.Count())]);

        return _listMotDePasseBrut;
    }

    private List<string> AjoutDuReste(Critere critere, Random _random)
    {
        List<string> _listMotDePasseParent = new();

        if (critere.AjoutMajuscule)
            _listMotDePasseParent.AddRange(_data.LettreMajuscule);

        if (critere.AjoutMinuscule)
            _listMotDePasseParent.AddRange(_data.LettreMinuscule);

        if (critere.AjoutChiffre)
            _listMotDePasseParent.AddRange(_data.Nombres);

        if (critere.AjoutSymbole)
            _listMotDePasseParent.AddRange(_data.Symbole);

        do
        {
            _listMotDePasseBrut.Add(_listMotDePasseParent[_random.Next(1, _listMotDePasseParent.Count())]);

        } while (_listMotDePasseBrut.Count != critere.Longueur);

        return _listMotDePasseBrut;
    }

    private void MelangerMdp(List<string> MotDePasseAMixer)
    {
        IOrderedEnumerable<string> motDePasseMelanger = MotDePasseAMixer.OrderBy(item => Random.Shared.Next());
    }

    private void AffichageMdp(List<string> motDePasseMelanger)
    {
        Console.Write("\r\nLe mot de passe généré est : ");

        foreach (string CaractereMdp in motDePasseMelanger)
            Console.Write(CaractereMdp);

        motDePasseMelanger.Clear(); // TODO : A verifier si je peut retirer!
    }

}