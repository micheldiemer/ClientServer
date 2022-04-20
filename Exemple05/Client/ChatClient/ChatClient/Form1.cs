using System.Net.Sockets;
using System.Net;
using Commun;


namespace ChatClient
{
    public partial class Fm_client : Form
    {
        public Fm_client()
        {
            InitializeComponent();
            adrIpLocale = UtilIP.GetAdrIpLocaleV4();
        }

        private readonly IPAddress adrIpLocale;
        
        

        private void Bt_envoyer_Click(object sender, EventArgs e)
        {
            byte[] messageBytes; ;
            
            // Création du socket
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint epEmetteur = new IPEndPoint(adrIpLocale, 0);
            sock.Bind(epEmetteur);
            UInt16 portNum = UtilIP.DEFAULT_PORT;
            IPEndPoint epRecepteur = new IPEndPoint(IPAddress.Parse(tb_ipDestinataire.Text), portNum);

            // Encodage du message en binaire
            MessageReseau leMessage = new MessageReseau(adrIpLocale, tb_message.Text);
            messageBytes = leMessage.GetInfos();
            sock.SendTo(messageBytes, epRecepteur);
            sock.Close();
        }

    }
}