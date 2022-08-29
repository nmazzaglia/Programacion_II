using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_3_Banco_Nico_V1
{
    internal class Cliente
    {
        private int codigo;
        private string nombre;
        private string apellido;
        private int dni;
        private Cuenta cuenta;
        

        public Cliente()
        {
            codigo = 0;
            nombre = String.Empty;
            apellido = String.Empty;
            dni = 0;
            //cuenta = new Cuenta();
        }

        public int Codigo
        { 
            get { return codigo; } 
            set { codigo = value; } 
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        

        override
        public string ToString()
        {
            return $"{codigo}-{apellido}, {nombre}";
        }
    }
}
