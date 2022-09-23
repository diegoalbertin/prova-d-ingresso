using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_d_ingresso
{
    class Program
    {
        static void Main(string[] args)
        {
            bool controllo;
            double consumoCorrente, consumoGas, SMCTotali, KWhTotali;
            string tmp;
            int sceltaMetodo;

            do
            {
                Console.WriteLine("inserisci i consumi di gas espressi in SMC\n");
                tmp = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(tmp, out consumoGas);
            } while (controllo == false || consumoGas < 0);

            do
            {
                Console.WriteLine("inserisci i consumi di corrente espressi in KWh\n");
                tmp = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(tmp, out consumoCorrente);
            } while (controllo == false || consumoCorrente < 0);

            do//metodo di riscaldamento
            {
                Console.WriteLine("\nscegli il metodo di riscaldamento :\n" +
                              "Premi 1 -> la caldaia tradizionale\n" +
                              "Premi 2 -> la caldaia a condensazione\n" +
                              "Premi 3 -> pompa di calore di buon livello \n" +
                              "Premi 4 -> pompa di calore economica\n" +
                              "Premi 5 -> stufa elettrica\n");
                tmp = Convert.ToString(Console.ReadLine());
                controllo = int.TryParse(tmp, out sceltaMetodo);
            } while (controllo == false || sceltaMetodo > 5 || sceltaMetodo < 1);

            SMCTotali = (consumoCorrente / 10.7) + consumoGas;
            KWhTotali = (consumoGas * 10.7) + consumoCorrente;
            caldaiaCondensazione caldaiaCondensazione = new caldaiaCondensazione();
            caldaiaTradizionale caldaiaTradizionale = new caldaiaTradizionale();
            PompaCaloreEconomica pompaCaloreEconomica = new PompaCaloreEconomica();
            PompaCaloreBuona pompaCaloreBuona = new PompaCaloreBuona();
            StufaElettrica stufaElettrica = new StufaElettrica();
            Riscaldamento metodoRiscaldamento = new Riscaldamento();
            switch (sceltaMetodo)
            {
                case 1:
                    metodoRiscaldamento = caldaiaTradizionale;
                    break;
                case 2:
                    metodoRiscaldamento = caldaiaCondensazione;
                    break;
                case 3:
                    metodoRiscaldamento = pompaCaloreBuona;
                    break;
                case 4:
                    metodoRiscaldamento = pompaCaloreEconomica;
                    break;
                case 5:
                    metodoRiscaldamento = stufaElettrica;
                    break;
            }
            List<object> metodiRiscaldamento;
            metodiRiscaldamento = new List<object>() { caldaiaTradizionale, caldaiaCondensazione, pompaCaloreBuona, pompaCaloreEconomica, stufaElettrica }; // Lista che contiene tutti i metodi di riscaldamento
            Bolletta bolletta;
            List<Bolletta> bolletteRiscaldamento = new List<Bolletta>();
            foreach (Riscaldamento element in metodiRiscaldamento)
            {
                if (element.GetMateriaPrima() == "Corrente")
                {
                    element.SetConsumi(consumoCorrente);
                    element.CalcolaUtilizzo(consumoGas);
                }
                else
                {
                    element.SetConsumi(consumoGas);
                    element.CalcolaUtilizzo(consumoCorrente);
                }
                element.CalcolaTotale();
                bolletta = new Bolletta();
                bolletta.SetCostoMateriaPrima(element.GetTotale());
                bolletta.SetCostoInstallazione(element.GetCostoInstallazione());
                bolletta.SetMetodoRiscaldamento(element);
                bolletteRiscaldamento.Add(bolletta);
            }
            foreach (Bolletta element in bolletteRiscaldamento)
            {
                element.CalcolaBolletta();
            }

            bolletteRiscaldamento = bolletteRiscaldamento.OrderBy(b => b.GetTotale()).ToList(); // Viene ordinata la lista di bollette tramite il totale di ogni bolletta

            foreach (Bolletta element in bolletteRiscaldamento)
            {
                Console.WriteLine($"{element.ToString()}");
            }

            if (sceltaMetodo.ToString() == bolletteRiscaldamento[0].GetMetodoRiscaldamento().ToString())
            {
                Console.Write("\n\nIl metodo attualmente installato è il più conveniente\n");
            }
            else
            {
                Console.WriteLine($"\n\nL'offerta più conveniente è la seguente: {bolletteRiscaldamento[0].ToString()}");
            }

            Console.ReadKey();
            Console.WriteLine("{0}", metodoRiscaldamento.GetCostoInstallazione());
            Console.ReadKey();
        }
    }
}
