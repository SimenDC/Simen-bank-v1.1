using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simenbankv1
{
    public class Zichtrekening
    {
        /// <summary>
        /// Het rekeningnummer in IBAN-formaat.
        /// </summary>
        public string Rekeningnummer { get; set; }

        /// <summary>
        /// Het bedrag dat op de rekening staat.
        /// </summary>
        public decimal Saldo { get; set; }

        /// <summary>
        /// Het bedrag dat onder nul mag gaan(€ 200 krediet wordt als +200 ingesteld).
        /// </summary>
        public decimal Kredietlimiet { get; set; }

        /// <summary>
        /// De naam van eigenaar van de rekening.
        /// </summary>
        public string Houder { get; set; }

        /// <summary>
        /// Een bedrag storten op de rekening.
        /// </summary>
        /// <param name="bedrag">Het bedrag dat op de rekening gestort wordt.</param>
        /// <returns>Het nieuwe saldo van de rekening.</returns>
        public decimal Storten(decimal bedrag)
        {
            // gestorte bedrag bij saldo tellen
            Saldo += bedrag;
            // nieuwe saldo teruggeven
            return Saldo;
        }

        /// <summary>
        /// Een bedrag van de rekening proberen afhalen.
        /// </summary>
        /// <param name="bedrag">Het bedrag dat we van de rekening proberen af te halen.</param>
        /// <returns>true als afhalen gelukt is; false indien niet.</returns>
        public bool Afhalen(decimal bedrag)
        {
            bool isGelukt = false;
            // Geld afhalen mogelijk ALS saldo + kredietlimiet >= bedrag
            if (Saldo + Kredietlimiet >= bedrag)
            {
                // geld afhalen => saldo aanpassen
                Saldo -= bedrag;
                // geld afhalen is gelukt
                isGelukt = true;
            }
            return isGelukt;
        }
        /// <summary>
        /// Een bedrag van de rekening proberen afhalen.
        /// </summary>
        /// <param name="bedrag">Het bedrag dat we van de rekening proberen af te halen.</param>
        /// <returns>true als afhalen gelukt is; false indien niet.</returns>
        public bool overschrijven(decimal bedrag)
        {
            bool Isgelukt = false;
            decimal BedragNaarAnderPers = 0;
            if (Saldo + Kredietlimiet >= bedrag)
            {
                Saldo -= bedrag;
                bedrag += BedragNaarAnderPers;
                Isgelukt = true;
            }
            return Isgelukt;
        }
    }
}
