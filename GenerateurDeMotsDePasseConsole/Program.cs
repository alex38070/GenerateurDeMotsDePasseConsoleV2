namespace GenerateurDeMotsDePasseConsoleV2;

internal class Program
{
    internal static void Main()
    {
        UtilitaireConsole.ColorerConsole();
        GenerateurMotDePasse generateurMdp = new();
        generateurMdp.Lancer();
    }
}