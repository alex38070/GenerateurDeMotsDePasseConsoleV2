namespace GenerateurDeMotsDePasseConsole;

internal class Data
{
    List<string> data = new();

    internal List<string> LettreMinuscule = new List<string>
    {
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
        "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
    };

    internal List<string> LettreMajuscule = new List<string>
    {
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
        "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
    };

    internal List<string> Nombres = new List<string>
    {
       "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
    };

    internal List<string> Symbole = new List<string>
    {
       "/", "!", "?"
    };
}