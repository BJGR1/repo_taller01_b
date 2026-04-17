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

namespace taller_secion_b
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("ya lo hice");
			
			//  directorio
			string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DATOSIUJO");
			
			string rutaReportes =Path.Combine(rutaRaiz, "Reportes");
			
			Console.WriteLine(rutaRaiz);
			Console.WriteLine(rutaReportes);
			if (!Directory.Exists(rutaReportes)){
				//crear el directorio reportes
				Directory.CreateDirectory(rutaReportes);
				Console.WriteLine("directorio creado correctamente");
			    
			}


			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}