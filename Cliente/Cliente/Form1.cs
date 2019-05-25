using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Cliente
{
    public partial class Form1 : Form
    {
        Color contactos;
        static private NetworkStream stream;
        static private StreamWriter streamw;
        static private StreamReader streamr;
        static private TcpClient client = new TcpClient();
        static private Clientes usuarios = new Clientes();
        private delegate void DAddItem(Clientes s);
        private string ip;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConecta_Click(object sender, EventArgs e)
        {            
            btnConecta.Visible = false;
            btnEnvia.Visible = true;
            lblUsuario.Text = txtInformacion.Text;
            usuarios.nick = txtInformacion.Text;
            ip = txtIP.Text;
            Conecta(ip);
        }

        private void btnEnvia_Click(object sender, EventArgs e)
        {
            usuarios.mensaje = txtInformacion.Text;
            Write();
            txtInformacion.Clear();
        }

        public void Conecta(string ip)
        {
            try
            {
                client.Connect(ip, 8000);
                if (client.Connected)
                {
                    Thread t = new Thread(Listen);
                    stream = client.GetStream();
                    streamw = new StreamWriter(stream);
                    streamr = new StreamReader(stream);
                    streamw.WriteLine(JsonConvert.SerializeObject(usuarios));
                    streamw.Flush();
                    t.Start();
                }
                else
                {
                    MessageBox.Show("Servidor no disponible");
                    Application.Exit();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Servidor no disponible {e.Message}");
                Application.Exit();
            }
        }
        public void Write()
        {
            string mensaje = JsonConvert.SerializeObject(usuarios);
            streamw.WriteLine(mensaje);
            streamw.Flush();
        }
        private void Listen()
        {
            while (client.Connected)
            {
                try
                {
                    var json = streamr.ReadLine();
                    if (!String.IsNullOrEmpty(json))
                    {
                        Clientes clientes = JsonConvert.DeserializeObject<Clientes>(json);
                        Form1.ActiveForm.Invoke(new DAddItem(AddItem), clientes);
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    Application.Exit();
                }
            }
        }

        private void AddItem(Clientes s)
        {

            contactos = System.Drawing.ColorTranslator.FromHtml($"#{s.color}");
            lstDatos.ForeColor = contactos;
            lstDatos.Items.Add($"{s.nick}:{s.mensaje}");

        }


        private void BtnColor_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                usuarios.color = (MyDialog.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
        }
    }
}
