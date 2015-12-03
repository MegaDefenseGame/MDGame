namespace MDGame
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
            this.components = new System.ComponentModel.Container();
            this.CoinsValue = new System.Windows.Forms.Label();
            this.HeroSelector = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Map = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.TimeEnemySpawn = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TimeEnemySpeed = new System.Windows.Forms.Timer(this.components);
            this.HeroSelector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Map.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CoinsValue
            // 
            this.CoinsValue.AutoSize = true;
            this.CoinsValue.Location = new System.Drawing.Point(71, 35);
            this.CoinsValue.Name = "CoinsValue";
            this.CoinsValue.Size = new System.Drawing.Size(25, 13);
            this.CoinsValue.TabIndex = 2;
            this.CoinsValue.Text = "200";
            // 
            // HeroSelector
            // 
            this.HeroSelector.BackColor = System.Drawing.Color.White;
            this.HeroSelector.Controls.Add(this.pictureBox4);
            this.HeroSelector.Controls.Add(this.pictureBox3);
            this.HeroSelector.Location = new System.Drawing.Point(27, 89);
            this.HeroSelector.Name = "HeroSelector";
            this.HeroSelector.Size = new System.Drawing.Size(101, 600);
            this.HeroSelector.TabIndex = 3;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::MDGame.Properties.Resources.CSHero2;
            this.pictureBox4.Location = new System.Drawing.Point(0, 99);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 103);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::MDGame.Properties.Resources.CSHero1;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 102);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(199, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(143, 38);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MDGame.Properties.Resources.CSLife;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 38);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // Map
            // 
            this.Map.Controls.Add(this.pictureBox5);
            this.Map.Location = new System.Drawing.Point(199, 89);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(700, 600);
            this.Map.TabIndex = 4;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::MDGame.Properties.Resources.wall_resize;
            this.pictureBox5.Location = new System.Drawing.Point(0, -2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(100, 102);
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(397, 23);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(99, 36);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "TestStart";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // TimeEnemySpawn
            // 
            this.TimeEnemySpawn.Tick += new System.EventHandler(this.TimeEnemySpawn_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MDGame.Properties.Resources.CSCoins;
            this.pictureBox1.Location = new System.Drawing.Point(27, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 38);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 711);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HeroSelector);
            this.Controls.Add(this.CoinsValue);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.HeroSelector.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Map.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label CoinsValue;
        private System.Windows.Forms.Panel HeroSelector;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel Map;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Timer TimeEnemySpawn;
        private System.Windows.Forms.Timer TimeEnemySpeed;
    }
}

