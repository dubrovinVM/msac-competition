using System;
using System.Collections.Generic;
using System.Text;
using msac_competition.BLL.BusinessModels;
using Xunit;

namespace msac_competition.Tests
{
    public class LogicTest
    {
        [Fact]
        public void RussianAlphabetTest()
        {
            string russianAlphabetLowercase = "а б в г д е ё ж з и й к л м н о п р с т у ф х ц ч ш щ ъ ы ь э ю я";
            string russianAlphabetUppercase = "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";

            string expectedLowercase = "a b v g d e yo zh z i y k l m n o p r s t u f kh ts ch sh shch \" y ' e yu ya";
            string expectedUppercase = "A B V G D E Yo Zh Z I Y K L M N O P R S T U F Kh Ts Ch Sh Shch \" Y ' E Yu Ya";

            Assert.Equal(expectedLowercase, Transliterate.Translit(russianAlphabetLowercase));
            Assert.Equal(expectedUppercase, Transliterate.Translit(russianAlphabetUppercase));
        }
    }
}
