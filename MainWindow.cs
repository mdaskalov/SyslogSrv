using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using SyslogSrv.Properties;
using Equin.ApplicationFramework;

namespace SyslogSrv
{
    public partial class MainWindow : Form
    {
        delegate void ReadFileCallback(string fileName);

        Settings settings;
        UdpClient serverUDP = null;
        TcpListener serverTCP = null;
        TcpClient[] client;
        AsyncCallback receiveCallback = null;
        Filter filter;
        BindingList<LogLine> lines;
        AggregateBindingListView<LogLine> view;
        Queue<DataPacket> dataQueue;
        int clients;

        private class TCPPacket
        {
            public TcpClient client;
            public Byte[] buffer;
            public string chunk;

            public TCPPacket(TcpClient cl)
            {
                client = cl;
                buffer = new Byte[256];
                chunk = "";
            }
        }

        private class DataPacket
        {
            public IPAddress ip;
            public string data;

            public DataPacket(IPAddress i, string d)
            {
                ip = i;
                data = d;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            settings = new Settings();
            client = new TcpClient[settings.MaxTCPClients];
            clients = 0;
            startToolStripMenuItem_Click(null, null);
            lines = new BindingList<LogLine>();
            view = new AggregateBindingListView<LogLine>();
            view.SourceLists.Add(lines);
            filter = new Filter(view);
            logLineBindingSource.DataSource = view;
            dataQueue = new Queue<DataPacket>();
        }

        // Thread safe
        private void readFile(string fileName)
        {
            if (lineSetDataGridView.InvokeRequired)
            {
                ReadFileCallback cb = new ReadFileCallback(readFile);
                Invoke(cb, new object[] { fileName });
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                Update();
                view.SourceLists.Remove(lines);
                try
                {
                    lines.Clear();
                    using (StreamReader sr = new StreamReader(fileDialog.FileName))
                    {
                        String line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            lines.Add(new LogLine(line));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Open file: " + ex.Message);
                }
                view.SourceLists.Add(lines);
                Cursor = Cursors.Default;
            }
        }

        private void doAcceptTcpClientCallback(IAsyncResult ar)
        {
            try
            {
                client[clients] = serverTCP.EndAcceptTcpClient(ar);

                waitForData(new TCPPacket(client[clients]));

                toolStripStatusLabel.Text = Convert.ToString(clients + 1) + " TCP connection(s).";
                IPEndPoint ep = (IPEndPoint)client[clients].Client.RemoteEndPoint;
                dataQueue.Enqueue(new DataPacket(null, "Connection " + Convert.ToString(clients + 1) + " from " + ep.Address.ToString()));
                
                if (clients < settings.MaxTCPClients) {
                    clients++;
                    serverTCP.BeginAcceptTcpClient(new AsyncCallback(doAcceptTcpClientCallback), null);
                }
            }
            catch (ObjectDisposedException) { }
            catch (Exception e)
            {
                MessageBox.Show("Accept: "+e.Message);
            }
        }

        private void onReadCallback(IAsyncResult ar)
        {
            try
            {
                TCPPacket packet = (TCPPacket)ar.AsyncState;

                if (packet.client.Connected)
                {
                    int len = packet.client.GetStream().EndRead(ar);
                    IPEndPoint ep = (IPEndPoint)packet.client.Client.RemoteEndPoint;

                    string data = packet.chunk+Encoding.Default.GetString(packet.buffer, 0, len);
                    int pos = data.LastIndexOf('\n');
                    if (pos != -1) {
                        packet.chunk = data.Substring(pos + 1);
                        data = data.Substring(0, pos);
                    }
                    dataQueue.Enqueue(new DataPacket(ep.Address, data));
                    waitForData(packet);
                }
            }
            catch (ObjectDisposedException) { }
            catch (Exception e)
            {
                MessageBox.Show("Read: "+e.Message);
            }
        }

        private void onReceiveCallback(IAsyncResult ar)
        {
            try
            {
                IPEndPoint ep = (IPEndPoint)(ar.AsyncState);
                if (serverUDP == null) return;

                Byte[] receiveBytes = serverUDP.EndReceive(ar, ref ep);
                dataQueue.Enqueue(new DataPacket(ep.Address, Encoding.Default.GetString(receiveBytes, 0, receiveBytes.Length)));
                serverUDP.BeginReceive(new AsyncCallback(onReceiveCallback), ep);
            }
            catch (ObjectDisposedException) { }
            catch (Exception e)
            {
                MessageBox.Show("Receive: " + e.Message);
            }
        }

        private void waitForData(TCPPacket packet)
        {
            try
            {
                if (receiveCallback == null)
                    receiveCallback = new AsyncCallback(onReadCallback);
                if (packet.client.Connected)
                    packet.client.GetStream().BeginRead(packet.buffer, 0, packet.buffer.Length, receiveCallback, packet);
            }
            catch (Exception e)
            {
                MessageBox.Show("wait for data: "+e.Message);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs arg)
        {
            try
            {
                string status="";
                if (settings.TCPPort != 0 || settings.UDPPort != 0)
                {                        
                    updateTimer.Enabled = true;
                    if (settings.TCPPort != 0)
                    {
                        serverTCP = new TcpListener(IPAddress.Any, settings.TCPPort);
                        serverTCP.Start();
                        serverTCP.BeginAcceptTcpClient(new AsyncCallback(doAcceptTcpClientCallback), null);
                        status += " TCP port " + Convert.ToString(settings.TCPPort);
                    }

                    if (settings.UDPPort != 0)
                    {
                        IPEndPoint ep = new IPEndPoint(IPAddress.Any, settings.UDPPort);
                        serverUDP = new UdpClient(ep);
                        serverUDP.BeginReceive(new AsyncCallback(onReceiveCallback), ep);
                        status += " UDP port " + Convert.ToString(settings.UDPPort);
                    }

                    startToolStripMenuItem.Enabled = false;
                    startTaskBarMenuItem.Enabled = false;
                    stopToolStripMenuItem.Enabled = true;
                    stopTaskBarMenuItem.Enabled = true;
                    toolStripStatusLabel.Text = "Listening to" + status + ".";
                }
                else
                {
                    toolStripStatusLabel.Text = "No defined ports to listen.";
                }
                Update();
            }
            catch (Exception e)
            {
                MessageBox.Show("start: "+e.Message);
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs arg)
        {
            try
            {
                if (serverTCP != null)
                {
                    serverTCP.Stop();
                    serverTCP = null;
                }
                if (serverUDP != null)
                {
                    serverUDP.Close();
                    serverUDP = null;
                }
                for(int i=0;i<clients;i++)
                {
                    if (client[i] != null) 
                    {
                        if (client[i].Connected)
                            client[i].GetStream().Close();
                        client[i] = null;
                    }
                }
                clients = 0;
                startToolStripMenuItem.Enabled = true;
                startTaskBarMenuItem.Enabled = true;
                stopToolStripMenuItem.Enabled = false;
                stopTaskBarMenuItem.Enabled = false;
                updateTimer.Enabled = false;
                toolStripStatusLabel.Text = "Stoped.";
                Update();
            }
            catch (Exception e)
            {
                MessageBox.Show("stop: "+e.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taskbarIcon.Visible = false;
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void viewMenuItem_Click(object sender, EventArgs e)
        {
            ipColumn.Visible = ipToolStripMenuItem.Checked;
            facilityColumn.Visible = facilityToolStripMenuItem.Checked;
            severityColumn.Visible = severityToolStripMenuItem.Checked;
            dateColumn.Visible = dateToolStripMenuItem.Checked;
            hostColumn.Visible = hostToolStripMenuItem.Checked;
            programColumn.Visible = programToolStripMenuItem.Checked;
            pidColumn.Visible = pidToolStripMenuItem.Checked;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lines.Clear();
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration config = new Configuration();
            config.ShowDialog();
            settings.Reload();
        }

        private void mainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = false;
                taskbarIcon.Visible = true;
            } 
        }

        private void restoreTaskBarMenuItem_Click(object sender, EventArgs e)
        {
            taskbarIcon_MouseDoubleClick(null, null);
        }

        private void taskbarIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            taskbarIcon.Visible = false;
            ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
            if (!lockToolStripMenuItem.Checked && lineSetDataGridView.RowCount > 0)
                lineSetDataGridView.FirstDisplayedScrollingRowIndex = lineSetDataGridView.RowCount - lineSetDataGridView.DisplayedRowCount(false);
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filter.ShowDialog();
            //DataGridViewCellStyle style =  lineSetDataGridView.Rows[0].Cells["messageColumn"].Style;
            //style.BackColor = Color.Red;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileDialog.ShowDialog();
        }

        private void fileDialog_FileOk(object sender, CancelEventArgs e)
        {
            readFile(fileDialog.FileName);
            toolStripStatusLabel.Text = "File loaded.";
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            if (dataQueue.Count > 0)
            {
                lines.RaiseListChangedEvents = false;
                while (dataQueue.Count > 0)
                {
                    DataPacket p = dataQueue.Dequeue();
                    int len;

                    while ((len = p.data.IndexOf('\n')) != -1)
                    {
                        lines.Add(new LogLine(p.ip, p.data.Substring(0, len)));
                        p.data = p.data.Substring(len + 1);
                    }
                    lines.Add(new LogLine(p.ip, p.data));
                }
                lines.RaiseListChangedEvents = true;
                lines.ResetBindings();
                if (!lockToolStripMenuItem.Checked && lineSetDataGridView.RowCount > 0)
                    lineSetDataGridView.FirstDisplayedScrollingRowIndex = lineSetDataGridView.RowCount - lineSetDataGridView.DisplayedRowCount(false);
            }
        }
    }
}