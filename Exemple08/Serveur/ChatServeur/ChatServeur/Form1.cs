using System.Net;
using System.Net.Sockets;
using Commun;

namespace ChatServeur
{
    public partial class Fm_serveur : Form
    {

        public Fm_serveur()
        {
            InitializeComponent();
            InitReception();
        }
       
        // la m�thonde Invoke prend en param�tre une m�thode de type AddItemDelegate
        private delegate void AddItemDelegate(MessageChat leMessage);
        private AddItemDelegate m_newMessage;
        // dans la m�thode init m_newMessage = new AddItemDelegate(this.AddItemToList);
        // dans la m�thode recevoir lb_messages.Invoke(m_newMessage, new string[] { strMessage });
        void AddItemToList(MessageChat leMessage)
        {
            string element = leMessage.IpEmetteur.ToString()
                                + " -> " + leMessage.Texte;
            lb_messages.Items.Add(element);
            lb_nbmessages.Text = lb_messages.Items.Count.ToString() + " message(s) re�u(s)";

        }


        private static int lgMessage = 1000;
        private static int portServeur = UtilIP.DEFAULT_PORT_SERVER;
        private static int portClient = UtilIP.DEFAULT_PORT_CLIENT;
        private IPAddress adrIpLocale;
        private Socket sockReception;
        private IPEndPoint epRecepteur;
        byte[] messageBytes;
        Dictionary<IPAddress, string> clients;




        private void InitReception()
        {

            m_newMessage = new AddItemDelegate(this.AddItemToList);

            clients = new Dictionary<IPAddress, string>();
            messageBytes = new byte[lgMessage];
            adrIpLocale = UtilIP.GetAdrIpLocaleV4();
            tb_ipV4.Text = adrIpLocale.ToString();
            sockReception = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            epRecepteur = new IPEndPoint(adrIpLocale, portServeur);
            sockReception.Bind(epRecepteur);
            EndPoint epTemp = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
            sockReception.BeginReceiveFrom(messageBytes, 0, lgMessage,
                SocketFlags.None, ref epTemp, new AsyncCallback(Recevoir), null);

        }



        private void EnvoyerMulticast(MessageChat leMessage)
        {
            byte[] messageMulticast;
            Socket sockEmission = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp);
            IPEndPoint epEmetteur = new IPEndPoint(adrIpLocale, 0);
            sockEmission.Bind(epEmetteur);
            IPAddress IpMulticast = UtilIP.IPMulticast();
            IPEndPoint epRecepteur = new IPEndPoint(IpMulticast, portClient);
            messageMulticast = MessageChat.Serialiser(leMessage);
            sockEmission.SendTo(messageMulticast, epRecepteur);
            sockEmission.Close();
        }
        private void EnvoyerBroadcast(MessageChat leMessage)
        {
            byte[] messageBroadcast;
            Socket sockEmission = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp);
            sockEmission.SetSocketOption(SocketOptionLevel.Socket,
            SocketOptionName.Broadcast, true);
            IPEndPoint epEmetteur = new IPEndPoint(adrIpLocale, 0);
                sockEmission.Bind(epEmetteur);
            IPEndPoint epRecepteur = new IPEndPoint(IPAddress.Broadcast, portClient);
            messageBroadcast = MessageChat.Serialiser(leMessage);
            sockEmission.SendTo(messageBroadcast, epRecepteur);
            sockEmission.Close();
        }


        private void Recevoir(IAsyncResult AR)
        {
            // R�cuop�ration des informations et des donn�es de l'�metteur
            EndPoint epTemp = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
            sockReception.EndReceiveFrom(AR, ref epTemp);
            IPEndPoint epEmetteur = (IPEndPoint)epTemp;

            // D�codage du message
            MessageChat leMessage = MessageChat.Deserialiser(messageBytes);

            // Mise � jour de l'interface graphique
            // L'interface graphique ne peut �tre mise � jour
            //   que par le processus principal
            // Utilisation de la m�thode Invoke afin de mettre � jour
            ///  l'interface graphique via le processus principal

            switch (leMessage.TypeMessage)
            {
                case 'C':
                    clients.Add(leMessage.IpEmetteur, leMessage.Texte);
                    lb_messages.Invoke(m_newMessage, leMessage);
                    break;
                case 'E':
                    string pseudo = clients[leMessage.IpEmetteur];
                    MessageChat messageRetransmis =
                    new MessageChat('R', adrIpLocale, pseudo + " -> " + leMessage.Texte);
                    EnvoyerBroadcast(messageRetransmis);
                    break;
                case 'D':
                    clients.Remove(leMessage.IpEmetteur);
                    break;
            }
            



            // R�ouverture du socket, attente d'un nouveau message
            Array.Clear(messageBytes, 0, messageBytes.Length);
            sockReception.BeginReceiveFrom(messageBytes, 0, lgMessage, SocketFlags.None, ref epTemp,
                                    new AsyncCallback(Recevoir), null);
            //MessageBox.Show(epEmetteur.Address.ToString() + " -> " + strMessage);
        }

        private void lb_messages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}