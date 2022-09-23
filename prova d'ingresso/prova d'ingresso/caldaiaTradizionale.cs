using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_d_ingresso
{
    class caldaiaTradizionale:Riscaldamento
    {
        public caldaiaTradizionale()
        {
            this.costoInstallazione = 1375;
            this.rendimento = 0.9;
            this.costoAnnuale = 1.05;
            this.materiaPrima = "Gas";
        }

        public override void CalcolaUtilizzo(double cons)
        {
            this.utilizzo = cons / (10.7 * this.rendimento);
        }

        public override string ToString()
        {
            return "Caldaia Tradizionale";
        }
    }
}
