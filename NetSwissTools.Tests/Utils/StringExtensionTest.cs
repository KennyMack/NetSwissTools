using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NetSwissTools.Utils;
using FluentAssertions;

namespace NetSwissTools.Tests.Utils
{
    public class StringExtensionTest
    {
        [Theory]
        [InlineData("Você é a vergonha da profission", "Você é a vergonha da profission", 0, 0)]
        [InlineData("Você é a vergonha da profission", "Você é a vergonha da profission", 0, 3000)]
        [InlineData("Você é a vergonha da profission", "Você", 0, 4)]
        [InlineData("Você é a vergonha da profission", "ocê ", 1, 4)]
        [InlineData("Você é a vergonha da profission", "é a vergonha da profission", 5, 27)]
        [InlineData("Você é a vergonha da profission", "é a vergonha da profission", 5, 29)]
        [InlineData("Você é a vergonha da profission", "é a vergonha da profission", 5, 3000)]
        [InlineData("Você é a vergonha da profission", "é", 5, 1)]
        public void Shoud_Substring_Text(string Text, string ShoudBeText, int Start, int Count)
        {
            Text.SubStr(Start, Count).Should().Be(ShoudBeText);
        }

        [Theory]
        [InlineData("Você é a vergonha da profission", "Você é a vergonha da profission", 0, 0)]
        [InlineData("Você é a vergonha da profission", "Você é a vergonha da profission", 0, 3000)]
        [InlineData("Você é a vergonha da profission", "Você...", 0, 4)]
        [InlineData("Você é a vergonha da profission", "ocê ...", 1, 4)]
        [InlineData("Você é a vergonha da profission", "é a vergonha da profission", 5, 27)]
        [InlineData("Você é a vergonha da profission", "é a vergonha da profission", 5, 29)]
        [InlineData("Você é a vergonha da profission", "é a vergonha da profission", 5, 3000)]
        [InlineData("Você é a vergonha da profission", "é...", 5, 1)]
        public void Shoud_ElipsisEnd_Substring_Text(string Text, string ShoudBeText, int Start, int Count)
        {
            Text.SubStrElipsisEnd(Start, Count).Should().Be(ShoudBeText);
        }

        [Theory]
        [InlineData("ORA-12154: TNS: could not resolve the connect identifier specified", "ORA-12154: TNS: could not resolve the connect identifier specified", true)]
        [InlineData("ORA-12154: TNS: could not resolve the connect identifier specified", "TNS: could not resolve the connect identifier specified", false)]
        [InlineData("ORA-00001: unique constraint violated\r\nORA-00002: no storage definition found for segment(0, 0)", "unique constraint violated\r\nno storage definition found for segment(0, 0)", false)]
        [InlineData("ORA-00001: unique constraint violated\r\nORA-00002: no storage definition found for segment(0, 0)", "ORA-00001: unique constraint violated\r\nORA-00002: no storage definition found for segment(0, 0)", true)]
        [InlineData("ORA-01653: unable to extend table companies", "unable to extend table companies", false)]
        [InlineData("ORA-01653: unable to extend table companies", "ORA-01653: unable to extend table companies", true)]
        [InlineData("ORA-20001: Você é a vergonha da profission", "Você é a vergonha da profission", false)]
        [InlineData("ORA-20001: Você é a vergonha da profission", "Você é a vergonha da profission", true)]
        public void Shoud_ClearOracleString(string Text, string ShoudBeText, bool onlyCustoms)
        {
            Text.ClearOracleString(onlyCustoms).Should().Be(ShoudBeText);
        }
    }
}
