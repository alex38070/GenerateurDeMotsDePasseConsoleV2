namespace GenerateurDeMotsDePasseConsoleV2;

public class Critere(int longueur, bool ajoutMajuscule, bool ajoutMinuscule, bool ajoutChiffre, bool ajoutSymbole)
{
    public int Longueur { get; } = longueur;
    public bool AjoutMajuscule { get; } = ajoutMajuscule;
    public bool AjoutMinuscule { get; } = ajoutMinuscule;
    public bool AjoutChiffre { get; } = ajoutChiffre;
    public bool AjoutSymbole { get; } = ajoutSymbole;


    internal static Critere DemanderChoixType(int longueur)
    {
        while (true)
        {
            bool ajoutMajuscule = UtilitairesConsole.DemanderOuiNon("\r\nInclure des lettres majuscules ?____(o/n) : ");
            bool ajoutMinuscule = UtilitairesConsole.DemanderOuiNon("Inclure des lettres minuscules ?____(o/n) : ");
            bool ajoutChiffre = UtilitairesConsole.DemanderOuiNon("Inclure des chiffres ?______________(o/n) : ");
            bool ajoutSymbole = UtilitairesConsole.DemanderOuiNon("Inclure des symboles ?______________(o/n) : ");

            if (!(ajoutMajuscule == false && ajoutMinuscule == false && ajoutChiffre == false && ajoutSymbole == false))
                return new(longueur, ajoutMajuscule, ajoutMinuscule, ajoutChiffre, ajoutSymbole);
        }

    }

}