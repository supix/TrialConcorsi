using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.DomainClasses
{
    public class Domanda
    {
        public Domanda()
        {
            this.AccettataConRiserva = false;
        }

        public string Id { get; internal set; }
        public string CodiceFiscale { get; set; }
        public int GiorniDiServizio { get; set; }
        public DateTime DataSalvataggio { get; set; }
        public bool AccettataConRiserva { get
            {
                return this.GiorniDiServizio < 50;
            }

            internal set {
            } }
    }
}
