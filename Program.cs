using System;

class Aerolinea
{
    static int[] asientos = new int[60];
    static bool vueloCreado = false;
    static int asiento;

    // Crear vuelos
    static void CrearVuelo()
    {
        Console.Clear();
        Console.Write("¿Desea crear un vuelo? (si: 1, no: 0): ");
        string decision = Console.ReadLine();
        do
        {
            if (decision == "1")
            {
                vueloCreado = true;
                Console.Write("Vuelo creado con éxito, presiona ENTER para volver");
                Console.ReadLine();
                mostrarMenu();
            }
            else if (decision == "0")
            {
                mostrarMenu();
            }
            else
            {
                Console.Write("Opción inválida, inténtelo de nuevo: ");
                decision = Console.ReadLine();
            }
        } while ((decision != "0") || (decision != "1"));
    }

    // Reservar un asiento
    static void ReservarAsiento()
    {
        Console.Clear();
        Console.Write("Ingrese el número de asiento a reservar (1-60): ");
        asiento = int.Parse(Console.ReadLine()) - 1;
        while ((asiento < 0) || (asiento > 59))
        {
            Console.Write("El número de asiento ingresado no es válido. Inténtelo de nuevo: ");
            asiento = int.Parse(Console.ReadLine()) - 1;
        }
        if (asientos[asiento] == 0)
        { 
            asientos[asiento] = 1;
            Console.Write("Su asiento ha sido reservado con éxito. Presione ENTER para volver");
            Console.ReadLine();
            mostrarMenu();
        }
        else
        {
            Console.Write("El asiento ya esta ocupado. Presione ENTER para volver");
            Console.ReadLine();
            mostrarMenu();
        }
    }

    // Cancelar una reserva
    static void CancelarReserva()
    {
        Console.Clear();
        Console.Write("Ingrese el número de asiento a cancelar (1-60): ");
        asiento = int.Parse(Console.ReadLine()) - 1;
        while (asiento < 0 || asiento > 59)
        {
            Console.Write("El número de asiento ingresado no es válido. Inténtelo de nuevo: ");
            asiento = int.Parse(Console.ReadLine()) - 1;
        }
        if (asientos[asiento] == 1)
        {
            asientos[asiento] = 0;
            Console.Write("Su reserva ha sido cancelada con éxito. Presione ENTER para volver");
        }
        else
        {
            Console.Write("El asiento ya estaba disponible. Presione ENTER para volver");
        }
        Console.ReadLine();
        mostrarMenu();
    }

    // Mostrar el estado del vuelo (asientos ocupados y disponibles)
    static void MostrarEstadoVuelo()
    {
        Console.Clear();
        Console.WriteLine("Estado actual de los asientos:" + "\n");
        for (int i = 0; i < asientos.Length; i++)
        {
            string estado = asientos[i] == 0 ? "Libre" : "Ocupado"; 
            Console.WriteLine((i + 1) + ". " + estado);

            // Salto de línea cada 10 asientos
            if ((i + 1) % 10 == 0)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine("Presione ENTER para volver");
        Console.ReadLine();
        mostrarMenu();
    }

    // Mostrar la cantidad de asientos ocupados y disponibles en un vuelo
    static void MostrarCantidadAsientos()
    {
        int ocupados = 0;
        int disponibles = 0;
        foreach (var asiento in asientos)
        {
            if (asiento == 0)
                disponibles++;
            else
                ocupados++;
        }
        Console.Clear();
        Console.WriteLine("- Asientos disponibles: " + disponibles);
        Console.WriteLine("- Asientos ocupados: " + ocupados);
        Console.Write("\nPresione ENTER para volver");
        Console.ReadLine();
        mostrarMenu();
    }

    // Buscar un asiento específico
    static void BuscarAsiento()
    {
        Console.Clear();
        Console.Write("Ingrese el número de asiento a buscar (1-60): ");
        asiento = int.Parse(Console.ReadLine()) - 1;
        while (asiento < 0 || asiento > 59)
        {
            Console.Write("El número de asiento ingresado no es válido. Inténtelo de nuevo: ");
            asiento = int.Parse(Console.ReadLine()) - 1;
        }
        if (asientos[asiento] == 0)
        {
            Console.WriteLine("El asiento está disponible.");
        }
        else
        {
            Console.WriteLine("El asiento está ocupado.");
        }
        Console.Write("\nPresione ENTER para volver");
        Console.ReadLine();
        mostrarMenu();
    }

    // Mostrar menu para la comodidad del usuario
    static void mostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("Bienvenido al sistema de nuestra aereolínea, las opciones son las siguientes:");
        Console.Write("\n1. Crear vuelo" + "\n2. Reservar asiento" + "\n3. Cancelar una reserva" + "\n4. Mostrar estado del vuelo" + "\n5. Mostrar asientos" + "\n6. Buscar un asiento" + "\n7. Salir");
        Console.Write("\n" + "\nElija una opcion: ");
        int opcion = int.Parse(Console.ReadLine());
        while ((opcion < 1) || (opcion > 7))
        {
            Console.Write("Opción inválida, inténtelo de nuevo: ");
            opcion = int.Parse(Console.ReadLine());
        }
        switch (opcion)
        {
            case 1:
                if (!vueloCreado)
                {
                    CrearVuelo();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("El vuelo ya ha sido creado. Presione ENTER para volver al menú");
                    Console.ReadLine();
                    mostrarMenu();
                }
                break;

            case 2:
                if (vueloCreado)
                {
                    ReservarAsiento();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Antes debe crear un vuelo. Presione ENTER para volver al menú");
                    Console.ReadLine();
                    mostrarMenu();
                }
                break;

            case 3:
                if (vueloCreado)
                {
                    CancelarReserva();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Antes debe crear un vuelo. Presione ENTER para volver al menú");
                    Console.ReadLine();
                    mostrarMenu();
                }
                break;

            case 4:
                if (vueloCreado)
                {
                    MostrarEstadoVuelo();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Antes debe crear un vuelo. Presione ENTER para volver al menú");
                    Console.ReadLine();
                    mostrarMenu();
                }
                break;

            case 5:
                if (vueloCreado)
                {
                    MostrarCantidadAsientos();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Antes debe crear un vuelo. Presione ENTER para volver al menú");
                    Console.ReadLine();
                    mostrarMenu();
                }
                break;

            case 6:
                if (vueloCreado)
                {
                    BuscarAsiento();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Antes debe crear un vuelo. Presione ENTER para volver al menú");
                    Console.ReadLine();
                    mostrarMenu();
                }
                break;

            case 7:
                Console.WriteLine("Gracias por confiar en nuestra aereolínea, el sistema se cerrará");
                Environment.Exit(7);
                break;
        }
    }
    static void Main()
    {
        mostrarMenu();
    }
}
