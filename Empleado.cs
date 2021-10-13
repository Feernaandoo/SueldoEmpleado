using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SueldoEmpleado
{
    public class Empleado
    {
        //Método constructor privado
        private Empleado()
        {
        }
        //Método que determina la hora según la categoría
        public static double asignaCostoHora(string categoria)
        {
            switch (categoria)
            {
                case "CAS": return 15;
                case "CAP": return 25;
            }
            return 0;
        }
        //Método que determina el monto bruto
        public static double calculaBruto(int horas, double costo)
        {
            return costo * horas;
        }
        //Método que determina el descuento
        public static double calculaDescuento(double bruto)
        {
            return 0.12 * bruto;
        }
        //Método que calcula el neto
        public static double calculaNeto(double bruto, double descuento)
        {
            return bruto - descuento;
        }
    }
}
