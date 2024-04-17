using System;

namespace Hoja_de_Trabajo___Tablas_Hash
{
    class Program
    {
        static void Main(string[] args)
        {
            // Agregar empleados por defecto
            Empleado empleadoJuan = new Empleado("Juan", "101", "Ventas");
            Empleado empleadoMaria = new Empleado("María", "102", "Finanzas");
            Empleado empleadoPedro = new Empleado("Pedro", "103", "TI");

            int opcion = 0;

            while (opcion != 4)
            {
                Console.WriteLine("1. Mostrar empleados");
                Console.WriteLine("2. Buscar empleado");
                Console.WriteLine("3. Agregar empleado");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Empleado.MostrarEmpleados();
                        break;
                    case 2:
                        Console.Write("ID del empleado: ");
                        string ID = Console.ReadLine();
                        Empleado.BuscarEmpleado(ID);
                        break;
                    case 3:
                        Empleado.agregarEmpleado();
                        break;
                    case 4:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida");
                        break;
                }
            }
        }
    }
}