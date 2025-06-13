namespace GenerateurDeMotsDePasseConsoleV2;

internal class Critere(int longueur, bool ajoutMajuscule, bool ajoutMinuscule, bool ajoutNombre, bool ajoutSymbole)
{
    internal int Longueur { get; } = longueur;
    internal bool AjoutMajuscule { get; set; } = ajoutMajuscule;
    internal bool AjoutMinuscule { get; set; } = ajoutMinuscule;
    internal bool AjoutNombre { get; set; } = ajoutNombre;
    internal bool AjoutSymbole { get; set; } = ajoutSymbole;
}
