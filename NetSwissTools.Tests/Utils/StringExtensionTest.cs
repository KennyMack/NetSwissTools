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
    }
}
