using System;
using System.Diagnostics;
using System.IO;

namespace VerificadorDeInstalacion
{
    public static class RegistroInicio
    {
        public static void CrearAccesoDirecto()
        {
            string origen = @"C:\ruta\a\Main.exe"; // Actualiza con la ruta correcta
            string destino = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Microsoft\Windows\Start Menu\Programs\Startup\Main.lnk");

            try
            {
                if (!File.Exists(destino))
                {
                    // Usar comando shell para crear el acceso directo
                    string arguments = $"/C mklink \"{destino}\" \"{origen}\"";
                    ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", arguments)
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false
                    };
                    Process process = Process.Start(processInfo);
                    process.WaitForExit();

                    if (process.ExitCode == 0)
                    {
                        Console.WriteLine($"Acceso directo creado en: {destino}");
                    }
                    else
                    {
                        Console.WriteLine($"Error al crear el acceso directo. Código de salida: {process.ExitCode}");
                    }
                }
                else
                {
                    Console.WriteLine("El acceso directo ya existe.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error al crear el acceso directo: {e.Message}");
            }
        }
    }
}
