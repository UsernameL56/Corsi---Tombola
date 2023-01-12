

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Corsi___Tombola
{
    internal class Program
    {
        static void Main(string[] args)             //MAIN  
        {
            //dichiarazione variabile per caricare il tabellone(matrice)
            int caricamento = 1;
            //dichiarazione variabili per la stampa del tabellone nella posizione desiderata
            int orizzontale = 10, verticale = 3;
            //dichiarazione matrici
            int nr = 9, nc = 10;
            int[,] tabellone = new int[nr, nc];
            int[,] CopiaTabellone = new int[nr, nc];
            int[,] CopiaTabellone2 = new int[nr, nc];
            int[,] Cartella1 = new int[3, 9];



            //stampa del titolo per il tabellone + colori per decorazione
            Console.SetCursorPosition(16, 2);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("   TABELLONE   ");
            Console.BackgroundColor = ConsoleColor.Black;

            //ciclo per caricare tutti i 90 numeri nella matrice
            for (int i = 0; i < nr; i++)
            {
                for (int z = 0; z < nc; z++)
                {
                    //in base all'indice, la matrice verrà caricata con il rispettivo valore
                    tabellone[i, z] = caricamento;
                    //caricamento di una seconda matrice con gli stessi valori, per confrontarli in seguito in un ciclo, dato che quelli del tabellone si azzerano nella funzione
                    CopiaTabellone[i, z] = caricamento;
                    CopiaTabellone2[i, z] = caricamento;
                    caricamento++;
                    //posizionamento del tabellone in ordine
                    Console.SetCursorPosition(orizzontale, verticale);
                    //controllo per il numero 10, dato che è l'unico numero a due cifre nella prima riga, per metterlo in riga con le altre decine
                    if (tabellone[i, z] == 10)
                    {
                        Console.SetCursorPosition((orizzontale) - 1, verticale);
                    }
                    orizzontale = orizzontale + 3;
                    //stampa del tabellone
                    Console.WriteLine(tabellone[i, z]);
                }
                //ritorno a sinistra per il cambio di riga
                orizzontale = 9;
                verticale++;

            }

            //matrice indice cartella
            for (int i = 0; i < 3; i++)
            {
                for (int z = 0; z < 9; z++)
                {
                    Cartella1[i, z] = 0;
                }
            }
            //CalcoloIndiceCartella(CopiaTabellone2, Cartella1);



            //ciclo che richiama la funzione di controllo
            while (ControlloTabellone(tabellone) == true)
            {
                //richiamo della variabile estrazione attra
                int NumeroEstratto = EstrazioneNumero(tabellone);
                //ripristino delle variabili di posizionamento del tabellone
                verticale = 3; orizzontale = 10;
                //condizione per verificare se il numero che viene estratto è già stato estratto oppure no
                if (NumeroEstratto != 0)
                {
                    //ciclo per capire dove posizionare il numero estratto nel tabellone
                    for (int i = 0; i < 9; i++)
                    {
                        for (int z = 0; z < 10; z++)
                        {
                            //Condizione per sovrapposizionare il numero estratto con quello base
                            if (CopiaTabellone[i, z] == NumeroEstratto)
                            {
                                //pausa di tempo tra un'estrazione e l'altra(si può modificare in base alle proprie esigenze)
                                Thread.Sleep(150);
                                //sovrapposizionamento dei numeri estratti sopra al tabellone
                                Console.SetCursorPosition(orizzontale, verticale);
                                //controllo per il numero 10, dato che è l'unico numero a due cifre nella prima riga, per metterlo in riga con le altre decine
                                if (CopiaTabellone[i, z] == 10)
                                {
                                    Console.SetCursorPosition((orizzontale) - 1, verticale);
                                }
                                //evidenzazione del numero estratto e scrittura sul tabellone
                                Console.BackgroundColor = ConsoleColor.Green;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine(NumeroEstratto);
                                //ripristino colori originali
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Gray;
                                //testo per far vedere il numero estratto
                                Console.SetCursorPosition(0, 13);
                                Console.WriteLine("Il Numero Estratto è: " + NumeroEstratto);
                                //pausa di mezzo secondo per far visualizzare il numero estratto(bisogna tener conto che si sommano a quelli messi per l'estrazione)
                                Thread.Sleep(1000);
                                //testo per cancellare il numero precedente in modo da non creare problemi con i numeri ad una cifra
                                Console.SetCursorPosition(0, 13);
                                Console.WriteLine("Il Numero Estratto è:   ");

                            }
                            orizzontale = orizzontale + 3;
                        }
                        //ritorno a sinistra per il cambio di riga
                        orizzontale = 9;
                        verticale++;
                    }
                }
            }

        }
        //FUNZIONI

        //funzione per estrarre un numero
        static int EstrazioneNumero(int[,] x)
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
            return estrazione;
        }

        //funzione per controllare i numeri che vengono estratti
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

        /*
        static void CalcoloIndiceCartella(int[,] tab, int[,]cartella)
        {
            Random r = new Random();
            //assegnamento di un valore randomico alla riga
            int riga = r.Next(0, 9);
            //assegnamento di un valore randomico alla colonna
            int colonna = r.Next(0, 10);
            int estr = tab[riga, colonna];
            int IndiceCalcolato = estr;
            IndiceCalcolato = (IndiceCalcolato / 10);
            if (estr == 90)
            {
                IndiceCalcolato = IndiceCalcolato - 1;
            }

            if (cartella[0, IndiceCalcolato] == 0)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int z = 0; z < 10; z++)
                    {
                        //condizione per verificare se ci sono numeri diversi da 0 nel tabellone
                        if (tab[i, z] != 0 || cartella[0, IndiceCalcolato] != 0)
                        {
                            tab[i, z] = 0;
                            bool check = true;
                        }
                    }
                }
                if (true)
                {
                    cartella[0, IndiceCalcolato] = estr;
                    Console.WriteLine(IndiceCalcolato + " " + cartella[0, IndiceCalcolato]);
                }
                
            }
        */

    }
}


