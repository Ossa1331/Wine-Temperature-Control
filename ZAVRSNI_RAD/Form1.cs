using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using System.IO.Ports;
using System.Threading;
using System.Linq;

namespace ZAVRSNI_RAD
{
    public partial class Form1 : Form
    {
        String[] ports;
        SerialPort port;
        string Line_Sub = "9999";
        bool isConnected = false;
        private SerialDataReceivedEventHandler port_DataReceived;
        public Form1()
        {
            InitializeComponent();
            getAvailableComPorts();



            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }
        }

        private void Port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            string line = port.ReadLine();
            this.BeginInvoke(new LineReceivedEvent(LineReceived), line);

        }
        private delegate void LineReceivedEvent(string line);
        public void LineReceived(string line)
        {


            if (line != Line_Sub)
            {
                if (line[0] == '1')
                {
                    textBox1.Text = line.Substring(2) + ((char)176) + "C";
                }
                else if (line[0] == '2')
                {
                    textBox2.Text = line.Substring(2) + ((char)176) + "C";
                }
                else if (line[0] == '3')
                {
                    textBox3.Text = line.Substring(2) + ((char)176) + "C";
                }
                else if (line[0] == '4')
                {
                    textBox4.Text = line.Substring(2) + ((char)176) + "C";
                }
                else if (line[0] == '5')
                {
                    textBox5.Text = line.Substring(2) + ((char)176) + "C";
                }
                else
                {

                }


            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IRELEJ1.Enabled = false;
            IRELEJ2.Enabled = false;
            IRELEJ3.Enabled = false;
            IRELEJ4.Enabled = false;
            IRELEJ5.Enabled = false;
            IRELEJ6.Enabled = false;

            textBox1.Text = "Disconnected";
            textBox2.Text = "Disconnected";
            textBox3.Text = "Disconnected";
            textBox4.Text = "Disconnected";
            textBox5.Text = "Disconnected";

            AUTOCONTROL_OFF.Enabled = false;

            UREDI.Hide();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                try
                {
                    for (int i = 0; i <= 100; i++)
                    {
                        progressBar1.Value = i;
                    }

                }
                catch
                {

                }
                connectToArduino();
                button2.BringToFront();
            }
            else
            {
                try
                {

                    for (int i = 100; i >= 0; i--)
                    {
                        progressBar1.Value = i;
                    }
                }
                catch
                {

                }
                disconnectFromArduino();
            }

        }

        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        private void connectToArduino()
        {
            isConnected = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port.DataReceived += Port_DataReceived;
        }

        private void disconnectFromArduino()
        {
            IRELEJ1.PerformClick();
            IRELEJ2.PerformClick();

            isConnected = false;
            port.Close();
            textBox1.Text = "Disconnected";
            textBox2.Text = "Disconnected";
            textBox3.Text = "Disconnected";
            textBox4.Text = "Disconnected";
            textBox5.Text = "Disconnected";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            disconnectFromArduino();
            button1.BringToFront();

            try
            {

                for (int i = 100; i >= 0; i--)
                {
                    progressBar1.Value = i;
                }
            }
            catch
            {

            }

        }


        private void URELEJ1_Click(object sender, EventArgs e)
        {
            port.Write("a");
            URELEJ1.Enabled = false;
            IRELEJ1.Enabled = true;
            UPALI1();

        }

        private void IRELEJ1_Click(object sender, EventArgs e)
        {
            port.Write("b");
            URELEJ1.Enabled = true;
            IRELEJ1.Enabled = false;
            UGASI_6();

        }

        private void URELEJ2_Click(object sender, EventArgs e)
        {
            port.Write("c");
            URELEJ2.Enabled = false;
            IRELEJ2.Enabled = true;
            UPALI2();
        }

        private void IRELEJ2_Click(object sender, EventArgs e)
        {
            port.Write("d");
            URELEJ2.Enabled = true;
            IRELEJ2.Enabled = false;
            UGASI_6();
        }

        private void URELEJ3_Click(object sender, EventArgs e)
        {
            port.WriteLine("e");
            URELEJ3.Enabled = false;
            IRELEJ3.Enabled = true;
            UPALI3();
        }

        private void IRELEJ3_Click(object sender, EventArgs e)
        {
            port.WriteLine("f");
            URELEJ3.Enabled = true;
            IRELEJ3.Enabled = false;
            UGASI_6();
        }

        private void URELEJ4_Click(object sender, EventArgs e)
        {
            port.WriteLine("g");
            URELEJ4.Enabled = false;
            IRELEJ4.Enabled = true;
            UPALI4();
        }

        private void IRELEJ4_Click(object sender, EventArgs e)
        {
            port.WriteLine("h");
            URELEJ4.Enabled = true;
            IRELEJ4.Enabled = false;
            UGASI_6();
        }

        private void URELEJ5_Click(object sender, EventArgs e)
        {
            port.WriteLine("i");
            URELEJ5.Enabled = false;
            IRELEJ5.Enabled = true;
            UPALI5();
        }

        private void IRELEJ5_Click(object sender, EventArgs e)
        {
            port.WriteLine("j");
            URELEJ5.Enabled = true;
            IRELEJ5.Enabled = false;
            UGASI_6();
        }

        private void URELEJ6_Click(object sender, EventArgs e)
        {
            port.WriteLine("k");
            URELEJ6.Enabled = false;
            IRELEJ6.Enabled = true;
        }

        private void IRELEJ6_Click(object sender, EventArgs e)
        {
            port.WriteLine("l");
            URELEJ6.Enabled = true;
            IRELEJ6.Enabled = false;
        }

        private void UKLJUCISVE_Click(object sender, EventArgs e)
        {
            URELEJ1.PerformClick();
            URELEJ2.PerformClick();
            URELEJ3.PerformClick();
            URELEJ4.PerformClick();
            URELEJ5.PerformClick();
            URELEJ6.PerformClick();
            ISKLJUCISVE.BringToFront();
        }

        private void ISKLJUCISVE_Click(object sender, EventArgs e)
        {
            IRELEJ1.PerformClick();
            IRELEJ2.PerformClick();
            IRELEJ3.PerformClick();
            IRELEJ4.PerformClick();
            IRELEJ5.PerformClick();
            IRELEJ6.PerformClick();
            UKLJUCISVE.BringToFront();
        }

        public float MaxTemp1;
        public float MaxTemp2;
        public float MaxTemp3;
        public float MaxTemp4;
        public float MaxTemp5;
        public bool AUTOCONTROL_ON_state = true;

        public void button3_Click(object sender, EventArgs e)
        {

            CLEAR.Enabled = false;

            if (MAX1.Text.Trim() == "")
            {
                throw new Exception("Ne moze biti prazno");
            }
            else
            {
                MaxTemp1 = float.Parse(MAX1.Text);
            }

            if (MAX2.Text.Trim() == "")
            {
                throw new Exception("Ne moze biti prazno");
            }
            else
            {
                MaxTemp2 = float.Parse(MAX1.Text);
            }

            if (MAX3.Text.Trim() == "")
            {
                throw new Exception("Ne moze biti prazno");
            }
            else
            {
                MaxTemp3 = float.Parse(MAX1.Text);
            }

            if (MAX4.Text.Trim() == "")
            {
                throw new Exception("Ne moze biti prazno");
            }
            else
            {
                MaxTemp4 = float.Parse(MAX1.Text);
            }

            if (MAX5.Text.Trim() == "")
            {
                throw new Exception("Ne moze biti prazno");
            }
            else
            {
                MaxTemp5 = float.Parse(MAX1.Text);
            }

            MAX1.ReadOnly = true;
            MAX2.ReadOnly = true;
            MAX3.ReadOnly = true;
            MAX4.ReadOnly = true;
            MAX5.ReadOnly = true;

            button3.Hide();
            UREDI.Show();
        }

        private void UREDI_Click(object sender, EventArgs e)
        {
            MAX1.ReadOnly = false;
            MAX2.ReadOnly = false;
            MAX3.ReadOnly = false;
            MAX4.ReadOnly = false;
            MAX5.ReadOnly = false;

            button3.Show();
            UREDI.Hide();

            CLEAR.Enabled = true;
        }

        public bool autoIsconnected = false;

        public void AUTOCONTROL_OFF_Click(object sender, EventArgs e)
        {
            AUTOCONTROL_ON.Enabled = true;
            AUTOCONTROL_ON.BringToFront();
            AUTOCONTROL_OFF.Enabled = false;
        }
        public void AUTOCONTROL_ON_Click(object sender, EventArgs e)
        {
            AUTOCONTROL_OFF.BringToFront();
            AUTOCONTROL_ON.Enabled = false;
            AUTOCONTROL_OFF.Enabled = true;
        } 

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox6.Text != "")
            {
                 MAX1.Text = textBox6.Text;
                 MAX2.Text = textBox6.Text;
                 MAX3.Text = textBox6.Text;
                 MAX4.Text = textBox6.Text;
                 MAX5.Text = textBox6.Text;
            }
            else
            {

            }

            textBox6.Clear();
            
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

            if(AUTOCONTROL_OFF.Enabled == true && isConnected == true)
            {
                if (float.Parse(textBox1.Text.Substring(0, 2)) > MaxTemp1)
                {
                    URELEJ1.PerformClick();
                }

                if (URELEJ1.Enabled == false)
                {
                    if (float.Parse(textBox1.Text.Substring(0, 2)) < MaxTemp1)
                    {
                        IRELEJ1.PerformClick();
                    }
                }
                else { }
            }
            else
            {

            }

         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (AUTOCONTROL_OFF.Enabled == true && isConnected == true)
            {
                if (float.Parse(textBox2.Text.Substring(0, 2)) > MaxTemp2)
                {
                    URELEJ2.PerformClick();
                }

                if (URELEJ2.Enabled == false)
                {
                    if (float.Parse(textBox2.Text.Substring(0, 2)) < MaxTemp2)
                    {
                        IRELEJ2.PerformClick();
                    }
                }
                else { }
            }
            else
            {

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (AUTOCONTROL_OFF.Enabled == true && isConnected == true)
            {
                if (float.Parse(textBox3.Text.Substring(0, 2)) > MaxTemp3)
                {
                    URELEJ3.PerformClick();
                }

                if (URELEJ3.Enabled == false)
                {
                    if (float.Parse(textBox3.Text.Substring(0, 2)) < MaxTemp3)
                    {
                        IRELEJ3.PerformClick();
                    }
                }
                else { }
            }
            else
            {

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (AUTOCONTROL_OFF.Enabled == true && isConnected == true)
            {
                if (float.Parse(textBox4.Text.Substring(0, 2)) > MaxTemp4)
                {
                    URELEJ4.PerformClick();
                }

                if (URELEJ4.Enabled == false)
                {
                    if (float.Parse(textBox4.Text.Substring(0, 2)) < MaxTemp4)
                    {
                        IRELEJ4.PerformClick();
                    }
                }
                else { }
            }
            else
            {

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (AUTOCONTROL_OFF.Enabled == true && isConnected == true)
            {
                if (float.Parse(textBox5.Text.Substring(0, 2)) > MaxTemp5)
                {
                    URELEJ5.PerformClick();
                }

                if (URELEJ5.Enabled == false)
                {
                    if (float.Parse(textBox5.Text.Substring(0, 2)) < MaxTemp5)
                    {
                        IRELEJ5.PerformClick();
                    }
                }
                else { }
            }
            else
            {

            }
        }

        private void CLEAR_Click(object sender, EventArgs e)
        {

            if (CLEAR.Enabled == true)
            {
                MAX1.Clear();
                MAX2.Clear();
                MAX3.Clear();
                MAX4.Clear();
                MAX5.Clear();
            }
            else
            {
                throw new Exception("GRESKA");
            }
        }
            
            public void UPALI()
            {
                if (URELEJ1.Enabled == true || URELEJ2.Enabled == true || URELEJ3.Enabled == true || URELEJ4.Enabled == true || URELEJ5.Enabled == true)
                {
                    URELEJ6.PerformClick();
            }
            else
            {

            }

            }


        public void UPALI1()
        {
            if (URELEJ1.Enabled == false && URELEJ6.Enabled == true)
            {
                URELEJ6.PerformClick();
            }
            else
            {
                
            }

        }


        public void UPALI2()
        {
            if (URELEJ2.Enabled == false && URELEJ6.Enabled == false)
            {

            }
            else
            {
                URELEJ6.PerformClick();
            }

        }

        public void UPALI3()
        {
            if (URELEJ3.Enabled == false && URELEJ6.Enabled == false)
            {

            }
            else
            {
                URELEJ6.PerformClick();
            }

        }

        public void UPALI4()
        {
            if (URELEJ4.Enabled == false && URELEJ6.Enabled == false)
            {

            }
            else
            {
                URELEJ6.PerformClick();
            }

        }

        public void UPALI5()
        {
            if (URELEJ5.Enabled == false && URELEJ6.Enabled == false)
            {

            }
            else
            {
                URELEJ6.PerformClick();
            }

        }

        public void UGASI_6()
        {
            if (URELEJ1.Enabled == true && URELEJ2.Enabled == true && URELEJ3.Enabled == true && URELEJ4.Enabled == true && URELEJ5.Enabled == true)
            {
                IRELEJ6.PerformClick();
            }
        }

    }
}
