namespace Hoja_de_Trabajo___Tablas_Hash;

using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;

public class Empleado
{
    
    //Tabla Hash
    public static Hashtable TablaEmpleados = new Hashtable();
    private string Nombre { get; set; }
    private string ID { get; set; }
    private string Departamento { get; set; }
    
    public Empleado(string nombre, string NoEmpleado, string departamento)
    {
        Nombre = nombre;
        ID = NoEmpleado;
        Departamento = departamento;
        
        //Agregar a la tabla
        TablaEmpleados.Add(EncriptarSHA256(ID), this);
    }
    
    private static string EncriptarSHA256(string ID)
    {
        //Encriptar
        using (SHA256 sha256Hash = SHA256.Create())
        {
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(ID));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    
    public static void MostrarEmpleados()
    {
        foreach (DictionaryEntry empleado in TablaEmpleados)
        {
            Console.WriteLine("ID: {0}, Nombre: {1}, Departamento: {2}", ((Empleado)empleado.Value).ID, ((Empleado)empleado.Value).Nombre, ((Empleado)empleado.Value).Departamento);
        }
    }
    
    public static void BuscarEmpleado(string ID)
    {
        string IDEncriptado = EncriptarSHA256(ID); // Encriptar el ID para buscar en la tabla
        if (TablaEmpleados.ContainsKey(IDEncriptado))
        {
            Empleado empleado = (Empleado)TablaEmpleados[IDEncriptado]; // Usar el ID encriptado para buscar en la tabla
            Console.WriteLine("ID: {0}, Nombre: {1}, Departamento: {2}", ID, empleado.Nombre, empleado.Departamento);
        }
        else
        {
            Console.WriteLine("Empleado no encontrado");
        }
    }
    
    public static void agregarEmpleado()
    {
        Console.WriteLine("Ingrese el nombre del empleado");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese el número de empleado");
        string NoEmpleado = Console.ReadLine();
        Console.WriteLine("Ingrese el departamento");
        string departamento = Console.ReadLine();
    
        if (TablaEmpleados.ContainsKey(EncriptarSHA256(NoEmpleado)))
        {
            // Empleado con el mismo número de empleado ya existe
            Console.WriteLine("Error: El número de empleado ya está en uso vuelva a ingresar los datos nuevamente");
            agregarEmpleado();
        }
        else
        {
            // Agregar un nuevo empleado
            Empleado empleado = new Empleado(nombre, NoEmpleado, departamento);
            Console.WriteLine("Empleado agregado correctamente.");
        }
    }


    
    
}