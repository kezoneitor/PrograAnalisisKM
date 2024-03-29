﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograAnalisisKM
{
    class Program
    {
        static int[][][] matriz;
        static Random rand = new Random();

        static void crearMatrizdeJuego(int n)
        {
            matriz = new int[n][][];
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
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int[] piezAux = new int[4];
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

        static void rotarpieza(int[] Pieza, int rotar)//llamamos la pieza que se quiere rotar
        {
            for (int a = 0; a < rotar; a++)// el ciclo que hara rotar la pieza las veces que se diga
            {
                int copia = Pieza[0], copia2 = Pieza[1], copia3 = Pieza[2], copia4 = Pieza[3];
                Pieza[0] = copia4;
                Pieza[1] = copia;
                Pieza[2] = copia2;
                Pieza[3] = copia3;
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
                    rotarpieza(matriz[i][j], rand.Next(4));
                }
            }
            imprimirMatriz(3);
        }
    }
}
