using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simenbankv1
{
    public class Spaarrekening
    {
        /// <summary>
        /// Dit moet in IBAN formaat
        /// </summary>
        public string rekeningnummer
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// Het bedrag dat op de rekening staat
        /// </summary>
        public decimal Saldo { get; set; }


        /// <summary>
        /// De naam van de eigenaar van de rekening
        /// </summary>
        public string houder { get; set; }


        /// <summary>
        /// de basis rentevoet in percentage
        /// </summary>
        public float basisrente { get; set; }


        /// <summary>
        /// de getrouwheidsrente
        /// </summary>
        public float getrouwheidsrente { get; set; }


        /// <summary>
        /// bedrag wordt gestort
        /// </summary>
        /// <param name="bedrag">het bedrag dat in totaal op de rekening staat</param>
        /// <returns>het bedrag dat in totoaal op de rekening staat</returns>
        public decimal storten(decimal bedrag)
        {
            // gestorte bedrag bij saldo tellen
            Saldo += bedrag;
            // nieuwe saldo teruggeven
            return Saldo;
        }

        /// <summary>
        /// het bedrag dat wordt overgeschreven
        /// </summary>
        /// <param name="bedrag">het bedrag dat wordt overgeschreven</param>
        /// <returns>het bedrag dat nu nog op de rekenin staat</returns>
        public bool overschrijven(decimal bedrag)
        {
            bool Isgelukt = false;
            decimal BedragNaarAnderPers = 0;
            if (Saldo >= bedrag)
            {
                Saldo -= bedrag;
                bedrag += BedragNaarAnderPers;
                Isgelukt = true;
            }
            return Isgelukt;
        }
    }
}
