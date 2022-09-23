using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_d_ingresso
{
    class Bolletta
    {
        protected double costoMateriaPrima;
        protected int spesaTrasGestCont;
        protected int oneri;
        protected int spesaFissaVendita; //QVD o PVC
        protected double totale;
        protected int installazione;
        protected Riscaldamento metodoRiscaldamento;

        public Bolletta()
        {
            this.spesaTrasGestCont = 96;
            this.oneri = 47;
            this.spesaFissaVendita = 70;
        }

        public void SetCostoMateriaPrima(double spesa)
        {
            this.costoMateriaPrima = spesa;
        }

        public string GetSpesaMateriaPrima()
        {
            return $"Spesa materia {this.costoMateriaPrima}";
        }

        public override string ToString()
        {
            return $"\nCosto bolletta {this.metodoRiscaldamento}: {Math.Round(this.totale, 4) + this.installazione}$ per il primo anno, di cui {this.installazione}$ per l'installazione, per gli anni successivi il prezzo sarebbe pari a {Math.Round(this.totale, 4)}$\n";
        }

        public void CalcolaBolletta()
        {
            this.totale = this.costoMateriaPrima + this.oneri + this.spesaTrasGestCont + this.spesaFissaVendita;
        }

        public double GetTotale()
        {
            return this.totale;
        }

        public void SetCostoInstallazione(int costoInt)
        {
            this.installazione = costoInt;
        }

        public void SetMetodoRiscaldamento(Riscaldamento metodo)
        {
            this.metodoRiscaldamento = metodo;
        }

        public Riscaldamento GetMetodoRiscaldamento()
        {
            return this.metodoRiscaldamento;
        }
    }
}
