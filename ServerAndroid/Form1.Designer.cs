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
            this.btnScan = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lstData = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lst2room = new System.Windows.Forms.ListBox();
            this.lst1room = new System.Windows.Forms.ListBox();
            this.lst3room = new System.Windows.Forms.ListBox();
            this.lst4room = new System.Windows.Forms.ListBox();
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
            this.txtHost.Text = "192.168.0.105";
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
            this.lstStatus.Location = new System.Drawing.Point(10, 310);
            this.lstStatus.Name = "lstStatus";
            this.lstStatus.Size = new System.Drawing.Size(256, 147);
            this.lstStatus.TabIndex = 7;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(10, 245);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(256, 42);
            this.btnScan.TabIndex = 8;
            this.btnScan.Text = "Определить местоположение";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(10, 91);
            this.txtStatus.Multiline = true;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(256, 148);
            this.txtStatus.TabIndex = 10;
            // 
            // lstData
            // 
            this.lstData.FormattingEnabled = true;
            this.lstData.Location = new System.Drawing.Point(10, 476);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(256, 121);
            this.lstData.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Вывод массива";
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
            this.label5.Location = new System.Drawing.Point(9, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Служебная информация";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(272, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(668, 665);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lst2room
            // 
            this.lst2room.FormattingEnabled = true;
            this.lst2room.Location = new System.Drawing.Point(546, 348);
            this.lst2room.Name = "lst2room";
            this.lst2room.Size = new System.Drawing.Size(145, 199);
            this.lst2room.TabIndex = 17;
            // 
            // lst1room
            // 
            this.lst1room.FormattingEnabled = true;
            this.lst1room.Location = new System.Drawing.Point(314, 348);
            this.lst1room.Name = "lst1room";
            this.lst1room.Size = new System.Drawing.Size(145, 199);
            this.lst1room.TabIndex = 18;
            // 
            // lst3room
            // 
            this.lst3room.FormattingEnabled = true;
            this.lst3room.Location = new System.Drawing.Point(760, 348);
            this.lst3room.Name = "lst3room";
            this.lst3room.Size = new System.Drawing.Size(145, 199);
            this.lst3room.TabIndex = 19;
            // 
            // lst4room
            // 
            this.lst4room.FormattingEnabled = true;
            this.lst4room.Location = new System.Drawing.Point(760, 37);
            this.lst4room.Name = "lst4room";
            this.lst4room.Size = new System.Drawing.Size(145, 108);
            this.lst4room.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 678);
            this.Controls.Add(this.lst4room);
            this.Controls.Add(this.lst3room);
            this.Controls.Add(this.lst1room);
            this.Controls.Add(this.lst2room);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.btnScan);
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
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ListBox lstData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lst2room;
        private System.Windows.Forms.ListBox lst1room;
        private System.Windows.Forms.ListBox lst3room;
        private System.Windows.Forms.ListBox lst4room;
    }
}

