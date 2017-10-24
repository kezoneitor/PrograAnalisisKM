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
        }

        static void imprimirMatriz(int n)
        {
            string m = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m += "<" + matriz[i][j].getArr() + "," + matriz[i][j].getDer() + "," + matriz[i][j].getAbj() + "," + matriz[i][j].getIzq() + ">\t";
                    if (j == n - 1)
                        m += "\n";
                }
                m += "\n";
            }
            Console.Write(m);
            Console.ReadKey();
        }

        static void rotarpieza(ref Pieza pieza, int rotar)//llamamos la pieza que se quiere rotar
        {
            for (int a = 0; a < rotar; a++)// el ciclo que hara rotar la pieza las veces que se diga
            {
                Pieza copia = new Pieza(pieza.getIzq(), pieza.getArr(),  pieza.getDer(), pieza.getAbj());
                pieza = copia;
            }
        }

        static void Main(string[] args)
        {
            crearMatrizdeJuego(3);
            imprimirMatriz(3);
            RevolverMatriz(3);
            imprimirMatriz(3);
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    rotarpieza(ref matriz[i][j], rand.Next(4));
                }
            }
            imprimirMatriz(3);
        }
    }
}
