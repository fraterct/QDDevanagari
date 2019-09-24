# QDDevanagari
Quick &amp; Dirty Devanagari&lt;->IAST conversion library in C#, released under MIT license.

This is a small single-C#-file library for doing simple string conversions between the Devanagari subset used in Sanskrit, and the International Alphabet of Sanskrit Transliteration (IAST) transliteration scheme.  A simple Windows tool utilizing the library is included.

As the title says, this is a "quick & dirty" utility, good for casual use when dealing with common Sanskrit characters.  No assumptions should be made about Devanagari characters used outside of Sanskrit, for other languages such as Hindi.  The author is not of Indian descent and is merely a hobbyist with some personal enthusiasm for Sanskrit, and wrote this for his own personal use for things such as translitering stotras.  It is being shared in the hopes that others may find similar value in it, despite it being a little rough around the edges.

Contents:
* DevanagariLib: Simple conversions to Transliterate Devanagari to IAST, or Detransliterate IAST to Devanagari.  There is also some convenience logic for "augmenting" regular Roman letters into the diacritical forms used with IAST.
* DevanagariLib.Tests: Some minor unit tests to verify basic functionality, and demonstrate rudimentary usage of DevanagariLib methods.
* Transliterator: A simple Windows Forms app to interactively demonstrate DevanagariLib functionality (Windows-specific).  Allows for simple typing of IAST characters without an IME, using a basic augmentation scheme (e.g. s' -> ś, a_ -> ā), and menu options for transliteration and detransliteration with Devanagari.

Disclaimer: The included Transliterator demo app uses the 'Siddhanta' font, released under the Creative Commons Attribution-NonCommercial-NoDerivs 3.0 Unported License; see http://svayambhava.blogspot.com/p/siddhanta-devanagariunicode-open-type.html .  There are no deep dependencies to this font, so feel free to locally replace its usage with any other Devanagari-capable Unicode font, if you prefer.
