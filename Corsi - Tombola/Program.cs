using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Corsi___Tombola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dichiarazione variabile per caricare il tabellone(matrice)
            int caricamento = 1;

            //dichiarazione matrice(tabellone)
            int nr = 9, nc = 10;
            int[,] tabellone = new int[nr, nc];

            //ciclo per caricare tutti i 90 numeri nella matrice
            for (int i = 0; i < nr; i++)
            {
                for (int z = 0; z < nc; z++)
                {
                    //in base all'indice, la matrice verrà caricata con il rispettivo valore
                    tabellone[i,z] = caricamento;
                    caricamento++;
                    //Console.WriteLine(tabellone[i, z]);
                }
            }
            //ciclo di estrazione dei numeri
            

            while (ControlloTabellone(tabellone)==true)
            {
                var tuple = EstrazioneNumero(tabellone);
                if (tuple.Item3 != 0)
                {
                    Console.WriteLine(tuple.Item3);
                }
            }
        }


        //funzione per estrarre un numero
        static Tuple<int, int, int> EstrazioneNumero(int[,] x )
        {
            //dichiarazione Random
            Random r = new Random();
            //assegnamento di un valore randomico alla riga
            int riga = r.Next(0, 9);
            //assegnamento di un valore randomico alla colonna
            int colonna = r.Next(0, 10);
            //la variabile estrazione sarà uguale al valore presente nella posizione randomica della matrice
            int estrazione = x[riga, colonna];
            //azzeramento del valore ottenuto per non farlo ripetere successivamente
            x[riga, colonna] = 0;
            return Tuple.Create(riga, colonna, estrazione);
        }

        static bool ControlloTabellone(int[,] x)
        {
            //ciclo per vedere se ci sono ancora numeri estraibili nel tabellone
            for (int i = 0; i < 9; i++)
            {
                for (int z = 0; z < 10; z++)
                {
                    //condizione per verificare se ci sono numeri diversi da 0 nel tabellone
                    if (x[i, z] != 0)
                    {
                        return true;
                    }
                }
            }
            //return se tutti i numeri sono stati estratti in modo da terminare l'estrazione dei numeri 
            return false;
        }

    }   
}
