namespace GenerateurDeMotsDePasseConsoleV2;

public class Critere(int longueur, bool ajoutMajuscule, bool ajoutMinuscule, bool ajoutChiffre, bool ajoutSymbole)
{
    public int Longueur { get; } = longueur;
    public bool AjoutMajuscule { get; } = ajoutMajuscule;
    public bool AjoutMinuscule { get; } = ajoutMinuscule;
    public bool AjoutChiffre { get; } = ajoutChiffre;
    public bool AjoutSymbole { get; } = ajoutSymbole;

    //public string NewCritere()
    //{
    //    do
    //    {
    //        ajoutMajuscule = UtilitairesConsole.DemanderOuiNon("Inclure des lettres majuscules ? (o/n) : ");
    //        ajoutMinuscule = UtilitairesConsole.DemanderOuiNon("Inclure des lettres minuscules ? (o/n) : ");
    //        ajoutChiffre = UtilitairesConsole.DemanderOuiNon("Inclure des chiffres ? (o/n) : ");
    //        ajoutSymbole = UtilitairesConsole.DemanderOuiNon("Inclure des symboles ? (o/n) : ");

    //    } while (ajoutMajuscule == false && ajoutMinuscule == false && ajoutChiffre == false && ajoutSymbole == false);
    //    return  null;
    //}


}