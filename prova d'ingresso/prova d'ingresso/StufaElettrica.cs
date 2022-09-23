using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_d_ingresso
{
    class StufaElettrica:Riscaldamento
    {
        public StufaElettrica()
        {
            this.costoInstallazione = 1400;
            this.rendimento = 1;
            this.costoAnnuale = 0.276;
            this.materiaPrima = "Corrente";
        }

        public override void CalcolaUtilizzo(double cons)
        {
            this.utilizzo = cons / (10.7 * this.rendimento);
        }

        public override string ToString()
        {
            return "stufa elettrica";
        }

    }
}
