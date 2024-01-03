namespace project
{
    partial class Form1
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnHighlight = new Button();
            btnRestart = new Button();
            menuStrip1 = new MenuStrip();
            gameToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            informationPanel = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnHighlight
            // 
            btnHighlight.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnHighlight.BackColor = Color.White;
            btnHighlight.FlatStyle = FlatStyle.Popup;
            btnHighlight.Location = new Point(318, 21);
            btnHighlight.Margin = new Padding(7, 6, 7, 6);
            btnHighlight.Name = "btnHighlight";
            btnHighlight.Size = new Size(183, 48);
            btnHighlight.TabIndex = 0;
            btnHighlight.Text = "Toggle highlight";
            btnHighlight.UseVisualStyleBackColor = false;
            btnHighlight.Click += button_highlight_Click;
            // 
            // btnRestart
            // 
            btnRestart.BackColor = Color.White;
            btnRestart.FlatStyle = FlatStyle.Popup;
            btnRestart.Location = new Point(318, 81);
            btnRestart.Margin = new Padding(7, 6, 7, 6);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(183, 48);
            btnRestart.TabIndex = 1;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = false;
            btnRestart.Click += button_restart_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { gameToolStripMenuItem, settingsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 4, 0, 4);
            menuStrip1.Size = new Size(1636, 37);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // gameToolStripMenuItem
            // 
            gameToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem6, toolStripMenuItem7, toolStripMenuItem2 });
            gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            gameToolStripMenuItem.Size = new Size(74, 29);
            gameToolStripMenuItem.Text = "Game";
            gameToolStripMenuItem.Click += gameToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(224, 34);
            toolStripMenuItem1.Text = "New Game";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // toolStripMenuItem6
            // 
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            toolStripMenuItem6.Size = new Size(224, 34);
            toolStripMenuItem6.Text = "Save Game";
            toolStripMenuItem6.Click += toolStripMenuItem6_Click;
            // 
            // toolStripMenuItem7
            // 
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            toolStripMenuItem7.Size = new Size(224, 34);
            toolStripMenuItem7.Text = "Restore Game";
            toolStripMenuItem7.Click += toolStripMenuItem7_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(224, 34);
            toolStripMenuItem2.Text = "Exit";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { informationPanel, toolStripMenuItem5 });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(92, 29);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // informationPanel
            // 
            informationPanel.Checked = true;
            informationPanel.CheckOnClick = true;
            informationPanel.CheckState = CheckState.Checked;
            informationPanel.Name = "informationPanel";
            informationPanel.Size = new Size(254, 34);
            informationPanel.Text = "Information Panel";
            informationPanel.Click += toolStripMenuItem4_Click_1;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(254, 34);
            toolStripMenuItem5.Text = "Speak";
            toolStripMenuItem5.Click += toolStripMenuItem5_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem3 });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "Help";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(164, 34);
            toolStripMenuItem3.Text = "About";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(354, 218);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(146, 34);
            textBox1.TabIndex = 3;
            textBox1.Text = "textBox1";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(354, 404);
            textBox2.Margin = new Padding(4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(146, 34);
            textBox2.TabIndex = 4;
            textBox2.Text = "textBox2";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._3;
            pictureBox1.Location = new Point(200, 185);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(110, 102);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(200, 356);
            pictureBox2.Margin = new Padding(4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(110, 108);
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Location = new Point(29, 222);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(67, 27);
            label1.TabIndex = 7;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(32, 408);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 27);
            label2.TabIndex = 8;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Salmon;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(29, 81);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.MaximumSize = new Size(110, 67);
            label3.Name = "label3";
            label3.Size = new Size(69, 29);
            label3.TabIndex = 9;
            label3.Text = "label3";
            label3.Click += label3_Click;
            // 
            // panel1
            // 
            panel1.AccessibleRole = AccessibleRole.None;
            panel1.BackColor = Color.LightPink;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnRestart);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnHighlight);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(1051, 65);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(561, 580);
            panel1.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 27F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1636, 1050);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Cursor = Cursors.Arrow;
            DoubleBuffered = true;
            Font = new Font("Calibri", 11F, FontStyle.Regular, GraphicsUnit.Point);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(7, 6, 7, 6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "O’Neillo Game";
            Load += Form1_Load_1;
            ClientSizeChanged += Form1_ClientSizeChanged;
            Paint += Form1_Paint;
            MouseClick += Form1_MouseClick;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHighlight;
        private Button btnRestart;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private TextBox textBox1;
        private TextBox textBox2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private Label label3;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripMenuItem toolStripMenuItem7;
        private Panel panel1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem informationPanel;
        private ToolStripMenuItem toolStripMenuItem5;
    }
}

