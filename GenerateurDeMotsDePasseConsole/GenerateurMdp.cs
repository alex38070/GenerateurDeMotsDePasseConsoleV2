namespace GenerateurDeMotsDePasseConsole;

internal class GenerateurMdp
{
    private List<string> MotDePasseAMixer = new List<string>();
    private Data data = new();

    int nombreDeChoixUtilisateur = 0; // besoin pour la methode modulo
    bool ajoutMinuscule = false;
    bool ajoutMajuscule = false;
    bool ajoutNombre = false;
    bool ajoutSymbole = false;
    string choixUtilisateur = string.Empty;

    public void Lancer()
    {
        GenerateurDeMotDePasse(MotDePasseAMixer);
    }

    private void GenerateurDeMotDePasse(List<string> MotDePasseAMixer)
    {
        do
        {
            ajoutMinuscule = false;
            ajoutMajuscule = false;
            ajoutNombre = false;
            ajoutSymbole = false;

            MotDePasseAMixer.Clear();
            MotDePasseAMixer.Clear();
            int saisieNombre = UtilitairesConsole.DemanderNombre(4, 40); // Choix nombre utilisateur
            int nombreAleatoire = UtilitairesConsole.NombreAleatoire(1, 4); // Choix nombre aleatoire

            ChoixTypesUtilisateur(saisieNombre, MotDePasseAMixer, nombreAleatoire);

            MixerList(nombreAleatoire, saisieNombre);

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
                    MixerList(nombreAleatoire, saisieNombre);
                    MelangerMdp(MotDePasseAMixer);
                }

            } while (choixUtilisateur == "1");

        } while (choixUtilisateur == "2");
        //Environment.Exit(0);
        Console.WriteLine("Merci au revoir");
    }

    private void ChoixTypesUtilisateur(int saisieNombre, List<string> MotDePasseAMixer, int nombreAleatoire)  // interdire jamais o parametre
    {
        bool choixVide = true;
        do
        {
            nombreDeChoixUtilisateur = 0; // besoin pour la methode modulo
            Console.Write("\r\nInclure des lettres minuscules ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                ajoutMinuscule = true;
                nombreDeChoixUtilisateur++;
            }
            Console.Write("Inclure des lettres majuscules ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                ajoutMajuscule = true;
                nombreDeChoixUtilisateur++;
            }
            Console.Write("Inclure des chiffres ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                ajoutNombre = true;
                nombreDeChoixUtilisateur++;
            }
            Console.Write("Inclure des symboles ? (o/n) : ");
            if ((Console.ReadLine() == "o"))
            {
                ajoutSymbole = true;
                nombreDeChoixUtilisateur++;
            }
            choixVide = false;

            if (nombreDeChoixUtilisateur == 0)
            {
                choixVide = true;
                Console.WriteLine("\r\nVeuillez faire au moins un choix : ");
            }

        } while (choixVide);
    }

    public void MixerList(int nombreAleatoire, int saisieNombre)
    {
        int modulo = (saisieNombre % nombreDeChoixUtilisateur);
        int resultat = (nombreDeChoixUtilisateur != 0) ? (saisieNombre / nombreDeChoixUtilisateur) : 1;

        if (ajoutMinuscule)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, resultat));
        if (ajoutMajuscule)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, resultat));
        if (ajoutNombre)
            IntegrerToutesLesListes(MotDePasseAMixer, ElementsAleatoires(data.Nombres, resultat));
        if (ajoutSymbole)
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
