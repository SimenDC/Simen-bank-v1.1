///Simen De Coster nr1 5AIT 
/*
 * OPGAVE
 * ======
 * Creëer 2 classes voor een eenvoudig banksysteem:
 * 1. Rekening
 * een bankrekening heeft volgende eigenschappen:
 * rekeningnummer (in IBAN-formaat)
 * saldo (het bedrag dat op de rekening staat)
 * kredietlimiet (het bedrag dat je onder nul mag gaan)
 * houder (de naam van de eigenaar van de rekening)
 * een bankrekening kan volgende acties uitvoeren:
 * storten: bedrag wordt gestort; geeft het nieuwe saldo terug
 * afhalen: bedrag wordt afgehaald indien mogelijk; geeft terug of het gelukt is om af te
 * halen of niet
 * 
 * 2. Client
 * een cliënt heeft volgende eigenschappen:
 * voornaam
 * familienaam
 * adres
 * lijst met rekeningen
 * een cliënt kan volgende acties uitvoeren:
 * rekening openen
 * rekening sluiten
 * rekening opzoeken (a.d.h.v. rekeningnummer)
 * storting uitvoeren (bedrag op een bepaalde rekening)
 * afhaling uitvoeren (bedrag van een bepaalde rekening)
 *
 * 
 * ANALYSE
 * =======
 * 
 * VRAAG alle gegevens aan de gebruiker
 *       aan gebruiker of hij een rekenining wilt openen
 *       aan de gebruiker zijn gegevens
 *       saldo
 *       kredietlimiet
 *       rekeningnummer
 *       houder 
 *       of ze willen storten of afhalen
 *       bedrag storten
 *       of ze willen afhalen
 *       of u wilt zoeken naar een rekening of niet
 * 
 * Bereken het stortbedrag(het saldo + storten bedrag)
 * Bereken het afhaalbedrag(het saldo - afhaal bedrag)
 * 
 * TOON
 *          alle antwoorden van de vragen
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simenbankv1
{
    class Program
    {
        static void Main(string[] args)
        {
            Client clientnr1 = new Client();
            clientnr1.Voornaam = "Jeanke";
            clientnr1.Familienaam = "Vermeueln";
            clientnr1.Adres = "Zonnedorp";

            Zichtrekening ClientRek = new Zichtrekening();
            ClientRek.Rekeningnummer = "BE11 22 33 44 55 66";
            ClientRek.Saldo = 1000;

            Spaarrekening SprRekening = new Spaarrekening();
            SprRekening.basisrente = 3;
            SprRekening.getrouwheidsrente = 7;

            Console.WriteLine($"Basisrente: {SprRekening.basisrente}%");
            Console.WriteLine($"Getrouwheid: {SprRekening.getrouwheidsrente}%");
            Console.WriteLine($"Rekeningnummer: {ClientRek.Rekeningnummer}");
            Console.ReadLine();
        }
    }
}
