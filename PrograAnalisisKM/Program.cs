using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograAnalisisKM
{
    class Program
    {
        static int[][][] matriz;

        static void crearMatrizdeJuego(int n)
        {
            matriz = new int[n][][];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                matriz[i] = new int[n][];
                for (int j = 0; j < n; j++)
                {
                    matriz[i][j] = new int[4];
                    matriz[i][j][0] = rand.Next(1, 23);
                    matriz[i][j][1] = rand.Next(1, 23);
                    matriz[i][j][2] = rand.Next(1, 23);
                    matriz[i][j][3] = rand.Next(1, 23);
                    if (i - 1 >= 0)
                    {
                        matriz[i][j][0] = matriz[i - 1][j][2];
                    }
                    if (j - 1 >= 0)
                    {
                        matriz[i][j][3] = matriz[i][j - 1][1];
                    }
                }
            }
            //Crear los bordes grises del juego
            for (int i = 0; i < n; i++)
            {
                int j = 0;
                while (j < n)
                {
                    if (i == 0)
                        matriz[i][j][0] = 0;
                    if (j == 0)
                        matriz[i][j][3] = 0;
                    if (i == n - 1)
                        matriz[i][j][2] = 0;
                    if (j == n - 1)
                        matriz[i][j][1] = 0;
                    j++;
                }
            }
        }

        static void RevolverMatriz(int n)
        {

            Random rand = new Random();
            //holisman
        }

        static void imprimirMatriz(int n)
        {
            string m = "";
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    m += "<";
                    for (int k = 0; k < 4; k++)
                    {
                        m += matriz[i][j][k] + ",";
                    }
                    m += ">\t";
                    if (j == n - 1)
                        m += "\n";
                }
                m += "\n";
            }
            Console.Write(m);
            Console.ReadKey();
        }

        static void rotarpieza(int[] Pieza)//llamamos la pieza que se quiere rotar
        {
            Random rand = new Random();// funcion para el random
            int random = rand.Next(4);// elegimos un random para ver cuanto se va a rotar la pieza
            Console.WriteLine("Random= " + random);
            for (int a = 0; a < random; a++)// el ciclo que hara rotar la pieza las veces que se diga
            {
                int copia = Pieza[0], copia2 = Pieza[1], copia3 = Pieza[2], copia4 = Pieza[3];
                Pieza[0] = copia4;
                Pieza[1] = copia;
                Pieza[2] = copia2;
                Pieza[3] = copia3;
            }
            Console.WriteLine(
                    "La pieza en la posicion 0 = " + Pieza[0] + "\n" +
                    "La pieza en la posicion 1 = " + Pieza[1] + "\n" +
                    "La pieza en la posicion 2 = " + Pieza[2] + "\n" +
                    "La pieza en la posicion 3 = " + Pieza[3] + "\n"
                 );
            Console.ReadKey();

        }


        static void Main(string[] args)
        {
            crearMatrizdeJuego(4);
            imprimirMatriz(4);
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    rotarpieza(matriz[i][j]);
                }
            }
        }
    }
}
