/*
 * Creado por SharpDevelop.
 * Usuario: brayhan garcia
 * Fecha: 17/4/2026
 * Hora: 2:26 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;


namespace taller_seccion_b
{
    class Program
    {
        public static void Main(string[] args)
        {
            string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DATOSIUJO");
            string rutaReportes = Path.Combine(rutaRaiz, "Reportes");
            string archivoSeguridad = Path.Combine(rutaReportes, "seguridad.txt");

            if (!Directory.Exists(rutaReportes))
            {
                Directory.CreateDirectory(rutaReportes);
                Console.WriteLine("directorio creado correctamente");
            }

            Console.WriteLine("ya lo hice");
            Console.WriteLine(rutaRaiz);
            Console.WriteLine(rutaReportes);

            Console.WriteLine("Introduce el usuario y la clave (formato: usuario;clave)");
            string entrada = Console.ReadLine();

            if (entrada.Contains(";"))
            {
                string[] partes = entrada.Split(';');
                string usuario = partes[0];
                string clave = partes[1];

                if (clave.Contains("123"))
                {
                    Console.WriteLine("Clave debil detectada, guardando aviso...");

                    using (StreamWriter sw = new StreamWriter(archivoSeguridad, true))
                    {
                        sw.WriteLine("Clave Debil detectada");
                    }
                }
                else
                {
                    Console.WriteLine("La clave es segura");
                }
            }

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}