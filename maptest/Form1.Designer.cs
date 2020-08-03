namespace maptest
{
    partial class MapTest
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
            this.MapArea = new System.Windows.Forms.PictureBox();
            this.InfoArea = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.numbertries = new System.Windows.Forms.TextBox();
            this.minimumwidth = new System.Windows.Forms.TextBox();
            this.maximumwidth = new System.Windows.Forms.TextBox();
            this.makesquare = new System.Windows.Forms.CheckBox();
            this.generaterooms = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.addspacebetween = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.spaceadded = new System.Windows.Forms.TextBox();
            this.tunnelsizetext = new System.Windows.Forms.TextBox();
            this.tunnelsize = new System.Windows.Forms.TextBox();
            this.gentunnels = new System.Windows.Forms.Button();
            this.usespaceasgrid = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MapArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoArea)).BeginInit();
            this.SuspendLayout();
            // 
            // MapArea
            // 
            this.MapArea.BackColor = System.Drawing.Color.Black;
            this.MapArea.Location = new System.Drawing.Point(0, 0);
            this.MapArea.Name = "MapArea";
            this.MapArea.Size = new System.Drawing.Size(600, 450);
            this.MapArea.TabIndex = 0;
            this.MapArea.TabStop = false;
            this.MapArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintMap);
            // 
            // InfoArea
            // 
            this.InfoArea.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.InfoArea.Location = new System.Drawing.Point(600, 0);
            this.InfoArea.Name = "InfoArea";
            this.InfoArea.Size = new System.Drawing.Size(200, 130);
            this.InfoArea.TabIndex = 1;
            this.InfoArea.TabStop = false;
            this.InfoArea.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintInfo);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(607, 137);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(94, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "# Tries:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(607, 164);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(94, 23);
            this.textBox2.TabIndex = 0;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Min Width:";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(607, 191);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(94, 23);
            this.textBox3.TabIndex = 0;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Max Width:";
            // 
            // numbertries
            // 
            this.numbertries.Location = new System.Drawing.Point(707, 137);
            this.numbertries.Name = "numbertries";
            this.numbertries.Size = new System.Drawing.Size(84, 20);
            this.numbertries.TabIndex = 1;
            this.numbertries.Text = "5000";
            // 
            // minimumwidth
            // 
            this.minimumwidth.Location = new System.Drawing.Point(707, 164);
            this.minimumwidth.Name = "minimumwidth";
            this.minimumwidth.Size = new System.Drawing.Size(84, 20);
            this.minimumwidth.TabIndex = 2;
            this.minimumwidth.Text = "50";
            // 
            // maximumwidth
            // 
            this.maximumwidth.Location = new System.Drawing.Point(707, 191);
            this.maximumwidth.Name = "maximumwidth";
            this.maximumwidth.Size = new System.Drawing.Size(84, 20);
            this.maximumwidth.TabIndex = 3;
            this.maximumwidth.Text = "100";
            // 
            // makesquare
            // 
            this.makesquare.AutoSize = true;
            this.makesquare.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makesquare.Location = new System.Drawing.Point(607, 221);
            this.makesquare.Name = "makesquare";
            this.makesquare.Size = new System.Drawing.Size(102, 19);
            this.makesquare.TabIndex = 4;
            this.makesquare.Text = "Make Square";
            this.makesquare.UseVisualStyleBackColor = true;
            // 
            // generaterooms
            // 
            this.generaterooms.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generaterooms.ForeColor = System.Drawing.Color.Navy;
            this.generaterooms.Location = new System.Drawing.Point(607, 323);
            this.generaterooms.Name = "generaterooms";
            this.generaterooms.Size = new System.Drawing.Size(184, 23);
            this.generaterooms.TabIndex = 21;
            this.generaterooms.Text = "Generate Rooms";
            this.generaterooms.UseVisualStyleBackColor = true;
            this.generaterooms.Click += new System.EventHandler(this.GenRooms);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Maroon;
            this.button1.Location = new System.Drawing.Point(607, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Exit Program";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ExitProgram);
            // 
            // addspacebetween
            // 
            this.addspacebetween.AutoSize = true;
            this.addspacebetween.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addspacebetween.Location = new System.Drawing.Point(607, 247);
            this.addspacebetween.Name = "addspacebetween";
            this.addspacebetween.Size = new System.Drawing.Size(190, 19);
            this.addspacebetween.TabIndex = 5;
            this.addspacebetween.Text = "Add Space Between Rooms";
            this.addspacebetween.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(607, 269);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(94, 23);
            this.textBox4.TabIndex = 0;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Space:";
            // 
            // spaceadded
            // 
            this.spaceadded.Location = new System.Drawing.Point(707, 272);
            this.spaceadded.Name = "spaceadded";
            this.spaceadded.Size = new System.Drawing.Size(84, 20);
            this.spaceadded.TabIndex = 6;
            this.spaceadded.Text = "50";
            // 
            // tunnelsizetext
            // 
            this.tunnelsizetext.Enabled = false;
            this.tunnelsizetext.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tunnelsizetext.Location = new System.Drawing.Point(607, 357);
            this.tunnelsizetext.Name = "tunnelsizetext";
            this.tunnelsizetext.ReadOnly = true;
            this.tunnelsizetext.Size = new System.Drawing.Size(94, 23);
            this.tunnelsizetext.TabIndex = 0;
            this.tunnelsizetext.TabStop = false;
            this.tunnelsizetext.Text = "Tunnel Size:";
            // 
            // tunnelsize
            // 
            this.tunnelsize.Enabled = false;
            this.tunnelsize.Location = new System.Drawing.Point(705, 357);
            this.tunnelsize.Name = "tunnelsize";
            this.tunnelsize.Size = new System.Drawing.Size(83, 20);
            this.tunnelsize.TabIndex = 7;
            this.tunnelsize.Text = "24";
            // 
            // gentunnels
            // 
            this.gentunnels.Enabled = false;
            this.gentunnels.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gentunnels.ForeColor = System.Drawing.Color.Indigo;
            this.gentunnels.Location = new System.Drawing.Point(607, 386);
            this.gentunnels.Name = "gentunnels";
            this.gentunnels.Size = new System.Drawing.Size(184, 23);
            this.gentunnels.TabIndex = 22;
            this.gentunnels.Text = "Generate Tunnels";
            this.gentunnels.UseVisualStyleBackColor = true;
            this.gentunnels.Click += new System.EventHandler(this.GenerateTunnels);
            // 
            // usespaceasgrid
            // 
            this.usespaceasgrid.AutoSize = true;
            this.usespaceasgrid.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usespaceasgrid.Location = new System.Drawing.Point(607, 298);
            this.usespaceasgrid.Name = "usespaceasgrid";
            this.usespaceasgrid.Size = new System.Drawing.Size(138, 19);
            this.usespaceasgrid.TabIndex = 8;
            this.usespaceasgrid.Text = "Use Space As Grid";
            this.usespaceasgrid.UseVisualStyleBackColor = true;
            // 
            // MapTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.usespaceasgrid);
            this.Controls.Add(this.gentunnels);
            this.Controls.Add(this.tunnelsize);
            this.Controls.Add(this.tunnelsizetext);
            this.Controls.Add(this.spaceadded);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.addspacebetween);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.generaterooms);
            this.Controls.Add(this.makesquare);
            this.Controls.Add(this.maximumwidth);
            this.Controls.Add(this.minimumwidth);
            this.Controls.Add(this.numbertries);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.InfoArea);
            this.Controls.Add(this.MapArea);
            this.Name = "MapTest";
            this.Text = "Map Test";
            ((System.ComponentModel.ISupportInitialize)(this.MapArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MapArea;
        private System.Windows.Forms.PictureBox InfoArea;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox numbertries;
        private System.Windows.Forms.TextBox minimumwidth;
        private System.Windows.Forms.TextBox maximumwidth;
        private System.Windows.Forms.CheckBox makesquare;
        private System.Windows.Forms.Button generaterooms;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox addspacebetween;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox spaceadded;
        private System.Windows.Forms.TextBox tunnelsizetext;
        private System.Windows.Forms.TextBox tunnelsize;
        private System.Windows.Forms.Button gentunnels;
        private System.Windows.Forms.CheckBox usespaceasgrid;
    }
}

