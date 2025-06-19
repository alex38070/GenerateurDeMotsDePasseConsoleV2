namespace GenerateurDeMotsDePasseConsoleV2;

internal class GenerateurMotDePasse
{
    private const string _lettreMajuscule = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";   // Majuscules
    private const string _lettreMinuscule = "abcdefghijklmnopqrstuvwxyz";   // Minuscules
    private const string _chiffre = "0123456789";                           // Chiffres
    private const string _symbole = "!@#$%^&*_-+=";                         // Symboles
    private readonly Random _random = new();
    private Critere? _critere;

    internal void Lancer()
    {
        string choixUtilisateur;

        do
        {
            int longueur = UtilitaireConsole.DemanderEntierDansIntervalle("Longueur du mot de passe souhaitée", 4, 40); // Choix nombre utilisateur
            _critere = DemanderTypeCaractere(longueur);

            do
            {
                List<string> mdp = GenererMotDePasse(_critere);
                AffichagerMdp(mdp);

                choixUtilisateur = UtilitaireConsole.DemanderRejouer();

            } while (choixUtilisateur == "1");

        } while (choixUtilisateur != "3");

        UtilitaireConsole.EcrireEnCouleur("\r\nMerci au revoir", ConsoleColor.Red, true);
    }

    private List<string> GenererMotDePasse(Critere _critere)
    {
        List<string> listMotDePasseBrut = [];
        List<string> listMotDePasseParent = [];

        if (_critere.AjoutMajuscule)
        {
            listMotDePasseBrut.Add(ChoisirElementAleatoire(_lettreMajuscule));
            listMotDePasseParent.Add(_lettreMajuscule);
        }

        if (_critere.AjoutMinuscule)
        {
            listMotDePasseBrut.Add(ChoisirElementAleatoire(_lettreMinuscule));
            listMotDePasseParent.Add(_lettreMinuscule);
        }

        if (_critere.AjoutChiffre)
        {
            listMotDePasseBrut.Add(ChoisirElementAleatoire(_chiffre));
            listMotDePasseParent.Add(_chiffre);
        }

        if (_critere.AjoutSymbole)
        {
            listMotDePasseBrut.Add(ChoisirElementAleatoire(_symbole));
            listMotDePasseParent.Add(_symbole);
        }

        while (listMotDePasseBrut.Count < _critere.Longueur)
        {
            string choixList = listMotDePasseParent[_random.Next(listMotDePasseParent.Count)];
            string element = choixList.Substring(_random.Next(choixList.Length), 1);
            listMotDePasseBrut.Add(element);
        }

        List<string> motDePasseMelanger = listMotDePasseBrut.OrderBy(item => _random.Next()).ToList();

        return motDePasseMelanger;
    }

    private static Critere DemanderTypeCaractere(int longueur)
    {
        while (true)
        {
            bool ajoutMajuscule = UtilitaireConsole.DemanderOuiNon("\r\nInclure des lettres majuscules ?____(o/n) : ");
            bool ajoutMinuscule = UtilitaireConsole.DemanderOuiNon("Inclure des lettres minuscules ?____(o/n) : ");
            bool ajoutChiffre = UtilitaireConsole.DemanderOuiNon("Inclure des chiffres ?______________(o/n) : ");
            bool ajoutSymbole = UtilitaireConsole.DemanderOuiNon("Inclure des symboles ?______________(o/n) : ");

            if (ajoutMajuscule || ajoutMinuscule || ajoutChiffre || ajoutSymbole)
                return new(longueur, ajoutMajuscule, ajoutMinuscule, ajoutChiffre, ajoutSymbole);
        }
    }

    private string ChoisirElementAleatoire(string texte)
        => texte.Substring(_random.Next(texte.Length), 1);

    private static void AffichagerMdp(List<string> motDePasseMelanger)
    {
        UtilitaireConsole.EcrireEnCouleur("\r\nLe mot de passe généré est________________: ", ConsoleColor.Blue, true);

        foreach (string caractereMdp in motDePasseMelanger)
            UtilitaireConsole.EcrireEnCouleur(caractereMdp, ConsoleColor.Red, true);
    }
}