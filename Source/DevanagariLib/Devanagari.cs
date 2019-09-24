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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QDDevanagari
{
    namespace DevanagariLib
    {
        public static class Devanagari
        {
            // Unicode Devanagari characters - not necessarily comprehensive; these are just what are currently supported
            public static class Chars
            {
                public const char

                // Om
                Om = '\u0950',

                // Markers
                CandraBindu = '\u0901',
                Anusvara = '\u0902',
                Visarga = '\u0903',
                Avagraha = '\u093D',
                Virama = '\u094D',
                Danda = '\u0964', // single pipe |
                DoubleDanda = '\u0965', // double pipe ||

                // Solo vowels
                Vowel_Solo_A = '\u0905',
                Vowel_Solo_AA = '\u0906',
                Vowel_Solo_I = '\u0907',
                Vowel_Solo_II = '\u0908',
                Vowel_Solo_U = '\u0909',
                Vowel_Solo_UU = '\u090A',
                Vowel_Solo_E = '\u090F',
                Vowel_Solo_AI = '\u0910',
                Vowel_Solo_O = '\u0913',
                Vowel_Solo_AU = '\u0914',
                Vowel_Solo_R = '\u090B',
                Vowel_Solo_RR = '\u0960',
                Vowel_Solo_L = '\u090C',
                Vowel_Solo_LL = '\u0961',

                // Consonents

                Cons_Guttural_KA = '\u0915',
                Cons_Guttural_KHA = '\u0916',
                Cons_Guttural_GA = '\u0917',
                Cons_Guttural_GHA = '\u0918',
                Cons_Guttural_NGA = '\u0919',

                Cons_Palatal_CA = '\u091A',
                Cons_Palatal_CHA = '\u091B',
                Cons_Palatal_JA = '\u091C',
                Cons_Palatal_JHA = '\u091D',
                Cons_Palatal_NYA = '\u091E',

                Cons_Cerebral_TTA = '\u091F',
                Cons_Cerebral_TTHA = '\u0920',
                Cons_Cerebral_DDA = '\u0921',
                Cons_Cerebral_DDHA = '\u0922',
                Cons_Cerebral_NNA = '\u0923',

                Cons_Dental_TA = '\u0924',
                Cons_Dental_THA = '\u0925',
                Cons_Dental_DA = '\u0926',
                Cons_Dental_DHA = '\u0927',
                Cons_Dental_NA = '\u0928',

                Cons_Labial_PA = '\u092A',
                Cons_Labial_PHA = '\u092B',
                Cons_Labial_BA = '\u092C',
                Cons_Labial_BHA = '\u092D',
                Cons_Labial_MA = '\u092E',

                // Semi-vowels, Sibilants and Aspirate

                SemiVowel_YA = '\u092F',
                SemiVowel_RA = '\u0930',
                SemiVowel_LA = '\u0932',
                SemiVowel_LLA = '\u0933',
                SemiVowel_VA = '\u0935',

                Sibilant_SHA = '\u0936', // Siva
                Sibilant_SSA = '\u0937', // Visnu
                Sibilant_SA = '\u0938',

                Aspirate_HA = '\u0939',

                // Vowel modifiers

                Vowel_Mod_AA = '\u093E',
                Vowel_Mod_I = '\u093F',
                Vowel_Mod_II = '\u0940',
                Vowel_Mod_U = '\u0941',
                Vowel_Mod_UU = '\u0942',
                Vowel_Mod_E = '\u0947',
                Vowel_Mod_AI = '\u0948',
                Vowel_Mod_O = '\u094B',
                Vowel_Mod_AU = '\u094C',
                Vowel_Mod_R = '\u0943',
                Vowel_Mod_RR = '\u0944',
                Vowel_Mod_L = '\u0962',
                Vowel_Mod_LL = '\u0963',

                // Digits and Misc

                VedicTone_Udatta = '\u0951',
                VedicTone_Anudatta = '\u0952',
                Accent_Grave = '\u0953',
                Accent_Acute = '\u0954',

                Digit_0 = '\u0966',
                Digit_1 = '\u0967',
                Digit_2 = '\u0968',
                Digit_3 = '\u0969',
                Digit_4 = '\u096A',
                Digit_5 = '\u096B',
                Digit_6 = '\u096C',
                Digit_7 = '\u096D',
                Digit_8 = '\u096E',
                Digit_9 = '\u096F',

                Sign_Abbreviation = '\u0970',
                Sign_HighSpacingDot = '\u0971'
                ;
            }

            [Flags]
            public enum AugmentType
            {
                None = 0,
                Macron = (1 << 0),
                Acute = (1 << 1),
                Updot = (1 << 2),
                Lodot = (1 << 3),
                Tilde = (1 << 4)
            }

            // utility function for augmenting a letter with IAST diacriticals
            public static char AugmentChar(char inChar, AugmentType inAugmentType)
            {
                if (inChar == 'A')
                {
                    if ((inAugmentType & AugmentType.Macron) != 0)
                        return 'Ā';
                }
                else if (inChar == 'a')
                {
                    if ((inAugmentType & AugmentType.Macron) != 0)
                        return 'ā';
                }
                else if (inChar == 'D')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                        return 'Ḍ';
                }
                else if (inChar == 'd')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                        return 'ḍ';
                }
                else if (inChar == 'H')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                        return 'Ḥ';
                }
                else if (inChar == 'h')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                        return 'ḥ';
                }
                else if (inChar == 'I')
                {
                    if ((inAugmentType & AugmentType.Macron) != 0)
                        return 'Ī';
                }
                else if (inChar == 'i')
                {
                    if ((inAugmentType & AugmentType.Macron) != 0)
                        return 'ī';
                }
                else if (inChar == 'L')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                    {
                        if ((inAugmentType & AugmentType.Macron) != 0)
                            return 'Ḹ';
                        else
                            return 'Ḷ';
                    }
                }
                else if (inChar == 'Ḷ')
                {
                    if ((inAugmentType & AugmentType.Macron) != 0)
                        return 'Ḹ';
                }
                else if (inChar == 'l')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                    {
                        if ((inAugmentType & AugmentType.Macron) != 0)
                            return 'ḹ';
                        else
                            return 'ḷ';
                    }
                }
                else if (inChar == 'ḷ')
                {
                    if ((inAugmentType & AugmentType.Macron) != 0)
                        return 'ḹ';
                }
                else if (inChar == 'M')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                        return 'Ṃ';
                }
                else if (inChar == 'm')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                        return 'ṃ';
                }
                else if (inChar == 'N')
                {
                    if ((inAugmentType & AugmentType.Updot) != 0)
                        return 'Ṅ';
                    else if ((inAugmentType & AugmentType.Lodot) != 0)
                        return 'Ṇ';
                    else if ((inAugmentType & AugmentType.Tilde) != 0)
                        return 'Ñ';
                }
                else if (inChar == 'n')
                {
                    if ((inAugmentType & AugmentType.Updot) != 0)
                        return 'ṅ';
                    else if ((inAugmentType & AugmentType.Lodot) != 0)
                        return 'ṇ';
                    else if ((inAugmentType & AugmentType.Tilde) != 0)
                        return 'ñ';
                }
                else if (inChar == 'R')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                    {
                        if ((inAugmentType & AugmentType.Macron) != 0)
                            return 'Ṝ';
                        else
                            return 'Ṛ';
                    }
                }
                else if (inChar == 'Ṛ')
                {
                    if ((inAugmentType & AugmentType.Macron) != 0)
                        return 'Ṝ';
                }
                else if (inChar == 'r')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                    {
                        if ((inAugmentType & AugmentType.Macron) != 0)
                            return 'ṝ';
                        else
                            return 'ṛ';
                    }
                }
                else if (inChar == 'ṛ')
                {
                    if ((inAugmentType & AugmentType.Macron) != 0)
                        return 'ṝ';
                }
                else if (inChar == 'S')
                {
                    if ((inAugmentType & AugmentType.Acute) != 0)
                        return 'Ś';
                    else if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                        return 'Ṣ';
                }
                else if (inChar == 's')
                {
                    if ((inAugmentType & AugmentType.Acute) != 0)
                        return 'ś';
                    else if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                        return 'ṣ';
                }
                else if (inChar == 'T')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                        return 'Ṭ';
                }
                else if (inChar == 't')
                {
                    if ((inAugmentType & (AugmentType.Updot | AugmentType.Lodot)) != 0)
                        return 'ṭ';
                }
                else if (inChar == 'U')
                {
                    if ((inAugmentType & AugmentType.Macron) != 0)
                        return 'Ū';
                }
                else if (inChar == 'u')
                {
                    if ((inAugmentType & AugmentType.Macron) != 0)
                        return 'ū';
                }

                return inChar;
            }

            // Transliterate a Unicode Devanagari string into IAST
            public static string Transliterate(string inDevanagariString)
            {
                bool checkForVowelModifier = false;
                string result = "";
                foreach (char devanagariChar in inDevanagariString)
                {
                    string s;
                    if (checkForVowelModifier)
                    {
                        checkForVowelModifier = false;
                        if (devanagariChar != Chars.Virama)
                        {
                            s = transliterateVowelModifier(devanagariChar);
                            if (s != null)
                            {
                                result += s;
                                continue;
                            }
                            else
                            {
                                result += 'a';
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    s = transliterateSoloVowel(devanagariChar);
                    if (s != null)
                    {
                        result += s;
                        continue;
                    }
                    s = transliterateConsSemiSibAsp(devanagariChar);
                    if (s != null)
                    {
                        result += s;
                        checkForVowelModifier = true;
                        continue;
                    }
                    s = transliterateOther(devanagariChar);
                    if (s != null)
                    {
                        result += s;
                        continue;
                    }
                    if (Char.IsWhiteSpace(devanagariChar))
                    {
                        result += devanagariChar;
                        continue;
                    }
                    result += devanagariChar;
                }
                if (checkForVowelModifier)
                {
                    result += 'a';
                }

                return result;
            }

            // Detransliterate an IAST string into Devanagari
            public static string Detransliterate(string inIASTString)
            {
                string result = null;

                if (inIASTString != null)
                {
                    string[] lines = inIASTString.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    foreach (var line in lines)
                    {
                        if (result != null)
                            result += "\r\n";

                        if (line.Length > 0)
                        {
                            string[] words = line.Split(new string[] { " ", "\t" }, StringSplitOptions.None);
                            foreach (var w in words)
                            {
                                string s = detransliterateWord(w.Trim().ToLower()); // $TODO detransliterate methods assume lowercase
                                if (s != null)
                                {
                                    result += s + " ";
                                }
                            }
                        }
                    }
                }

                return (result != null) ? result.Trim() : inIASTString;
            }

            #region Transliteration internals

            private static string transliterateOther(char inDevanagariSymbol)
            {
                string result = null;
                switch (inDevanagariSymbol)
                {
                    case Chars.Om: result = "o" + AugmentChar('m', AugmentType.Lodot); break;
                    case Chars.CandraBindu: result = "" + AugmentChar('m', AugmentType.Lodot); break;
                    case Chars.Anusvara: result = "" + AugmentChar('m', AugmentType.Lodot); break;
                    case Chars.Visarga: result = "" + AugmentChar('h', AugmentType.Lodot); break;
                    case Chars.Avagraha: result = "-"; break; // $TODO could also be transliterated as hyphen; add an option for this?
                    case Chars.Virama: result = ""; break;
                    case Chars.Danda: result = "|"; break;
                    case Chars.DoubleDanda: result = "||"; break;
                    case Chars.VedicTone_Udatta: result = ""; break;
                    case Chars.VedicTone_Anudatta: result = ""; break;
                    case Chars.Accent_Grave: result = ""; break;
                    case Chars.Accent_Acute: result = ""; break;

                    case Chars.Digit_0: result = "0"; break;
                    case Chars.Digit_1: result = "1"; break;
                    case Chars.Digit_2: result = "2"; break;
                    case Chars.Digit_3: result = "3"; break;
                    case Chars.Digit_4: result = "4"; break;
                    case Chars.Digit_5: result = "5"; break;
                    case Chars.Digit_6: result = "6"; break;
                    case Chars.Digit_7: result = "7"; break;
                    case Chars.Digit_8: result = "8"; break;
                    case Chars.Digit_9: result = "9"; break;

                    case Chars.Sign_Abbreviation: result = ""; break;
                    case Chars.Sign_HighSpacingDot: result = ""; break;

                    default: break;
                }
                return result;
            }

            private static string transliterateConsSemiSibAsp(char inDevanagariLetter)
            {
                string result = null;
                switch (inDevanagariLetter)
                {
                    case Chars.Cons_Guttural_KA: result = "k"; break;
                    case Chars.Cons_Guttural_KHA: result = "kh"; break;
                    case Chars.Cons_Guttural_GA: result = "g"; break;
                    case Chars.Cons_Guttural_GHA: result = "gh"; break;
                    case Chars.Cons_Guttural_NGA: result = "" + AugmentChar('n', AugmentType.Updot); break;

                    case Chars.Cons_Palatal_CA: result = "c"; break;
                    case Chars.Cons_Palatal_CHA: result = "ch"; break;
                    case Chars.Cons_Palatal_JA: result = "j"; break;
                    case Chars.Cons_Palatal_JHA: result = "jh"; break;
                    case Chars.Cons_Palatal_NYA: result = "" + AugmentChar('n', AugmentType.Tilde); break;

                    case Chars.Cons_Cerebral_TTA: result = "" + AugmentChar('t', AugmentType.Lodot); break;
                    case Chars.Cons_Cerebral_TTHA: result = "" + AugmentChar('t', AugmentType.Lodot).ToString() + "h"; break;
                    case Chars.Cons_Cerebral_DDA: result = "" + AugmentChar('d', AugmentType.Lodot); break;
                    case Chars.Cons_Cerebral_DDHA: result = "" + AugmentChar('d', AugmentType.Lodot).ToString() + "h"; break;
                    case Chars.Cons_Cerebral_NNA: result = "" + AugmentChar('n', AugmentType.Lodot); break;

                    case Chars.Cons_Dental_TA: result = "t"; break;
                    case Chars.Cons_Dental_THA: result = "th"; break;
                    case Chars.Cons_Dental_DA: result = "d"; break;
                    case Chars.Cons_Dental_DHA: result = "dh"; break;
                    case Chars.Cons_Dental_NA: result = "n"; break;

                    case Chars.Cons_Labial_PA: result = "p"; break;
                    case Chars.Cons_Labial_PHA: result = "ph"; break;
                    case Chars.Cons_Labial_BA: result = "b"; break;
                    case Chars.Cons_Labial_BHA: result = "bh"; break;
                    case Chars.Cons_Labial_MA: result = "m"; break;

                    case Chars.SemiVowel_YA: result = "y"; break;
                    case Chars.SemiVowel_RA: result = "r"; break;
                    case Chars.SemiVowel_LA: result = "l"; break;
                    case Chars.SemiVowel_LLA: result = "" + AugmentChar('l', AugmentType.Lodot); break;
                    case Chars.SemiVowel_VA: result = "v"; break;

                    case Chars.Sibilant_SHA: result = "" + AugmentChar('s', AugmentType.Acute); break;
                    case Chars.Sibilant_SSA: result = "" + AugmentChar('s', AugmentType.Lodot); break;
                    case Chars.Sibilant_SA: result = "s"; break;

                    case Chars.Aspirate_HA: result = "h"; break;

                    default: break;
                }
                return result;
            }

            private static string transliterateSoloVowel(char inDevanagariSoloVowel)
            {
                string result = null;
                switch (inDevanagariSoloVowel)
                {
                    case Chars.Vowel_Solo_A: result = "a"; break;
                    case Chars.Vowel_Solo_AA: result = "" + AugmentChar('a', AugmentType.Macron); break;
                    case Chars.Vowel_Solo_I: result = "i"; break;
                    case Chars.Vowel_Solo_II: result = "" + AugmentChar('i', AugmentType.Macron); break;
                    case Chars.Vowel_Solo_U: result = "u"; break;
                    case Chars.Vowel_Solo_UU: result = "" + AugmentChar('u', AugmentType.Macron); break;
                    case Chars.Vowel_Solo_E: result = "e"; break;
                    case Chars.Vowel_Solo_AI: result = "ai"; break;
                    case Chars.Vowel_Solo_O: result = "o"; break;
                    case Chars.Vowel_Solo_AU: result = "au"; break;
                    case Chars.Vowel_Solo_R: result = "" + AugmentChar('r', AugmentType.Lodot); break;
                    case Chars.Vowel_Solo_RR: result = "" + AugmentChar('r', AugmentType.Lodot | AugmentType.Macron); break;
                    case Chars.Vowel_Solo_L: result = "" + AugmentChar('l', AugmentType.Lodot); break;
                    case Chars.Vowel_Solo_LL: result = "" + AugmentChar('l', AugmentType.Lodot | AugmentType.Macron); break;
                    default: break;
                }
                return result;
            }

            private static string transliterateVowelModifier(char inDevanagariVowelModifier)
            {
                string result = null;
                switch (inDevanagariVowelModifier)
                {
                    case Chars.Vowel_Mod_AA: result = "" + AugmentChar('a', AugmentType.Macron); break;
                    case Chars.Vowel_Mod_I: result = "i"; break;
                    case Chars.Vowel_Mod_II: result = "" + AugmentChar('i', AugmentType.Macron); break;
                    case Chars.Vowel_Mod_U: result = "u"; break;
                    case Chars.Vowel_Mod_UU: result = "" + AugmentChar('u', AugmentType.Macron); break;
                    case Chars.Vowel_Mod_E: result = "e"; break;
                    case Chars.Vowel_Mod_AI: result = "ai"; break;
                    case Chars.Vowel_Mod_O: result = "o"; break;
                    case Chars.Vowel_Mod_AU: result = "au"; break;
                    case Chars.Vowel_Mod_R: result = "" + AugmentChar('r', AugmentType.Lodot); break;
                    case Chars.Vowel_Mod_RR: result = "" + AugmentChar('r', AugmentType.Lodot | AugmentType.Macron); break;
                    case Chars.Vowel_Mod_L: result = "" + AugmentChar('l', AugmentType.Lodot); break;
                    case Chars.Vowel_Mod_LL: result = "" + AugmentChar('l', AugmentType.Lodot | AugmentType.Macron); break;
                    default: break;
                }
                return result;
            }

            #endregion

            #region  Detransliteration internals

            private static string detransliterateWord(string inString)
            {
                string result = null;

                if ((inString.Length == 2) && (inString[0] == 'o') && (inString[1] == AugmentChar('m', AugmentType.Lodot)))
                {
                    // special case for Om (only used when it's its own word)
                    result = "" + Chars.Om;
                }
                else
                {
                    string testStr = inString + " "; // add space for padding as individual detransliteration tests don't watch for end of string
                    int stringPos = 0;

                    while (stringPos < inString.Length)
                    {
                        int startPos = stringPos;

                        string s = detransliterateSoloVowel(testStr, ref stringPos);
                        if (s != null)
                        {
                            if (result == null)
                                result = "";
                            result += s;
                        }
                        else
                        {
                            s = detransliterateConsSemiSibAsp(testStr, ref stringPos);
                            if (s != null)
                            {
                                if (result == null)
                                    result = "";
                                result += s;
                            
                                s = detransliterateVowelModifier(testStr, ref stringPos);
                                if (s != null)
                                {
                                    result += s;
                                }
                                else
                                {
                                    result += "" + Chars.Virama;
                                }
                            }
                            else
                            {
                                s = detransliterateOther(testStr, ref stringPos);
                                if (s != null)
                                {
                                    if (result == null)
                                        result = "";
                                    result += s;
                                }
                            }
                        }

                        if (stringPos == startPos)
                            break; // no forward progress
                    }
                }

                return result;
            }

            private static string detransliterateOther(string inString, ref int ioStringPos)
            {
                string result = null;

                char c = inString[ioStringPos];
                if (c == '\'' || c == '-')
                    result = "" + Chars.Avagraha;
                else if (c == AugmentChar('m', AugmentType.Lodot))
                    result = "" + Chars.Anusvara;
                else if (c == AugmentChar('h', AugmentType.Lodot))
                    result = "" + Chars.Visarga;
                else if (c == '|')
                {
                    if (inString[ioStringPos + 1] == '|')
                    {
                        result = "" + Chars.DoubleDanda;
                        ++ioStringPos;
                    }
                    else
                    {
                        result = "" + Chars.Danda;
                    }
                }
                else if (c == '0') result = "" + Chars.Digit_0;
                else if (c == '1') result = "" + Chars.Digit_1;
                else if (c == '2') result = "" + Chars.Digit_2;
                else if (c == '3') result = "" + Chars.Digit_3;
                else if (c == '4') result = "" + Chars.Digit_4;
                else if (c == '5') result = "" + Chars.Digit_5;
                else if (c == '6') result = "" + Chars.Digit_6;
                else if (c == '7') result = "" + Chars.Digit_7;
                else if (c == '8') result = "" + Chars.Digit_8;
                else if (c == '9') result = "" + Chars.Digit_9;

                if (result != null)
                    ++ioStringPos;

                return result;
            }

            private static string detransliterateConsSemiSibAsp(string inString, ref int ioStringPos)
            {
                string result = null;

                switch (inString[ioStringPos])
                {
                    case 'k':
                        {
                            ++ioStringPos;
                            switch (inString[ioStringPos])
                            {
                                case 'h': result = "" + Chars.Cons_Guttural_KHA; ++ioStringPos; break;
                                default: result = "" + Chars.Cons_Guttural_KA; break;
                            }
                        }
                        break;
                    case 'g':
                        {
                            ++ioStringPos;
                            switch (inString[ioStringPos])
                            {
                                case 'h': result = "" + Chars.Cons_Guttural_GHA; ++ioStringPos; break;
                                default: result = "" + Chars.Cons_Guttural_GA; break;
                            }
                        }
                        break;
                    case 'c':
                        {
                            ++ioStringPos;
                            switch (inString[ioStringPos])
                            {
                                case 'h': result = "" + Chars.Cons_Palatal_CHA; ++ioStringPos; break;
                                default: result = "" + Chars.Cons_Palatal_CA; break;
                            }
                        }
                        break;
                    case 'j':
                        {
                            ++ioStringPos;
                            switch (inString[ioStringPos])
                            {
                                case 'h': result = "" + Chars.Cons_Palatal_JHA; ++ioStringPos; break;
                                default: result = "" + Chars.Cons_Palatal_JA; break;
                            }
                        }
                        break;
                    case 't':
                        {
                            ++ioStringPos;
                            switch (inString[ioStringPos])
                            {
                                case 'h': result = "" + Chars.Cons_Dental_THA; ++ioStringPos; break;
                                default: result = "" + Chars.Cons_Dental_TA; break;
                            }
                        }
                        break;
                    case 'd':
                        {
                            ++ioStringPos;
                            switch (inString[ioStringPos])
                            {
                                case 'h': result = "" + Chars.Cons_Dental_DHA; ++ioStringPos; break;
                                default: result = "" + Chars.Cons_Dental_DA; break;
                            }
                        }
                        break;
                    case 'p':
                        {
                            ++ioStringPos;
                            switch (inString[ioStringPos])
                            {
                                case 'h': result = "" + Chars.Cons_Labial_PHA; ++ioStringPos; break;
                                default: result = "" + Chars.Cons_Labial_PA; break;
                            }
                        }
                        break;
                    case 'b':
                        {
                            ++ioStringPos;
                            switch (inString[ioStringPos])
                            {
                                case 'h': result = "" + Chars.Cons_Labial_BHA; ++ioStringPos; break;
                                default: result = "" + Chars.Cons_Labial_BA; break;
                            }
                        }
                        break;
                    case 'n': result = "" + Chars.Cons_Dental_NA; ++ioStringPos; break;
                    case 'm': result = "" + Chars.Cons_Labial_MA; ++ioStringPos; break;
                    case 'y': result = "" + Chars.SemiVowel_YA; ++ioStringPos; break;
                    case 'r': result = "" + Chars.SemiVowel_RA; ++ioStringPos; break;
                    case 'l': result = "" + Chars.SemiVowel_LA; ++ioStringPos; break;
                    case 'v': result = "" + Chars.SemiVowel_VA; ++ioStringPos; break;
                    case 's': result = "" + Chars.Sibilant_SA; ++ioStringPos; break;
                    case 'h': result = "" + Chars.Aspirate_HA; ++ioStringPos; break;
                    default:
                        {
                            char c = inString[ioStringPos];
                            if (c == AugmentChar('n', AugmentType.Updot))
                                result = "" + Chars.Cons_Guttural_NGA;
                            else if (c == AugmentChar('n', AugmentType.Tilde))
                                result = "" + Chars.Cons_Palatal_NYA;
                            else if (c == AugmentChar('n', AugmentType.Lodot))
                                result = "" + Chars.Cons_Cerebral_NNA;
                            else if (c == AugmentChar('l', AugmentType.Lodot))
                                result = "" + Chars.SemiVowel_LLA;
                            else if (c == AugmentChar('s', AugmentType.Acute))
                                result = "" + Chars.Sibilant_SHA;
                            else if (c == AugmentChar('s', AugmentType.Lodot))
                                result = "" + Chars.Sibilant_SSA;
                            else if (c == AugmentChar('t', AugmentType.Lodot))
                            {
                                if (inString[ioStringPos + 1] == 'h')
                                {
                                    result = "" + Chars.Cons_Cerebral_TTHA;
                                    ++ioStringPos;
                                }
                                else
                                {
                                    result = "" + Chars.Cons_Cerebral_TTA;
                                }
                            }
                            else if (c == AugmentChar('d', AugmentType.Lodot))
                            {
                                if (inString[ioStringPos + 1] == 'h')
                                {
                                    result = "" + Chars.Cons_Cerebral_DDHA;
                                    ++ioStringPos;
                                }
                                else
                                {
                                    result = "" + Chars.Cons_Cerebral_DDA;
                                }
                            }

                            if (result != null)
                                ++ioStringPos;
                        }
                        break;
                }

                return result;
            }

            private static string detransliterateSoloVowel(string inString, ref int ioStringPos)
            {
                string result = null;

                switch (inString[ioStringPos])
                {
                    case 'a':
                        {
                            ++ioStringPos;
                            switch (inString[ioStringPos])
                            {
                                case 'i': result = "" + Chars.Vowel_Solo_AI; ++ioStringPos; break;
                                case 'u': result = "" + Chars.Vowel_Solo_AU; ++ioStringPos; break;
                                default: result = "" + Chars.Vowel_Solo_A; break;
                            }
                        }
                        break;
                    case 'i': result = "" + Chars.Vowel_Solo_I; ++ioStringPos; break;
                    case 'u': result = "" + Chars.Vowel_Solo_U; ++ioStringPos; break;
                    case 'e': result = "" + Chars.Vowel_Solo_E; ++ioStringPos; break;
                    case 'o': result = "" + Chars.Vowel_Solo_O; ++ioStringPos; break;
                    default:
                        {
                            char c = inString[ioStringPos];
                            if (c == AugmentChar('a', AugmentType.Macron))
                                result = "" + Chars.Vowel_Solo_AA;
                            else if (c == AugmentChar('i', AugmentType.Macron))
                                result = "" + Chars.Vowel_Solo_II;
                            else if (c == AugmentChar('u', AugmentType.Macron))
                                result = "" + Chars.Vowel_Solo_UU;
                            else if (c == AugmentChar('r', AugmentType.Lodot))
                                result = "" + Chars.Vowel_Solo_R;
                            else if (c == AugmentChar('r', AugmentType.Lodot | AugmentType.Macron))
                                result = "" + Chars.Vowel_Solo_RR;
                            else if (c == AugmentChar('l', AugmentType.Lodot))
                                result = "" + Chars.Vowel_Solo_L;
                            else if (c == AugmentChar('l', AugmentType.Lodot | AugmentType.Macron))
                                result = "" + Chars.Vowel_Solo_LL;

                            if (result != null)
                                ++ioStringPos;
                        }
                        break;
                }

                return result;
            }

            private static string detransliterateVowelModifier(string inString, ref int ioStringPos)
            {
                string result = null;

                switch (inString[ioStringPos])
                {
                    case 'a':
                        {
                            ++ioStringPos;
                            switch (inString[ioStringPos])
                            {
                                case 'i': result = "" + Chars.Vowel_Mod_AI; ++ioStringPos; break;
                                case 'u': result = "" + Chars.Vowel_Mod_AU; ++ioStringPos; break;
                                default: result = ""; break; // nothing to add (a is the default vowel modifier), but the character was accepted/eaten, so just return empty instead of null
                            }
                        }
                        break;
                    case 'i': result = "" + Chars.Vowel_Mod_I; ++ioStringPos; break;
                    case 'u': result = "" + Chars.Vowel_Mod_U; ++ioStringPos; break;
                    case 'e': result = "" + Chars.Vowel_Mod_E; ++ioStringPos; break;
                    case 'o': result = "" + Chars.Vowel_Mod_O; ++ioStringPos; break;
                    default:
                        {
                            char c = inString[ioStringPos];
                            if (c == AugmentChar('a', AugmentType.Macron))
                                result = "" + Chars.Vowel_Mod_AA;
                            else if (c == AugmentChar('i', AugmentType.Macron))
                                result = "" + Chars.Vowel_Mod_II;
                            else if (c == AugmentChar('u', AugmentType.Macron))
                                result = "" + Chars.Vowel_Mod_UU;
                            else if (c == AugmentChar('r', AugmentType.Lodot))
                                result = "" + Chars.Vowel_Mod_R;
                            else if (c == AugmentChar('r', AugmentType.Lodot | AugmentType.Macron))
                                result = "" + Chars.Vowel_Mod_RR;
                            else if (c == AugmentChar('l', AugmentType.Lodot))
                                result = "" + Chars.Vowel_Mod_L;
                            else if (c == AugmentChar('l', AugmentType.Lodot | AugmentType.Macron))
                                result = "" + Chars.Vowel_Mod_LL;

                            if (result != null)
                                ++ioStringPos;
                        }
                        break;
                }

                return result;
            }

            #endregion
        }
    }
}
