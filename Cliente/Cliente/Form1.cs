using Model;
using Newtonsoft.Json;
using System;
using System.Collections;
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
        Hashtable emotions;
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
            lstDatos.SelectionColor = contactos;
            lstDatos.SelectedText = $"{Environment.NewLine}{ s.nick}:{Environment.NewLine}{s.mensaje}";
        }


        private void BtnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowHelp = true;
            if (colorDialog.ShowDialog() == DialogResult.OK)
                usuarios.color = (colorDialog.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
        }

        void Emotions()
        {
            emotions = new Hashtable(6);
            emotions.Add(":)", Cliente.Properties.Resources._1f60a);
            emotions.Add(":P", Cliente.Properties.Resources._1f60b);
            emotions.Add("u_u", Cliente.Properties.Resources._1f60c);
            emotions.Add("love", Cliente.Properties.Resources._1f60d);
            emotions.Add("cool", Cliente.Properties.Resources._1f60e);
            emotions.Add("kiss", Cliente.Properties.Resources._1f61a);
            emotions.Add(";)", Cliente.Properties.Resources._1f60f);
            emotions.Add(";P", Cliente.Properties.Resources._1f61c);
            emotions.Add("XP", Cliente.Properties.Resources._1f61d);
            emotions.Add(":(", Cliente.Properties.Resources._1f61e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Emotions();
        }

        private void LstDatos_TextChanged(object sender, EventArgs e)
        {
            AddEmotions();
        }
        private void AddEmotions()
        {
            foreach (string emote in emotions.Keys)
            {
                while (lstDatos.Text.Contains(emote))
                {
                    int ind = lstDatos.Text.IndexOf(emote);
                    lstDatos.Select(ind, emote.Length);
                    Clipboard.SetImage((Image)emotions[emote]);
                    lstDatos.Paste();
                }
            }
        }


    }
}
