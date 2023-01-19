

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
        static void Main(string[] args)
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
            int[,] Cartella2 = new int[3, 9];
            int contatore = 0;



            //stampa del titolo per il tabellone + colori per decorazione
            Console.SetCursorPosition(16, 2);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("   TABELLONE   ");
            Console.BackgroundColor = ConsoleColor.Black;

            //stampa del titolo per la prima cartella + colori per decorazione
            Console.SetCursorPosition(55, 2);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("   CARTELLA 1   ");
            Console.BackgroundColor = ConsoleColor.Black;

            //stampa del titolo per la seconda cartella + colori per decorazione
            Console.SetCursorPosition(55, 8);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("   CARTELLA 2   ");
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

/*
            //caricamento di 0 per le due cartelle
            for (int i = 0; i < 3; i++)
            {
                for (int z = 0; z < 9; z++)
                {
                    Cartella1[i, z] = 0;
                    Cartella2[i, z] = 0;
                }
            }

            //stampa della prima cartella
            while (contatore<15)
            {
                //richiamo alla funzione di estrazione per la cartella
                var tuple = EstrazioneCartella(CopiaTabellone2);
                //se il valore estratto è diverso da 0, la posizione nella cartella non è già stata occupata, e il contatore è minore di 5 allora inserisci il valore estratto nella cartella
                if (tuple.Item1!=0 && Cartella1[0, tuple.Item2] == 0 && contatore<5)
                {
                    Cartella1[0, tuple.Item2] = tuple.Item1;
                    //incremento del contatore
                    contatore++;
                }
                //se il valore estratto è diverso da 0, la posizione nella cartella non è già stata occupata, e il contatore è compreso tra 5 e 9 allora inserisci il valore estratto nella cartella
                if (tuple.Item1 != 0 && Cartella1[1, tuple.Item2] == 0 && contatore>4 && contatore < 10)
                {
                    Cartella1[1, tuple.Item2] = tuple.Item1;
                    //incremento del contatore
                    contatore++;
                }
                //se il valore estratto è diverso da 0, la posizione nella cartella non è già stata occupata, e il contatore è maggiore di 9 allora inserisci il valore estratto nella cartella
                if (tuple.Item1 != 0 && Cartella1[2, tuple.Item2] == 0 && contatore > 9)
                {
                    Cartella1[2, tuple.Item2] = tuple.Item1;
                    //incremento del contatore
                    contatore++;
                }
            }

            //resettamento del contatore e modifica delle posizioni
            contatore = 0; orizzontale = 50; verticale = 3;
            //ciclo di stampa
            for (int i = 0; i < 3; i++)
            {
                for (int z = 0; z < 9; z++)
                {
                    //posizionamento e stampa della cartella
                    Console.SetCursorPosition(orizzontale, verticale);
                    Console.WriteLine(Cartella1[i, z]);
                    orizzontale = orizzontale + 3;
                }
                //ritorno a sinistra per il cambio di riga
                orizzontale = 50;
                verticale++;
            }

            //stampa della seconda cartella
            while (contatore < 15)
            {
                //richiamo alla funzione di estrazione per la cartella
                var tuple = EstrazioneCartella(CopiaTabellone2);
                //se il valore estratto è diverso da 0, la posizione nella cartella non è già stata occupata, e il contatore è minore di 5 allora inserisci il valore estratto nella cartella
                if (tuple.Item1 != 0 && Cartella2[0, tuple.Item2] == 0 && contatore < 5)
                {
                    Cartella2[0, tuple.Item2] = tuple.Item1;
                    //incremento del contatore
                    contatore++;
                }
                //se il valore estratto è diverso da 0, la posizione nella cartella non è già stata occupata, e il contatore è compreso tra 5 e 9 allora inserisci il valore estratto nella cartella
                if (tuple.Item1 != 0 && Cartella2[1, tuple.Item2] == 0 && contatore > 4 && contatore < 10)
                {
                    Cartella2[1, tuple.Item2] = tuple.Item1;
                    //incremento del contatore
                    contatore++;
                }
                //se il valore estratto è diverso da 0, la posizione nella cartella non è già stata occupata, e il contatore è maggiore di 9 allora inserisci il valore estratto nella cartella
                if (tuple.Item1 != 0 && Cartella2[2, tuple.Item2] == 0 && contatore > 9)
                {
                    Cartella2[2, tuple.Item2] = tuple.Item1;
                    //incremento del contatore
                    contatore++;
                }
            }

            //resettamento del contatore e modifica delle posizion
            orizzontale = 50; verticale = 9;
            for (int i = 0; i < 3; i++)
            {
                for (int z = 0; z < 9; z++)
                {
                    //posizionamento e stampa della cartella
                    Console.SetCursorPosition(orizzontale, verticale);
                    Console.WriteLine(Cartella2[i, z]);
                    orizzontale = orizzontale + 3;
                }
                //ritorno a sinistra per il cambio di riga
                orizzontale = 50;
                verticale++;
            }
*/


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

        static Tuple<int, int> EstrazioneCartella(int[,] tab)
        {
            Random r = new Random();
            //assegnamento di un valore randomico alla riga
            int riga = r.Next(0, 9);
            //assegnamento di un valore randomico alla colonna
            int colonna = r.Next(0, 10);
            //estrazione numero casuale dalla copia della tabella
            int estr = tab[riga, colonna];
            //azzeramento del valore ottenuto per non farlo ripetere successivamente
            tab[riga, colonna] = 0;
            //copiatura del numero estratto per poi ricavare l'indice per posizionare il numero nella cartella
            int IndiceCalcolato = estr;
            IndiceCalcolato = (IndiceCalcolato / 10);
            //condizione in caso il numero sia 90 perchè anche questo va nell'ottava posizione della cartella
            if (estr == 90)
            {
                IndiceCalcolato = IndiceCalcolato - 1;
            }
            //utilizzo di tuple per più valori in return
            return Tuple.Create(estr, IndiceCalcolato);
        }
    }
}


