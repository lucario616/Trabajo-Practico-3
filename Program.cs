using System;

class Aerolinea
{
    static List<int[]> vuelos = new List<int[]>(); // Matriz jagged para los vuelos
    static int vueloSeleccionado = -1;
    static bool vueloCreado = false;

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
                vuelos.Add(new int[60]);
                Console.Write("Vuelo creado con éxito, vuelo número: " + vuelos.Count + "\nPresiona ENTER para volver");
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

    // Seleccionar un vuelo
    static void SeleccionarVuelo()
    {
        if (!vueloCreado)
        {
            Console.WriteLine("Debe crear un vuelo para seleccionarlo. Presione ENTER para volver.");
            Console.ReadLine();
            mostrarMenu();
            return;
        }
        Console.Clear();
        Console.Write("Ingrese el número de vuelo a seleccionar (1-{0}): ", vuelos.Count);
        vueloSeleccionado = int.Parse(Console.ReadLine()) - 1;
        while (vueloSeleccionado < 0 || vueloSeleccionado >= vuelos.Count)
        {
            Console.Write("Número de vuelo inválido. Inténtelo de nuevo: ");
            vueloSeleccionado = int.Parse(Console.ReadLine()) - 1;
        }
        Console.WriteLine("Vuelo {0} seleccionado. Presiona ENTER para continuar.", vueloSeleccionado + 1);
        Console.ReadLine();
        mostrarMenu();
    }


    // Reservar un asiento
    static void ReservarAsiento()
    {
        if (vueloSeleccionado == -1)
        {
            Console.WriteLine("Debe seleccionar un vuelo antes de reservar. Presione ENTER para volver.");
            Console.ReadLine();
            mostrarMenu();
            return;
        }

        Console.Clear();
        Console.Write("Ingrese el número de asiento a reservar (1-60): ");
        int asiento = int.Parse(Console.ReadLine()) - 1;
        while (asiento < 0 || asiento > 59)
        {
            Console.Write("Número de asiento inválido. Inténtelo de nuevo: ");
            asiento = int.Parse(Console.ReadLine()) - 1;
        }
        if (vuelos[vueloSeleccionado][asiento] == 0)
        {
            vuelos[vueloSeleccionado][asiento] = 1;
            Console.WriteLine("Su asiento ha sido reservado con éxito.");
        }
        else
        {
            Console.WriteLine("El asiento ya está ocupado.");
        }
        Console.WriteLine("Presione ENTER para volver.");
        Console.ReadLine();
        mostrarMenu();
    }

    // Cancelar una reserva
    static void CancelarReserva()
    {
        if (vueloSeleccionado == -1)
        {
            Console.WriteLine("Debe seleccionar un vuelo antes de cancelar una reserva. Presione ENTER para volver.");
            Console.ReadLine();
            mostrarMenu();
            return;
        }
        Console.Clear();
        Console.Write("Ingrese el número de asiento a cancelar (1-60): ");
        int asiento = int.Parse(Console.ReadLine()) - 1;
        while (asiento < 0 || asiento > 59)
        {
            Console.Write("Número de asiento inválido. Inténtelo de nuevo: ");
            asiento = int.Parse(Console.ReadLine()) - 1;
        }
        if (vuelos[vueloSeleccionado][asiento] == 1)
        {
            vuelos[vueloSeleccionado][asiento] = 0;
            Console.WriteLine("Reserva cancelada con éxito.");
        }
        else
        {
            Console.WriteLine("El asiento ya estaba disponible.");
        }
        Console.WriteLine("Presione ENTER para volver.");
        Console.ReadLine();
        mostrarMenu();
    }

    // Mostrar el estado del vuelo (asientos ocupados y disponibles)
    static void MostrarEstadoVuelo()
    {
        if (vueloSeleccionado == -1)
        {
            Console.WriteLine("Debe seleccionar un vuelo antes de ver su estado. Presione ENTER para volver.");
            Console.ReadLine();
            mostrarMenu();
            return;
        }
        Console.Clear();
        Console.WriteLine("Estado del vuelo {0}:", vueloSeleccionado + 1);
        Console.WriteLine();
        for (int i = 0; i < vuelos[vueloSeleccionado].Length; i++)
        {
            string estado = vuelos[vueloSeleccionado][i] == 0 ? "Libre" : "Ocupado";
            Console.WriteLine("Asiento {0}: {1}", i + 1, estado);
             
            //Salto de línea cada 10 asientos
            if ((i + 1) % 10 == 0)
            {
                Console.WriteLine();
            }
        }
        Console.Write("Presione ENTER para volver.");
        Console.ReadLine();
        mostrarMenu();
    }

    // Mostrar la cantidad de asientos ocupados y disponibles en un vuelo
    static void MostrarCantidadAsientos()
    {
        if (vueloSeleccionado == -1)
        {
            Console.WriteLine("Debe seleccionar un vuelo antes de ver el estado de sus asientos. Presione ENTER para volver.");
            Console.ReadLine();
            mostrarMenu();
            return;
        }
        int ocupados = 0;
        int disponibles = 0;
        foreach (var asiento in vuelos[vueloSeleccionado])
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
        if (vueloSeleccionado == -1)
        {
            Console.WriteLine("Debe seleccionar un vuelo antes de buscar un asiento. Presione ENTER para volver al menú.");
            Console.ReadLine();
            mostrarMenu();
            return;
        }
        Console.Clear();
        Console.Write("Ingrese el número de asiento a buscar (1-60): ");
        int asiento = int.Parse(Console.ReadLine()) - 1;
        while (asiento < 0 || asiento > 59)
        {
            Console.Write("El número de asiento ingresado no es válido. Inténtelo de nuevo: ");
            asiento = int.Parse(Console.ReadLine()) - 1;
        }
        if (vuelos[vueloSeleccionado][asiento] == 0)
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
        Console.Write("\n1. Crear vuelo" + "\n2. Seleccionar vuelo" + "\n3. Reservar asiento" + "\n4. Cancelar una reserva" + "\n5. Mostrar estado del vuelo" + "\n6. Mostrar asientos" + "\n7. Buscar un asiento" + "\n8. Salir");
        Console.Write("\n" + "\nElija una opcion: ");
        string opcion = Console.ReadLine();
        switch (opcion)
        {
            case "1":
                CrearVuelo();
                break;

            case "2":
                SeleccionarVuelo();
                break;

            case "3":
                ReservarAsiento();
                break;

            case "4":
                CancelarReserva();
                break;

            case "5":
                MostrarEstadoVuelo();
                break;

            case "6":
                MostrarCantidadAsientos();
                break;

            case "7":
                BuscarAsiento();
                break;

            case "8":
                Console.Write("Gracias por confiar en nuestra aereolínea, el sistema se cerrará");
                Environment.Exit(0);
                break;

            default:
                Console.Write("Opción inválida, presione ENTER para intentar de nuevo");
                Console.ReadLine();
                mostrarMenu();
                break;
        }
    }
    static void Main()
    {
        mostrarMenu();
    }
}
