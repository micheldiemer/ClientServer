using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;


namespace Commun
{
    [Serializable]
    public class MessageChat : ISerializable
    {
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

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Use the AddValue method to specify serialized values.
            info.AddValue("typeMessage", typeMessage, typeof(char));
            info.AddValue("texte", texte, typeof(string));
            info.AddValue("ipEmetteur", ipEmetteur.ToString(), typeof(string));
        }

        // The special constructor is used to deserialize values.
        public MessageChat(SerializationInfo info, StreamingContext context)
        {
            // Reset the property value using the GetValue method.
            typeMessage = (char)info.GetValue("typeMessage", typeof(char));
            texte = (string)info.GetValue("texte", typeof(string));
            string ip = (string)info.GetValue("ipEmetteur", typeof(string));
            ipEmetteur = IPAddress.Parse(ip);
        }

        public MessageChat()
        {
            typeMessage = ' ';
            texte = "";
            ipEmetteur = IPAddress.Parse("127.0.0.1");
        }
        public MessageChat(char p_typeMessage, IPAddress p_ipEmetteur, string p_texte)
        {
            typeMessage = p_typeMessage;
            ipEmetteur = p_ipEmetteur;
            texte = p_texte;
        }
        public static byte[] Serialiser(MessageChat p_message)
        {
            MemoryStream flux = new MemoryStream();
            BinaryFormatter formateur = new BinaryFormatter();
            formateur.Serialize(flux, p_message);
            byte[] buffer = flux.GetBuffer();
            flux.Close();
            return buffer;
        }

        public static MessageChat Deserialiser(byte[] p_buffer)
        {
            MemoryStream flux = new MemoryStream(p_buffer);
            BinaryFormatter formateur = new BinaryFormatter();
            object obj = formateur.Deserialize(flux);
            flux.Close();
            return (MessageChat)obj;
        }
    }
}