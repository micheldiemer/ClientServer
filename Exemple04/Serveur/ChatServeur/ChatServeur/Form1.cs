using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatServeur
{
    public partial class Fm_serveur : Form
    {

        public Fm_serveur()
        {
            InitializeComponent();
            init();
        }
       
        // la méthonde Invoke prend en paramètre une méthode de type AddItemDelegate
        private delegate void AddItemDelegate(MessageReseau leMessage);
        private AddItemDelegate m_newMessage;
        // dans la méthode init m_newMessage = new AddItemDelegate(this.AddItemToList);
        // dans la méthode recevoir lb_messages.Invoke(m_newMessage, new string[] { strMessage });
        void AddItemToList(MessageReseau leMessage)
        {
            string element = leMessage.IpEmetteur.ToString()
                                + " -> " + leMessage.Texte;
            lb_messages.Items.Add(element);
            lb_nbmessages.Text = lb_messages.Items.Count.ToString() + " message(s) reçu(s)";

        }


        private int lgMessage = 40;
        private IPAddress? adrIpLocale;
        private Socket? sock;
        private IPEndPoint epRecepteur;
        byte[]? messageBytes;


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

        private void init()
        {

            m_newMessage = new AddItemDelegate(this.AddItemToList);

            messageBytes = new byte[lgMessage];

            // récupération de l'adresse IP
            adrIpLocale = getAdrIpLocaleV4();
            tb_port.Text = portNum.ToString();
            try
            {
                tb_ipV4.Text = adrIpLocale.ToString();
            }
            catch (SocketException e)
            {
                tb_ipV4.Text = "Erreur " + e.Message;
            }

            // Création du Socket
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            epRecepteur = new IPEndPoint(adrIpLocale, portNum);
            sock.Bind(epRecepteur);
            EndPoint epTemp = (EndPoint)new IPEndPoint(IPAddress.Any, 0);

            // Réception des données de manière Asynchrone, cf. fonction "recevoir"
            sock.BeginReceiveFrom(messageBytes, 0, lgMessage, SocketFlags.None, ref epTemp,
                                new AsyncCallback(recevoir), null);

        }
        

        private void recevoir(IAsyncResult AR)
        {
            // Récuopération des informations et des données de l'émetteur
            EndPoint epTemp = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
            sock.EndReceiveFrom(AR, ref epTemp);
            IPEndPoint epEmetteur = (IPEndPoint)epTemp;

            // Décodage du message
            MessageReseau leMessage = new MessageReseau(messageBytes);

            // Mise à jour de l'interface graphique
            // L'interface graphique ne peut être mise à jour
            //   que par le processus principal
            // Utilisation de la méthode Invoke afin de mettre à jour
            ///  l'interface graphique via le processus principal
            lb_messages.Invoke(m_newMessage, leMessage);

            // Réouverture du socket, attente d'un nouveau message
            Array.Clear(messageBytes, 0, messageBytes.Length);
            sock.BeginReceiveFrom(messageBytes, 0, lgMessage, SocketFlags.None, ref epTemp,
                                    new AsyncCallback(recevoir), null);
            //MessageBox.Show(epEmetteur.Address.ToString() + " -> " + strMessage);
        }

    }
}