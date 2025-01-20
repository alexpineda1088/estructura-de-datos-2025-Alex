using System;
using System.Collections.Generic;

// Clase Nodo que representa un vehículo
class Nodo
{
    public string Placa; // Placa del vehículo
    public string Marca; // Marca del vehículo
    public string Modelo; // Modelo del vehículo
    public int Anio; // Año del vehículo
    public decimal Precio; // Precio del vehículo
    public Nodo Siguiente; // Apunta al siguiente nodo de la lista

    public Nodo(string placa, string marca, string modelo, int anio, decimal precio)
    {
        Placa = placa;
        Marca = marca;
        Modelo = modelo;
        Anio = anio;
        Precio = precio;
        Siguiente = null;
    }
}

// Clase ListaEnlazada para gestionar la lista de vehículos
class ListaEnlazada
{
    public Nodo Cabeza; // Primer nodo de la lista

    public ListaEnlazada()
    {
        Cabeza = null;
    }

    // Método para agregar un vehículo a la lista
    public void AgregarVehiculo(string placa, string marca, string modelo, int anio, decimal precio)
    {
        Nodo nuevoNodo = new Nodo(placa, marca, modelo, anio, precio);

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

    // Método para buscar un vehículo por placa
    public Nodo BuscarPorPlaca(string placa)
    {
        Nodo actual = Cabeza;
        while (actual != null)
        {
            if (actual.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase))
            {
                return actual; // Retorna el nodo si encuentra la placa
            }
            actual = actual.Siguiente;
        }
        return null; // Retorna null si no encuentra el vehículo
    }

    // Método para mostrar vehículos por año
    public void VerPorAnio(int anio)
    {
        Nodo actual = Cabeza;
        bool encontrado = false;
        while (actual != null)
        {
            if (actual.Anio == anio)
            {
                Console.WriteLine($"Placa: {actual.Placa}, Marca: {actual.Marca}, Modelo: {actual.Modelo}, Año: {actual.Anio}, Precio: {actual.Precio:C}");
                encontrado = true;
            }
            actual = actual.Siguiente;
        }
        if (!encontrado)
        {
            Console.WriteLine("No se encontraron vehículos para el año especificado.");
        }
    }

    // Método para mostrar todos los vehículos registrados
    public void VerTodosLosVehiculos()
    {
        Nodo actual = Cabeza;
        if (actual == null)
        {
            Console.WriteLine("No hay vehículos registrados.");
            return;
        }

        while (actual != null)
        {
            Console.WriteLine($"Placa: {actual.Placa}, Marca: {actual.Marca}, Modelo: {actual.Modelo}, Año: {actual.Anio}, Precio: {actual.Precio:C}");
            actual = actual.Siguiente;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada listaVehiculos = new ListaEnlazada();
        int opcion;

        do
        {
            Console.WriteLine("\n*** Sistema de Registro de Vehículos ***");
            Console.WriteLine("1. Agregar vehículo");
            Console.WriteLine("2. Buscar vehículo por placa");
            Console.WriteLine("3. Ver vehículos por año");
            Console.WriteLine("4. Ver todos los vehículos registrados");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Por favor, ingrese una opción válida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese la placa del vehículo: ");
                    string placa = Console.ReadLine();
                    Console.Write("Ingrese la marca del vehículo: ");
                    string marca = Console.ReadLine();
                    Console.Write("Ingrese el modelo del vehículo: ");
                    string modelo = Console.ReadLine();
                    Console.Write("Ingrese el año del vehículo: ");
                    int anio = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el precio del vehículo: ");
                    decimal precio = decimal.Parse(Console.ReadLine());

                    listaVehiculos.AgregarVehiculo(placa, marca, modelo, anio, precio);
                    Console.WriteLine("Vehículo agregado con éxito.");
                    break;

                case 2:
                    Console.Write("Ingrese la placa del vehículo a buscar: ");
                    string placaBusqueda = Console.ReadLine();
                    Nodo vehiculoEncontrado = listaVehiculos.BuscarPorPlaca(placaBusqueda);

                    if (vehiculoEncontrado != null)
                    {
                        Console.WriteLine($"Vehículo encontrado: Placa: {vehiculoEncontrado.Placa}, Marca: {vehiculoEncontrado.Marca}, Modelo: {vehiculoEncontrado.Modelo}, Año: {vehiculoEncontrado.Anio}, Precio: {vehiculoEncontrado.Precio:C}");
                    }
                    else
                    {
                        Console.WriteLine("Vehículo no encontrado.");
                    }
                    break;

                case 3:
                    Console.Write("Ingrese el año de los vehículos a mostrar: ");
                    int anioBusqueda = int.Parse(Console.ReadLine());
                    listaVehiculos.VerPorAnio(anioBusqueda);
                    break;

                case 4:
                    Console.WriteLine("\nVehículos registrados:");
                    listaVehiculos.VerTodosLosVehiculos();
                    break;

                case 5:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }

        } while (opcion != 5);
    }
}

