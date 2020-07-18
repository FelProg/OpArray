using System;
using System.Globalization;

namespace OpArray
{
    class Program
    {
        static string[] Arreglo = new string[10];
        static void Main(string[] args)
        {
            try
            {
                Agregar("Cero");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private static bool ValidaVacio()
        {
            return Arreglo[0] == null ? true : false;
        }

        private static bool ValidaLleno()
        {
            return Arreglo[Arreglo.Length - 1] != null ? true : false;
        }

        private static bool ValidaExiste(string Dato)
        {
            if (!ValidaVacio())//Si el arreglo no esta vacío
            {
                foreach(string registro in Arreglo)
                {
                    if(registro == null)
                    {
                        return false;
                    }

                    if (registro.ToUpper() == Dato.ToUpper())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static void Agregar(string Dato)
        {
            try
            {
                if (ValidaLleno())
                {
                    throw new Exception("El arreglo está lleno");
                }

                if (!ValidaExiste(Dato))
                {
                    int arregloLength = Arreglo.Length;
                    for(int i=0; i<Arreglo.Length; i++)
                    {
                        if(Arreglo[i] == null)
                        {
                            Arreglo[i] = Dato;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
