namespace GenerateurDeMotsDePasseConsoleV2;

internal class GenerateurMdp
{
    private List<string> motDePasseAMixer = new List<string>();
    private Data data = new();
    Random random = new();

    int nombreDeChoixUtilisateur = 0; // besoin pour la methode modulo
    string choixUtilisateur = string.Empty;

    //public void Lancer()
    //{
    //    GenerateurDeMotDePasse(motDePasseAMixer);
    //}

    //private void GenerateurDeMotDePasse(List<string> MotDePasseAMixer)
    //{
    //    do
    //    {
    //        int saisieNombre = UtilitairesConsole.DemanderNombre(4, 40); // Choix nombre utilisateur
    //        AjoutPremierElement(random);
    //        AjoutElementsAleatoire(saisieNombre, nombreDeChoixUtilisateur);
    //        MelangerMdp(MotDePasseAMixer);

    //        do
    //        {
    //            Console.WriteLine();
    //            Console.WriteLine("\r\nSouhaitez-vous générer un nouveau mot de passe ?\r\n");
    //            Console.WriteLine("1. Oui, avec les mêmes critères");
    //            Console.WriteLine("2. Oui, avec de nouveaux critères");
    //            Console.WriteLine("3. Non, quitter l'application");

    //            Console.Write("\r\nChoix : ");
    //            choixUtilisateur = UtilitairesConsole.DemanderString();

    //            if (choixUtilisateur == "1")
    //            {
    //                AjoutPremierElement(random);
    //                AjoutElementsAleatoire(saisieNombre, nombreDeChoixUtilisateur);
    //                MelangerMdp(MotDePasseAMixer);
    //            }

    //        } while (choixUtilisateur == "1");

    //    } while (choixUtilisateur == "2");
    //    Console.WriteLine("Merci au revoir");
    //}

    //public List<string> AjoutPremierElement(Random random)
    //{
    //    bool choixVide = false;

    //    while (true)
    //    {
    //        nombreDeChoixUtilisateur = 0; // besoin pour la methode modulo

    //        Console.Write("\r\nInclure des lettres minuscules ? (o/n) : ");
    //        if ((Console.ReadLine() == "o"))
    //        {
    //            nombreDeChoixUtilisateur++;
    //        }
    //        Console.Write("Inclure des lettres majuscules ? (o/n) : ");
    //        if ((Console.ReadLine() == "o"))
    //        {
    //            nombreDeChoixUtilisateur++;
    //        }
    //        Console.Write("Inclure des chiffres ? (o/n) : ");
    //        if ((Console.ReadLine() == "o"))
    //        {
    //            nombreDeChoixUtilisateur++;
    //        }
    //        Console.Write("Inclure des symboles ? (o/n) : ");
    //        if ((Console.ReadLine() == "o"))
    //        {
    //            nombreDeChoixUtilisateur++;
    //        }

    //        if (nombreDeChoixUtilisateur == 0)
    //        {
    //            choixVide = true;
    //            Console.WriteLine("\r\nVeuillez faire au moins un choix : ");
    //        }

    //        motDePasseAMixer.Add(data.LettreMinuscule[random.Next(1, data.LettreMinuscule.Count())]);
    //        motDePasseAMixer.Add(data.LettreMajuscule[random.Next(1, data.LettreMajuscule.Count())]);
    //        motDePasseAMixer.Add(data.Nombres[random.Next(1, data.Nombres.Count())]);
    //        motDePasseAMixer.Add(data.Symbole[random.Next(1, data.Symbole.Count())]);

    //    }
    //}

    public void AjoutElementsAleatoire(int saisieNombre, int nombreDeChoixUtilisateur)
    {
        for (int i = 0; i < saisieNombre - nombreDeChoixUtilisateur; i++)
        {
            int nombreAleatoire = random.Next(1, 4);

            switch (nombreAleatoire)
            {
                case 1:
                    motDePasseAMixer.Add(data.LettreMinuscule[random.Next(1, data.LettreMinuscule.Count())]);
                    break;

                case 2:
                    motDePasseAMixer.Add(data.LettreMajuscule[random.Next(1, data.LettreMajuscule.Count())]);
                    break;

                case 3:
                    motDePasseAMixer.Add(data.Nombres[random.Next(1, data.Nombres.Count())]);
                    break;

                case 4:
                    motDePasseAMixer.Add(data.Symbole[random.Next(1, data.Symbole.Count())]);
                    break;
            }
        }
    }



    //private void ChoixTypesUtilisateur(int saisieNombre, List<string> MotDePasseAMixer, int nombreAleatoire)  // interdire jamais o parametre
    //{
    //}

    //public void MixerList(int nombreAleatoire, int saisieNombre)
    //{
    //    int modulo = (saisieNombre % nombreDeChoixUtilisateur);
    //    int resultat = (nombreDeChoixUtilisateur != 0) ? (saisieNombre / nombreDeChoixUtilisateur) : 1;

    //    if (ajoutMinuscule)
    //        IntegrerToutesLesListes(motDePasseAMixer, ElementsAleatoires(data.LettreMinuscule, resultat));
    //    if (ajoutMajuscule)
    //        IntegrerToutesLesListes(motDePasseAMixer, ElementsAleatoires(data.LettreMajuscule, resultat));
    //    if (ajoutNombre)
    //        IntegrerToutesLesListes(motDePasseAMixer, ElementsAleatoires(data.Nombres, resultat));
    //    if (ajoutSymbole)
    //        IntegrerToutesLesListes(motDePasseAMixer, ElementsAleatoires(data.Symbole, resultat));

    //}


    //private List<string> IntegrerToutesLesListes(List<string> MotDePasseMixer, List<string> ListAleatoire)
    //{
    //    foreach (string Element in ListAleatoire)
    //    {
    //        MotDePasseMixer.Add(Element);
    //    }
    //    return MotDePasseMixer;
    //}

}
