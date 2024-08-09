using System;
using System.Collections.Generic;

namespace VerificadorDeInstalacion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> programas = new List<string>
            {
                "aida64", "rustdesk", "Anydesk", "Xprinter", "winrar", 
                "Crystaldisk", "Edge", "Chrome", "GanaT", 
                "Accesos_Directos", "GanaT_Bolivares", "GanaT_Pesos", "GanaT_Dolares"
            };
            
            List<string> faltantes = Verificador.VerificarProgramas(programas);
            foreach (string programa in faltantes)
            {
                Instalador.InstalarPrograma(programa);
            }
        }
    }
}
