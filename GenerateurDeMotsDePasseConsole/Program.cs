namespace GenerateurDeMotsDePasseConsoleV2;

public class Program
{
    static void Main()
    {
        GenerateurMotDePasses generateurMdp = new();
        generateurMdp.GenererMotDePasse();
    }
}