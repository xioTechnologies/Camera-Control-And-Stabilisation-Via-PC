using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace x_IMU_Camera_Control
{
    /// <summary>
    /// GimbalSerial class.
    /// </summary>
    class GimbalSerial
    {
        /// <summary>
        /// Serial port object to compunicate with Pololu Maestro Servo Controller
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// Serial port name of Pololu Maestro Servo Controller
        /// </summary>
        private string portName;

        /// <summary>
        /// Gets or sets the name of the serial port.
        /// </summary>
        /// <value>
        /// Port name string.
        /// </value> 
        public string PortName
        {
            get
            {
                return portName;
            }
            set
            {
                portName = value;
                serialPort.PortName = portName;
            }
        }

        /// <summary>
        /// Gets a value indicating the open or closed status of the serial port.
        /// </summary>
        /// <value>
        /// Open state bool.
        /// </value>  
        public bool IsOpen
        {
            get
            {
                return serialPort.IsOpen;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GimbalSerial"/> class.
        /// </summary>
        public GimbalSerial()
            : this("COM1")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GimbalSerial"/> class.
        /// </summary>
        /// <param name="ComPort">
        /// Port name asigned to the Pololu Maestro Servo Controller (for example, COM1).
        /// </param>
        public GimbalSerial(string portName)
        {
            serialPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
        }

        /// <summary>
        /// Gets an array of serial port names for the current computer. Invalid characters are removed.
        /// </summary>
        public static string[] GetPortNames()
        {
            string[] portNames = SerialPort.GetPortNames();
            for (int i = 0; i < portNames.Length; i++)
            {
                portNames[i] = "COM" + new string(portNames[i].Where(ch => char.IsDigit(ch)).ToArray());
                if (portNames[i].Length > "COMxxx".Length)
                {
                    portNames[i] = portNames[i].Substring(0, "COMxxx".Length);
                }
            }
            return portNames;
        }

        /// <summary>
        /// Opens a new serial port communication.
        /// </summary>
        public void Open()
        {
            serialPort.Open();
        }

        /// <summary>
        /// Closes the port connection.
        /// </summary>
        public void Close()
        {
            serialPort.Close();
        }

        /// <summary>
        /// Sends the gimbal to the home position (all servo angles at 0 degrees).
        /// </summary>
        public void SetHome()
        {
            SetPan(0.0f);
            SetRoll(0.0f);
            SetTilt(0.0f);
        }

        /// <summary>
        /// Sets the pan servo angle in degrees.
        /// </summary>
        /// <param name="angle">
        /// Angle in degrees.
        /// </param>
        public void SetPan(float angle)
        {
            SetServoTarget(0, (uint)(4.0f * (1500.0f + (225.0f / 180.0f) * angle)));    // Gimbal target position in 0.25 us units
        }

        /// <summary>
        /// Sets the roll servo angle in degrees.
        /// </summary>
        /// <param name="angle">
        /// Angle in degrees.
        /// </param>
        public void SetRoll(float angle)
        {
            SetServoTarget(1, (uint)(4.0f * (1500.0f + (225.0f / 180.0f) * angle)));    // Gimbal target position in 0.25 us units
        }

        /// <summary>
        /// Sets the tilt servo angle in degrees.
        /// </summary>
        /// <param name="angle">
        /// Angle in degrees.
        /// </param>
        public void SetTilt(float angle)
        {
            SetServoTarget(2, (uint)(4.0f * (1555.0f + (-925.0f / 90.0f) * angle)));    // Gimbal target position in 0.25 us units (note 1555 us centre point account for mechanical bias)
        }

        /// <summary>
        /// Sets the servo target position in 0.25 us units.
        /// </summary>
        /// <param name="servo">
        /// Servo channel.
        /// </param>
        /// <param name="target">
        /// Servo target position in 0.25 us units.
        /// </param>
        private void SetServoTarget(byte servo, uint target)
        {
            byte[] data = { 132, servo, 0, 0 };                 // packet = 0x84, <servo 0-6>, <target lower 7-bits>, <target upper 7-bits>
            data[2] = (byte)((byte)127 & (byte)target);         // split upper and lwoer 7-bits of data and clear MSBs
            data[3] = (byte)((byte)127 & (byte)(target >> 7));
            try
            {
                serialPort.Write(data, 0, data.Length);
            }
            catch { }
        }
    }
}
