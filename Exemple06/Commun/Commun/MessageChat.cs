using System.Net;
using System.Text;

namespace Commun
{
    public class MessageChat
    {
        private static char separateur = '#';

        private IPAddress ipEmetteur;
        public IPAddress IpEmetteur
        {
            get { return ipEmetteur; }
            set { ipEmetteur = value; }
        }

        private char typeMessage;
        public char TypeMessage
        {
            get { return typeMessage; }
        }

        private string texte;
        public string Texte
        {
            get { return texte; }
            set { texte = value; }
        }
        public MessageChat(char p_typeMessage, IPAddress p_ipEmetteur, string p_texte)
        {
            typeMessage = p_typeMessage;
            ipEmetteur = p_ipEmetteur;
            texte = p_texte;
        }
        public byte[] GetInfos()
        {
            string infos = typeMessage.ToString() + separateur
                            + ipEmetteur.ToString() + separateur.ToString()
            + texte + separateur.ToString();
            return Encoding.Unicode.GetBytes(infos);
        }
        public MessageChat(byte[] p_infos)
        {
            string infos = Encoding.Unicode.GetString(p_infos);
            string[] tabInfos = infos.Split(new char[] { separateur });
            typeMessage = tabInfos[0][0];
            ipEmetteur = IPAddress.Parse(tabInfos[1]);
            texte = tabInfos[2];
        }
    }
}