using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_d_ingresso
{
    class Riscaldamento
    {
        protected double rendimento;
        protected double utilizzo;
        protected double costoAnnuale;
        protected double consumi;
        protected double costoTotale;
        protected string materiaPrima;
        protected int costoInstallazione;

        public Riscaldamento()
        {
        }

        public virtual void CalcolaUtilizzo(double cons)
        {
        }

        public void SetConsumi(double consumo)
        {
            this.consumi = consumo;
        }

        public override string ToString()
        {
            return $"Il rendimento del modello è: {this.rendimento}, il costo annuale è: {this.costoAnnuale} e i consumi sono: {this.consumi}";
        }

        public void CalcolaTotale()
        {
            this.costoTotale = this.costoAnnuale * (this.consumi + this.utilizzo);
        }
        public double GetTotale()
        {
            return this.costoTotale;
        }

        public string GetMateriaPrima()
        {
            return this.materiaPrima;
        }
        public int GetCostoInstallazione()
        {
            return this.costoInstallazione;
        }
    }
}
