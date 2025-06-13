namespace GenerateurDeMotsDePasseConsoleV2;

public class Program
{
    private static int longueur { get; set; }
    private static bool AjoutMajuscule { get; set; }
    private static bool AjoutMinuscule { get; set; }
    private static bool AjoutNombre { get; set; }
    private static bool AjoutSymbole { get; set; }
    private static List<string> ListMotDePasseBrut { get; set; } = new List<string>();
    private static List<string> ListMotDePasseMixer { get; set; } = new List<string>();
    public static int nombreDeChoixUtilisateur { get; set; } = 0; // besoin pour la methode modulo
    private static Random random { get; set; } = new();
    private static Data data { get; set; } = new();

    static void Main(string[] args)
    {
        longueur = UtilitairesConsole.DemanderNombre(4, 40);// Choix nombre utilisateur
        Critere critere = new(longueur, AjoutMajuscule, AjoutMinuscule, AjoutNombre, AjoutSymbole);
        ChoixUtilisateur();
        AjoutPremierElement(random);
        MixerList();
        MelangerMdp(ListMotDePasseBrut);
    }

    public static void ChoixUtilisateur()
    {
        bool choixVide = false;

        do
        {

            Console.Write("\r\nInclure des lettres minuscules ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                AjoutMajuscule = true;
                nombreDeChoixUtilisateur++;
            }
            Console.Write("Inclure des lettres majuscules ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                AjoutMinuscule = true;
                nombreDeChoixUtilisateur++;
            }
            Console.Write("Inclure des chiffres ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                AjoutNombre = true;
                nombreDeChoixUtilisateur++;
            }
            Console.Write("Inclure des symboles ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                AjoutSymbole = true;
                nombreDeChoixUtilisateur++;
            }

            if (nombreDeChoixUtilisateur == 0)
            {
                choixVide = true;
                Console.WriteLine("\r\nVeuillez faire au moins un choix : ");
            }
        } while (choixVide);

    }
    public static List<string> AjoutPremierElement(Random random)
    {
        if (AjoutMajuscule)
            ListMotDePasseBrut.Add(data.LettreMinuscule[random.Next(1, data.LettreMinuscule.Count())]);
        if (AjoutMinuscule)
            ListMotDePasseBrut.Add(data.LettreMajuscule[random.Next(1, data.LettreMajuscule.Count())]);
        if (AjoutNombre)
            ListMotDePasseBrut.Add(data.Nombres[random.Next(1, data.Nombres.Count())]);
        if (AjoutSymbole)
            ListMotDePasseBrut.Add(data.Symbole[random.Next(1, data.Symbole.Count())]);
        return ListMotDePasseBrut;
    }

    public static void MixerList()
    {
        for (int i = 0; i < 10; i++)
        {
            if (AjoutMajuscule)
                ListMotDePasseBrut.Add(data.LettreMinuscule[random.Next(1, data.LettreMinuscule.Count())]);
        }
    }

    private List<string> IntegrerToutesLesListes(List<string> MotDePasseMixer, List<string> ListAleatoire)
    {
        foreach (string Element in ListAleatoire)
        {
            MotDePasseMixer.Add(Element);
        }
        return MotDePasseMixer;
    }

    public static List<string> ElementsAleatoires(List<string> ListAleatoire, int nombreMax, int nombreDeChoixUtilisateur)
    {
        List<string> ElementsAleatoires = new List<string>();

        for (int i = 0; i < nombreMax; i++)
        {
            int lettreAleatoire = UtilitairesConsole.NombreAleatoire(0, ListAleatoire.Count());
            ElementsAleatoires.Add(ListAleatoire[lettreAleatoire]);
        }
        return ElementsAleatoires;
    }

    public static void MelangerMdp(List<string> motDePasseAMixer)
    {
        IOrderedEnumerable<string> motDePasseMelanger = motDePasseAMixer.OrderBy(item => Random.Shared.Next());
        Console.Write("Le mot de passe généré est : ");
        foreach (string CaractereMdp in motDePasseMelanger)
        {
            Console.Write(CaractereMdp);

        }
    }


}