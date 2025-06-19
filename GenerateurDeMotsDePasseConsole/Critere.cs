namespace GenerateurDeMotsDePasseConsoleV2;

internal class Critere(int longueur, bool ajoutMajuscule, bool ajoutMinuscule, bool ajoutChiffre, bool ajoutSymbole)
{
    internal int Longueur { get; } = longueur;
    internal bool AjoutMajuscule { get; } = ajoutMajuscule;
    internal bool AjoutMinuscule { get; } = ajoutMinuscule;
    internal bool AjoutChiffre { get; } = ajoutChiffre;
    internal bool AjoutSymbole { get; } = ajoutSymbole;
}