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
                Imprimir();
                Agregar("Uno");
                Agregar("Dos");
                Agregar("Dos");
                Agregar("Tres");
                Imprimir();
                Buscar("Uno");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
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
                    //forza la ejecución del catch y envía un mensaje 
                    //de exepción a desplegar evitando el resto del código.
                    throw new Exception("El arreglo está lleno");
                }

                if (ValidaExiste(Dato))
                {
                    Console.WriteLine($"Ya existe {Dato} en el arreglo");
                    return;
                }
                
                    //variable para almacenar la longitud del arreglo, de tal forma que 
                    //en una iteración muy grande, evite que el for este preguntando por
                    //el .Length del arreglo repetidas veces.
                    int arregloLength = Arreglo.Length;
                    for(int i=0; i<arregloLength; i++)
                    {
                        if(Arreglo[i] == null)
                        {
                            Arreglo[i] = Dato;
                            break;
                        }
                    }
                                     
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private static void Imprimir()
        {
            try
            {
                if (ValidaVacio())
                {
                    Console.WriteLine("El arreglo está vacío");
                    return;
                }
                

                int arregloLength = Arreglo.Length;
                for(int i=0; i<arregloLength; i++)
                {
                    if(Arreglo[i] == null)
                    {
                        Console.WriteLine("Fin del arreglo");
                        break;
                    }
                    Console.WriteLine($"[{i}] - {Arreglo[i]}");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private static void Buscar(string dato)
        {
            if (!ValidaVacio())
            {
                int pos = Array.IndexOf(Arreglo, dato);
                if (pos > -1)
                {
                    Console.WriteLine($"{dato} esta en el lugar [{pos}]");
                    return;
                }
                Console.WriteLine($"{dato} no se encuentra en la tabla");
            }
        }



    }
}
