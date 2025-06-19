namespace GenerateurDeMotsDePasseConsoleV2;

// TODO : Je crois qu'on classe, ce n'est jamais au pluriel (+ respecter toutes les conventions de nommages, Classe, Méthode, Propriété, Attribut, Variables, etc.)
internal class GenerateurMotDePasses
{
    // TODO : Tu ne vois pas que la variable est en gris ?
    private readonly Random _random = new(); // readonly impossible de la modifier.
    internal const string lettreMajuscule = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";   // Majuscules
    internal const string lettreMinuscule = "abcdefghijklmnopqrstuvwxyz";   // Minuscules
    internal const string chiffre = "0123456789";                           // Chiffres
    internal const string symbole = "!@#$%^&*_-+=";                         // Symboles

    internal void GenererMotDePasse()
    {
        // TODO : Est ce que c'est possible de ne pas avoir à déclarer ces variables en haut ?
        Critere _critere;
        string choixUtilisateur;

        UtilitairesConsole.AffichageDate();

        do
        {
            int longueur = UtilitairesConsole.DemanderLongueur(4, 40); // Choix nombre utilisateur
            _critere = Critere.DemanderChoixType(longueur);

            do
            {
                List<string> mdp = GenererMotDePasse(_critere);
                AffichageMdp(mdp);

                UtilitairesConsole.ListChoixRejouer();

                choixUtilisateur = UtilitairesConsole.DemanderRejouer();

            } while (choixUtilisateur == "1");

        } while (choixUtilisateur != "3");

        Console.WriteLine("\r\nMerci au revoir");
    }

    private List<string> GenererMotDePasse(Critere _critere)
    {
        Random _random = new();
        List<string> listMotDePasseBrut = [];
        List<string> listMotDePasseParent = [];

        if (_critere.AjoutMajuscule)
        {
            // TODO : Est ce qu'il n'y a pas quelque chose que tu fais systématiquement concernant le random que tu pourrais extraire dans une méthode ?
            listMotDePasseBrut.Add(lettreMajuscule.Substring(_random.Next(lettreMajuscule.Length), 1));
            listMotDePasseParent.Add(lettreMajuscule);
        }

        if (_critere.AjoutMinuscule)
        {
            listMotDePasseBrut.Add(lettreMinuscule.Substring(_random.Next(lettreMajuscule.Length), 1));
            listMotDePasseParent.Add(lettreMajuscule);
        }

        if (_critere.AjoutChiffre)
        {
            listMotDePasseBrut.Add(chiffre.Substring(_random.Next(chiffre.Length), 1));
            listMotDePasseParent.Add(chiffre);
        }

        if (_critere.AjoutSymbole)
        {
            listMotDePasseBrut.Add(symbole.Substring(_random.Next(symbole.Length), 1));
            listMotDePasseParent.Add(symbole);
        }

        // TODO : Intérêt du DO WHILE ?
        do
        {
            string choixList = listMotDePasseParent[_random.Next(listMotDePasseParent.Count)];
            string element = choixList.Substring(_random.Next(choixList.Length), 1);
            listMotDePasseBrut.Add(element);

        } while (listMotDePasseBrut.Count < _critere.Longueur);

        // TODO : Quel est l'intérêt de cette ligne ?
        IOrderedEnumerable<string> motDePasseMelanger = listMotDePasseBrut.OrderBy(item => Random.Shared.Next());

        return listMotDePasseBrut;
    }

    private static void AffichageMdp(List<string> motDePasseMelanger)
    {
        UtilitairesConsole.WriteColor("\r\nLe mot de passe généré est________________: ", ConsoleColor.Blue, true);

        foreach (string CaractereMdp in motDePasseMelanger)
            Console.Write(CaractereMdp); // TODO : Pas de couleur ici ?

        motDePasseMelanger.Clear(); // TODO : Comment s'en passer ?
    }
}