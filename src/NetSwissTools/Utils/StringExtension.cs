using NetSwissTools.Exceptions;
using NetSwissTools.System;
using NetSwissTools.Validations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace NetSwissTools.Utils
{
    public static class StringExtension
    {
        /// <summary>
        /// Cuts the text up to the indicated position and returns the indicated 
        /// number of characters.
        /// if the number of characters is greater than the text size all the text will be returned
        /// </summary>
        /// <param name="text">Text to be cutted</param>
        /// <param name="start">Initial position</param>
        /// <param name="count">Number of characters</param>
        /// <returns>System.String.</returns>
        public static string SubStr(this string text, int start, int count)
        {
            if (text.Length > count && count > 0)
                return text.Substring(start, count);

            return text;
        }

        /// <summary>
        /// Cut string to short string
        /// </summary>
        /// <param name="value">text</param>
        /// <param name="size">size of string</param>
        /// <returns>System.String</returns>
        public static string ToShortString(this string value, int size = 60) =>
            value.SubStr(0, size);

        /// <summary>
        /// make the first character of the text uppercase
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>System.String.</returns>
        public static string CapitalizeFirst(this string text)
        {
            if (text.Length > 1)
                return $"{text.SubStr(0, 1).ToUpper()}{text.Substring(1)}";

            return text.ToUpper();
        }

        /// <summary>
        /// Title case
        /// </summary>
        /// <param name="text">texto</param>
        /// <returns>System.String.</returns>
        public static string ToTitleCase(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);
        }

        /// <summary>
        /// Check if the string is empty
        /// </summary>
        /// <param name="text">Text</param>
        /// <returns>System.bool.</returns>
        public static bool IsEmpty(this string text)
        {
            return string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text);
        }

        /// <summary>
        /// Removes duplicate spaces from the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string RemoveDoubleSpaces(this string value)
        {
            return Regex.Replace(value, "[ ]{2,}", " ", RegexOptions.None);
        }

        /// <summary>
        /// Retorna apenas os numeros da string.
        /// </summary>
        /// <param name="toNormalize">Texto</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NetToolException">Erro ao processar a string</exception>
        public static string OnlyNumbers(this string toNormalize)
        {
            try
            {
                if (toNormalize.IsEmpty()) return string.Empty;

                var toReturn = Regex.Replace(toNormalize, "[^0-9]", string.Empty);
                return toReturn;
            }
            catch (Exception ex)
            {
                throw new NetToolException("String can't be processed", ex);
            }
        }

        /// <summary>
        /// Strings the reverse.
        /// </summary>
        /// <param name="toReverse">To reverse.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception">Error reversing string string</exception>
        public static string StringReverse(this string toReverse)
        {
            try
            {
                if (toReverse.IsEmpty() || toReverse.Length == 1) return toReverse;

                return new string(toReverse.ToCharArray().Reverse().ToArray());
            }
            catch (Exception ex)
            {
                throw new NetToolException("String can't be reversed", ex);
            }
        }

        /// <summary>
        /// Format the specified valor.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="mask">The mask.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NetToolException">Error formating string</exception>
        public static string Format(this string text, string mask)
        {
            try
            {
                if (text.IsEmpty())
                    return text;

                var output = string.Empty;
                var index = 0;
                foreach (var m in mask)
                {
                    if (m == '#')
                    {
                        if (index >= text.Length)
                            continue;

                        output += text[index];
                        index++;
                    }
                    else
                        output += m;
                }

                return output;
            }
            catch (Exception ex)
            {
                throw new NetToolException("String can't be formated", ex);
            }
        }

        /// <summary>
        /// To the m d5 hash.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NetToolException">Error generating the hash MD5</exception>
        public static string ToMd5Hash(this string input)
        {
            try
            {
                using (var md5 = MD5.Create())
                {
                    var inputBytes = Encoding.UTF8.GetBytes(input);
                    var hash = md5.ComputeHash(inputBytes);

                    var sb = new StringBuilder();
                    foreach (var t in hash)
                    {
                        sb.Append(t.ToString("x2"));
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new NetToolException("MD5 can't be generated", ex);
            }
        }

        /// <summary>
        /// Remove punctuation, spaces and dashes from a string, leaving only Digits and Letters
        /// </summary>
        /// <param name="str">String para processar.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="NetToolException">Error processing the string</exception>
        public static string RemoveMask(this string str)
        {
            try
            {
                if (str.IsEmpty()) return str;

                var digitsOnlyRegex = new Regex(@"[^\w]");
                return digitsOnlyRegex.Replace(str, string.Empty);
            }
            catch (Exception ex)
            {
                throw new NetToolException("Mask can't be removed", ex);
            }
        }

        /// <summary>
        /// Check if the string is a cep valid
        /// </summary>
        /// <param name="cep">The cep.</param>
        /// <returns>System.bool.</returns>
        /// <exception cref="NetToolException">Error processing the string</exception>
        public static bool IsCep(this string cep)
        {
            try
            {
                cep = cep.OnlyNumbers();

                if (cep.Length == 8)
                {
                    cep = $"{cep.Substring(0, 5)}-{cep.Substring(5, 3)}";
                }

                return Regex.IsMatch(cep, "[0-9]{5}-[0-9]{3}");
            }
            catch (Exception ex)
            {
                throw new NetToolException("Cep can't be checked", ex);
            }
        }

        /// <summary>
        /// Checks if the string is a valid CPF or CNPJ.
        /// </summary>
        /// <param name="cpfcnpj">CPFCNPJ</param>
        /// <returns>System.bool.</returns>
        /// <exception cref="NetToolException">Error validating CPF or CNPJ</exception>
        public static bool IsCPFOrCNPJ(this string cpfcnpj)
        {
            var value = cpfcnpj.OnlyNumbers();
            switch (value.Length)
            {
                case 11:
                    return value.IsCPF();

                case 14:
                    return value.IsCNPJ();

                default:
                    return false;
            }
        }

        /// <summary>
        /// Checks if the string is a valid CPF.
        /// </summary>
        /// <param name="vrCPF">CPF</param>
        /// <param name="adjustSize">If must <c>true</c> [adjust size].</param>
        /// <returns>System.bool.</returns>
        /// <exception cref="NetToolException">Error validating CPF</exception>
        public static bool IsCPF(this string vrCPF, bool adjustSize = false)
        {
            try
            {
                var cpf = vrCPF.OnlyNumbers();
                if (adjustSize)
                    cpf = cpf.ZeroFill(11);

                if (cpf.Length != 11)
                    return false;

                if (new string(cpf[0], cpf.Length) == cpf)
                    return false;

                var numeros = new int[11];
                for (var i = 0; i < 11; i++)
                    numeros[i] = int.Parse(cpf[i].ToString());

                var soma = 0;
                for (var i = 0; i < 9; i++)
                    soma += (10 - i) * numeros[i];

                var resultado = soma % 11;
                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[9] != 0)
                        return false;
                }
                else if (numeros[9] != 11 - resultado)
                    return false;

                soma = 0;
                for (var i = 0; i < 10; i++)
                    soma += (11 - i) * numeros[i];

                resultado = soma % 11;
                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[10] != 0)
                        return false;
                }
                else if (numeros[10] != 11 - resultado)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                throw new NetToolException("Error validating CPF", ex);
            }
        }

        /// <summary>
        /// Checks if the string is a valid CNPJ.
        /// </summary>
        /// <param name="vrCNPJ">CNPJ</param>
        /// <param name="adjustSize">If must <c>true</c> [adjust size].</param>
        /// <returns>System.bool.</returns>
        /// <exception cref="NetToolException">Error validating CNPJ</exception>
        public static bool IsCNPJ(this string vrCNPJ, bool adjustSize = false)
        {
            try
            {
                var cnpj = vrCNPJ.OnlyNumbers();
                if (adjustSize)
                    cnpj = cnpj.ZeroFill(14);

                if (cnpj.Length != 14)
                    return false;

                if (new string(cnpj[0], cnpj.Length) == cnpj)
                    return false;

                var resultado = new int[2];
                int nrDig;
                const string ftmt = "6543298765432";
                var cnpjOk = new bool[2];
                var digitos = new int[14];
                var soma = new int[2];
                soma[0] = 0;
                soma[1] = 0;
                resultado[0] = 0;
                resultado[1] = 0;
                cnpjOk[0] = false;
                cnpjOk[1] = false;

                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(cnpj.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        soma[0] += digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1));
                    if (nrDig <= 12)
                        soma[1] += digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1));
                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = soma[nrDig] % 11;
                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        cnpjOk[nrDig] = digitos[12 + nrDig] == 0;
                    else
                        cnpjOk[nrDig] = digitos[12 + nrDig] == 11 - resultado[nrDig];
                }

                return cnpjOk[0] && cnpjOk[1];
            }
            catch (Exception ex)
            {
                throw new NetToolException("Error validation CNPJ", ex);
            }
        }

        /// <summary>
        /// Verifica se é uma inscrição estadual válida
        /// </summary>
        /// <param name="pInscr">Inscrição estadual</param>
        /// <param name="pUf">Sigla UF</param>
        /// <returns>bool</returns>
        /// <exception cref="HinoException">Erro ao IE</exception>
        public static bool IsIE(this string pInscr, string pUf)
        {
            try
            {
                if (pInscr.IsEmpty()) return false;
                if (pInscr.Trim().ToUpper() == "ISENTO") return true;
                if (!pUf.ValidateUF() || pUf.ToUpper() == "EX") return false;

                const string c09 = "0-9";
                int[,] cPesos =
                {
                    {0, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6},
                    {0, 0, 2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5},
                    {2, 0, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6},
                    {0, 2, 3, 4, 5, 6, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0, 0, 0, 0},
                    {0, 2, 3, 4, 5, 6, 7, 0, 0, 8, 9, 0, 0, 0},
                    {0, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5},
                    {0, 2, 3, 4, 5, 6, 7, 2, 3, 4, 5, 6, 7, 8},
                    {0, 0, 2, 3, 4, 5, 6, 7, 2, 3, 4, 5, 6, 7},
                    {0, 0, 2, 1, 2, 1, 2, 1, 2, 1, 1, 2, 1, 0},
                    {0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 2, 3, 0},
                    {0, 0, 0, 0, 10, 8, 7, 6, 5, 4, 3, 1, 0, 0},
                    {0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 2, 3, 0, 0},
                    {0, 0, 2, 3, 4, 5, 6, 7, 8, 3, 4, 5, 6, 7}
                };

                string[] vDigitos = { "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
                var fsDocto = "";
                char d;
                for (var i = 1; i <= pInscr.Trim().Length; i++)
                {
                    if ("0123456789P".IndexOf(pInscr.Substring(i - 1, 1), 0, StringComparison.OrdinalIgnoreCase) + 1 > 0)
                        fsDocto += pInscr.Substring(i - 1, 1);
                }

                var tamanho = 0;
                var xRot = "E";
                var xMd = 11;
                var xTp = 1;
                var yRot = "";
                var yMd = 0;
                var yTp = 0;
                var fatorF = 0;
                var fatorG = 0;

                switch (pUf.ToUpper())
                {
                    case "AC":
                        switch (fsDocto.Length)
                        {
                            case 9:
                                tamanho = 9;
                                vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "1", "0", "", "", "", "", "" };
                                break;

                            case 13:
                                tamanho = 13;
                                xTp = 2;
                                yRot = "E";
                                yMd = 11;
                                yTp = 1;
                                vDigitos = new[] { "DVY", "DVX", c09, c09, c09, c09, c09, c09, c09, c09, c09, "1", "0", "" };
                                break;
                        }
                        break;

                    case "AL":
                        tamanho = 9;
                        xRot = "BD";
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "4", "2", "", "", "", "", "" };
                        break;

                    case "AP":
                        if (fsDocto.Length == 9)
                        {
                            tamanho = 9;
                            xRot = "CE";
                            vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "3", "0", "", "", "", "", "" };

                            if (((long)fsDocto.ToInt64()).IsBetweenII(30170010, 30190229))
                                fatorF = 1;
                            else if (fsDocto.ToInt64() >= 30190230)
                                xRot = "E";
                        }
                        break;

                    case "AM":
                        tamanho = 9;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, c09, c09, "", "", "", "", "" };
                        break;

                    case "BA":
                        if (fsDocto.Length < 9)
                            fsDocto = fsDocto.ZeroFill(9);

                        tamanho = 9;
                        xTp = 2;
                        yTp = 3;
                        yRot = "E";
                        vDigitos = new[] { "DVX", "DVY", c09, c09, c09, c09, c09, c09, c09, "", "", "", "", "" };
                        if (fsDocto[1].In('0', '1', '2', '3', '4', '5', '8'))
                        {
                            xMd = 10;
                            yMd = 10;
                        }
                        else
                        {
                            xMd = 11;
                            yMd = 11;
                        }
                        break;

                    case "CE":
                        tamanho = 9;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, c09, "0", "", "", "", "", "" };
                        break;

                    case "DF":
                        tamanho = 13;
                        xTp = 2;
                        yRot = "E";
                        yMd = 11;
                        yTp = 1;
                        vDigitos = new[] { "DVY", "DVX", c09, c09, c09, c09, c09, c09, c09, c09, c09, "7", "0", "" };
                        break;

                    case "ES":
                        tamanho = 9;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, c09, c09, "", "", "", "", "" };
                        break;

                    case "GO":
                        if (fsDocto.Length == 9)
                        {
                            tamanho = 9;
                            vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "0,1,5", "1", "", "", "", "", "" };

                            if (((long)fsDocto.ToInt64()).IsBetweenII(101031050, 101199979))
                                fatorG = 1;
                        }
                        break;

                    case "MA":
                        tamanho = 9;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "2", "1", "", "", "", "", "" };
                        break;

                    case "MT":
                        if (fsDocto.Length == 9)
                            fsDocto = fsDocto.ZeroFill(11);

                        tamanho = 11;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, c09, c09, c09, c09, "", "", "" };
                        break;

                    case "MS":
                        tamanho = 9;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "8", "2", "", "", "", "", "" };
                        break;

                    case "MG":
                        tamanho = 13;
                        xRot = "AE";
                        xMd = 10;
                        xTp = 10;
                        yRot = "E";
                        yMd = 11;
                        yTp = 11;
                        vDigitos = new[] { "DVY", "DVX", c09, c09, c09, c09, c09, c09, c09, c09, c09, c09, c09, "" };
                        break;

                    case "PA":
                        tamanho = 9;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "5", "1", "", "", "", "", "" };
                        break;

                    case "PB":
                        tamanho = 9;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "6", "1", "", "", "", "", "" };
                        break;

                    case "PR":
                        tamanho = 10;
                        xTp = 9;
                        yRot = "E";
                        yMd = 11;
                        yTp = 8;
                        vDigitos = new[] { "DVY", "DVX", c09, c09, c09, c09, c09, c09, c09, c09, "", "", "", "" };
                        break;

                    case "PE":
                        switch (fsDocto.Length)
                        {
                            case 14:
                                tamanho = 14;
                                xTp = 7;
                                fatorF = 1;
                                vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, c09, c09, c09, c09, "1-9", "8", "1" };
                                break;

                            case 9:
                                tamanho = 9;
                                xTp = 14;
                                xMd = 11;
                                yRot = "E";
                                yMd = 11;
                                yTp = 7;
                                vDigitos = new[] { "DVY", "DVX", c09, c09, c09, c09, c09, c09, c09, "", "", "", "", "" };
                                break;
                        }
                        break;

                    case "PI":
                        tamanho = 9;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "9", "1", "", "", "", "", "" };
                        break;

                    case "RJ":
                        tamanho = 8;
                        xTp = 8;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "1,7,8,9", "", "", "", "", "", "" };
                        break;

                    case "RN":
                        xRot = "BD";
                        switch (fsDocto.Length)
                        {
                            case 9:
                                tamanho = 9;
                                vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "0", "2", "", "", "", "", "" };
                                break;

                            case 10:
                                tamanho = 10;
                                xTp = 11;
                                vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, c09, "0", "2", "", "", "", "" };
                                break;
                        }
                        break;

                    case "RS":
                        tamanho = 10;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, c09, c09, "0-4", "", "", "", "" };
                        break;

                    case "RO":
                        fatorF = 1;
                        switch (fsDocto.Length)
                        {
                            case 9:
                                tamanho = 9;
                                xTp = 4;
                                vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, c09, "1-9", "", "", "", "", "" };
                                break;

                            case 14:
                                tamanho = 14;
                                vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, c09, c09, c09, c09, c09, c09, c09 };
                                break;
                        }
                        break;

                    case "RR":
                        tamanho = 9;
                        xRot = "D";
                        xMd = 9;
                        xTp = 5;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "4", "2", "", "", "", "", "" };
                        break;

                    case "SC":
                    case "SE":
                        tamanho = 9;
                        vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, c09, c09, "", "", "", "", "" };
                        break;

                    case "SP":
                        xRot = "D";
                        xTp = 12;
                        if (fsDocto.ToUpper()[0] == 'P')
                        {
                            tamanho = 13;
                            vDigitos = new[] { c09, c09, c09, "DVX", c09, c09, c09, c09, c09, c09, c09, c09, "P", "" };
                        }
                        else
                        {
                            tamanho = 12;
                            yRot = "D";
                            yMd = 11;
                            yTp = 13;
                            vDigitos = new[] { "DVY", c09, c09, "DVX", c09, c09, c09, c09, c09, c09, c09, c09, "", "" };
                        }
                        break;

                    case "TO":
                        if (fsDocto.Length == 11)
                        {
                            tamanho = 11;
                            xTp = 6;
                            vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, "1,2,3,9", "0,9", "9", "2", "", "", "" };
                        }
                        else
                        {
                            tamanho = 9;
                            vDigitos = new[] { "DVX", c09, c09, c09, c09, c09, c09, c09, c09, "", "", "", "", "" };
                        }
                        break;
                }

                var ok = (tamanho > 0) && (fsDocto.Length == tamanho);
                if (!ok)
                    return false;

                fsDocto = fsDocto.FillRight(14);
                var dvx = 0;
                var dvy = 0;
                var I = 13;

                //Verificando os digitos nas posicoes são permitidos
                while (I >= 0)
                {
                    d = fsDocto[13 - I];

                    switch (vDigitos[I])
                    {
                        case "":
                            ok = d == ' ';
                            break;

                        case "DVX":
                        case "DVY":
                        case c09:
                            ok = char.IsNumber(d);
                            // ReSharper disable once SwitchStatementMissingSomeCases
                            switch (vDigitos[I])
                            {
                                case "DVX":
                                    dvx = d.ToInt32() ?? 0;
                                    break;

                                case "DVY":
                                    dvy = d.ToInt32() ?? 0;
                                    break;
                            }
                            break;

                        default:
                            if (vDigitos[I].Contains(','))
                            {
                                ok = vDigitos[I].Contains(d);
                            }
                            else if (vDigitos[I].Contains('-'))
                            {
                                ok = ((int)ConvertEx.ToInt32(d)).IsBetweenII(Convert.ToInt32(vDigitos[I].Substring(0, 1)), Convert.ToInt32(vDigitos[I].Substring(2, 1)));
                            }
                            else
                            {
                                ok = d == vDigitos[I][0];
                            }
                            break;
                    }

                    if (!ok)
                        return false;

                    I--;
                }

                var passo = 'X';
                while (xTp > 0)
                {
                    var soma = 0;
                    var somAq = 0;
                    I = 14;

                    while (I > 0)
                    {
                        d = fsDocto[14 - I];
                        if (char.IsNumber(d))
                        {
                            var nD = ConvertEx.ToInt32(d) ?? 0;//.ToInt32(0);
                            var m = nD * cPesos[xTp - 1, I - 1];
                            soma += m;

                            if (xRot.Contains('A'))
                                somAq = somAq + (int)Math.Truncate((decimal)m / 10);
                        }

                        I--;
                    }

                    if (xRot.Contains('A'))
                        soma += somAq;
                    else if (xRot.Contains('B'))
                        soma *= 10;
                    else if (xRot.Contains('C'))
                        soma += 5 + (4 * fatorF);

                    //Calculando digito verificador
                    var dv = (int)Math.Truncate((decimal)soma % xMd);
                    if (xRot.Contains('E'))
                        dv = (int)Math.Truncate((decimal)xMd - dv);

                    //Apenas GO modifica o FatorG para diferente de 0
                    switch (dv)
                    {
                        case 10:
                            dv = fatorG;
                            break;

                        case 11:
                            dv = fatorF;
                            break;
                    }

                    if (passo == 'X')
                        ok = dvx == dv;
                    else
                        ok = dvy == dv;

                    if (!ok)
                        return false;

                    if (passo == 'X')
                    {
                        passo = 'Y';
                        xRot = yRot;
                        xMd = yMd;
                        xTp = yTp;
                    }
                    else
                        break;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new NetToolException("Error validating IE", ex);
            }
        }

        /// <summary>
        /// Format IE
        /// </summary>
        /// <param name="pInscr">Inscrição Estadual</param>
        /// <param name="pUf">UF</param>
        /// <returns>System.String.</returns>
        public static string FormatIE(this string pInscr, string pUf)
        {
            var mascara = new string('#', pInscr.Length);
            pUf = pUf.Trim().ToUpper();

            Guard.Against<ArgumentException>(!ValidateUF(pUf), "Invalid UF.");

            switch (pUf)
            {
                case "AC":
                    mascara = "##.###.###/###-##";
                    break;

                case "AL":
                    mascara = "#########";
                    break;

                case "AP":
                    mascara = "#########";
                    break;

                case "AM":
                    mascara = "##.###.###-#";
                    break;

                case "BA":
                    mascara = "#######-##";
                    break;

                case "CE":
                    mascara = "########-#";
                    break;

                case "DF":
                    mascara = "###########-##";
                    break;

                case "ES":
                    mascara = "#########";
                    break;

                case "GO":
                    mascara = "##.###.###-#";
                    break;

                case "MA":
                    mascara = "#########";
                    break;

                case "MT":
                    mascara = "##########-#";
                    break;

                case "MS":
                    mascara = "##.###.###-#";
                    break;

                case "MG":
                    mascara = "###.###.###/####";
                    break;

                case "PA":
                    mascara = "##-######-#";
                    break;

                case "PB":
                    mascara = "########-#";
                    break;

                case "PR":
                    mascara = "###.#####-##";
                    break;

                case "PE":
                    mascara = pInscr.Length > 9 ? "##.#.###.#######-#" : "#######-##";
                    break;

                case "PI":
                    mascara = "#########";
                    break;

                case "RJ":
                    mascara = "##.###.##-#";
                    break;

                case "RN":
                    mascara = pInscr.Length > 9 ? "##.#.###.###-#" : "##.###.###-#";
                    break;

                case "RS":
                    mascara = "###/#######";
                    break;

                case "RO":
                    mascara = pInscr.Length > 13 ? "#############-#" : "###.#####-#";
                    break;

                case "RR":
                    mascara = "########-#";
                    break;

                case "SC":
                    mascara = "###.###.###";
                    break;

                case "SP":
                    mascara = pInscr.Length > 1 && pInscr[0] == 'P' ? "#-########.#/###" : "###.###.###.###";
                    break;

                case "SE":
                    mascara = "##.###.###-#";
                    break;

                case "TO":
                    mascara = pInscr.Length == 11 ? "##.##.######-#" : "##.###.###-#";
                    break;
            }

            var fsDocto = "";
            for (var i = 1; i <= pInscr.Trim().Length; i++)
            {
                if ("0123456789P".IndexOf(pInscr.Substring(i - 1, 1), 0, StringComparison.OrdinalIgnoreCase) + 1 > 0)
                    fsDocto += pInscr.Substring(i - 1, 1);
            }

            return fsDocto.Length < mascara.Count(x => x == '#')
                ? fsDocto.ZeroFill(mascara.Count(x => x == '#')).Format(mascara)
                : fsDocto.Format(mascara);
        }

        /// <summary>
        /// Checks if UF is Valid
        /// </summary>
        /// <param name="uf">UF</param>
        /// <returns>System.Boolean</returns>
        public static bool ValidateUF(this string uf)
        {
            if (uf.IsEmpty()) return false;

            string[] cUFsValidas = Configurations.UFList;

            /*
            {
                "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS",
                "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC",
                "SP", "SE", "TO", "EX"
            };
            */

            return cUFsValidas.Contains(uf.Trim().ToUpper());
        }

        /// <summary>
        /// Checks if the email is valid
        /// </summary>
        /// <param name="email">email.</param>
        /// <returns>bool</returns>
        /// <exception cref="NetToolException">Error validating the E-mail</exception>
        public static bool IsEmail(this string email)
        {
            try
            {
                var emailRegex = @"^(([^<>()[\]\\.,;áàãâäéèêëíìîïóòõôöúùûüç:\s@\""]+"
                                 + @"(\.[^<>()[\]\\.,;áàãâäéèêëíìîïóòõôöúùûüç:\s@\""]+)*)|(\"".+\""))@"
                                 + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|"
                                 + @"(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$";

                var rx = new Regex(emailRegex);
                return rx.IsMatch(email);
            }
            catch (Exception ex)
            {
                throw new NetToolException("Error validating the E-mail", ex);
            }
        }

        /// <summary>
        /// Remove special characteres from email
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>System.String</returns>
        public static string FormatEmail(this string email)
        {
            try
            {
                if (email.IsEmpty())
                    return string.Empty;

                var retorno = email.RemoveAccents();
                var cEspeciais = new[] {  "#", Environment.NewLine,
                                          "\n", "\r", ",", "?", "&", "/", "!", ";",
                                          "'", "\"", "#",  "¨", "%", "&", "*", "(", ")",
                                          "+", "=", "}", "{", "^", "~", "\\",
                                          ",", ">", "<", ";", ":", "/", "?", "°", "£", "¢",
                                          "¬", "³", "²", "¹", "´", "º", "]", "[", "§", "°",
                                          "‘", "’", "”", "“", "+", "ƒ", "‡" };

                retorno = retorno.ReplaceAny(cEspeciais, string.Empty);
                return retorno.Trim();
            }
            catch (Exception ex)
            {
                throw new NetToolException("Error cleaning the email.", ex);
            }

        }

        /// <summary>
        /// Splits the emails that are in the string
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>string[]</returns>
        /// <exception cref="NetToolException">Error spliting the email</exception>
        public static string[] SplitEmail(this string email)
        {
            try
            {
                var emails = new string[] { email };

                if (email.IndexOf(',') > -1)
                    emails = email.Split(',');
                else if (email.IndexOf(';') > -1)
                    emails = email.Split(';');
                else if (email.IndexOf(' ') > -1)
                    emails = email.Split(' ');
                else if (email.IndexOf('|') > -1)
                    emails = email.Split('|');
                else if (email.IndexOf('/') > -1)
                    emails = email.Split('/');
                else if (email.IndexOf('\\') > -1)
                    emails = email.Split('\\');

                return emails;
            }
            catch (Exception ex)
            {
                throw new NetToolException("Error spliting the email", ex);
            }
        }

        /// <summary>
        /// Checks if the website url is valid
        /// </summary>
        /// <param name="urlsite">url site</param>
        /// <returns>System.Boolean</returns>
        /// <exception cref="NetToolException">Error validation the Website url</exception>
        public static bool IsSite(this string urlsite)
        {
            try
            {
                //string siteRegex = @"/^http:\/\/www\.[a-z]+\.(com)|(edu)|(net)$/";
                const string siteRegex = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";

                var rx = new Regex(siteRegex);
                return rx.IsMatch(urlsite);
            }
            catch (Exception ex)
            {
                throw new NetToolException("Error validation the Website url", ex);
            }
        }


        /// <summary>
        /// Checks if is a number
        /// </summary>
        /// <param name="number">string of numbers</param>
        /// <returns>System.Boolean</returns>
        /// <exception cref="NetToolException">Error validating the string</exception>
        public static bool IsNumeric(this string number)
        {
            try
            {
                var reNum = new Regex(@"^\d+$");
                return reNum.IsMatch(number);
            }
            catch (Exception ex)
            {
                throw new NetToolException("Error validating the string", ex);
            }
        }

        /// <summary>
        /// Aligns the string to the right/left and fills with the given character until it is the specified size.
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="length">Desired final size</param>
        /// <param name="with">Character to fill</param>
        /// <param name="left">Fill direction</param>
        /// <returns>System.String</returns>
        public static string StringFill(this string text, int length, char with = ' ', bool left = true)
        {
            if (text.IsEmpty())
            {
                text = string.Empty;
            }

            if (text.Length > length)
            {
                text = text.Remove(length);
            }
            else
            {
                length -= text.Length;

                if (left)
                    text = new string(with, length) + text;
                else
                    text += new string(with, length);
            }

            return text;
        }

        /// <summary>
        /// Aligns the string to the right and fills the left with the information provided until it is the specified size.
        /// If size smaller than the current string returns a string of the specified size.
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="length">Desired final size</param>
        /// <param name="with">Character to fill</param>
        /// <returns>System.String</returns>
        public static string FillRight(this string text, int length, char with = ' ')
        {
            return text.StringFill(length, with);
        }

        /// <summary>
        /// Alinha a string a esquerda e preenche a direita com o caracter informado até ficar do tamanho especificado.
        /// If size smaller than the current string returns a string of the specified size.
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="length">Desired final size</param>
        /// <param name="with">Character to fill</param>
        /// <returns>System.String</returns>
        public static string FillLeft(this string text, int length, char with = ' ')
        {
            return text.StringFill(length, with, false);
        }

        /// <summary>
        /// Fills a string with zero to the right until it is the specified size.
        /// </summary>
        /// <param name="text">text</param>
        /// <param name="length">Desired final size</param>
        /// <returns>System.String</returns>
        public static string ZeroFill(this string text, int length)
        {
            return text.OnlyNumbers().StringFill(length, '0');
        }

        /// <summary>
        /// Replaces the accented characters of a string.
        /// </summary>
        /// <param name="value">texto</param>
        /// <returns>System.String</returns>
        public static string RemoveAccents(this string value)
        {
            if (value.IsEmpty()) return value;
            byte[] bytes = Encoding.GetEncoding("iso-8859-8").GetBytes(value);
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// Clear special characteres from string
        /// </summary>
        /// <param name="text">text</param>
        /// <returns>System.String</returns>
        public static string ClearSpecialCharacteres(this string text)
        {
            try
            {
                if (text.IsEmpty())
                    return string.Empty;

                var retorno = text.RemoveAccents();
                var cEspeciais = new[] { "#39", "---", "--", "-", "'", "#", Environment.NewLine,
                                          "\n", "\r", ",", ".", "?", "&", ":", "/", "!", ";",
                                          "'", "\"", "#", "@", "¨", "%", "&", "*", "(", ")",
                                          "-", "_", "+", "=", "}", "{", "^", "~", "\\", ".",
                                          ",", ">", "<", ";", ":", "/", "?", "°", "£", "¢",
                                          "¬", "³", "²", "¹", "´", "º", "]", "[", "§", "°",
                                          "‘", "’", "”", "“", "+", "ƒ", "‡" };

                retorno = retorno.ReplaceAny(cEspeciais, string.Empty);
                return retorno.Trim();
            }
            catch (Exception ex)
            {
                throw new NetToolException("Error cleaning the string.", ex);
            }
        }

        /// <summary>
        /// Replaces all characters passed in the array with the new character and returns the new string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="oldChars">old characteres</param>
        /// <param name="newChar">new characteres</param>
        /// <returns>System.String.</returns>
        public static string ReplaceAny(this string text, IEnumerable<char> oldChars, char newChar)
        {
            var builder = new StringBuilder(text);

            foreach (var oldChar in oldChars)
                builder.Replace(oldChar, newChar);

            return builder.ToString();
        }

        /// <summary>
        /// Replaces all characters passed in the array with the new character and returns the new string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="oldChars">old characteres</param>
        /// <param name="newChar">new characteres</param>
        /// <returns>System.String.</returns>
        public static string ReplaceAny(this string text, IEnumerable<string> oldChars, string newChar)
        {
            var builder = new StringBuilder(text);

            foreach (var oldChar in oldChars)
                builder.Replace(oldChar, newChar);

            return builder.ToString();
        }

        /// <summary>
        /// Format the CPF/CNPJ.
        /// </summary>
        /// <param name="value">text</param>
        /// <returns>System.String</returns>
        public static string FormatCPFCNPJ(this string value)
        {
            value = value.OnlyNumbers();
            switch (value.Trim().Length)
            {
                case 11:
                    return FormatCPF(value);

                case 14:
                    return FormatCNPJ(value);

                default:
                    return value;
            }
        }

        /// <summary>
        /// Format the CPF
        /// * if it is less than 11 characters long
        /// will be filled with zeros
        /// </summary>
        /// <param name="cpf">digits</param>
        /// <returns>System.String</returns>
        public static string FormatCPF(this string cpf)
        {
            try
            {
                return cpf.ZeroFill(11).Format("###.###.###-##");
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Format the CNPJ
        /// * if it is less than 14 characters long
        /// will be filled with zeros
        /// </summary>
        /// <param name="cnpj">digits</param>
        /// <returns>System.String</returns>
        public static string FormatCNPJ(this string cnpj)
        {
            try
            {
                return cnpj.ZeroFill(14).Format("##.###.###/####-##");
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Remove space from start and end of string
        /// </summary>
        /// <param name="text">text</param>
        /// <returns>System.String</returns>
        public static string TrimStartAndEnd(this string text)
        {
            var retvalue = text.Trim();
            if (!string.IsNullOrEmpty(retvalue) ||
                !string.IsNullOrWhiteSpace(retvalue))
            {
                if (retvalue[0].ToString() == " ")
                    retvalue = retvalue.TrimStartAndEnd();

                if (retvalue[retvalue.Length - 1].ToString() == " ")
                    retvalue = retvalue.TrimStartAndEnd();
            }
            return retvalue;
        }

        /// <summary>
        /// Clear string returned from oracle database
        /// </summary>
        /// <param name="text">Oracle error message</param>
        /// <returns>System.String</returns>
        public static string ClearOracleString(this string text)
        {
            var TemErro = text.SubStr(0, 4) == "ORA-";

            if (TemErro)
            {
                var mensagemPartes = text.Split(
                    new[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None);

                var temErroCustom = mensagemPartes.Any(r => Convert.ToInt32(r.SubStr(4, 5)).IsBetweenII(20000, 20999));

                if (temErroCustom)
                {
                    StringBuilder resultado = new StringBuilder();
                    foreach (var message in mensagemPartes)
                    {
                        if (!message.IsEmpty() && message.StartsWith("ORA") && Convert.ToInt32(message.SubStr(4, 5)).IsBetweenII(20000, 20999))
                            resultado.AppendLine(message[10..].TrimStartAndEnd());
                        else if (!message.IsEmpty() && !message.StartsWith("ORA"))
                            resultado.AppendLine(message);
                    }
                    return resultado.ToString();
                }
            }

            return text;
        }
    }
}
