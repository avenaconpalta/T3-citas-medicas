using System;
using System.Collections.Generic;
using System.Linq;

public class Estudiante
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public string Universidad { get; set; }

    public Estudiante(int codigo, string nombre, string universidad)
    {
        Codigo = codigo;
        Nombre = nombre;
        Universidad = universidad;
    }

    public override string ToString()
    {
        return $"Código: {Codigo}, Nombre: {Nombre}, Universidad: {Universidad}";
    }
}

public class Cita
{
    public int Numero { get; set; }
    public Estudiante Estudiante { get; set; }
    public string Enfermedad { get; set; }
    public double Precio { get; set; }

    public Cita(int numero, Estudiante estudiante, string enfermedad, double precio)
    {
        Numero = numero;
        Estudiante = estudiante;
        Enfermedad = enfermedad;
        Precio = precio;
    }

    public override string ToString()
    {
        return $"Número: {Numero}, Enfermedad: {Enfermedad}, Estudiante: {Estudiante.Nombre}, Universidad: {Estudiante.Universidad}, Precio: {Precio:C}";
    }
}

public static class CitaUtil
{
    public static void CrearCita(List<Cita> citas)
    {
        Console.WriteLine("Ingrese los datos del estudiante:");
        Console.Write("Código: ");
        int codigo = int.Parse(Console.ReadLine());

        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Universidad: ");
        string universidad = Console.ReadLine();

        Estudiante estudiante = new Estudiante(codigo, nombre, universidad);

        Console.WriteLine("Ingrese los datos de la cita:");
        Console.Write("Número de cita: ");
        int numero = int.Parse(Console.ReadLine());

        Console.Write("Enfermedad: ");
        string enfermedad = Console.ReadLine();

        Console.Write("Precio: ");
        double precio = double.Parse(Console.ReadLine());

        Cita cita = new Cita(numero, estudiante, enfermedad, precio);
        citas.Add(cita);

        Console.WriteLine("Cita creada con éxito.");
    }

    public static void ListarCitas(List<Cita> citas)
    {
        double sumaPrecios = 0;

        foreach (var cita in citas)
        {
            Console.WriteLine(cita);
            sumaPrecios += cita.Precio;
        }

        Console.WriteLine($"Total de precios: {sumaPrecios:C}");
    }

    public static void ModificarUniversidad(List<Cita> citas, string textoOriginal, string textoNuevo)
    {
        foreach (var cita in citas)
        {
            if (cita.Estudiante.Universidad.Contains(textoOriginal))
            {
                cita.Estudiante.Universidad = cita.Estudiante.Universidad.Replace(textoOriginal, textoNuevo);
            }
        }

        Console.WriteLine("Modificación realizada con éxito.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Cita> citas = new List<Cita>();
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nMenú de opciones:");
            Console.WriteLine("1. Crear Cita");
            Console.WriteLine("2. Listar Citas");
            Console.WriteLine("3. Modificar Universidad de forma masiva");
            Console.WriteLine("4. Fin");
            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    CitaUtil.CrearCita(citas);
                    break;
                case 2:
                    CitaUtil.ListarCitas(citas);
                    break;
                case 3:
                    Console.Write("Ingrese el texto a buscar: ");
                    string textoOriginal = Console.ReadLine();
                    Console.Write("Ingrese el texto nuevo: ");
                    string textoNuevo = Console.ReadLine();
                    CitaUtil.ModificarUniversidad(citas, textoOriginal, textoNuevo);
                    break;
                case 4:
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }
}
