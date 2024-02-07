namespace sondeneme1
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.musteriTxt = new System.Windows.Forms.TextBox();
            this.oncelikTxt = new System.Windows.Forms.TextBox();
            this.masaTxt = new System.Windows.Forms.TextBox();
            this.garsonTxt = new System.Windows.Forms.TextBox();
            this.asciTxt = new System.Windows.Forms.TextBox();
            this.baslatBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(65, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Müşteri Sayısı : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(56, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Öncelikli Sayısı : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(80, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Masa Sayısı : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(65, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Garson Sayısı : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(89, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Asci Sayısı : ";
            // 
            // musteriTxt
            // 
            this.musteriTxt.Location = new System.Drawing.Point(200, 113);
            this.musteriTxt.Name = "musteriTxt";
            this.musteriTxt.Size = new System.Drawing.Size(129, 20);
            this.musteriTxt.TabIndex = 5;
            // 
            // oncelikTxt
            // 
            this.oncelikTxt.Location = new System.Drawing.Point(200, 155);
            this.oncelikTxt.Name = "oncelikTxt";
            this.oncelikTxt.Size = new System.Drawing.Size(129, 20);
            this.oncelikTxt.TabIndex = 6;
            // 
            // masaTxt
            // 
            this.masaTxt.Location = new System.Drawing.Point(200, 197);
            this.masaTxt.Name = "masaTxt";
            this.masaTxt.Size = new System.Drawing.Size(129, 20);
            this.masaTxt.TabIndex = 7;
            // 
            // garsonTxt
            // 
            this.garsonTxt.Location = new System.Drawing.Point(200, 239);
            this.garsonTxt.Name = "garsonTxt";
            this.garsonTxt.Size = new System.Drawing.Size(129, 20);
            this.garsonTxt.TabIndex = 8;
            // 
            // asciTxt
            // 
            this.asciTxt.Location = new System.Drawing.Point(200, 281);
            this.asciTxt.Name = "asciTxt";
            this.asciTxt.Size = new System.Drawing.Size(129, 20);
            this.asciTxt.TabIndex = 9;
            // 
            // baslatBtn
            // 
            this.baslatBtn.Location = new System.Drawing.Point(200, 328);
            this.baslatBtn.Name = "baslatBtn";
            this.baslatBtn.Size = new System.Drawing.Size(129, 35);
            this.baslatBtn.TabIndex = 10;
            this.baslatBtn.Text = "Başlat";
            this.baslatBtn.UseVisualStyleBackColor = true;
            this.baslatBtn.Click += new System.EventHandler(this.baslatBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(145, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "PROBLEM 1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(10, 363);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(541, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "PROBLEM 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(471, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 18);
            this.label8.TabIndex = 14;
            this.label8.Text = "Saniye : ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(550, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(137, 20);
            this.textBox1.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(558, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 35);
            this.button2.TabIndex = 16;
            this.button2.Text = "Başlat";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 477);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.baslatBtn);
            this.Controls.Add(this.asciTxt);
            this.Controls.Add(this.garsonTxt);
            this.Controls.Add(this.masaTxt);
            this.Controls.Add(this.oncelikTxt);
            this.Controls.Add(this.musteriTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox musteriTxt;
        private System.Windows.Forms.TextBox oncelikTxt;
        private System.Windows.Forms.TextBox masaTxt;
        private System.Windows.Forms.TextBox garsonTxt;
        private System.Windows.Forms.TextBox asciTxt;
        private System.Windows.Forms.Button baslatBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}

