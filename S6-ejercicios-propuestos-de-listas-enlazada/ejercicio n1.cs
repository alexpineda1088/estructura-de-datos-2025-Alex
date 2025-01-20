using System;

// Clase Nodo que representa un elemento de la lista enlazada
class Nodo
{
    public int Valor; // Almacena el valor del nodo
    public Nodo Siguiente; // Apunta al siguiente nodo de la lista

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

// Clase ListaEnlazada para gestionar la lista
class ListaEnlazada
{
    public Nodo Cabeza; // Primer nodo de la lista

    public ListaEnlazada()
    {
        Cabeza = null;
    }

    // Método para agregar un nodo al final de la lista
    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);

        if (Cabeza == null)
        {
            // Si la lista está vacía, el nuevo nodo es la cabeza
            Cabeza = nuevoNodo;
        }
        else
        {
            // Recorremos la lista hasta el final
            Nodo actual = Cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            // Agregamos el nuevo nodo al final
            actual.Siguiente = nuevoNodo;
        }
    }

    // Método para eliminar nodos fuera del rango
    public void EliminarFueraDeRango(int min, int max)
    {
        // Eliminamos nodos al principio que estén fuera del rango
        while (Cabeza != null && (Cabeza.Valor < min || Cabeza.Valor > max))
        {
            Cabeza = Cabeza.Siguiente;
        }

        // Recorremos la lista para eliminar nodos en el medio o al final
        Nodo actual = Cabeza;
        while (actual != null && actual.Siguiente != null)
        {
            if (actual.Siguiente.Valor < min || actual.Siguiente.Valor > max)
            {
                // Saltamos el nodo fuera de rango
                actual.Siguiente = actual.Siguiente.Siguiente;
            }
            else
            {
                // Avanzamos al siguiente nodo
                actual = actual.Siguiente;
            }
        }
    }

    // Método para imprimir los elementos de la lista
    public void Imprimir()
    {
        Nodo actual = Cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();
        Random random = new Random();

        // Llenamos la lista con 50 números aleatorios entre 1 y 999
        for (int i = 0; i < 50; i++)
        {
            int numeroAleatorio = random.Next(1, 1000); // Genera un número aleatorio entre 1 y 999
            lista.Agregar(numeroAleatorio);
        }

        // Imprimimos la lista original
        Console.WriteLine("Lista original:");
        lista.Imprimir();

        // Leemos los límites del rango desde el teclado
        Console.WriteLine("Ingrese el límite inferior del rango:");
        int limiteInferior = int.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el límite superior del rango:");
        int limiteSuperior = int.Parse(Console.ReadLine());

        // Eliminamos los nodos fuera del rango
        lista.EliminarFueraDeRango(limiteInferior, limiteSuperior);

        // Imprimimos la lista modificada
        Console.WriteLine("Lista después de eliminar nodos fuera del rango:");
        lista.Imprimir();
    }
}
