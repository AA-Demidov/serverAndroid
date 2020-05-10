namespace ServerAndroid
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.lstStatus = new System.Windows.Forms.ListBox();
            this.btnRSSI = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lstData = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lst2room = new System.Windows.Forms.ListBox();
            this.lst1room = new System.Windows.Forms.ListBox();
            this.lst3room = new System.Windows.Forms.ListBox();
            this.lst4room = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lstAnton = new System.Windows.Forms.ListBox();
            this.lstUlyana = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(151, 9);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(45, 11);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(100, 20);
            this.txtHost.TabIndex = 3;
            this.txtHost.Text = "192.168.0.106";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(45, 37);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "5000";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(151, 35);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lstStatus
            // 
            this.lstStatus.FormattingEnabled = true;
            this.lstStatus.Location = new System.Drawing.Point(947, 20);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(179, 147);
            this.lstStatus.TabIndex = 7;
            // 
            // btnRSSI
            // 
            this.btnRSSI.Location = new System.Drawing.Point(10, 237);
            this.btnRSSI.Name = "btnRSSI";
            this.btnRSSI.Size = new System.Drawing.Size(256, 42);
            this.btnRSSI.TabIndex = 8;
            this.btnRSSI.Text = "Определение место положения: Методом RSSI";
            this.btnRSSI.UseVisualStyleBackColor = true;
            this.btnRSSI.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(10, 91);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(256, 140);
            this.txtStatus.TabIndex = 10;
            // 
            // lstData
            // 
            this.lstData.FormattingEnabled = true;
            this.lstData.Location = new System.Drawing.Point(10, 307);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(256, 121);
            this.lstData.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(948, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Вывод общего массива";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Терминал сервера";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Служебная информация";
            // 
            // lst2room
            // 
            this.lst2room.FormattingEnabled = true;
            this.lst2room.Location = new System.Drawing.Point(513, 17);
            this.lst2room.Name = "lst2room";
            this.lst2room.Size = new System.Drawing.Size(81, 69);
            this.lst2room.TabIndex = 17;
            // 
            // lst1room
            // 
            this.lst1room.FormattingEnabled = true;
            this.lst1room.Location = new System.Drawing.Point(426, 17);
            this.lst1room.Name = "lst1room";
            this.lst1room.Size = new System.Drawing.Size(81, 69);
            this.lst1room.TabIndex = 18;
            // 
            // lst3room
            // 
            this.lst3room.FormattingEnabled = true;
            this.lst3room.Location = new System.Drawing.Point(600, 17);
            this.lst3room.Name = "lst3room";
            this.lst3room.Size = new System.Drawing.Size(81, 69);
            this.lst3room.TabIndex = 19;
            // 
            // lst4room
            // 
            this.lst4room.FormattingEnabled = true;
            this.lst4room.Location = new System.Drawing.Point(687, 17);
            this.lst4room.Name = "lst4room";
            this.lst4room.Size = new System.Drawing.Size(81, 69);
            this.lst4room.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(272, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(670, 499);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(423, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Синяя";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(510, 1);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Красная";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(597, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Зеленая";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(684, 1);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Фиолетовая";
            // 
            // lstAnton
            // 
            this.lstAnton.FormattingEnabled = true;
            this.lstAnton.Location = new System.Drawing.Point(948, 189);
            this.lstAnton.Name = "lstAnton";
            this.lstAnton.Size = new System.Drawing.Size(179, 134);
            this.lstAnton.TabIndex = 26;
            // 
            // lstUlyana
            // 
            this.lstUlyana.FormattingEnabled = true;
            this.lstUlyana.Location = new System.Drawing.Point(948, 342);
            this.lstUlyana.Name = "lstUlyana";
            this.lstUlyana.Size = new System.Drawing.Size(179, 134);
            this.lstUlyana.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(948, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(126, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Вывод массива Антона";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(948, 326);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Вывод массива Ульяны";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(355, 340);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(66, 30);
            this.btnTest.TabIndex = 30;
            this.btnTest.Text = "Антон";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 51);
            this.button1.TabIndex = 31;
            this.button1.Text = "355; 180";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(689, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 51);
            this.button2.TabIndex = 32;
            this.button2.Text = "689; 180";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(600, 340);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(66, 51);
            this.button3.TabIndex = 33;
            this.button3.Text = "600; 340";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(780, 340);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 51);
            this.button4.TabIndex = 34;
            this.button4.Text = "780; 340";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(355, 340);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 51);
            this.button5.TabIndex = 37;
            this.button5.Text = "355; 340";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(600, 180);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(66, 51);
            this.button7.TabIndex = 39;
            this.button7.Text = "600; 180";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(780, 180);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(66, 51);
            this.button8.TabIndex = 40;
            this.button8.Text = "780; 180";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Visible = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(10, 434);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 51);
            this.button6.TabIndex = 41;
            this.button6.Text = "355; 340";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 596);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lstUlyana);
            this.Controls.Add(this.lstAnton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lst4room);
            this.Controls.Add(this.lst3room);
            this.Controls.Add(this.lst1room);
            this.Controls.Add(this.lst2room);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnRSSI);
            this.Controls.Add(this.lstStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ServerAndroid";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ListBox lstStatus;
        private System.Windows.Forms.Button btnRSSI;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ListBox lstData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lst2room;
        private System.Windows.Forms.ListBox lst1room;
        private System.Windows.Forms.ListBox lst3room;
        private System.Windows.Forms.ListBox lst4room;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lstAnton;
        private System.Windows.Forms.ListBox lstUlyana;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
    }
}

