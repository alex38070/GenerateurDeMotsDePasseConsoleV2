namespace GenerateurDeMotsDePasseConsoleV2;

public class Critere(int longueur, bool ajoutMajuscule, bool ajoutMinuscule, bool ajoutNombre, bool ajoutSymbole)
{
    public int Longueur { get; } = longueur;
    public bool AjoutMajuscule { get; } = ajoutMajuscule;
    public bool AjoutMinuscule { get; } = ajoutMinuscule;
    public bool AjoutNombre { get; } = ajoutNombre;
    public bool AjoutSymbole { get; } = ajoutSymbole;
}
