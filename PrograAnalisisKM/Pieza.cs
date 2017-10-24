using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograAnalisisKM
{
    class Pieza
    {
        private int arr, der, abj, izq;
        private bool colocada;
        private string tipo;

        public Pieza(int arr, int der, int abj, int izq)
        {
            this.arr = arr;
            this.der = der;
            this.abj = abj;
            this.izq = izq;
            this.tipo = "";
            this.colocada = false;
        }

        public void rotar()//llamamos la pieza que se quiere rotar
        {
            int aux = this.getIzq();
            this.setIzq(this.getArr());
            this.setArr(this.getDer());
            this.setDer(this.getAbj());
            this.setAbj(aux);
        }

        public void rotarN(int rotar)//llamamos la pieza que se quiere rotar
        {
            int aux;
            for (int a = 0; a < rotar; a++)// el ciclo que hara rotar la pieza las veces que se diga
            {
                aux = this.getIzq();
                this.setIzq(this.getArr());
                this.setArr(this.getDer());
                this.setDer(this.getAbj());
                this.setAbj(aux);
            }
        }

        public int getArr()
        {
            return this.arr;
        }
        public void setArr(int arr)
        {
            this.arr = arr;
        }

        public int getDer()
        {
            return this.der;
        }
        public void setDer(int der)
        {
            this.der = der;
        }

        public int getAbj()
        {
            return this.abj;
        }
        public void setAbj(int abj)
        {
            this.abj = abj;
        }

        public int getIzq()
        {
            return this.izq;
        }
        public void setIzq(int izq)
        {
            this.izq = izq;
        }

        public bool getColocada()
        {
            return this.colocada;
        }
        public void setColocada(bool colocada)
        {
            this.colocada = colocada;
        }

        public string getTipo()
        {
            return this.tipo;
        }
        public void setTipo(string tipo)
        {
            this.tipo = tipo;
        }

    }
}
