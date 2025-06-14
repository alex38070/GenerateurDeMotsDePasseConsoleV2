//namespace GenerateurDeMotsDePasseConsoleV2;

using GenerateurDeMotsDePasseConsoleV2;

namespace GenerateurDeMotsDePasseConsole;

internal class GenerateurMdp
{

    private int Longueur { get; set; }
    internal bool AjoutMajuscule { get; private set; }
    internal bool AjoutMinuscule { get; private set; }
    internal bool AjoutNombre { get; private set; }
    internal bool AjoutSymbole { get; private set; }
    internal bool ChoixVide { get; private set; }
    internal string ChoixSaisie { get; private set; } = string.Empty;
    internal List<string> ListMotDePasseBrut { get; private set; } = new List<string>();
    internal List<string> ListMotDePasseMixer { get; private set; } = new List<string>();
    internal int NombreDeChoixUtilisateur { get; private set; } = 0; // besoin pour la methode modulo
    internal Random random { get; set; } = new();
    private Data data { get; set; } = new();

    private List<string> MotDePasseAMixer = new List<string>();

    string choixUtilisateur = string.Empty;

    public void Lancer()
    {
        GenerateurDeMotDePasse(MotDePasseAMixer);
    }

    private void GenerateurDeMotDePasse(List<string> MotDePasseAMixer)
    {
        do
        {
            MotDePasseAMixer.Clear();
            MotDePasseAMixer.Clear();
            int nombreAleatoire = UtilitairesConsole.NombreAleatoire(1, 4); // Choix nombre aleatoire
            Critere newMdp = new(Longueur, AjoutMajuscule, AjoutMinuscule, AjoutNombre, AjoutSymbole);
            Longueur = UtilitairesConsole.DemanderNombre(4, 40); // Choix nombre utilisateur

            ChoixTypesUtilisateur(Longueur, MotDePasseAMixer, nombreAleatoire);

            MixerList(nombreAleatoire, Longueur);

            Console.WriteLine();
            MelangerMdp(MotDePasseAMixer);

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
                    MotDePasseAMixer.Clear();
                    MixerList(nombreAleatoire, Longueur);
                    MelangerMdp(MotDePasseAMixer);
                }

            } while (choixUtilisateur == "1");

        } while (choixUtilisateur == "2");
        //Environment.Exit(0);
        Console.WriteLine("Merci au revoir");
    }

    private void ChoixTypesUtilisateur(int saisieNombre, List<string> MotDePasseAMixer, int nombreAleatoire)  // interdire jamais o parametre
    {
        do
        {
            Console.Write("\r\nInclure des lettres minuscules ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                AjoutMinuscule = true;
                NombreDeChoixUtilisateur++;
            }
            Console.Write("Inclure des lettres majuscules ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                AjoutMajuscule = true;
                NombreDeChoixUtilisateur++;
            }
            Console.Write("Inclure des chiffres ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                AjoutNombre = true;
                NombreDeChoixUtilisateur++;
            }
            Console.Write("Inclure des symboles ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                AjoutSymbole = true;
                NombreDeChoixUtilisateur++;
            }
            if (NombreDeChoixUtilisateur == 0)
            {
                ChoixVide = true;
                Console.WriteLine("\r\nVeuillez faire au moins un choix : ");
            }

        } while (ChoixVide);
    }

    public void MixerList(int nombreAleatoire, int saisieNombre)
    {
        int modulo = (saisieNombre % NombreDeChoixUtilisateur);
        int resultat = (NombreDeChoixUtilisateur != 0) ? (saisieNombre / NombreDeChoixUtilisateur) : 1;

        if (AjoutMinuscule)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, resultat));
        if (AjoutMajuscule)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, resultat));
        if (AjoutNombre)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, resultat));
        if (AjoutSymbole)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Symbole, resultat));

        switch (nombreAleatoire)
        {
            case 1:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, modulo));
                break;

            case 2:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, modulo));
                break;

            case 3:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, modulo));
                break;

            case 4:
                IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Symbole, modulo));
                break;
        }
    }

    private List<string> ElementsAleatoires(List<string> ListAleatoire, int nombreMax)
    {
        List<string> ElementsAleatoires = new List<string>();

        for (int i = 0; i < nombreMax; i++)
        {
            int lettreAleatoire = UtilitairesConsole.NombreAleatoire(0, ListAleatoire.Count());
            ElementsAleatoires.Add(ListAleatoire[lettreAleatoire]);
        }
        return ElementsAleatoires;
    }

    private List<string> IntegrerToutesLesListes(List<string> MotDePasseMixer, List<string> ListAleatoire)
    {
        foreach (string Element in ListAleatoire)
        {
            MotDePasseMixer.Add(Element);
        }
        return MotDePasseMixer;
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
}

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
//    public List<string> AjoutPremierElement(Random random)
//    {
//        if (AjoutMajuscule)
//            ListMotDePasseBrut.Add(data.LettreMinuscule[random.Next(1, data.LettreMinuscule.Count())]);
//        if (AjoutMinuscule)
//            ListMotDePasseBrut.Add(data.LettreMajuscule[random.Next(1, data.LettreMajuscule.Count())]);
//        if (AjoutNombre)
//            ListMotDePasseBrut.Add(data.Nombres[random.Next(1, data.Nombres.Count())]);
//        if (AjoutSymbole)
//            ListMotDePasseBrut.Add(data.Symbole[random.Next(1, data.Symbole.Count())]);
//        return ListMotDePasseBrut;
//    }

//    public void AjoutDuReste()
//    {
//        int nombreAleatoire = random.Next(1, 5);

//        int reste = longueur - nombreDeChoixUtilisateur;
//        //int modulo = ()
//        Console.WriteLine(ListMotDePasseBrut.Count);
//        do
//        {
//            UtilitairesConsole.NombreAleatoire(1, 4);
//            if (AjoutMajuscule && nombreAleatoire == 1)
//                ListMotDePasseBrut.Add(data.LettreMinuscule[random.Next(1, data.LettreMinuscule.Count())]);
//            if (AjoutMinuscule && nombreAleatoire == 2)
//                ListMotDePasseBrut.Add(data.LettreMajuscule[random.Next(1, data.LettreMajuscule.Count())]);
//            if (AjoutMinuscule && nombreAleatoire == 3)
//                ListMotDePasseBrut.Add(data.Nombres[random.Next(1, data.Nombres.Count())]);
//            if (AjoutSymbole && nombreAleatoire == 4)
//                ListMotDePasseBrut.Add(data.Symbole[random.Next(1, data.Symbole.Count())]);

//        } while (!(longueur == ListMotDePasseBrut.Count));
//        Console.WriteLine(ListMotDePasseBrut.Count);

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
