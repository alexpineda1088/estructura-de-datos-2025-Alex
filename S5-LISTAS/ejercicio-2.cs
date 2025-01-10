using System; // Para el uso de la consola
using System.Collections.Generic; // Para manejar listas

class Program
{
    static void Main()
    {
        // Crear una lista que almacena las asignaturas del curso
        List<string> asignaturas = new List<string>()
        {
            "Matemáticas",  // Primera asignatura
            "Física",       // Segunda asignatura
            "Química",      // Tercera asignatura
            "Historia",     // Cuarta asignatura
            "Lengua"        // Quinta asignatura
        };

        // Mostrar un mensaje personalizado para cada asignatura
        foreach (string asignatura in asignaturas)
        {
            // El mensaje "Yo estudio <asignatura>"
            Console.WriteLine($"Yo estudio {asignatura}");
        }

        // Pausar la ejecución para que el usuario pueda ver el resultado
        Console.WriteLine("\nPresione cualquier tecla para finalizar...");
        Console.ReadKey(); // Espera a que el usuario presione una tecla
    }
}
