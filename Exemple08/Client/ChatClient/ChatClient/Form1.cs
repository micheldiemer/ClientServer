using System.Net.Sockets;
using System.Net;
using Commun;


namespace ChatClient
{
    public partial class Fm_client : Form
    {

        // la méthonde Invoke prend en paramètre une méthode de type AddItemDelegate
        private delegate void AddItemDelegate(MessageChat leMessage);
        private AddItemDelegate m_newMessage;
        // dans la méthode init m_newMessage = new AddItemDelegate(this.AddItemToList);
        // dans la méthode recevoir lb_messages.Invoke(m_newMessage, new string[] { strMessage });
        void AddItemToList(MessageChat leMessage)
        {
            string element = leMessage.IpEmetteur.ToString()
                                + " -> " + leMessage.Texte;
            lb_messages.Items.Add(element);


        }

        public Fm_client()
        {
            InitializeComponent();
            adrIpLocale = UtilIP.GetAdrIpLocaleV4();
            ipServeur = adrIpLocale;
            m_newMessage = new AddItemDelegate(this.AddItemToList);
        }

        private readonly IPAddress adrIpLocale;
        private readonly IPAddress ipServeur;
        private static int portServeur = UtilIP.DEFAULT_PORT_SERVER;
        private static int portClient = UtilIP.DEFAULT_PORT_CLIENT;
        private static int lgMessage = 1000;
        private Socket sockReception;
        private IPEndPoint epRecepteur;
        byte[] messageBytes;

        private void Envoyer(MessageChat leMessage)
        {
            byte[] messageBytes;
            Socket sock = new Socket(AddressFamily.InterNetwork,
            SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint epEmetteur = new IPEndPoint(adrIpLocale, 0);
            sock.Bind(epEmetteur);
            IPEndPoint epRecepteur = new IPEndPoint(ipServeur, portServeur);
            messageBytes = MessageChat.Serialiser(leMessage);
            sock.SendTo(messageBytes, epRecepteur);
            sock.Close();
            tb_message.Clear();
            tb_message.Focus();
        }


        private void Bt_envoyer_Click(object sender, EventArgs e)
        {
            MessageChat leMessage = new MessageChat('E', adrIpLocale,
                        tb_message.Text);
            Envoyer(leMessage);
        }

        private void Bt_connecter_Click(object sender, EventArgs e)
        {
            if (tb_pseudo.Text != "")
            {
                bt_connecter.Enabled = false;
                tb_pseudo.Enabled = false;
                MessageChat leMessage = new MessageChat('C', adrIpLocale, tb_pseudo.Text);
                Envoyer(leMessage);
                bt_envoyer.Enabled = true;
                tb_message.Enabled = true;
                InitReception();
                tb_message.Focus();
            }
        }

        private void InitReception()
        {
            messageBytes = new byte[lgMessage];
            sockReception = new Socket(AddressFamily.InterNetwork,
            SocketType.Dgram, ProtocolType.Udp);
            epRecepteur = new IPEndPoint(adrIpLocale, portClient);
            sockReception.Bind(epRecepteur);
            IPAddress IpMulticast = UtilIP.IPMulticast();
            MulticastOption optionMulticast = new MulticastOption(IpMulticast, adrIpLocale);
            sockReception.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, optionMulticast);
            EndPoint epTemp = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
            sockReception.BeginReceiveFrom(
                messageBytes, 
                0, 
                lgMessage,
                SocketFlags.None, 
                ref epTemp,
                new AsyncCallback(Recevoir),
                null
            );
        }


        private void Recevoir(IAsyncResult AR)
        {
            EndPoint epTemp = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
            sockReception.EndReceiveFrom(AR, ref epTemp);
            MessageChat leMessage = MessageChat.Deserialiser(messageBytes);
            if(leMessage.TypeMessage == 'R')
                lb_messages.Invoke(m_newMessage, leMessage);
            Array.Clear(messageBytes, 0, messageBytes.Length);
            sockReception.BeginReceiveFrom(messageBytes, 0, lgMessage,
            SocketFlags.None, ref epTemp,
            new AsyncCallback(Recevoir),
            null);
        }

        private void Fm_client_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageChat leMessage = new MessageChat('D', adrIpLocale, tb_pseudo.Text);
            Envoyer(leMessage);
        }
    }
}