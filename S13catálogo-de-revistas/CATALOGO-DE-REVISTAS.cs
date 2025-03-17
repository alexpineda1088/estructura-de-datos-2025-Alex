using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear el catálogo de revistas 
        List<string> catalogo = new List<string>
        {
            "Vistazo",
            "Familia",
            "Hogar",
            "La Onda",
            "Semana",
            "El Comercio Revista",
            "Expreso Revista",
            "El mercurio Cuenca",
            "Revista Metro",
            "Gente"
        };

        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar un título");
            Console.WriteLine("2. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "2")
            {
                break;
            }
            else if (opcion == "1")
            {
                Console.Write("Ingrese el título de la revista a buscar: ");
                string titulo = Console.ReadLine();
                
                // Se puede usar cualquiera de las dos búsquedas:
                bool encontrado = BusquedaIterativa(catalogo, titulo);
                // bool encontrado = BusquedaRecursiva(catalogo, titulo, 0);
                
                Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
            }
            else
            {
                Console.WriteLine("Opción no válida, intente de nuevo.");
            }
        }
    }

    // Método de búsqueda iterativa
    static bool BusquedaIterativa(List<string> catalogo, string titulo)
    {
        foreach (string revista in catalogo)
        {
            if (revista.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true; // Se encontró el título
            }
        }
        return false; // No se encontró el título
    }

    // Método de búsqueda recursiva
    static bool BusquedaRecursiva(List<string> catalogo, string titulo, int indice)
    {
        if (indice >= catalogo.Count)
        {
            return false; // Si se recorrió toda la lista y no se encontró, devolver false
        }
        if (catalogo[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase))
        {
            return true; // Se encontró el título
        }
        return BusquedaRecursiva(catalogo, titulo, indice + 1); // Llamada recursiva
    }
}
