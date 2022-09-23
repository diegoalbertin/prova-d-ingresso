using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_d_ingresso
{
    class PompaCaloreBuona:Riscaldamento
    {
        public PompaCaloreBuona()
        {
            this.costoInstallazione = 1000;
            this.rendimento =3.6;
            this.costoAnnuale = 0.276;
            this.materiaPrima = "Corrente";
        }

        public override void CalcolaUtilizzo(double cons)
        {
            this.utilizzo = cons / (10.7 * this.rendimento);
        }

        public override string ToString()
        {
            return "Pompa di calore buon livello";
        }
    }
}
