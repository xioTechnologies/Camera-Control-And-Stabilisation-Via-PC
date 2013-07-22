namespace x_IMU_Camera_Control_via_PC
{
    partial class Form_main
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
            this.groupBox_xIMUport = new System.Windows.Forms.GroupBox();
            this.label_quaternionPacketsReceived = new System.Windows.Forms.Label();
            this.textBox_QuaternionPacketsReceived = new System.Windows.Forms.TextBox();
            this.comboBox_xIMUportName = new System.Windows.Forms.ComboBox();
            this.button_refreshXIMUportList = new System.Windows.Forms.Button();
            this.button_openXIMUport = new System.Windows.Forms.Button();
            this.label_xIMUportName = new System.Windows.Forms.Label();
            this.groupBox_gimbalPort = new System.Windows.Forms.GroupBox();
            this.comboBox_gimbalPortName = new System.Windows.Forms.ComboBox();
            this.button_refreshGimbalPortList = new System.Windows.Forms.Button();
            this.button_openGimbalPort = new System.Windows.Forms.Button();
            this.label_plolluPortName = new System.Windows.Forms.Label();
            this.button_xIMUtare = new System.Windows.Forms.Button();
            this.groupBox_settings = new System.Windows.Forms.GroupBox();
            this.radioButton_stabiliseMode = new System.Windows.Forms.RadioButton();
            this.radioButton_controlMode = new System.Windows.Forms.RadioButton();
            this.groupBox_xIMUport.SuspendLayout();
            this.groupBox_gimbalPort.SuspendLayout();
            this.groupBox_settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_xIMUport
            // 
            this.groupBox_xIMUport.Controls.Add(this.label_quaternionPacketsReceived);
            this.groupBox_xIMUport.Controls.Add(this.textBox_QuaternionPacketsReceived);
            this.groupBox_xIMUport.Controls.Add(this.comboBox_xIMUportName);
            this.groupBox_xIMUport.Controls.Add(this.button_refreshXIMUportList);
            this.groupBox_xIMUport.Controls.Add(this.button_openXIMUport);
            this.groupBox_xIMUport.Controls.Add(this.label_xIMUportName);
            this.groupBox_xIMUport.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_xIMUport.Location = new System.Drawing.Point(0, 0);
            this.groupBox_xIMUport.Name = "groupBox_xIMUport";
            this.groupBox_xIMUport.Size = new System.Drawing.Size(559, 81);
            this.groupBox_xIMUport.TabIndex = 1;
            this.groupBox_xIMUport.TabStop = false;
            this.groupBox_xIMUport.Text = "x-IMU Port";
            // 
            // label_quaternionPacketsReceived
            // 
            this.label_quaternionPacketsReceived.AutoSize = true;
            this.label_quaternionPacketsReceived.Location = new System.Drawing.Point(6, 52);
            this.label_quaternionPacketsReceived.Name = "label_quaternionPacketsReceived";
            this.label_quaternionPacketsReceived.Size = new System.Drawing.Size(147, 13);
            this.label_quaternionPacketsReceived.TabIndex = 24;
            this.label_quaternionPacketsReceived.Text = "Quaternion packets recevied:";
            // 
            // textBox_QuaternionPacketsReceived
            // 
            this.textBox_QuaternionPacketsReceived.Enabled = false;
            this.textBox_QuaternionPacketsReceived.Location = new System.Drawing.Point(159, 49);
            this.textBox_QuaternionPacketsReceived.Name = "textBox_QuaternionPacketsReceived";
            this.textBox_QuaternionPacketsReceived.Size = new System.Drawing.Size(81, 20);
            this.textBox_QuaternionPacketsReceived.TabIndex = 23;
            this.textBox_QuaternionPacketsReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comboBox_xIMUportName
            // 
            this.comboBox_xIMUportName.FormattingEnabled = true;
            this.comboBox_xIMUportName.Location = new System.Drawing.Point(159, 22);
            this.comboBox_xIMUportName.Name = "comboBox_xIMUportName";
            this.comboBox_xIMUportName.Size = new System.Drawing.Size(81, 21);
            this.comboBox_xIMUportName.TabIndex = 0;
            // 
            // button_refreshXIMUportList
            // 
            this.button_refreshXIMUportList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_refreshXIMUportList.Location = new System.Drawing.Point(347, 20);
            this.button_refreshXIMUportList.Name = "button_refreshXIMUportList";
            this.button_refreshXIMUportList.Size = new System.Drawing.Size(100, 23);
            this.button_refreshXIMUportList.TabIndex = 1;
            this.button_refreshXIMUportList.Text = "Refresh List";
            this.button_refreshXIMUportList.UseVisualStyleBackColor = true;
            this.button_refreshXIMUportList.Click += new System.EventHandler(this.button_refreshXIMUlist_Click);
            // 
            // button_openXIMUport
            // 
            this.button_openXIMUport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_openXIMUport.Location = new System.Drawing.Point(453, 20);
            this.button_openXIMUport.Name = "button_openXIMUport";
            this.button_openXIMUport.Size = new System.Drawing.Size(100, 23);
            this.button_openXIMUport.TabIndex = 2;
            this.button_openXIMUport.Text = "Open Port";
            this.button_openXIMUport.UseVisualStyleBackColor = true;
            this.button_openXIMUport.Click += new System.EventHandler(this.button_openXIMUport_Click);
            // 
            // label_xIMUportName
            // 
            this.label_xIMUportName.AutoSize = true;
            this.label_xIMUportName.Location = new System.Drawing.Point(6, 25);
            this.label_xIMUportName.Name = "label_xIMUportName";
            this.label_xIMUportName.Size = new System.Drawing.Size(58, 13);
            this.label_xIMUportName.TabIndex = 22;
            this.label_xIMUportName.Text = "Port name:";
            // 
            // groupBox_gimbalPort
            // 
            this.groupBox_gimbalPort.Controls.Add(this.comboBox_gimbalPortName);
            this.groupBox_gimbalPort.Controls.Add(this.button_refreshGimbalPortList);
            this.groupBox_gimbalPort.Controls.Add(this.button_openGimbalPort);
            this.groupBox_gimbalPort.Controls.Add(this.label_plolluPortName);
            this.groupBox_gimbalPort.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_gimbalPort.Location = new System.Drawing.Point(0, 81);
            this.groupBox_gimbalPort.Name = "groupBox_gimbalPort";
            this.groupBox_gimbalPort.Size = new System.Drawing.Size(559, 56);
            this.groupBox_gimbalPort.TabIndex = 2;
            this.groupBox_gimbalPort.TabStop = false;
            this.groupBox_gimbalPort.Text = "Gimbal Port";
            // 
            // comboBox_gimbalPortName
            // 
            this.comboBox_gimbalPortName.FormattingEnabled = true;
            this.comboBox_gimbalPortName.Location = new System.Drawing.Point(159, 22);
            this.comboBox_gimbalPortName.Name = "comboBox_gimbalPortName";
            this.comboBox_gimbalPortName.Size = new System.Drawing.Size(81, 21);
            this.comboBox_gimbalPortName.TabIndex = 0;
            // 
            // button_refreshGimbalPortList
            // 
            this.button_refreshGimbalPortList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_refreshGimbalPortList.Location = new System.Drawing.Point(347, 20);
            this.button_refreshGimbalPortList.Name = "button_refreshGimbalPortList";
            this.button_refreshGimbalPortList.Size = new System.Drawing.Size(100, 23);
            this.button_refreshGimbalPortList.TabIndex = 1;
            this.button_refreshGimbalPortList.Text = "Refresh List";
            this.button_refreshGimbalPortList.UseVisualStyleBackColor = true;
            this.button_refreshGimbalPortList.Click += new System.EventHandler(this.button_refreshGimbalPortList_Click);
            // 
            // button_openGimbalPort
            // 
            this.button_openGimbalPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_openGimbalPort.Location = new System.Drawing.Point(453, 20);
            this.button_openGimbalPort.Name = "button_openGimbalPort";
            this.button_openGimbalPort.Size = new System.Drawing.Size(100, 23);
            this.button_openGimbalPort.TabIndex = 2;
            this.button_openGimbalPort.Text = "Open Port";
            this.button_openGimbalPort.UseVisualStyleBackColor = true;
            this.button_openGimbalPort.Click += new System.EventHandler(this.button_openGimbalPort_Click);
            // 
            // label_plolluPortName
            // 
            this.label_plolluPortName.AutoSize = true;
            this.label_plolluPortName.Location = new System.Drawing.Point(6, 25);
            this.label_plolluPortName.Name = "label_plolluPortName";
            this.label_plolluPortName.Size = new System.Drawing.Size(58, 13);
            this.label_plolluPortName.TabIndex = 22;
            this.label_plolluPortName.Text = "Port name:";
            // 
            // button_xIMUtare
            // 
            this.button_xIMUtare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_xIMUtare.Location = new System.Drawing.Point(347, 20);
            this.button_xIMUtare.Name = "button_xIMUtare";
            this.button_xIMUtare.Size = new System.Drawing.Size(206, 23);
            this.button_xIMUtare.TabIndex = 3;
            this.button_xIMUtare.Text = "Set Zero Position (x-IMU Tare)";
            this.button_xIMUtare.UseVisualStyleBackColor = true;
            this.button_xIMUtare.Click += new System.EventHandler(this.button_xIMUtare_Click);
            // 
            // groupBox_settings
            // 
            this.groupBox_settings.Controls.Add(this.radioButton_stabiliseMode);
            this.groupBox_settings.Controls.Add(this.radioButton_controlMode);
            this.groupBox_settings.Controls.Add(this.button_xIMUtare);
            this.groupBox_settings.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_settings.Location = new System.Drawing.Point(0, 137);
            this.groupBox_settings.Name = "groupBox_settings";
            this.groupBox_settings.Size = new System.Drawing.Size(559, 56);
            this.groupBox_settings.TabIndex = 4;
            this.groupBox_settings.TabStop = false;
            this.groupBox_settings.Text = "Settings";
            // 
            // radioButton_stabiliseMode
            // 
            this.radioButton_stabiliseMode.AutoSize = true;
            this.radioButton_stabiliseMode.Location = new System.Drawing.Point(188, 23);
            this.radioButton_stabiliseMode.Name = "radioButton_stabiliseMode";
            this.radioButton_stabiliseMode.Size = new System.Drawing.Size(93, 17);
            this.radioButton_stabiliseMode.TabIndex = 5;
            this.radioButton_stabiliseMode.Text = "Stabilise mode";
            this.radioButton_stabiliseMode.UseVisualStyleBackColor = true;
            // 
            // radioButton_controlMode
            // 
            this.radioButton_controlMode.AutoSize = true;
            this.radioButton_controlMode.Checked = true;
            this.radioButton_controlMode.Location = new System.Drawing.Point(37, 23);
            this.radioButton_controlMode.Name = "radioButton_controlMode";
            this.radioButton_controlMode.Size = new System.Drawing.Size(87, 17);
            this.radioButton_controlMode.TabIndex = 4;
            this.radioButton_controlMode.TabStop = true;
            this.radioButton_controlMode.Text = "Control mode";
            this.radioButton_controlMode.UseVisualStyleBackColor = true;
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 197);
            this.Controls.Add(this.groupBox_settings);
            this.Controls.Add(this.groupBox_gimbalPort);
            this.Controls.Add(this.groupBox_xIMUport);
            this.Name = "Form_main";
            this.Text = "x-IMU Camera Control";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox_xIMUport.ResumeLayout(false);
            this.groupBox_xIMUport.PerformLayout();
            this.groupBox_gimbalPort.ResumeLayout(false);
            this.groupBox_gimbalPort.PerformLayout();
            this.groupBox_settings.ResumeLayout(false);
            this.groupBox_settings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_xIMUport;
        private System.Windows.Forms.ComboBox comboBox_xIMUportName;
        private System.Windows.Forms.Button button_refreshXIMUportList;
        private System.Windows.Forms.Button button_openXIMUport;
        private System.Windows.Forms.Label label_xIMUportName;
        private System.Windows.Forms.Label label_quaternionPacketsReceived;
        private System.Windows.Forms.TextBox textBox_QuaternionPacketsReceived;
        private System.Windows.Forms.GroupBox groupBox_gimbalPort;
        private System.Windows.Forms.ComboBox comboBox_gimbalPortName;
        private System.Windows.Forms.Button button_refreshGimbalPortList;
        private System.Windows.Forms.Button button_openGimbalPort;
        private System.Windows.Forms.Label label_plolluPortName;
        private System.Windows.Forms.Button button_xIMUtare;
        private System.Windows.Forms.GroupBox groupBox_settings;
        private System.Windows.Forms.RadioButton radioButton_stabiliseMode;
        private System.Windows.Forms.RadioButton radioButton_controlMode;
    }
}

