
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
            Console.WriteLine("Introduce el usuario y la clave (usuario;clave)");
            string entrada = Console.ReadLine();

            if (entrada != null && entrada.Contains(";"))
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

string rutaBase = Directory.GetCurrentDirectory();
int indiceRepo = rutaBase.IndexOf("repo_taller01_b");


string rutaRepositorio = (indiceRepo != -1) 
    ? rutaBase.Substring(0, indiceRepo + "repo_taller01_b".Length) 
    : rutaBase;

string imagenOrigen = Path.Combine(rutaRepositorio, "avatar.jpg");
string imagenDestino = Path.Combine(rutaReportes, "respaldo.jpg");

Console.WriteLine("Buscando imagen en: " + imagenOrigen);
            if (File.Exists(imagenOrigen))
            {
                using (FileStream fsIn = new FileStream(imagenOrigen, FileMode.Open, FileAccess.Read))
                using (FileStream fsOut = new FileStream(imagenDestino, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[1024];
                    int bytesLeidos;
                    while ((bytesLeidos = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fsOut.Write(buffer, 0, bytesLeidos);
                    }
                }
                Console.WriteLine("Imagen clonada byte a byte con exito");
            }
            else
            {
                Console.WriteLine("No se encontro la imagen en: " + imagenOrigen);
            }

            if (Directory.Exists(rutaReportes))
            {
                string[] archivos = Directory.GetFiles(rutaReportes);
                foreach (string archivo in archivos)
                {
                    FileInfo info = new FileInfo(archivo);
                    if (info.Length > 5120)
                    {
                        Console.WriteLine("Borrando archivo pesado: " + info.Name);
                        info.Delete();
                    }
                }
            }

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}