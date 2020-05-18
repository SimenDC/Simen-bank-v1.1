using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simenbankv1
{
    public class Client
    {
        private List<Zichtrekening> rekeningen;

        public Client()
        {
            rekeningen = new List<Zichtrekening>();
        }

        /// <summary>
        /// De voornaam van de cliënt.
        /// </summary>
        public string Voornaam { get; set; }
        /// <summary>
        /// De familienaam van de cliënt.
        /// </summary>
        public string Familienaam { get; set; }
        /// <summary>
        /// Het adres van de cliënt (vereenvoudigd als string)
        /// </summary>
        public string Adres { get; set; }

        /// <summary>
        /// De rekeningen van deze cliënt
        /// </summary>
        public List<Zichtrekening> Rekeningen
        {
            get { return rekeningen; }
            set { rekeningen = value; }
        }

        /// <summary>
        /// Open een rekening voor deze cliënt.
        /// </summary>
        /// <param name="rekening">De rekening voor deze cliënt.</param>
        public void RekeningOpenen(Zichtrekening rekening)
        {
            // Deze cliënt als houder van de rekening instellen
            rekening.Houder = $"{Voornaam} {Familienaam}";
            // De rekening toevoegen aan de rekeningen van de cliënt
            rekeningen.Add(rekening);
        }

        /// <summary>
        /// sluit de rekening alleen als er geen geld meer op staat
        /// </summary>
        /// <param name="rekeningnummer">Het rekeningnummer van de te sluiten rekening.</param>
        /// <returns>true indien sluiting gelukt is; false indien niet.</returns>
        public bool RekeningSluiten(string rekeningnummer)
        {
            bool isGelukt;
            // zoek de te sluiten rekening
            Zichtrekening teSluitenRekening = RekeningOpzoeken(rekeningnummer);
            // Verwijder de gezochte rekening uit de lijst
            isGelukt = rekeningen.Remove(teSluitenRekening);
            return isGelukt;
        }

        /// <summary>
        /// Zoek een rekening van deze cliënt op.
        /// </summary>
        /// <param name="rekeningnummer">Het rekeningnummer van de te zoeken rekening.</param>
        /// <returns>De rekening indien gevonden; null indien niet gevonden.</returns>
        public Zichtrekening RekeningOpzoeken(string rekeningnummer)
        {
            Zichtrekening gezochteRekening = null;
            foreach (Zichtrekening rekening in rekeningen)
            {
                if (rekening.Rekeningnummer == rekeningnummer)
                    gezochteRekening = rekening;
            }
            return gezochteRekening;
        }


        /// <summary>
        /// bedrag op een bepaalde rekening plaatsen
        /// </summary>
        /// <param name="bedrag">het bedrag dat gaat worden gestort op de rekening</param>
        /// <returns>of de storting succesvol is gebeurtd</returns>
        public decimal StortingUitvoeren(decimal bedrag)
        {

            Rekening Stort = new Rekening();
            Stort.Saldo += bedrag;
            //dit geef terug of hij is voltooid
            return Stort.Saldo;
        }

        /// <summary>
        /// bedraga van een bepaalde rekening halen
        /// </summary>
        /// <param name="bedrag">het bedrag dat van de rekening wordt gehaalt</param>
        /// <returns>dat waneer er niet genoeg geld op de rekening staat. het niet gaat</returns>
        public bool afhalingUitvoeren(decimal bedrag = 0)
        {
            bool isGelukt = false;
            Rekening Afhaal = new Rekening();
            // Geld afhalen mogelijk ALS saldo + kredietlimiet >= bedrag
            if (Afhaal.Saldo >= bedrag)
            {
                // geld afhalen => saldo aanpassen
                Afhaal.Saldo -= bedrag;
                // geld afhalen is gelukt
                isGelukt = true;

            }
            return isGelukt;

        }

        /// <summary>
        /// Bedrag van een bepaalde rekening naar een bepaald rekeningnummer
        /// </summary>
        /// <param name="bedrag">Het bedrag dat van een bepaalde rekening naar een bepaalde rekeningummer moet</param>
        /// <returns>Of de overschrijving succesvol is gebeurt</returns>
        public bool OverschrijvingUitvoeren(decimal bedrag)
        {

            bool IsGelukt = false;
            decimal BedragNaarAnderPers = 0;
            Rekening Overschrijven = new Rekening();
            //je kan allen geld afhalen als er genoeg geld opstaat
            if (Overschrijven.Saldo > bedrag)
            {
                Overschrijven.Saldo -= bedrag;
                BedragNaarAnderPers += bedrag;
                //dit geeft weer of hij succesvol is.
                IsGelukt = true;

            }
            return IsGelukt;
        }
    }
}
