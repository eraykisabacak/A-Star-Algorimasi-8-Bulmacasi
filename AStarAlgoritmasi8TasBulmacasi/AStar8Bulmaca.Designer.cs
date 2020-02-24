namespace AStarAlgoritmasi8TasBulmacasi
{
    partial class AStar8Bulmaca
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBaslangic = new System.Windows.Forms.TextBox();
            this.txtAmac = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSonuc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Başlangıç Durumu:";
            // 
            // txtBaslangic
            // 
            this.txtBaslangic.Location = new System.Drawing.Point(179, 27);
            this.txtBaslangic.Name = "txtBaslangic";
            this.txtBaslangic.Size = new System.Drawing.Size(189, 26);
            this.txtBaslangic.TabIndex = 1;
            this.txtBaslangic.Text = "1,3,2,8,0,4,5,6,7";
            this.txtBaslangic.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBaslangic_KeyPress);
            // 
            // txtAmac
            // 
            this.txtAmac.Location = new System.Drawing.Point(179, 68);
            this.txtAmac.Name = "txtAmac";
            this.txtAmac.Size = new System.Drawing.Size(189, 26);
            this.txtAmac.TabIndex = 3;
            this.txtAmac.Text = "1,2,3,8,0,4,7,6,5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Amaç Durumu:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Çöz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSonuc
            // 
            this.txtSonuc.Location = new System.Drawing.Point(388, 27);
            this.txtSonuc.Multiline = true;
            this.txtSonuc.Name = "txtSonuc";
            this.txtSonuc.ReadOnly = true;
            this.txtSonuc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSonuc.Size = new System.Drawing.Size(222, 605);
            this.txtSonuc.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 644);
            this.Controls.Add(this.txtSonuc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAmac);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBaslangic);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBaslangic;
        private System.Windows.Forms.TextBox txtAmac;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSonuc;
    }
}

