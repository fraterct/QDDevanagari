/*
MIT License

Copyright (c) 2019 fraterct

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QDDevanagari
{
    using QDDevanagari.DevanagariLib;

    namespace DevanagariLib.Tests
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void AugmentTest()
            {
                string OmNamahShivaya = "oṃ namaḥ śivāya";
                string OmNamahShivayaManual = "o"
                    + Devanagari.AugmentChar('m', Devanagari.AugmentType.Lodot)
                    + " nama"
                    + Devanagari.AugmentChar('h', Devanagari.AugmentType.Lodot)
                    + " "
                    + Devanagari.AugmentChar('s', Devanagari.AugmentType.Acute)
                    + "iv"
                    + Devanagari.AugmentChar('a', Devanagari.AugmentType.Macron)
                    + "ya";

                Assert.AreEqual(OmNamahShivaya, OmNamahShivayaManual);
            }

            [TestMethod]
            public void SimpleRoundTripTest()
            {
                string NavarnaMantraDevanagari = "ॐ ऐं ह्रीं क्लीं चामुण्डायै विच्चे";
                string NavarnaMantraIAST = "oṃ aiṃ hrīṃ klīṃ cāmuṇḍāyai vicce";

                string NavarnaMantraDevanagariTransliterated = Devanagari.Transliterate(NavarnaMantraDevanagari);
                string NavarnaMantraIASTDetransliterated = Devanagari.Detransliterate(NavarnaMantraIAST);

                Assert.AreEqual(NavarnaMantraDevanagariTransliterated, NavarnaMantraIAST);
                Assert.AreEqual(NavarnaMantraIASTDetransliterated, NavarnaMantraDevanagari);
            }
        }
    }
}
