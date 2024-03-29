namespace QDDevanagari
{
    namespace Transliterator
    {
        partial class MainForm
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    //DisposeFMod();

                    if (components != null)
                    {
                        components.Dispose();
                    }
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.MainMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuItemFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuItemEditConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuItemEditConvertTransToDevanagari = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuItemEditConvertDevanagariToTrans = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuItemEditFontSize = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuItemEditFontSizeComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.MainTabControlPageProject = new System.Windows.Forms.TabPage();
            this.LabelTransUsage = new System.Windows.Forms.Label();
            this.EditBoxCurrentMarkerTrans = new System.Windows.Forms.TextBox();
            this.OpenFileDialogMP3 = new System.Windows.Forms.OpenFileDialog();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.OpenFileDialogProject = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialogProject = new System.Windows.Forms.SaveFileDialog();
            this.MainMenu.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.MainTabControlPageProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuItemFile,
            this.MainMenuItemEdit});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(712, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // MainMenuItemFile
            // 
            this.MainMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuItemFileExit});
            this.MainMenuItemFile.Name = "MainMenuItemFile";
            this.MainMenuItemFile.Size = new System.Drawing.Size(37, 20);
            this.MainMenuItemFile.Text = "&File";
            // 
            // MainMenuItemFileExit
            // 
            this.MainMenuItemFileExit.Name = "MainMenuItemFileExit";
            this.MainMenuItemFileExit.Size = new System.Drawing.Size(92, 22);
            this.MainMenuItemFileExit.Text = "E&xit";
            this.MainMenuItemFileExit.Click += new System.EventHandler(this.MainMenuItemFileExit_Click);
            // 
            // MainMenuItemEdit
            // 
            this.MainMenuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuItemEditConvert,
            this.MainMenuItemEditFontSize});
            this.MainMenuItemEdit.Name = "MainMenuItemEdit";
            this.MainMenuItemEdit.Size = new System.Drawing.Size(39, 20);
            this.MainMenuItemEdit.Text = "&Edit";
            // 
            // MainMenuItemEditConvert
            // 
            this.MainMenuItemEditConvert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuItemEditConvertTransToDevanagari,
            this.MainMenuItemEditConvertDevanagariToTrans});
            this.MainMenuItemEditConvert.Name = "MainMenuItemEditConvert";
            this.MainMenuItemEditConvert.Size = new System.Drawing.Size(188, 22);
            this.MainMenuItemEditConvert.Text = "&Convert Selected Text";
            // 
            // MainMenuItemEditConvertTransToDevanagari
            // 
            this.MainMenuItemEditConvertTransToDevanagari.Name = "MainMenuItemEditConvertTransToDevanagari";
            this.MainMenuItemEditConvertTransToDevanagari.ShortcutKeyDisplayString = "Ctrl+Alt+D";
            this.MainMenuItemEditConvertTransToDevanagari.Size = new System.Drawing.Size(287, 22);
            this.MainMenuItemEditConvertTransToDevanagari.Text = "Transliterated to Devanagari";
            this.MainMenuItemEditConvertTransToDevanagari.Click += new System.EventHandler(this.MainMenuItemEditConvertTransToDevanagari_Click);
            // 
            // MainMenuItemEditConvertDevanagariToTrans
            // 
            this.MainMenuItemEditConvertDevanagariToTrans.Name = "MainMenuItemEditConvertDevanagariToTrans";
            this.MainMenuItemEditConvertDevanagariToTrans.ShortcutKeyDisplayString = "Ctrl+Alt+T";
            this.MainMenuItemEditConvertDevanagariToTrans.Size = new System.Drawing.Size(287, 22);
            this.MainMenuItemEditConvertDevanagariToTrans.Text = "Devanagari to Transliterated";
            this.MainMenuItemEditConvertDevanagariToTrans.Click += new System.EventHandler(this.MainMenuItemEditConvertDevanagariToTrans_Click);
            // 
            // MainMenuItemEditFontSize
            // 
            this.MainMenuItemEditFontSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuItemEditFontSizeComboBox});
            this.MainMenuItemEditFontSize.Name = "MainMenuItemEditFontSize";
            this.MainMenuItemEditFontSize.Size = new System.Drawing.Size(188, 22);
            this.MainMenuItemEditFontSize.Text = "&Font Size";
            this.MainMenuItemEditFontSize.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenuItemEditFontSize_DropDownItemClicked);
            this.MainMenuItemEditFontSize.Click += new System.EventHandler(this.MainMenuItemEditFontSize_Click);
            // 
            // MainMenuItemEditFontSizeComboBox
            // 
            this.MainMenuItemEditFontSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MainMenuItemEditFontSizeComboBox.Items.AddRange(new object[] {
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.MainMenuItemEditFontSizeComboBox.Name = "MainMenuItemEditFontSizeComboBox";
            this.MainMenuItemEditFontSizeComboBox.Size = new System.Drawing.Size(121, 23);
            this.MainMenuItemEditFontSizeComboBox.DropDownClosed += new System.EventHandler(this.MainMenuItemEditFontSizeComboBox_DropDownClosed);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTabControl.Controls.Add(this.MainTabControlPageProject);
            this.MainTabControl.Location = new System.Drawing.Point(12, 27);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(688, 477);
            this.MainTabControl.TabIndex = 1;
            // 
            // MainTabControlPageProject
            // 
            this.MainTabControlPageProject.Controls.Add(this.LabelTransUsage);
            this.MainTabControlPageProject.Controls.Add(this.EditBoxCurrentMarkerTrans);
            this.MainTabControlPageProject.Location = new System.Drawing.Point(4, 22);
            this.MainTabControlPageProject.Name = "MainTabControlPageProject";
            this.MainTabControlPageProject.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabControlPageProject.Size = new System.Drawing.Size(680, 451);
            this.MainTabControlPageProject.TabIndex = 0;
            this.MainTabControlPageProject.Text = "Transliterator";
            this.MainTabControlPageProject.UseVisualStyleBackColor = true;
            // 
            // LabelTransUsage
            // 
            this.LabelTransUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelTransUsage.AutoSize = true;
            this.LabelTransUsage.Location = new System.Drawing.Point(6, 349);
            this.LabelTransUsage.Name = "LabelTransUsage";
            this.LabelTransUsage.Size = new System.Drawing.Size(473, 91);
            this.LabelTransUsage.TabIndex = 20;
            this.LabelTransUsage.Text = resources.GetString("LabelTransUsage.Text");
            // 
            // EditBoxCurrentMarkerTrans
            // 
            this.EditBoxCurrentMarkerTrans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditBoxCurrentMarkerTrans.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditBoxCurrentMarkerTrans.Location = new System.Drawing.Point(3, 3);
            this.EditBoxCurrentMarkerTrans.Multiline = true;
            this.EditBoxCurrentMarkerTrans.Name = "EditBoxCurrentMarkerTrans";
            this.EditBoxCurrentMarkerTrans.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.EditBoxCurrentMarkerTrans.Size = new System.Drawing.Size(674, 343);
            this.EditBoxCurrentMarkerTrans.TabIndex = 14;
            this.EditBoxCurrentMarkerTrans.TextChanged += new System.EventHandler(this.EditBoxCurrentMarkerTrans_TextChanged);
            this.EditBoxCurrentMarkerTrans.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditBoxCurrentMarkerTrans_KeyDown);
            // 
            // OpenFileDialogMP3
            // 
            this.OpenFileDialogMP3.DefaultExt = "mp3";
            this.OpenFileDialogMP3.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 1000;
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // OpenFileDialogProject
            // 
            this.OpenFileDialogProject.DefaultExt = "chandi";
            this.OpenFileDialogProject.Filter = "Chandi Projects (*.chandi)|*.chandi|All files (*.*)|*.*";
            // 
            // SaveFileDialogProject
            // 
            this.SaveFileDialogProject.DefaultExt = "chandi";
            this.SaveFileDialogProject.Filter = "Chandi Projects (*.chandi)|*.chandi|All files (*.*)|*.*";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 516);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(620, 550);
            this.Name = "MainForm";
            this.Text = "QDDevanagari Transliterator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.MainTabControlPageProject.ResumeLayout(false);
            this.MainTabControlPageProject.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.MenuStrip MainMenu;
            private System.Windows.Forms.ToolStripMenuItem MainMenuItemFile;
            private System.Windows.Forms.ToolStripMenuItem MainMenuItemFileExit;
            private System.Windows.Forms.TabControl MainTabControl;
            private System.Windows.Forms.TabPage MainTabControlPageProject;
            private System.Windows.Forms.OpenFileDialog OpenFileDialogMP3;
            private System.Windows.Forms.Timer MainTimer;
            private System.Windows.Forms.OpenFileDialog OpenFileDialogProject;
            private System.Windows.Forms.SaveFileDialog SaveFileDialogProject;
            private System.Windows.Forms.TextBox EditBoxCurrentMarkerTrans;
            private System.Windows.Forms.Label LabelTransUsage;
            private System.Windows.Forms.ToolStripMenuItem MainMenuItemEdit;
            private System.Windows.Forms.ToolStripMenuItem MainMenuItemEditConvert;
            private System.Windows.Forms.ToolStripMenuItem MainMenuItemEditConvertTransToDevanagari;
            private System.Windows.Forms.ToolStripMenuItem MainMenuItemEditConvertDevanagariToTrans;
            private System.Windows.Forms.ToolStripMenuItem MainMenuItemEditFontSize;
            private System.Windows.Forms.ToolStripComboBox MainMenuItemEditFontSizeComboBox;
        }
    }
}
