using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

// 実装された機能:
// - 実行内容などのステータスを記録する機能。
// - 開始済みかどうかを検証してから安全に開始する機能。
// - 定期的に自動接続する機能。
// -- 例えば他のスクリプトなどの制御なしに、実行時に自動でホストとして起動することができます。
// -- 例えばクライアントが接続に失敗したとき、自動的に接続させたりすることができます。

// 実装方針:
// base.client.RegisterHandler(MsgType.Error, OnError);
// 形式でエラーメッセージを取得しようとしても具体的なメッセージは得られず、
// 主にエラーコードだけが取得できるので、これを使ったエラーのハンドリングは取り止めました。

// エラーコードについて:
// エラー発生時に取得することができるエラーコードは、
// transport layer NetworkError code: に等しいようです。
// https://docs.unity3d.com/ScriptReference/Networking.NetworkError.html

/// <summary>
/// 自動接続機能などを持った NetworkManager です。
/// </summary>
public class CustomNetworkManager : NetworkManager
{
    #region Struct

    /// <summary>
    /// 実行された内容や現在の状態を表すメッセージ。
    /// </summary>
    public struct UNETStatusMessage
    {
        public DateTime time;
        public string   message;
    }

    #endregion Struct

    #region Enum

    /// <summary>
    /// 接続の種類。
    /// </summary>
    public enum UNETConnectionType
    {
        /// <summary>
        /// サーバーとして接続。
        /// </summary>
        Server = 0,

        /// <summary>
        /// ホストとして接続。
        /// </summary>
        Host = 1,

        /// <summary>
        /// クライアントとして接続。
        /// </summary>
        Client = 2,

        /// <summary>
        /// 接続されていません。
        /// </summary>
        None = 3,
    }

    #endregion Enum

    #region Const Field

    protected const string MessageDefault = "…";

    #endregion const Field

    #region Field

    /// <summary>
    /// 現在の接続の種類。
    /// </summary>
    private UNETConnectionType connectionType;

    /// <summary>
    /// クライアントで実行されるとき、サーバーに接続されているかどうか。
    /// </summary>
    private bool clientIsConnectedToServer;

    #region Autio Connect Settings

    /// <summary>
    /// 自動接続するかどうか。true のとき自動接続します。
    /// </summary>
    public bool autoConnect;

    /// <summary>
    /// 自動接続の種類。
    /// </summary>
    public UNETConnectionType autoConnectionType;

    /// <summary>
    /// 自動接続を試みる場合の試行間隔。
    /// </summary>
    public float autoConnectIntervalTimeSec = 15;

    /// <summary>
    /// 最後に自動接続を試みた時間。
    /// </summary>
    protected float autoConnectPreviousTryTimeSec = 0;

    #endregion Auto Connect Settings

    #region Status 

    /// <summary>
    /// ステータスメッセージの最大保存数。
    /// </summary>
    public int statusMessagesCount = 10;

    /// <summary>
    /// ステータスメッセージ。
    /// 先頭が最新のメッセージになります。
    /// </summary>
    protected List<UNETStatusMessage> statusMessages;

    #endregion Status

    #region Event Class

    /// <summary>
    /// エラーコードの情報を持った、NetworkConnection のラッパー。
    /// </summary>
    [Serializable]
    public class NetworkConnectionError
    {
        #region Field

        /// <summary>
        /// エラーコード。
        /// </summary>
        public int errorCode;

        /// <summary>
        /// NetworkConnection。
        /// </summary>
        public NetworkConnection networkConnection;

        #endregion Field
    }

    /// <summary>
    /// NetworkConnection を引数とするイベント。
    /// </summary>
    [Serializable]
    public class NetworkConnectionEvent : UnityEvent<NetworkConnection> { }

    /// <summary>
    /// NetworkConnection
    /// </summary>
    [Serializable]
    public class NetworkConnectionErrorEvent : UnityEvent<NetworkConnectionError> { }

    /// <summary>
    /// NetworkClient を引数とするイベント。
    /// </summary>
    [Serializable]
    public class NetworkClientEvent : UnityEvent<NetworkClient> { }

    #endregion Event Class

    #region Event Handler

    #region Server Event Handler

    /// <summary>
    /// サーバーで開始したときに実行されるイベントハンドラ。
    /// </summary>
    public UnityEvent StartServerEventHandler;

    /// <summary>
    /// サーバーで停止したときに実行されるイベントハンドラ。
    /// </summary>
    public UnityEvent StopServerEventHandler;

    /// <summary>
    /// サーバーでクライアントが接続されたときに実行されるイベントハンドラ。
    /// </summary>
    public NetworkConnectionEvent ServerConnectEventHandler;

    /// <summary>
    /// サーバーでクライアントが切断されたときに実行されるイベントハンドラ。
    /// </summary>
    public NetworkConnectionEvent ServerDisconnectEventHandler;

    /// <summary>
    /// サーバーでエラーが起きたときに実行されるイベントハンドラ。
    /// </summary>
    public NetworkConnectionErrorEvent ServerErrorEventHandler;

    #endregion Server Event Handler

    #region Host Event Handler

    /// <summary>
    /// ホストで開始したときに実行されるイベントハンドラ。
    /// </summary>
    public UnityEvent StartHostEventHandler;

    /// <summary>
    /// ホストで停止したときに実行されるイベントハンドラ。
    /// </summary>
    public UnityEvent StopHostEventHandler;

    #endregion Host Event Handler

    #region Client Event Handler

    /// <summary>
    /// クライアントで開始したときに実行されるイベントハンドラ。
    /// </summary>
    public NetworkClientEvent StartClientEventHandler;

    /// <summary>
    /// クライアントで停止したときに実行されるイベントハンドラ。
    /// </summary>
    public UnityEvent StopClientEventHandler;

    /// <summary>
    /// クライアントでサーバーに接続したときに実行されるイベントハンドラ。
    /// </summary>
    public NetworkConnectionEvent ClientConnectEventHandler;

    /// <summary>
    /// クライアントでサーバーから切断されたときに実行されるイベントハンドラ。
    /// </summary>
    public NetworkConnectionEvent ClientDisconnectEventHandler;

    /// <summary>
    /// クライアントでエラーが起きたときに実行されるイベントハンドラ。
    /// </summary>
    public NetworkConnectionErrorEvent ClientErrorEventHandler;

    #endregion Client Event Hanler

    #endregion Event Handler

    #endregion Field

    #region Property

    /// <summary>
    /// NetworkManager の singleton のインスタンス。
    /// </summary>
    public static new CustomNetworkManager singleton
    {
        get
        {
            return (CustomNetworkManager)NetworkManager.singleton;
        }
    }

    /// <summary>
    /// 現在の接続の種類を取得します。
    /// </summary>
    public UNETConnectionType ConnectionType
    {
        get { return this.connectionType; }
    }

    /// <summary>
    /// ステータスメッセージのリストを取得します。
    /// </summary>
    public List<UNETStatusMessage> StatusMessages
    {
        get { return this.statusMessages; }
    }

    #endregion Propery

    #region Method

    // NOTE:
    // Awake で初期化時に呼び出すことは強くしない方が良いです。
    // NetworkManager が Awake を使った初期化を実行するためです。
    // Awake によって、singleton などの初期化を行っているようです。
    // Awake を override する手段がないので、やむを得ずこのような実装になります。
    // (Unity は Awake → OnEnable → Start の順に実行されます。)

    /// <summary>
    /// 有効化時に呼び出されます。
    /// </summary>
    protected virtual void OnEnable()
    {
        this.connectionType = UNETConnectionType.None;

        this.statusMessages = new List<UNETStatusMessage>();

        AddStatusMessage(CustomNetworkManager.MessageDefault);
    }

    /// <summary>
    /// 開始時に呼び出されます。
    /// </summary>
    protected virtual void Start()
    {
        TryToAutoStart(true);
    }

    /// <summary>
    /// 更新時に呼び出されます。
    /// </summary>
    protected virtual void Update()
    {
        TryToAutoStart();
    }

    #region Status Message

    /// <summary>
    /// ステータスメッセージを追加します。
    /// </summary>
    /// <param name="statusMessage">
    /// 追加するメッセージ。
    /// </param>
    public void AddStatusMessage(string statusMessage)
    {
        AddStatusMessage(new UNETStatusMessage()
        {
            time = DateTime.Now,
            message = statusMessage
        });
    }

    /// <summary>
    /// ステータスメッセージを追加します。
    /// </summary>
    /// <param name="statusMessage">
    /// 追加するメッセージ。
    /// </param>
    public void AddStatusMessage(UNETStatusMessage statusMessage)
    {
        this.statusMessages.Insert(0, statusMessage);
        TrimStatusMessages();
    }

    /// <summary>
    /// ステータスメッセージをトリムして最大数に合わせます。
    /// </summary>
    protected void TrimStatusMessages()
    {
        int count = this.statusMessages.Count;

        while (count > this.statusMessagesCount)
        {
            this.statusMessages.RemoveAt(count - 1);

            count = count - 1;
        }
    }

    /// <summary>
    /// すべてのステータスメッセージを削除します。
    /// </summary>
    public void ClearStatusMessages()
    {
        this.statusMessages.Clear();
    }

    #endregion Status Message

    #region Start Stop

    /// <summary>
    /// 自動接続を試みます。自動接続モードでないときは何も処理されません。
    /// </summary>
    /// <param name="ignoreAutoConnectInterval">
    /// 自動接続を試行するインターバル時間を無視するかどうか。
    /// true のとき無視します。規定値は false です。
    /// </param>
    protected virtual void TryToAutoStart(bool ignoreAutoConnectInterval = false)
    {
        // 自動接続が無効であったり、既に接続されているときは処理を抜けます。

        if (!this.autoConnect || this.connectionType != UNETConnectionType.None)
        {
            return;
        }

        // 再接続を試みるインターバール時間が経過していなかったら処理を抜けます。
        // ただし、インターバル時間を無視する場合があります(初回起動時など)。

        if (!ignoreAutoConnectInterval)
        { 
            float currentTime = Time.timeSinceLevelLoad;
            float remainingTimeSec = currentTime - this.autoConnectPreviousTryTimeSec;

            if (this.autoConnectIntervalTimeSec > remainingTimeSec)
            {
                return;
            }

            this.autoConnectPreviousTryTimeSec = currentTime;
        }

        // 情報を追加して接続を試みます。

        AddStatusMessage("Try to Auto Connect.");

        switch (this.autoConnectionType)
        {
            case UNETConnectionType.Server:
                {
                    base.StartServer();
                    break;
                }
            case UNETConnectionType.Host:
                {
                    base.StartHost();
                    break;
                }
            case UNETConnectionType.Client:
                {
                    base.StartClient();
                    break;
                }
        }
    }

    /// <summary>
    /// 既にいずれかの形式で開始されていないかを確認してからサーバーとして開始します。
    /// 既にいずれかの形式で開始されているとき、サーバーとして開始しません。
    /// </summary>
    public virtual void StartServerSafe()
    {
        if (this.connectionType != UNETConnectionType.None)
        {
            AddStatusMessage("Faild to Start Server. : Already Started as " + this.connectionType.ToString());
            return;
        }

        base.StartServer();
    }

    /// <summary>
    /// 既にいずれかの形式で開始されていないかを確認してからホストとして開始します。
    /// 既にいずれかの形式で開始されているとき、ホストとして開始しません。
    /// </summary>
    public virtual void StartHostSafe()
    {
        if (this.connectionType != UNETConnectionType.None)
        {
            AddStatusMessage("Faild to Start Host. : Already Started as " + this.connectionType.ToString());
            return;
        }

        base.StartHost();
    }

    /// <summary>
    /// 既にいずれかの形式で開始されていないかを確認してからクライアントとして開始します。
    /// 既にいずれかの形式で開始されているとき、クライアントとして開始しません。
    /// </summary>
    public virtual void StartClientSafe()
    {
        if (this.connectionType != UNETConnectionType.None)
        {
            AddStatusMessage("Faild to Start Client. : Already Started as " + this.connectionType.ToString());
            return;
        }

        base.StartClient();
    }

    /// <summary>
    /// サーバー、ホスト、クライアントにかかわらず停止処理を実行します。
    /// </summary>
    public virtual void Stop()
    {
        switch (this.connectionType)
        {
            case UNETConnectionType.Server:
                {
                    base.StopServer();
                    break;
                }
            case UNETConnectionType.Host:
                {
                    base.StopHost();
                    break;
                }
            case UNETConnectionType.Client:
                {
                    base.StopClient();
                    break;
                }
            case UNETConnectionType.None:
                {
                    AddStatusMessage("Failed to Stop : Nothing is Started.");
                    break;
                }
        }
    }

    #endregion Start Stop

    // NOTE:
    // 以下のメソッドで実行される一部の処理は、base メソッドよりも先に実行されています。
    // base メソッドの中で、引数となる接続情報を破棄する処理などが実行されるためです。
    // 
    // Host として起動する場合、OnStartHost が実行された後に、
    // OnStartServer, OnStartClient が実行される点に注意してください。
    // 
    // 停止するタイミングで this.autoConnectPreviousTryTimeSec をリセットしています。
    // 停止した直後に自動接続が実行されないようにするための措置です。

    #region Override Server

    /// <summary>
    /// サーバーで開始されたときに呼び出されます。
    /// </summary>
    public override void OnStartServer()
    {
        if (this.connectionType != UNETConnectionType.Host)
        {
            AddStatusMessage("Start Server.");
            this.connectionType = UNETConnectionType.Server;
        }

        base.OnStartServer();

        this.StartServerEventHandler.Invoke();
    }

    /// <summary>
    /// サーバーで停止されたときに呼び出されます。
    /// </summary>
    public override void OnStopServer()
    {
        AddStatusMessage("Stop Server.");

        this.connectionType = UNETConnectionType.None;

        this.autoConnectPreviousTryTimeSec = Time.timeSinceLevelLoad;

        base.OnStopServer();

        this.StopServerEventHandler.Invoke();
    }

    /// <summary>
    /// サーバーでクライアントが接続されたときに呼び出されます。
    /// </summary>
    /// <param name="networkConnection">
    /// 該当する接続情報。
    /// </param>
    public override void OnServerConnect(NetworkConnection networkConnection)
    {
        AddStatusMessage("Client Connected : " + networkConnection.address);

        base.OnServerConnect(networkConnection);

        this.ServerConnectEventHandler.Invoke(networkConnection);
    }

    /// <summary>
    /// サーバーでクライアントとの接続が切断されたときに呼び出されます。
    /// </summary>
    /// <param name="networkConnection">
    /// 該当する接続情報。
    /// </param>
    public override void OnServerDisconnect(NetworkConnection networkConnection)
    {
        AddStatusMessage("Client Disconnected : " + networkConnection.address);

        base.OnServerDisconnect(networkConnection);

        this.ServerDisconnectEventHandler.Invoke(networkConnection);
    }

    /// <summary>
    /// サーバーでエラーが起きたときに呼び出されます。
    /// </summary>
    /// <param name="networkConnection">
    /// 該当する接続情報。
    /// </param>
    /// <param name="errorCode">
    /// エラーコード。
    /// </param>
    public override void OnServerError(NetworkConnection networkConnection, int errorCode)
    {
        AddStatusMessage("Server Get Error : " + (NetworkError)errorCode);

        base.OnServerError(networkConnection, errorCode);

        this.ServerErrorEventHandler.Invoke(new NetworkConnectionError()
        {
            networkConnection = networkConnection,
            errorCode = errorCode
        });
    }

    #endregion Override Server

    #region Override Host

    /// <summary>
    /// ホストで開始されたときに呼び出されます。
    /// </summary>
    public override void OnStartHost()
    {
        AddStatusMessage("Start Host.");

        this.connectionType = UNETConnectionType.Host;

        base.OnStartHost();

        this.StartHostEventHandler.Invoke();
    }

    /// <summary>
    /// ホストで停止したときに呼び出されます。
    /// </summary>
    public override void OnStopHost()
    {
        AddStatusMessage("Stop Host.");

        this.connectionType = UNETConnectionType.None;

        this.autoConnectPreviousTryTimeSec = Time.timeSinceLevelLoad;

        base.OnStopHost();

        this.StopHostEventHandler.Invoke();
    }

    #endregion Override Host

    #region Override Client

    /// <summary>
    /// クライアントで開始されたときに呼び出されます。
    /// </summary>
    /// <param name="networkClient">
    /// 該当するクライアント。
    /// </param>
    public override void OnStartClient(NetworkClient networkClient)
    {
        if (this.connectionType != UNETConnectionType.Host)
        {
            AddStatusMessage("Start Client.");
            this.connectionType = UNETConnectionType.Client;
        }

        base.OnStartClient(networkClient);

        this.StartClientEventHandler.Invoke(networkClient);
    }

    /// <summary>
    /// クライアントで停止したときに呼び出されます。
    /// </summary>
    public override void OnStopClient()
    {
        AddStatusMessage("Stop Client.");

        this.connectionType = UNETConnectionType.None;

        this.autoConnectPreviousTryTimeSec = Time.timeSinceLevelLoad;

        base.OnStopClient();

        this.StopClientEventHandler.Invoke();
    }

    /// <summary>
    /// クライアントでサーバーに接続したときに呼び出されます。
    /// </summary>
    /// <param name="networkConnection">
    /// 該当する接続情報。
    /// </param>
    public override void OnClientConnect(NetworkConnection networkConnection)
    {
        AddStatusMessage("Connected to Server. : " + networkConnection.address);

        this.clientIsConnectedToServer = true;

        base.OnClientConnect(networkConnection);

        this.ClientConnectEventHandler.Invoke(networkConnection);
    }

    /// <summary>
    /// クライアントでサーバーから切断されたときに呼び出されます。
    /// </summary>
    /// <param name="networkConnection">
    /// 該当する接続情報。
    /// </param>
    public override void OnClientDisconnect(NetworkConnection networkConnection)
    {
        // クライアントが一度でも接続に成功しているときと、
        // 一度も成功していないときとでメッセージを分け、状況を把握しやすくします。

        if (this.clientIsConnectedToServer)
        {
            AddStatusMessage("Disconnected from Server. : " + networkConnection.address);
        }
        else
        {
            AddStatusMessage("Faild to Connect Server. : " + networkConnection.address);
        }

        this.clientIsConnectedToServer = false;

        base.OnClientDisconnect(networkConnection);

        this.ClientDisconnectEventHandler.Invoke(networkConnection);
    }

    /// <summary>
    /// クライアントでエラーが起きたときに呼び出されます。
    /// </summary>
    /// <param name="networkConnection">
    /// 該当する接続情報。
    /// </param>
    /// <param name="errorCode">
    /// エラーコード。
    /// </param>
    public override void OnClientError(NetworkConnection networkConnection, int errorCode)
    {
        AddStatusMessage("Client Get Error : " + (NetworkError)errorCode);

        base.OnClientError(networkConnection, errorCode);

        this.ClientErrorEventHandler.Invoke(new NetworkConnectionError()
        {
            networkConnection = networkConnection,
            errorCode = errorCode
        });
    }

    #endregion Override Client

    #endregion Method
}