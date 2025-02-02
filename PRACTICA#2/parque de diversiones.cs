using System;
using System.Collections.Generic;

// Clase que representa a una persona en la cola
public class Persona
{
    // Propiedad para almacenar el nombre de la persona
    public string Nombre { get; set; }
    
    // Propiedad para almacenar el número de asiento asignado
    public int NumeroDeAsiento { get; set; }

    // Constructor que inicializa la persona con un nombre
    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}

// Clase que maneja la cola de espera y la asignación de asientos
public class ColaEspera
{
    // Cola de personas que esperan para subir a la atracción
    private Queue<Persona> cola;
    
    // Número máximo de asientos disponibles
    private int maxAsientos;
    
    // Variable que lleva la cuenta del próximo asiento disponible
    private int asientoActual;

    // Constructor que inicializa la cola de espera y el número de asientos
    public ColaEspera(int maxAsientos)
    {
        cola = new Queue<Persona>(); // Inicializa la cola vacía
        this.maxAsientos = maxAsientos; // Establece el número máximo de asientos
        this.asientoActual = 1; // El primer asiento es el número 1
    }

    // Método para agregar una persona a la cola de espera
    public void AgregarPersona(Persona persona)
    {
        // Verifica si hay espacio disponible en la cola (menos de 30 personas)
        if (cola.Count < maxAsientos)
        {
            // Asigna un número de asiento a la persona
            persona.NumeroDeAsiento = asientoActual++;
            
            // Agrega la persona a la cola
            cola.Enqueue(persona);
            
            // Muestra un mensaje en consola confirmando que la persona se ha agregado a la cola
            Console.WriteLine($"{persona.Nombre} se ha agregado a la cola y tiene el asiento {persona.NumeroDeAsiento}.");
        }
        else
        {
            // Si no hay espacio disponible, muestra un mensaje de error
            Console.WriteLine("Lo siento, todos los asientos están ocupados.");
        }
    }

    // Método para simular que una persona sube a la atracción
    public void SubirAlosAsientos()
    {
        // Verifica si hay personas en la cola de espera
        if (cola.Count > 0)
        {
            // Saca la primera persona de la cola (es la que sube primero)
            Persona persona = cola.Dequeue();
            
            // Muestra un mensaje en consola indicando que la persona está subiendo a la atracción
            Console.WriteLine($"{persona.Nombre} está subiendo a la atracción con el asiento número {persona.NumeroDeAsiento}.");
        }
        else
        {
            // Si no hay personas en la cola, muestra un mensaje indicando que la cola está vacía
            Console.WriteLine("No hay personas en la cola.");
        }
    }
}

// Clase principal que contiene el programa y ejecuta el flujo del sistema
class Program
{
    static void Main()
    {
        // Crea una nueva instancia de ColaEspera con un máximo de 30 asientos
        ColaEspera colaEspera = new ColaEspera(30);

        // Agregar personas a la cola de espera
        colaEspera.AgregarPersona(new Persona("Juan"));
        colaEspera.AgregarPersona(new Persona("Maria"));
        colaEspera.AgregarPersona(new Persona("Pedro"));

        // Simula que las personas suben a la atracción
        colaEspera.SubirAlosAsientos();
        colaEspera.SubirAlosAsientos();
        colaEspera.SubirAlosAsientos();

        // Intentar agregar una persona cuando ya no hay espacio (prueba de límite)
        colaEspera.AgregarPersona(new Persona("Ana"));
    }
}

