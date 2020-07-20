using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

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
                Imprimir();
                Agregar("Dos");
                Agregar("Tres");
                Imprimir();
                Buscar("Uno");
                Eliminar("Dos");
                Imprimir();
                Buscar("Dos");
                Buscar("Tres");
                Imprimir();

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
                Console.Write($"Agregando[{Dato}] :  ");
                if (ValidaLleno())
                {
                    //forza la ejecución del catch y envía un mensaje 
                    //de exepción a desplegar evitando el resto del código.
                    throw new Exception("El arreglo está lleno");
                }

                if (ValidaExiste(Dato))
                {
                    Console.WriteLine($"{Dato} ya existe, no fue agregado");
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
                            Console.Write($"[{Dato}] Agregado \n");
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

                Console.WriteLine("\n------------------------\n");
                int arregloLength = Arreglo.Length;
                for(int i=0; i<arregloLength; i++)
                {
                    if(Arreglo[i] == null)
                    {
                        Console.WriteLine("\n------------------------\n");
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

        private static int Buscar(string dato, bool ban = true)
        {
            if (!ValidaVacio())
            {
                int pos = Array.IndexOf(Arreglo, dato);
                //me devuelve la posición en caso de ser llamada por eliminar
                if (!ban)
                    return pos;
                Console.Write($"Buscando [{dato}] :  ");
                //imprime los mensajes en pantalla en caso de utilizar el metodo
                //buscar directamente.
                if (pos > -1)
                    Console.WriteLine($"{dato} esta en el lugar [{pos}]");
                else
                    Console.WriteLine($"{dato} no se encuentra en la tabla");
                
            }
            //devuelve en los casos: arreglo vacio o dato no encontrado
            return -1;
        }

        private static void Eliminar(string dato)
        {
            //pos pide a Buscar la posicion sin los mensajes desplegados.
            int pos = Buscar(dato, false);
            Console.Write($"Eliminando [{dato}] :  ");
            if (pos == -1)
            {
                Console.WriteLine($"El dato {dato} no existe \n");
                return;
            }
            
            //como sabemos que si existe, lo eliminamos.
            Arreglo[pos] = null;
            Console.Write($"[{dato}] Eliminado \n");

            int arregloLength = Arreglo.Length;
            

            //recorre el siguiente elemento del arreglo empezando de pos para no dejar
            //espacios vacios entre los datos del arreglo.
            for (int i = pos; i<arregloLength; i++)
            {
                //si el siguiente valor esta vacio o se alcanzó el fin del arreglo.
                if (Arreglo[pos + 1] != null)
                {
                    //recorre el siguiente valor en el arreglo.
                    Arreglo[pos] = Arreglo[pos + 1];  
                    //como ya se hizo la copia, se borra para no duplicarlo.
                    Arreglo[pos + 1] = null;
                }
                else
                {
                    return; //si encuentra un espacio en blanco, lo saca de la busqueda.
                }
                
            }
        }



    }
}
