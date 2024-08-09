using System;
using System.Collections.Generic;
using System.IO;

namespace VerificadorDeInstalacion
{
    public static class Verificador
    {
        private static readonly Dictionary<string, string[]> PROGRAMS = new Dictionary<string, string[]>
        {
            { "aida64", new string[] { @"C:\Program Files (x86)\FinalWire\AIDA64 Extreme\aida64.exe" } },
            { "rustdesk", new string[] { @"C:\Program Files\RustDesk\rustdesk.exe" } },
            { "Anydesk", new string[] { @"C:\Program Files (x86)\AnyDesk\Anydesk.exe" } },
            { "Xprinter", new string[] { @"C:\XINYE POS Printer Driver\XPrinter Driver V7.77\XPrinter Driver V7.77.exe" } },
            { "winrar", new string[] { @"C:\Program Files\WinRAR\WinRAR.exe" } },
            { "Crystaldisk", new string[] { @"C:\Program Files\CrystalDiskInfo\DiskInfo64.exe" } },
            { "Edge", new string[] { @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe" } },
            { "Chrome", new string[] { @"C:\Program Files\Google\Chrome\Application\chrome.exe" } },
            { "GanaT_Bolivares", new string[] { @"C:\GanaT_Bolivares\GanaT.exe" } },
            { "GanaT_Pesos", new string[] { @"C:\GanaT_Pesos\GanaT.exe" } },
            { "GanaT_Dolares", new string[] { @"C:\GanaT_Dolares\GanaT.exe" } },
            { "GanaT", new string[] 
                { 
                    @"C:\%USERPROFILE%\Desktop\GanaT Bolivares.lnk",
                    @"C:\%USERPROFILE%\Desktop\GanaT Dolares.lnk",
                    @"C:\%USERPROFILE%\Desktop\GanaT Pesos.lnk"
                } 
            },
            { "Accesos_Directos", new string[]
                {
                    @"C:\%USERPROFILE%\Desktop\KingDeportes.lnk",
                    @"C:\%USERPROFILE%\Desktop\PagoListo.lnk",
                    @"C:\%USERPROFILE%\Desktop\Bemovil.lnk",
                    @"C:\%USERPROFILE%\Desktop\MisMarcadores.lnk",
                    @"C:\%USERPROFILE%\Desktop\SuperGana.lnk",
                    @"C:\%USERPROFILE%\Desktop\Payall.lnk",
                    @"C:\%USERPROFILE%\Desktop\Visitanos en Gana Loterias.lnk"
                }
            }
        };

        public static List<string> VerificarProgramas(List<string> programas)
        {
            List<string> faltantes = new List<string>();
            foreach (string programa in programas)
            {
                if (PROGRAMS.ContainsKey(programa))
                {
                    bool encontrado = false;
                    foreach (string path in PROGRAMS[programa])
                    {
                        if (File.Exists(Environment.ExpandEnvironmentVariables(path)))
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (!encontrado)
                    {
                        faltantes.Add(programa);
                    }
                }
            }
            return faltantes;
        }
    }
}
