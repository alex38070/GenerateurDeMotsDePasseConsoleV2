using GenerateurDeMotsDePasseConsoleV2;

namespace GenerateurDeMotsDePasseConsole;

internal class GenerateurMdp
{
    //internal bool ChoixVide { get; private set; }
    //internal string ChoixSaisie { get; private set; } = string.Empty;
    //internal int NombreDeChoixUtilisateur { get; private set; } = 0; // besoin pour la methode modulo
    //private List<string> MotDePasseAMixer = new List<string>();

    public List<string> _listMotDePasseBrut = new();
    private readonly Data? _data = new(); // readonly impossible de la modifier.
    private readonly Random? _random = new(); // readonly impossible de la modifier.
    string _choixUtilisateur = string.Empty;


    public void Lancer()
    {
        GenerateurDeMotDePasse(_listMotDePasseBrut);
    }

    private void GenerateurDeMotDePasse(List<string> ListMotDePasseBrut)
    {
        do
        {

            int longueur = UtilitairesConsole.DemanderLongueur(4, 40); // Choix nombre utilisateur

            bool ajoutMajuscule = UtilitairesConsole.DemanderOuiNon("Inclure des lettres majuscules ? (o/n) : ");
            bool ajoutMinuscule = UtilitairesConsole.DemanderOuiNon("Inclure des lettres minuscules ? (o/n) : ");
            bool ajoutChiffre = UtilitairesConsole.DemanderOuiNon("Inclure des chiffres ? (o/n) : ");
            bool ajoutSymbole = UtilitairesConsole.DemanderOuiNon("Inclure des symboles ? (o/n) : ");

            Critere critere = new(longueur, ajoutMajuscule, ajoutMinuscule, ajoutChiffre, ajoutSymbole);

            AjoutPremierElement(_random, critere, ListMotDePasseBrut);
            AjoutDuReste(critere);
            MelangerMdp(ListMotDePasseBrut);

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
                    AjoutPremierElement(_random, critere, ListMotDePasseBrut);
                    AjoutDuReste(critere);
                    MelangerMdp(ListMotDePasseBrut);
                }

            } while (_choixUtilisateur == "1");

        } while (_choixUtilisateur == "2");
        //Environment.Exit(0);
        Console.WriteLine("Merci au revoir");
    }

    public List<string> AjoutPremierElement(Random random, Critere critere, List<string> ListMotDePasseBrut)
    {
        if (critere.AjoutMajuscule)
            ListMotDePasseBrut.Add(_data.LettreMajuscule[random.Next(1, _data.LettreMajuscule.Count())]);
        if (critere.AjoutMinuscule)
            ListMotDePasseBrut.Add(_data.LettreMinuscule[random.Next(1, _data.LettreMinuscule.Count())]);
        if (critere.AjoutChiffre)
            ListMotDePasseBrut.Add(_data.Nombres[random.Next(1, _data.Nombres.Count())]);
        if (critere.AjoutSymbole)
            ListMotDePasseBrut.Add(_data.Symbole[random.Next(1, _data.Symbole.Count())]);
        return ListMotDePasseBrut;
    }

    public List<string> AjoutDuReste(Critere critere)
    {
        if (critere.AjoutMajuscule == true)
            _listMotDePasseBrut.Add(_data.LettreMajuscule[_random.Next(1, _data.LettreMajuscule.Count())]);

        if (critere.AjoutMinuscule == true)
            _listMotDePasseBrut.Add(_data.LettreMinuscule[_random.Next(1, _data.LettreMinuscule.Count())]);

        if (critere.AjoutChiffre == true)
            _listMotDePasseBrut.Add(_data.Nombres[_random.Next(1, _data.Nombres.Count())]);

        if (critere.AjoutSymbole == true)
            _listMotDePasseBrut.Add(_data.Symbole[_random.Next(1, _data.Symbole.Count())]);

        return _listMotDePasseBrut;
        //if (critere.AjoutMajuscule)
        //if (critere.AjoutMinuscule)
        //    _listMotDePasseBrut.Add(data.LettreMajuscule[random.Next(1, data.LettreMajuscule.Count())]);
        //if (critere.AjoutSymbole)
        //    _listMotDePasseBrut.Add(data.Nombres[random.Next(1, data.Nombres.Count())]);
        //if (critere.AjoutChiffre)
        //    _listMotDePasseBrut.Add(data.Symbole[random.Next(1, data.Symbole.Count())]);
    }

    private void MelangerMdp(List<string> MotDePasseAMixer)
    {
        IOrderedEnumerable<string> motDePasseMelanger = MotDePasseAMixer.OrderBy(item => Random.Shared.Next());
        Console.Write("Le mot de passe généré est : ");
        foreach (string CaractereMdp in motDePasseMelanger)
        {
            Console.Write(CaractereMdp);

        }
        MotDePasseAMixer.Clear(); // TODO : A verifier si je peut retirer!
    }


    //public void ChoixTypesUtilisateur(Critere critere)
    //{
    //    
    //}
}

//public void MixerList(int saisieNombre, Critere critere)
//{

//    if (critere.AjoutMinuscule)
//        IntegrerToutesLesListes(ListMotDePasseBrut, ElementsAleatoires(data.LettreMinuscule, resultat));
//    if (critere.AjoutMajuscule)
//        IntegrerToutesLesListes(ListMotDePasseBrut, ElementsAleatoires(data.LettreMajuscule, resultat));
//    if (critere.AjoutNombre)
//        IntegrerToutesLesListes(ListMotDePasseBrut, ElementsAleatoires(data.Nombres, resultat));
//    if (critere.AjoutSymbole)
//        IntegrerToutesLesListes(ListMotDePasseBrut, ElementsAleatoires(data.Symbole, resultat));

//    switch (nombreAleatoire)
//    {
//        case 1:
//            IntegrerToutesLesListes(ListMotDePasseBrut, ElementsAleatoires(data.LettreMinuscule, modulo));
//            break;

//        case 2:
//            IntegrerToutesLesListes(ListMotDePasseBrut, ElementsAleatoires(data.LettreMajuscule, modulo));
//            break;

//        case 3:
//            IntegrerToutesLesListes(ListMotDePasseBrut, ElementsAleatoires(data.Nombres, modulo));
//            break;

//        case 4:
//            IntegrerToutesLesListes(ListMotDePasseBrut, ElementsAleatoires(data.Symbole, modulo));
//            break;
//    }
//}

//    private List<string> ElementsAleatoires(List<string> ListAleatoire, int nombreMax)
//    {
//        List<string> ElementsAleatoires = new List<string>();

//        for (int i = 0; i < nombreMax; i++)
//        {
//            int lettreAleatoire = UtilitairesConsole.NombreAleatoire(0, ListAleatoire.Count());
//            ElementsAleatoires.Add(ListAleatoire[lettreAleatoire]);
//        }
//        return ElementsAleatoires;
//    }

//    private List<string> IntegrerToutesLesListes(List<string> MotDePasseMixer, List<string> ListAleatoire)
//    {
//        foreach (string Element in ListAleatoire)
//        {
//            MotDePasseMixer.Add(Element);
//        }
//        return MotDePasseMixer;
//    }


//public class GenerateurMdp
//{
//    private int longueur { get; set; }
//    internal bool AjoutMajuscule { get; private set; }
//    internal bool AjoutMinuscule { get; private set; }
//    internal bool AjoutNombre { get; private set; }
//    internal bool AjoutSymbole { get; private set; }
//    internal bool choixVide { get; private set; }
//    internal string ChoixSaisie { get; private set; } = string.Empty;

//    internal List<string> ListMotDePasseBrut { get; private set; } = new List<string>();
//    internal List<string> ListMotDePasseMixer { get; private set; } = new List<string>();
//    internal int nombreDeChoixUtilisateur { get; private set; } = 0; // besoin pour la methode modulo
//    internal Random random { get; set; } = new();
//    private Data data { get; set; } = new();

//    public void Lancer()
//    {
//        GenerateurDeMotDePasse();
//    }

//    public void GenerateurDeMotDePasse()
//    {
//        do
//        {
//            ListMotDePasseBrut.Clear();
//            longueur = UtilitairesConsole.DemanderNombre(4, 40);// Choix nombre utilisateur
//            Critere newMdp = new(longueur, AjoutMajuscule, AjoutMinuscule, AjoutNombre, AjoutSymbole);
//            ChoixUtilisateur();
//            AjoutPremierElement(random);
//            AjoutDuReste();
//            MelangerMdp(ListMotDePasseBrut);
//            do
//            {
//                Console.WriteLine();
//                Console.WriteLine("\r\nSouhaitez-vous générer un nouveau mot de passe ?\r\n");
//                Console.WriteLine("1. Oui, avec les mêmes critères");
//                Console.WriteLine("2. Oui, avec de nouveaux critères");
//                Console.WriteLine("3. Non, quitter l'application");

//                Console.Write("\r\nChoix : ");
//                ChoixSaisie = UtilitairesConsole.DemanderString();
//                if (ChoixSaisie == "1")
//                {
//                    ListMotDePasseBrut.Clear();
//                    AjoutPremierElement(random);
//                    AjoutDuReste();
//                    MelangerMdp(ListMotDePasseBrut);
//                }

//            } while (ChoixSaisie == "1");

//        } while (ChoixSaisie == "2");
//        Console.WriteLine("Merci au revoir");
//    }

//    public void ChoixUtilisateur()
//    {
//        do
//        {
//            ListMotDePasseBrut.Clear();
//            choixVide = false;
//            nombreDeChoixUtilisateur = 0;
//            Console.Write("\r\nInclure des lettres minuscules ? (o/n) : ");
//            if ((Console.ReadLine() == "o"))
//            {
//                AjoutMajuscule = true;
//                nombreDeChoixUtilisateur++;
//            }
//            Console.Write("Inclure des lettres majuscules ? (o/n) : ");
//            if ((Console.ReadLine() == "o"))
//            {
//                AjoutMinuscule = true;
//                nombreDeChoixUtilisateur++;
//            }
//            Console.Write("Inclure des chiffres ? (o/n) : ");
//            if ((Console.ReadLine() == "o"))
//            {
//                AjoutNombre = true;
//                nombreDeChoixUtilisateur++;
//            }
//            Console.Write("Inclure des symboles ? (o/n) : ");
//            if ((Console.ReadLine() == "o"))
//            {
//                AjoutSymbole = true;
//                nombreDeChoixUtilisateur++;
//            }

//            if (nombreDeChoixUtilisateur == 0)
//            {
//                choixVide = true;
//                Console.WriteLine("\r\nVeuillez faire au moins un choix : ");
//            }
//        } while (choixVide);

//    }


//    public void MelangerMdp(List<string> ListMotDePasseBrut)
//    {
//        IOrderedEnumerable<string> motDePasseMelanger = ListMotDePasseBrut.OrderBy(item => Random.Shared.Next());
//        Console.Write("Le mot de passe généré est : ");
//        foreach (string CaractereMdp in motDePasseMelanger)
//        {
//            Console.Write(CaractereMdp);

//        }
//    }
//}

