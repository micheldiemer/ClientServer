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
       
        // la m�thonde Invoke prend en param�tre une m�thode de type AddItemDelegate
        private delegate void AddItemDelegate(string text);
        private AddItemDelegate m_newMessage;
        // dans la m�thode init m_newMessage = new AddItemDelegate(this.AddItemToList);
        // dans la m�thode recevoir lb_messages.Invoke(m_newMessage, new string[] { strMessage });
        void AddItemToList(string element)
        {
            lb_messages.Items.Add(element);
            lb_nbmessages.Text = lb_messages.Items.Count.ToString() + " message(s) re�u(s)";

        }


        private int lgMessage = 40;
        private IPAddress? adrIpLocale;
        private Socket? sock;
        private IPEndPoint epRecepteur;
        byte[]? message;


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

            message = new byte[lgMessage];

            // r�cup�ration de l'adresse IP
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

            // Cr�ation du Socket
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            epRecepteur = new IPEndPoint(adrIpLocale, portNum);
            sock.Bind(epRecepteur);
            EndPoint epTemp = (EndPoint)new IPEndPoint(IPAddress.Any, 0);

            // R�ception des donn�es de mani�re Asynchrone, cf. fonction "recevoir"
            sock.BeginReceiveFrom(message, 0, lgMessage, SocketFlags.None, ref epTemp,
                                new AsyncCallback(recevoir), null);

        }
        

        private void recevoir(IAsyncResult AR)
        {
            // R�cuop�ration des informations et des donn�es de l'�metteur
            EndPoint epTemp = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
            sock.EndReceiveFrom(AR, ref epTemp);
            IPEndPoint epEmetteur = (IPEndPoint)epTemp;

            // D�codage du message
            string strMessage;
            strMessage = Encoding.Unicode.GetString(message, 0, message.Length);

            // Mise � jour de l'interface graphique
            // L'interface graphique ne peut �tre mise � jour
            //   que par le processus principal
            // Utilisation de la m�thode Invoke afin de mettre � jour
            ///  l'interface graphique via le processus principal
            lb_messages.Invoke(m_newMessage, new string[] { strMessage });

            // R�ouverture du socket, attente d'un nouveau message
            Array.Clear(message, 0, message.Length);
            sock.BeginReceiveFrom(message, 0, lgMessage, SocketFlags.None, ref epTemp,
                                    new AsyncCallback(recevoir), null);
            //MessageBox.Show(epEmetteur.Address.ToString() + " -> " + strMessage);
        }

    }
}