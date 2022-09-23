using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_d_ingresso
{
    class PompaCaloreEconomica:Riscaldamento
    {
        public PompaCaloreEconomica()
        {
            this.costoInstallazione = 3000;
            this.rendimento = 2.8;
            this.costoAnnuale = 0.276;
            this.materiaPrima = "Corrente";
        }

        public override void CalcolaUtilizzo(double cons)
        {
            this.utilizzo = cons / (10.7 * this.rendimento);
        }

        public override string ToString()
        {
            return "Pompa di calore economica";
        }

    }
}
