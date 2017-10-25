using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograAnalisisKM
{
    class ProgramObj
    {
        static Pieza[][] matriz;
        static Pieza[][] matrizResuelta;
        static Random rand = new Random();

        static void crearMatrizdeJuego(int n)
        {
            matriz = new Pieza[n][];
            for (int i = 0; i < n; i++)
            {
                matriz[i] = new Pieza[n];
                for (int j = 0; j < n; j++)
                {
                    Pieza pieza = new Pieza(rand.Next(1, 23), rand.Next(1, 23), rand.Next(1, 23), rand.Next(1, 23));
                    if (i - 1 >= 0)
                    {
                        pieza.setArr(matriz[i - 1][j].getAbj());
                    }
                    if (j - 1 >= 0)
                    {
                        pieza.setIzq(matriz[i][j - 1].getDer());
                    }
                    matriz[i][j] = pieza;
                }
            }

            //Crear los bordes grises del juego
            for (int i = 0; i < n; i++)
            {
                int j = 0;
                while (j < n)
                {
                    if (i == 0)
                        matriz[i][j].setArr(0);
                    if (j == 0)
                        matriz[i][j].setIzq(0);
                    if (i == n - 1)
                        matriz[i][j].setAbj(0);
                    if (j == n - 1)
                        matriz[i][j].setDer(0);
                    j++;
                }
            }
        }

        static void RevolverMatriz(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Pieza piezAux;
                    piezAux = matriz[i][j];
                    int iAux = rand.Next(0,n);
                    int jAux = rand.Next(0, n);
                    matriz[i][j] = matriz[iAux][jAux];
                    matriz[iAux][jAux] = piezAux;
                }
            }
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    matriz[i][j].rotarN(rand.Next(4));
                }
            }
        }

        static void imprimirMatriz(int n)
        {
            string top = "";
            string mid = "";
            string bot = "";
            string all = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matriz[i][j].getArr() < 10)
                    {
                        top += "| \\  " + matriz[i][j].getArr() + " / |";
                    }
                    else
                    {
                        top += "| \\ " + matriz[i][j].getArr() + " / |";
                    }
                    if (matriz[i][j].getIzq() < 10 && matriz[i][j].getDer() < 10)
                    {
                        mid += "|  " + matriz[i][j].getIzq() + "   " + matriz[i][j].getDer() + " |";
                    }
                    else if (matriz[i][j].getIzq() < 10 && matriz[i][j].getDer() >= 10)
                    {
                        mid += "|  " + matriz[i][j].getIzq() + "  " + matriz[i][j].getDer() + " |";
                    }
                    else if (matriz[i][j].getIzq() >= 10 && matriz[i][j].getDer() < 10)
                    {
                        mid += "| " + matriz[i][j].getIzq() + "   " + matriz[i][j].getDer() + " |";
                    }
                    else
                    {
                        mid += "| " + matriz[i][j].getIzq() + "  " + matriz[i][j].getDer() + " |";
                    }
                    if (matriz[i][j].getAbj() < 10)
                    {
                        bot += "|_/__" + matriz[i][j].getAbj() + "_\\_|";
                    }
                    else
                    {
                        bot += "|_/_" + matriz[i][j].getAbj() + "_\\_|";
                    }
                }
                all += top + "\n" + mid + "\n" + bot + "\n";
                top = mid = bot = "";
            }
            Console.Write(all);
            Console.ReadKey();
            Console.WriteLine("____________________________");
        }

        static void resolverGenetico()
        {

        }

        static void Main(string[] args)
        {
            //Creacion de la matriz inicial
            crearMatrizdeJuego(3);
            RevolverMatriz(3);
            imprimirMatriz(3);
        }
    }
}
