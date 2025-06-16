using GenerateurDeMotsDePasseConsoleV2;

namespace GenerateurDeMotsDePasseConsole;

internal class GenerateurMdp
{
    internal bool ChoixVide { get; private set; }
    internal string ChoixSaisie { get; private set; } = string.Empty;
    public List<string> ListMotDePasseBrut { get; private set; } = new List<string>();
    internal int NombreDeChoixUtilisateur { get; private set; } = 0; // besoin pour la methode modulo
    private Data? data { get; set; } = new();
    private Random? random { get; set; } = new();


    //private List<string> MotDePasseAMixer = new List<string>();

    string choixUtilisateur = string.Empty;

    public void Lancer()
    {
        GenerateurDeMotDePasse(ListMotDePasseBrut);
    }

    private void GenerateurDeMotDePasse(List<string> ListMotDePasseBrut)
    {
        do
        {
            int longueur = UtilitairesConsole.DemanderLongueur(4, 40); // Choix nombre utilisateur

            bool ajoutMajuscule = UtilitairesConsole.ChoixAjoutMajuscule();
            bool ajoutMinuscule = UtilitairesConsole.ChoixAjoutMinuscule();
            bool ajoutNombre = UtilitairesConsole.ChoixAjoutchiffres();
            bool ajoutSymbole = UtilitairesConsole.ChoixAjoutSymbole(ajoutMajuscule, ajoutMinuscule, ajoutNombre);

            if (ajoutMajuscule != true && ajoutMinuscule != true && ajoutNombre != true)
                ajoutSymbole = true;

            Critere critere = new(longueur, ajoutMajuscule, ajoutMinuscule, ajoutNombre, ajoutSymbole);

            AjoutPremierElement(random, critere, ListMotDePasseBrut);
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
                choixUtilisateur = UtilitairesConsole.DemanderString();

                if (choixUtilisateur == "1")
                {
                    AjoutPremierElement(random, critere, ListMotDePasseBrut);
                    AjoutDuReste(critere);
                    MelangerMdp(ListMotDePasseBrut);
                }

            } while (choixUtilisateur == "1");

        } while (choixUtilisateur == "2");
        //Environment.Exit(0);
        Console.WriteLine("Merci au revoir");
    }

    public List<string> AjoutPremierElement(Random random, Critere critere, List<string> ListMotDePasseBrut)
    {
        if (critere.AjoutMajuscule)
            ListMotDePasseBrut.Add(data.LettreMinuscule[random.Next(1, data.LettreMinuscule.Count())]);
        if (critere.AjoutMinuscule)
            ListMotDePasseBrut.Add(data.LettreMajuscule[random.Next(1, data.LettreMajuscule.Count())]);
        if (critere.AjoutSymbole)
            ListMotDePasseBrut.Add(data.Nombres[random.Next(1, data.Nombres.Count())]);
        if (critere.AjoutNombre)
            ListMotDePasseBrut.Add(data.Symbole[random.Next(1, data.Symbole.Count())]);
        return ListMotDePasseBrut;
    }

    public void AjoutDuReste(Critere critere)
    {
        int NombreDeChoixUtilisateur = 0;
        if (critere.AjoutMajuscule == true)
            NombreDeChoixUtilisateur++;

        if (critere.AjoutMinuscule == true)
            NombreDeChoixUtilisateur++;

        if (critere.AjoutNombre == true)
            NombreDeChoixUtilisateur++;

        if (critere.AjoutSymbole == true)
            NombreDeChoixUtilisateur++;

        int nombreAleatoire = random.Next(1, 5);

        int reste = critere.Longueur - NombreDeChoixUtilisateur;
        //int modulo = ()
        Console.WriteLine(ListMotDePasseBrut.Count);
        do
        {
            UtilitairesConsole.NombreAleatoire(1, 4);
            if (critere.AjoutMajuscule && nombreAleatoire == 1)
                ListMotDePasseBrut.Add(data.LettreMinuscule[random.Next(1, data.LettreMinuscule.Count())]);
            if (critere.AjoutMinuscule && nombreAleatoire == 2)
                ListMotDePasseBrut.Add(data.LettreMajuscule[random.Next(1, data.LettreMajuscule.Count())]);
            if (critere.AjoutMinuscule && nombreAleatoire == 3)
                ListMotDePasseBrut.Add(data.Nombres[random.Next(1, data.Nombres.Count())]);
            if (critere.AjoutSymbole && nombreAleatoire == 4)
                ListMotDePasseBrut.Add(data.Symbole[random.Next(1, data.Symbole.Count())]);

        } while (!(critere.Longueur == ListMotDePasseBrut.Count));
        Console.WriteLine(ListMotDePasseBrut.Count);
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
//    int modulo = (saisieNombre % NombreDeChoixUtilisateur);
//    int resultat = (NombreDeChoixUtilisateur != 0) ? (saisieNombre / NombreDeChoixUtilisateur) : 1;

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

