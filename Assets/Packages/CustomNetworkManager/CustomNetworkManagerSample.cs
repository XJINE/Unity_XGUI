using System;
using UnityEngine;

public class CustomNetworkManagerSample : MonoBehaviour
{
    #region Field

    public string networkAddress = "127.0.0.1";

    public int networkPort = 5555;

    public Rect infoArea;

    #endregion Field

    #region Method

    protected virtual void Start()
    {
        CustomNetworkManager.singleton.networkAddress = this.networkAddress;
        CustomNetworkManager.singleton.networkPort = this.networkPort;
    }

    protected virtual void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CustomNetworkManager.singleton.autoConnect = !CustomNetworkManager.singleton.autoConnect;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            CustomNetworkManager.singleton.StartServerSafe();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            CustomNetworkManager.singleton.StartHostSafe();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CustomNetworkManager.singleton.StartClientSafe();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            CustomNetworkManager.singleton.Stop();
        }
    }

    protected virtual void OnGUI()
    {
        GUILayout.BeginArea(this.infoArea);

        GUILayout.Label("= Key Control =");
        GUILayout.Label("A : Toggle Auto Connect.");
        GUILayout.Label("S : Start As Server.");
        GUILayout.Label("H : Start As Host.");
        GUILayout.Label("C : Start As Client.");
        GUILayout.Label("D : Stop.");

        GUILayout.Label("= Status Log =");

        foreach (CustomNetworkManager.UNETStatusMessage statusMessage in CustomNetworkManager.singleton.StatusMessages)
        {
            GUILayout.Label(statusMessage.time.ToLongTimeString() + " - "+ statusMessage.message);
        }

        GUILayout.EndArea();
    }

    // NOTE:
    // Inspector View から StartServerEventHandler にこのメソッドを追加しています。

    public virtual void SampleEventHandler()
    {
        CustomNetworkManager.singleton.AddStatusMessage("EventHandle Message.");
    }

    protected void GetCommandLineSettings()
    {
        string[] args  = Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "-networkaddress")
            {
                if (i + 1 < args.Length)
                {
                    this.networkAddress = args[i + 1];
                }
            }
            if (args[i] == "-networkport")
            {
                if (i + 1 < args.Length)
                {
                    int tempPort;

                    if (int.TryParse(args[i + 1], out tempPort))
                    {
                        this.networkPort = tempPort;
                    }
                }
            }
        }
    }

    #endregion Method
}