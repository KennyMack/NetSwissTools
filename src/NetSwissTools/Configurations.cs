using System;
using System.Collections.Generic;
using System.Text;

namespace NetSwissTools
{
    public class Configurations
    {
        static string[] UFListBase =
        {
            "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS",
            "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC",
            "SP", "SE", "TO", "EX"
        };

        public static string[] UFList => UFListBase;

        public static void SetDefaultUFList(string[] list) =>
            UFListBase = list;
    }
}
