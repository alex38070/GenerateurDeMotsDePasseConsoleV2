/*
 * 1. demander a l-utilsateur :
 * 
 *      Combien de caractere doit contenir le mot de passe
 *      S'il souhaite la presence : au moin 
 *          une majuscule
 *          un nombre
 *          un symbole
 *          
 *      Générer aleatoirement une suite de caractère repondant au critaire de l'utilisateur
 *      
 *      list choix utilisateur :
*           List majuscule
*           List nombre
*           List symbole
*      
*      
 * 
 */
namespace GenerateurDeMotsDePasseConsoleV2;

public class Program
{
    static void Main(string[] args)
    {
        GenerateurMdp generateurMdp = new GenerateurMdp();
        generateurMdp.Lancer();
    }
}