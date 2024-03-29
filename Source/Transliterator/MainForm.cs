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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using System.IO;
using QDDevanagari.DevanagariLib;

namespace QDDevanagari
{
    namespace Transliterator
    {
        public partial class MainForm : Form
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll")]
            private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
            private PrivateFontCollection _fonts = new PrivateFontCollection();
            private Font _editBoxFont = null;
            private int _editBoxFontSize = 24;
            private FontFamily _editBoxFontFamily = null;

            private Font InitFont(byte[] fontData, float pointSize, out FontFamily outFontFamily)
            {
                IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
                System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            
                uint dummy = 0;
                int familyCount = _fonts.Families.Length;
                _fonts.AddMemoryFont(fontPtr, fontData.Length);
                AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

                outFontFamily = _fonts.Families[familyCount];
                return new Font(_fonts.Families[familyCount], pointSize);
            }

            public MainForm()
            {
                InitializeComponent();

                // The Siddhanta font is a free font published under the
                // Creative Commons Attribution-NonCommercial-NoDerivs 3.0 Unported License
                // http://svayambhava.blogspot.com/p/siddhanta-devanagariunicode-open-type.html
                _editBoxFont = InitFont(Properties.Resources.siddhanta, (float)_editBoxFontSize, out _editBoxFontFamily);
            }

            private void MainForm_Load(object sender, EventArgs e)
            {
                EditBoxCurrentMarkerTrans.Font = _editBoxFont;

                Refresh();
            }

            private void RefreshFontSizeComboBox()
            {
                foreach (var item in MainMenuItemEditFontSizeComboBox.Items)
                {
                    int fontSize = 0;
                    if (!int.TryParse(item.ToString(), out fontSize))
                        continue;
                    if (fontSize == _editBoxFontSize)
                    {
                        MainMenuItemEditFontSizeComboBox.SelectedItem = item;
                        break;
                    }
                }
            }

            public override void Refresh()
            {
                base.Refresh();
                RefreshFontSizeComboBox();
            }

            private void MainTimer_Tick(object sender, EventArgs e)
            {
            }

            private bool _editMutex = false;
            private void EditBoxCurrentMarkerTrans_TextChanged(object sender, EventArgs e)
            {
                if (_editMutex)
                    return;

                _editMutex = true;

                if (EditBoxCurrentMarkerTrans.Text.Length >= 2)
                {
                    if ((EditBoxCurrentMarkerTrans.SelectionLength == 0)
                     && (EditBoxCurrentMarkerTrans.SelectionStart >= 2))
                    {
                        string followingText = EditBoxCurrentMarkerTrans.Text.Substring(EditBoxCurrentMarkerTrans.SelectionStart);

                        string s = EditBoxCurrentMarkerTrans.Text.Substring(0, EditBoxCurrentMarkerTrans.SelectionStart);
                        char[] lastCharStr = s.ToCharArray(s.Length - 2, 2);
                        char srcChar = lastCharStr[0];
                        char augChar = lastCharStr[1];

                        Devanagari.AugmentType augType = Devanagari.AugmentType.None;
                        if (augChar == '_')
                            augType |= Devanagari.AugmentType.Macron;
                        else if (augChar == '\'')
                            augType |= Devanagari.AugmentType.Acute;
                        else if (augChar == '<')
                            augType |= Devanagari.AugmentType.Lodot;
                        else if (augChar == '>')
                            augType |= Devanagari.AugmentType.Updot;
                        else if (augChar == '~')
                            augType |= Devanagari.AugmentType.Tilde;

                        char desiredChar = Devanagari.AugmentChar(srcChar, augType);

                        if (desiredChar != srcChar)
                        {
                            s = s.Substring(0, s.Length - 2);
                            s += desiredChar;
                            EditBoxCurrentMarkerTrans.Text = s + followingText;
                            EditBoxCurrentMarkerTrans.SelectionStart = s.Length;
                            EditBoxCurrentMarkerTrans.ScrollToCaret();
                        }
                    }
                }

                _editMutex = false;
            }

            private void ConvertSelectedTransToDevanagari()
            {
                string selText = EditBoxCurrentMarkerTrans.SelectedText;
                if (selText != null)
                {
                    string convText = Devanagari.Detransliterate(selText);
                    if (convText != null)
                        EditBoxCurrentMarkerTrans.SelectedText = convText;
                }
            }
            private void ConvertSelectedDevanagariToTrans()
            {
                string selText = EditBoxCurrentMarkerTrans.SelectedText;
                if (selText != null)
                {
                    string convText = Devanagari.Transliterate(selText);
                    if (convText != null)
                        EditBoxCurrentMarkerTrans.SelectedText = convText;
                }
            }

            private void EditBoxCurrentMarkerTrans_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.Alt)
                {
                    if (e.KeyValue == 't' || e.KeyValue == 'T')
                        ConvertSelectedDevanagariToTrans();
                    else if (e.KeyValue == 'd' || e.KeyValue == 'D')
                        ConvertSelectedTransToDevanagari();
                }
            }

            private void MainMenuItemFileExit_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
            {
            }

            private void MainMenuItemEditConvertDevanagariToTrans_Click(object sender, EventArgs e)
            {
                ConvertSelectedDevanagariToTrans();
            }

            private void MainMenuItemEditConvertTransToDevanagari_Click(object sender, EventArgs e)
            {
                ConvertSelectedTransToDevanagari();
            }

            private void MainMenuItemEditFontSize_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
            {
            }

            private void MainMenuItemEditFontSize_Click(object sender, EventArgs e)
            {
            }

            private void MainMenuItemEditFontSizeComboBox_DropDownClosed(object sender, EventArgs e)
            {
                int fontSize;
                if (int.TryParse(MainMenuItemEditFontSizeComboBox.SelectedItem.ToString(), out fontSize))
                {
                    if (_editBoxFontSize != fontSize)
                    {
                        _editBoxFontSize = fontSize;
                        _editBoxFont = new Font(_editBoxFontFamily, (float)_editBoxFontSize);
                        EditBoxCurrentMarkerTrans.Font = _editBoxFont;
                        Refresh();
                    }
                }
            }
        }
    }
}