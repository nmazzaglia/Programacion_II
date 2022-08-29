using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema1_3_Banco_Nico_V1
{
    internal class Cuenta
    {
        private int cbu;
        private decimal saldo;
        private int tipoCuenta;
        private int ultimoMovimiento;

        public Cuenta()
        {
            cbu = 0;
            saldo = 0;
            tipoCuenta = 0;
            ultimoMovimiento = 0;
        }

        public override string ToString()
        {
            return $"CBU: {cbu},Saldo ${saldo},Tipo de Cuena {tipoCuenta},Ultimo movimiento {ultimoMovimiento}";
        }

    }
}
