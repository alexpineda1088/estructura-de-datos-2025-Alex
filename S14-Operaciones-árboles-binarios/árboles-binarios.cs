using System;

class Nodo
{
    public int dato;
    public Nodo izquierda, derecha;

    public Nodo(int dato)
    {
        this.dato = dato;
        izquierda = derecha = null;
    }
}

class ArbolBinario
{
    public Nodo raiz;

    public void Insertar(int dato)
    {
        raiz = InsertarRecursivo(raiz, dato);
    }

    private Nodo InsertarRecursivo(Nodo raiz, int dato)
    {
        if (raiz == null)
        {
            return new Nodo(dato);
        }

        if (dato < raiz.dato)
        {
            raiz.izquierda = InsertarRecursivo(raiz.izquierda, dato);
        }
        else if (dato > raiz.dato)
        {
            raiz.derecha = InsertarRecursivo(raiz.derecha, dato);
        }

        return raiz;
    }

    public bool Buscar(int dato)
    {
        return BuscarRecursivo(raiz, dato);
    }

    private bool BuscarRecursivo(Nodo raiz, int dato)
    {
        if (raiz == null) return false;
        if (raiz.dato == dato) return true;

        return dato < raiz.dato ? BuscarRecursivo(raiz.izquierda, dato) : BuscarRecursivo(raiz.derecha, dato);
    }

    public void RecorridoInorden()
    {
        RecorridoInorden(raiz);
        Console.WriteLine();
    }

    private void RecorridoInorden(Nodo raiz)
    {
        if (raiz != null)
        {
            RecorridoInorden(raiz.izquierda);
            Console.Write(raiz.dato + " ");
            RecorridoInorden(raiz.derecha);
        }
    }

    public void RecorridoPreorden()
    {
        RecorridoPreorden(raiz);
        Console.WriteLine();
    }

    private void RecorridoPreorden(Nodo raiz)
    {
        if (raiz != null)
        {
            Console.Write(raiz.dato + " ");
            RecorridoPreorden(raiz.izquierda);
            RecorridoPreorden(raiz.derecha);
        }
    }

    public void RecorridoPostorden()
    {
        RecorridoPostorden(raiz);
        Console.WriteLine();
    }

    private void RecorridoPostorden(Nodo raiz)
    {
        if (raiz != null)
        {
            RecorridoPostorden(raiz.izquierda);
            RecorridoPostorden(raiz.derecha);
            Console.Write(raiz.dato + " ");
        }
    }

    public void Eliminar(int dato)
    {
        raiz = EliminarRecursivo(raiz, dato);
    }

    private Nodo EliminarRecursivo(Nodo raiz, int dato)
    {
        if (raiz == null) return raiz;

        if (dato < raiz.dato)
        {
            raiz.izquierda = EliminarRecursivo(raiz.izquierda, dato);
        }
        else if (dato > raiz.dato)
        {
            raiz.derecha = EliminarRecursivo(raiz.derecha, dato);
        }
        else
        {
            if (raiz.izquierda == null) return raiz.derecha;
            else if (raiz.derecha == null) return raiz.izquierda;

            raiz.dato = MinValor(raiz.derecha);
            raiz.derecha = EliminarRecursivo(raiz.derecha, raiz.dato);
        }

        return raiz;
    }

    private int MinValor(Nodo nodo)
    {
        int minv = nodo.dato;
        while (nodo.izquierda != null)
        {
            minv = nodo.izquierda.dato;
            nodo = nodo.izquierda;
        }
        return minv;
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion, valor;

        do
        {
            Console.WriteLine("\n--- Menú de Árbol Binario ---");
            Console.WriteLine("1. Insertar un número");
            Console.WriteLine("2. Buscar un número");
            Console.WriteLine("3. Recorrido Inorden");
            Console.WriteLine("4. Recorrido Preorden");
            Console.WriteLine("5. Recorrido Postorden");
            Console.WriteLine("6. Eliminar un número");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (int.TryParse(Console.ReadLine(), out opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el número a insertar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                            arbol.Insertar(valor);
                        else
                            Console.WriteLine("Entrada no válida.");
                        break;
                    case 2:
                        Console.Write("Ingrese el número a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                            Console.WriteLine(arbol.Buscar(valor) ? "Número encontrado" : "Número no encontrado");
                        else
                            Console.WriteLine("Entrada no válida.");
                        break;
                    case 3:
                        Console.WriteLine("Recorrido Inorden:");
                        arbol.RecorridoInorden();
                        break;
                    case 4:
                        Console.WriteLine("Recorrido Preorden:");
                        arbol.RecorridoPreorden();
                        break;
                    case 5:
                        Console.WriteLine("Recorrido Postorden:");
                        arbol.RecorridoPostorden();
                        break;
                    case 6:
                        Console.Write("Ingrese el número a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            arbol.Eliminar(valor);
                            Console.WriteLine("Número eliminado (si existía).");
                        }
                        else
                            Console.WriteLine("Entrada no válida.");
                        break;
                    case 7:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
            }

        } while (opcion != 7);
    }
}
