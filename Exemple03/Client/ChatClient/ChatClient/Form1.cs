using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ChatClient
{
    public partial class Fm_client : Form
    {
        public Fm_client()
        {
            InitializeComponent();
            adrIpLocale = getAdrIpLocaleV4();
        }

        private IPAddress adrIpLocale;
        private UInt16 portNum = 33000;
        private IPAddress getAdrIpLocaleV4()
        {
            string hote = Dns.GetHostName();
            IPHostEntry ipLocales = Dns.GetHostEntry(hote);
            foreach (IPAddress ip in ipLocales.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            return null; // aucune adresse IP V4
        }

        private void bt_envoyer_Click(object sender, EventArgs e)
        {
            byte[] message;
            
            // Cr�ation du socket
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint epEmetteur = new IPEndPoint(adrIpLocale, 0);
            sock.Bind(epEmetteur);
            IPEndPoint epRecepteur = new IPEndPoint(IPAddress.Parse(tb_ipDestinataire.Text), portNum);
            
            // Encodage du message en binaire
            message = Encoding.Unicode.GetBytes(tb_message.Text);
            
            // Envoi du message
            sock.SendTo(message, epRecepteur);
            sock.Close();
        }

    }
}