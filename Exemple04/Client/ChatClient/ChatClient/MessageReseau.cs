using System;
using System.Net;
using System.Text;

class MessageReseau
{
    private static char separateur = '#';
    private IPAddress ipEmetteur;
    public IPAddress IpEmetteur
    {
        get { return ipEmetteur; }
        set { ipEmetteur = value; }
    }
    private string texte;
    public string Texte
    {
        get { return texte; }
        set { texte = value; }
    }
    public MessageReseau(IPAddress p_ipEmetteur, string p_texte)
    {
        ipEmetteur = p_ipEmetteur;
        texte = p_texte;
    }
    public byte[] GetInfos()
    {
        string infos = ipEmetteur.ToString() + separateur.ToString()
        + texte + separateur.ToString();
        return Encoding.Unicode.GetBytes(infos);
    }
    public MessageReseau(byte[] p_infos)
    {
        string infos = Encoding.Unicode.GetString(p_infos);
        string[] tabInfos = infos.Split(new char[] { separateur });
        ipEmetteur = IPAddress.Parse(tabInfos[0]);
        texte = tabInfos[1];
    }
}