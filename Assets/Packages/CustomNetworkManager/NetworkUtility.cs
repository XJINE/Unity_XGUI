using System.Net;

/// <summary>
/// Network を伴う実装をするときに、よく使う機能。
/// </summary>
public class NetworkUtility
{
    /// <summary>
    /// 実行環境(ローカル)の IPAddress を取得します。
    /// </summary>
    /// <returns>
    /// 実行環境(ローカル)の IPAddress。
    /// </returns>
    protected static string GetLocalIPAddress()
    {
        string ipaddress = "";
        IPHostEntry ipentry = Dns.GetHostEntry(Dns.GetHostName());

        foreach (IPAddress ip in ipentry.AddressList)
        {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                ipaddress = ip.ToString();
                break;
            }
        }

        return ipaddress;
    }
}