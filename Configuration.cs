using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SyslogSrv.Properties;

namespace SyslogSrv
{
    public partial class Configuration : Form
    {
        Settings settings;

        public Configuration()
        {
            InitializeComponent();
            settings = new Settings();
            scrollBackLines.Text = Convert.ToString(settings.ScrollbackLines);
            maxTcpClients.Text = Convert.ToString(settings.MaxTCPClients);
            tcpPort.Text = settings.TCPPort == 0 ? "1468" : Convert.ToString(settings.TCPPort);
            tcpPort.Enabled = (settings.TCPPort != 0);
            enableTCP.Checked = (settings.TCPPort != 0);
            udpPort.Text = settings.UDPPort == 0 ? "514" : Convert.ToString(settings.UDPPort);
            udpPort.Enabled = (settings.UDPPort != 0);
            enableUDP.Checked = (settings.UDPPort != 0);
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            settings.ScrollbackLines = Convert.ToUInt32(scrollBackLines.Text);
            settings.MaxTCPClients = Convert.ToUInt16(maxTcpClients.Text);
            settings.TCPPort = Convert.ToInt16(tcpPort.Enabled ? tcpPort.Text : "0");
            settings.UDPPort = Convert.ToInt16(udpPort.Enabled ? udpPort.Text : "0");
            settings.Save();
            Close();
        }

        private void enableTCP_CheckedChanged(object sender, EventArgs e)
        {
            if (enableTCP.Checked)
                tcpPort.Enabled = true;
            else
            {
                tcpPort.Text = "1468";
                tcpPort.Enabled = false;
            }
        }

        private void enableUDP_CheckedChanged(object sender, EventArgs e)
        {
            if (enableUDP.Checked)
                udpPort.Enabled = true;
            else
            {
                udpPort.Text = "514";
                udpPort.Enabled = false;
            }
        }
    }
}