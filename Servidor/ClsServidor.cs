using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Servidor
{
    public class ClsServidor
    {
        private struct Connection
        {
            public NetworkStream stream;
            public StreamWriter streamw;
            public StreamReader streamr;
            public Clientes clientes;
        }

        private TcpListener server = null;
        private readonly IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 8000);
        private TcpClient client = new TcpClient();
        private List<Connection> list = new List<Connection>();
        private Connection conn;

        public ClsServidor()
        {
            Inicio();
        }


        private void Inicio()
        {
            Console.WriteLine("Servidor OK!");
            server = new TcpListener(ipEndPoint);
            server.Start();
            while (true)
            {
                try
                {
                    client = server.AcceptTcpClient();
                    conn = new Connection
                    {
                        stream = client.GetStream()
                    };
                    conn.streamr = new StreamReader(conn.stream);
                    conn.streamw = new StreamWriter(conn.stream);
                    Clientes clientes = JsonConvert.DeserializeObject<Clientes>(conn.streamr.ReadLine());
                    conn.clientes = clientes;
                    list.Add(conn);
                    Console.WriteLine($"{conn.clientes.nick} se ha conectado");
                    Thread t = new Thread(Escuchar_Conexion);
                    t.Start();
                }
                catch (Exception e)
                {
                    Console.Write($"{e.Message}");
                }
            }
        }

        private void Escuchar_Conexion(object obj)
        {
            Connection hcon = conn;
            do
            {
                try
                {
                    string tmp = hcon.streamr.ReadLine();                    
                    foreach (Connection c in list)
                    {
                        try
                        {
                            c.streamw.WriteLine(tmp);
                            c.streamw.Flush();
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
                catch (Exception)
                {
                    list.Remove(hcon);
                    Console.WriteLine($"{conn.clientes.nick} se ha desconectado");
                    break;
                }
            } while (true);
        }

    }

}
