using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace x_IMU_Camera_Control
{
    public partial class Form_main : Form
    {
        /// <summary>
        /// x-IMU serial object used to commutate to the x-IMU via USB or Bluetooth.
        /// </summary>
        private x_IMU_API.xIMUserial xIMUserial;

        /// <summary>
        /// GimbalSerial object to control gimbal via Pololu servo controller
        /// </summary>
        private GimbalSerial gimbalSerial;

        /// <summary>
        /// For update timer used to periodically update form data
        /// </summary>
        private System.Windows.Forms.Timer formUpdateTimer;

        public Form_main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form load event to create objects and set default form values
        /// </summary>
        private void Form_main_Load(object sender, EventArgs e)
        {
            this.Text = Assembly.GetExecutingAssembly().GetName().Name + " " + Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();

            // Create x-IMU and gimbal serial objects
            xIMUserial = new x_IMU_API.xIMUserial();
            xIMUserial.QuaternionDataReceived += new x_IMU_API.xIMUserial.onQuaternionDataReceived(xIMUserial_QuaternionDataReceived);
            gimbalSerial = new GimbalSerial();

            // Get ports names
            refreshXIMUportList();
            refreshPololuPortList();

            // Create and start form update timer
            formUpdateTimer = new System.Windows.Forms.Timer();
            formUpdateTimer.Interval = 50;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            formUpdateTimer.Start();
        }

        /// <summary>
        /// Form close event to close serial ports.
        /// </summary>
        private void Form_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            xIMUserial.Close();
            gimbalSerial.Close();
        }

        /// <summary>
        /// Timer tick event to update packet counter text box
        /// </summary>
        private void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            textBox_QuaternionPacketsReceived.Text = Convert.ToString(xIMUserial.PacketCounter.QuaternionPacketsRead);
        }

        /// <summary>
        /// Button click event to open x-IMU serial port
        /// </summary>
        private void button_openXIMUport_Click(object sender, EventArgs e)
        {
            if (button_openXIMUport.Text == "Open Port")
            {
                try
                {
                    comboBox_xIMUportName.Enabled = false;
                    button_refreshXIMUportList.Enabled = false;
                    button_openXIMUport.Enabled = false;
                    button_openXIMUport.Text = "Opening...";
                    this.Update();
                    xIMUserial.PortName = comboBox_xIMUportName.Text;
                    xIMUserial.Open();
                    button_openXIMUport.Text = "Close Port";
                    button_openXIMUport.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button_openXIMUport.Text = "Open Port";
                    comboBox_xIMUportName.Enabled = true;
                    button_refreshXIMUportList.Enabled = true;
                    button_openXIMUport.Enabled = true;
                }
            }
            else if (button_openXIMUport.Text == "Close Port")
            {
                xIMUserial.Close();
                comboBox_xIMUportName.Enabled = true;
                button_refreshXIMUportList.Enabled = true;
                button_openXIMUport.Text = "Open Port";
            }
        }

        /// <summary>
        /// Button click event to refresh potential x-IMU serial port names
        /// </summary>
        private void button_refreshXIMUlist_Click(object sender, EventArgs e)
        {
            refreshXIMUportList();
        }

        /// <summary>
        /// Adds available port names to the port name ComboBox and selects the last in the list.
        /// </summary>
        private void refreshXIMUportList()
        {
            string[] aviablePorts = x_IMU_API.xIMUserial.GetPortNames();
            comboBox_xIMUportName.Items.Clear();
            for (int i = 0; i < aviablePorts.Length; i++)
            {
                comboBox_xIMUportName.Items.Add(aviablePorts[i]);
            }
            comboBox_xIMUportName.SelectedIndex = comboBox_xIMUportName.Items.Count - 1;
        }

        /// <summary>
        /// Button click event to open gimbal serial port
        /// </summary>
        private void button_openGimbalPort_Click(object sender, EventArgs e)
        {
            if (button_openGimbalPort.Text == "Open Port")
            {
                try
                {
                    comboBox_gimbalPortName.Enabled = false;
                    button_refreshGimbalPortList.Enabled = false;
                    button_openGimbalPort.Enabled = false;
                    button_openGimbalPort.Text = "Opening...";
                    this.Update();
                    gimbalSerial.PortName = comboBox_gimbalPortName.Text;
                    gimbalSerial.Open();
                    button_openGimbalPort.Text = "Close Port";
                    button_openGimbalPort.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button_openGimbalPort.Text = "Open Port";
                    comboBox_gimbalPortName.Enabled = true;
                    button_refreshGimbalPortList.Enabled = true;
                    button_openGimbalPort.Enabled = true;
                }
            }
            else if (button_openGimbalPort.Text == "Close Port")
            {
                gimbalSerial.Close();
                comboBox_gimbalPortName.Enabled = true;
                button_refreshGimbalPortList.Enabled = true;
                button_openGimbalPort.Text = "Open Port";
            }
        }

        /// <summary>
        /// Button click event to refresh potential gimbal serial port names
        /// </summary>
        private void button_refreshGimbalPortList_Click(object sender, EventArgs e)
        {
            refreshPololuPortList();
        }

        /// <summary>
        /// Adds available port names to the port name combo box and selects the last in the list.
        /// </summary>
        private void refreshPololuPortList()
        {
            string[] aviablePorts = System.IO.Ports.SerialPort.GetPortNames();
            comboBox_gimbalPortName.Items.Clear();
            for (int i = 0; i < aviablePorts.Length; i++)
            {
                comboBox_gimbalPortName.Items.Add(aviablePorts[i]);
            }
            comboBox_gimbalPortName.SelectedIndex = comboBox_gimbalPortName.Items.Count - 1;
        }

        /// <summary>
        /// Quaternion data received event to set servo angles of gimbal.
        /// </summary>
        void xIMUserial_QuaternionDataReceived(object sender, x_IMU_API.QuaternionData e)
        {
            x_IMU_API.QuaternionData quaternionData;
            if (radioButton_controlMode.Checked)
            {
                quaternionData = e;
            }
            else
            {
                quaternionData = e.ConvertToConjugate();
            }
            try
            {
                float[] EulerAngles = quaternionData.ConvertToEulerAngles();
                gimbalSerial.SetTilt(EulerAngles[0]);
                gimbalSerial.SetRoll(EulerAngles[1]);
                gimbalSerial.SetPan(EulerAngles[2]);
            }
            catch { }
        }

        /// <summary>
        /// Button click event to send tare command to x-IMU.
        /// </summary>
        private void button_xIMUtare_Click(object sender, EventArgs e)
        {
            if (xIMUserial.IsOpen)
            {
                xIMUserial.SendCommandPacket(x_IMU_API.CommandCodes.AlgorithmTare);
            }
        }
    }
}
