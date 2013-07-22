using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace x_IMU_Camera_Control_via_PC
{
    public partial class Form_main : Form
    {
        #region Variables

        /// <summary>
        /// x-IMU serial object used to commutate to the x-IMU via USB or Bluetooth.
        /// </summary>
        private xIMU_API.xIMUserial xIMUserial;

        /// <summary>
        /// GimbalSerial object to control gimbal via Pololu servo controller
        /// </summary>
        private GimbalSerial gimbalSerial;

        /// <summary>
        /// For update timer used to periodically update form data
        /// </summary>
        private System.Windows.Forms.Timer formUpdateTimer;

        #endregion

        public Form_main()
        {
            InitializeComponent();
        }

        #region Form load/close and form update timer

        /// <summary>
        /// Form load event to create objects and set default form values
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            #region Create x-IMU and gimbal serial objects

            xIMUserial = new xIMU_API.xIMUserial();
            xIMUserial.QuaternionDataReceived += new xIMU_API.xIMUserial.onQuaternionDataReceived(xIMUserial_QuaternionDataReceived);

            gimbalSerial = new GimbalSerial();

            #endregion

            #region Set default form control values

            refreshXIMUportList();
            refreshPololuPortList();

            #endregion

            #region Create and start form update timer

            formUpdateTimer = new System.Windows.Forms.Timer();
            formUpdateTimer.Interval = 50;
            formUpdateTimer.Tick += new EventHandler(formUpdateTimer_Tick);
            formUpdateTimer.Start();

            #endregion
        }

        /// <summary>
        /// Form close event to close serial ports.
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            xIMUserial.Close();
            gimbalSerial.Close();
        }

        /// <summary>
        /// Timer tick event to update packet counter text box
        /// </summary>
        private void formUpdateTimer_Tick(object sender, EventArgs e)
        {
            textBox_QuaternionPacketsReceived.Text = Convert.ToString(xIMUserial.PacketCounter.QuaternionDataPacketsReceived);
        }

        #endregion

        #region x-IMU Port

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
                    MessageBox.Show(ex.Message, "Error");
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
        /// ...
        /// </summary>
        private void button_refreshXIMUlist_Click(object sender, EventArgs e)
        {
            refreshXIMUportList();
        }

        /// <summary>
        /// Adds available port names to the port name combo box and selects the last in the list.
        /// </summary>
        private void refreshXIMUportList()
        {
            string[] aviablePorts = xIMU_API.xIMUserial.GetPortNames();
            comboBox_xIMUportName.Items.Clear();
            for (int i = 0; i < aviablePorts.Length; i++)
            {
                comboBox_xIMUportName.Items.Add(aviablePorts[i]);
            }
            comboBox_xIMUportName.SelectedIndex = comboBox_xIMUportName.Items.Count - 1;
        }

        #endregion

        #region Gimbal Port

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
                    MessageBox.Show(ex.Message, "Error");
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

        #endregion

        #region x-IMU data received event and send command

        /// <summary>
        /// Quaternion data received event to set servo angles of gimbal.
        /// </summary>
        void xIMUserial_QuaternionDataReceived(object sender, xIMU_API.QuaternionData e)
        {
            xIMU_API.QuaternionData quat;
            if (radioButton_controlMode.Checked)
            {
                quat = e;
            }
            else
            {
                quat = e.ConvertToConjugate();
            }
            try
            {
                float[] EulerAngles = quat.ConvertToEulerAngles();
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
                xIMUserial.SendCommandPacket(xIMU_API.CommandCodes.Tare);
            }
        }

        #endregion
    }
}
