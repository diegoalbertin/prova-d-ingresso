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
            bool controllo;                                             //dichiarazione delle variabili che verranno utilizzate per ii vari controlli
            double consumoCorrente, consumoGas, SMCTotali, KWhTotali;   //e per gli inserimenti dei valori dei consumi
            string tmp;
            int sceltaMetodo;

            do                                                                          //ciclo do while per l'inserimento del consumo di gas
            {
                Console.WriteLine("inserisci i consumi di gas espressi in SMC\n");
                tmp = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(tmp, out consumoGas);
            } while (controllo == false || consumoGas < 0);

            do                                                                         //ciclo do while per l'inserimento del consumo di corrente
            {
                Console.WriteLine("inserisci i consumi di corrente espressi in KWh\n");
                tmp = Convert.ToString(Console.ReadLine());
                controllo = double.TryParse(tmp, out consumoCorrente);
            } while (controllo == false || consumoCorrente < 0);

            do                                                                         //ciclo do while per l'inserimento del metodo di riscaldamento
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

            SMCTotali = (consumoCorrente / 10.7) + consumoGas;                      //calcolo smc e kwh totali
            KWhTotali = (consumoGas * 10.7) + consumoCorrente;
            caldaiaCondensazione caldaiaCondensazione = new caldaiaCondensazione(); //dichiarazione delle varie classi e oggetti
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
            //dichiarazione lista contenente i vari metodi di riscaldamento 
            List<object> metodiRiscaldamento = new List<object>() { caldaiaTradizionale, caldaiaCondensazione, pompaCaloreBuona, pompaCaloreEconomica, stufaElettrica }; // Lista che contiene tutti i metodi di riscaldamento
            Bolletta bolletta;
            List<Bolletta> bolletteRiscaldamento = new List<Bolletta>();
            foreach (Riscaldamento element in metodiRiscaldamento)      //vengono create le bollette per ogni metodo di riscaldamento
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
            foreach (Bolletta element in bolletteRiscaldamento)//vengono calcolate le bollette
            {
                element.CalcolaBolletta();
            }

            bolletteRiscaldamento = bolletteRiscaldamento.OrderBy(b => b.GetTotale()).ToList(); // Viene ordinata la lista di bollette tramite il totale di ogni bolletta

            foreach (Bolletta element in bolletteRiscaldamento)     //vengono elencati i vari metodi e le relative bollette
            {
                Console.WriteLine($"{element.ToString()}");
            }

            if (sceltaMetodo.ToString() == bolletteRiscaldamento[0].GetMetodoRiscaldamento().ToString())            //suggerimento della scelta migliore all'utente
            {
                Console.Write("\n\nIl metodo attualmente installato è il più conveniente\n");
            }
            else
            {
                Console.WriteLine($"\n\nL'offerta più conveniente è la seguente: {bolletteRiscaldamento[0].ToString()}");
            }

            Console.ReadKey();
        }
    }
}
