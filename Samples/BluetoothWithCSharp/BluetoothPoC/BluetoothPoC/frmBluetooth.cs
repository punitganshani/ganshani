using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using InTheHand.Net;
using System.Threading;

namespace BluetoothPoC
{
    public partial class frmBluetooth : Form
    {
        InTheHand.Net.BluetoothAddress[] address_array = new BluetoothAddress[1000];
        private Thread thrSend;
        int Selected;
        OpenFileDialog diaglog;

        public frmBluetooth()
        {
            InitializeComponent();

        }

        private void btnDiscover_Click(object sender, EventArgs e)
        {
            InTheHand.Net.Sockets.BluetoothClient bc = new InTheHand.Net.Sockets.BluetoothClient();
            InTheHand.Net.Sockets.BluetoothDeviceInfo[] array = bc.DiscoverDevices();
            for (int i = 0; i < array.Length; i++)
            {
                this.address_array[i] = array[i].DeviceAddress;
                this.lstDevices.Items.Add(array[i].DeviceName);
            }

        }

        private void btnGetMAC_Click(object sender, EventArgs e)
        {
            if (this.lstDevices.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a device.");
                return;
            }

            int index = this.lstDevices.SelectedIndex;
            string mac = this.address_array[index].ToString();
            string nap = this.address_array[index].Nap.ToString();
            string sap = this.address_array[index].Sap.ToString();
            MessageBox.Show(mac + " " + nap + " " + sap);
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (this.lstDevices.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a device.");
                return;
            }
            Selected = this.lstDevices.SelectedIndex;

            diaglog = new OpenFileDialog();
            diaglog.ShowDialog();
            this.thrSend = new Thread(new ThreadStart(sendfile));
            this.thrSend.Start();

        }

        private void sendfile()
        {
            int index = Selected;
            InTheHand.Net.BluetoothAddress address = this.address_array[index];

            string [] filename = diaglog.FileName.Split('\\');
            System.Uri uri = new Uri("obex://" + address.ToString() + "/" + filename[filename.Length -1]);
            ObexWebRequest request = new ObexWebRequest(uri);
            if (diaglog.FileName.Trim().Length > 0)
            {
                request.ReadFile(diaglog.FileName);
                ObexWebResponse response = (ObexWebResponse)request.GetResponse();
                response.Close();
                if (response.StatusCode.ToString().Trim() == "Success, Final")
                {
                    MessageBox.Show("File Sent");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InTheHand.Net.Sockets.BluetoothClient bc = new InTheHand.Net.Sockets.BluetoothClient();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}
