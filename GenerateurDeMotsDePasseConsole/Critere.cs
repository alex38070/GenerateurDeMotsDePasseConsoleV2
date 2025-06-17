namespace GenerateurDeMotsDePasseConsoleV2;

public class Critere(int longueur, bool ajoutMajuscule, bool ajoutMinuscule, bool ajoutChiffre, bool ajoutSymbole)
{
    public int Longueur { get; } = longueur;
    public bool AjoutMajuscule { get; } = ajoutMajuscule;
    public bool AjoutMinuscule { get; } = ajoutMinuscule;
    public bool AjoutChiffre { get; } = ajoutChiffre;
    public bool AjoutSymbole { get; } = ajoutSymbole;

    public void NewCritere()
    {
    }


}