namespace GenerateurDeMotsDePasseConsoleV2;

public class Critere(int longueur, bool ajoutMajuscule, bool ajoutMinuscule, bool ajoutNombre, bool ajoutSymbole)
{
    public int Longueur { get; set; } = longueur;
    public bool AjoutMajuscule { get; } = ajoutMajuscule = false;
    public bool AjoutMinuscule { get; } = ajoutMinuscule = false;
    public bool AjoutNombre { get; } = ajoutNombre = false;
    public bool AjoutSymbole { get; } = ajoutSymbole = false;
}
