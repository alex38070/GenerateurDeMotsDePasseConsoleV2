namespace GenerateurDeMotsDePasseConsoleV2;

public class Critere(int longueur, bool ajoutMajuscule, bool ajoutMinuscule, bool ajoutChiffre, bool ajoutSymbole)
{
    public int Longueur { get; } = longueur;
    public bool AjoutMajuscule { get; } = ajoutMajuscule;
    public bool AjoutMinuscule { get; } = ajoutMinuscule;
    public bool AjoutChiffre { get; } = ajoutChiffre;
    public bool AjoutSymbole { get; } = ajoutSymbole;

    public Critere NewCritere()
    {
        Critere critere = new(longueur, ajoutMajuscule, ajoutMinuscule, ajoutChiffre, ajoutSymbole);
        if (ajoutMajuscule == false && ajoutMinuscule == false && ajoutChiffre == false && ajoutSymbole == false)
            return critere;
        return critere;

    }
}