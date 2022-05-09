using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NativeWebSocket;
using StreamChat.Libs.Logs;
using StreamChat.Libs.Utils;

namespace StreamChat.Libs.Websockets {

    public class WebsocketWebGLClient : IWebsocketClient {

        public bool IsRunning { get; private set; }

        public event Action Connected;
        public event Action ConnectionFailed;

        private WebSocket _internalClient = null;
        // private CancellationTokenSource _connectionCts;
        private readonly ConcurrentQueue<string> _receiveQueue = new ConcurrentQueue<string> ();
        private readonly ILogs _logs;

        bool _isConnecting = false;

        Uri url;

        public WebsocketWebGLClient (ILogs logs) {
            _logs = logs ??
                throw new ArgumentNullException (nameof (logs));
        }

        public void Dispose () {
            IsRunning = false;
            _internalClient?.Close ();
            _internalClient = null;
        }

        public async Task ConnectAsync (Uri serverUri) {

            _logs.Info ("ConnectAsync :" + serverUri.AbsoluteUri);

            // _connectionCts?.Dispose ();
            url = serverUri;

            if (_internalClient != null) {

                _logs.Info ("ConnectAsync Try close previous webclient state:" + _internalClient.State.ToString ());
                _internalClient.OnClose -= OnClosed;
                _internalClient.OnOpen -= OnOpen;
                _internalClient.OnError -= OnError;
                _internalClient.OnMessage -= OnMessage;

                if (_internalClient.State == WebSocketState.Open) {
                    _internalClient.Close ();
                }

                _internalClient = null;
            }

            IsRunning = false;

            //_connectionCts = new CancellationTokenSource ();

            try {
                _logs.Info ("ConnectAsync Try Connecting");

                _internalClient = new WebSocket (url.AbsoluteUri);
                _internalClient.OnClose += OnClosed;
                _internalClient.OnOpen += OnOpen;
                _internalClient.OnError += OnError;
                _internalClient.OnMessage += OnMessage;

                _isConnecting = true;
                _internalClient.Connect ();

            } catch (Exception ex) {
                _logs.Exception (ex);
                ConnectionFailed?.Invoke ();
                IsRunning = false;
            }
        }

        private void OnClosed (WebSocketCloseCode closeCode) {
            _logs.Warning ("_internalClient.OnClose :" + closeCode.ToString ());
            IsRunning = false;

            if (_isConnecting) {
                _logs.Warning ("_internalClient.OnClose ConnectionFailed Invoke");

                _isConnecting = false;
                //연결 시도 실패시에만 Invoke 되어야한다.
                ConnectionFailed?.Invoke ();
            } else if (closeCode == WebSocketCloseCode.Abnormal) {
                _logs.Warning ("_internalClient.OnClose Try Reconnect");
                // _internalClient.Connect();
                ConnectAsync (url);
            }

            //if (closeCode != WebSocketCloseCode.Normal)
            //    ConnectionFailed?.Invoke ();

            // if (closeCode == WebSocketCloseCode.Abnormal){
            //      ConnectionFailed?.Invoke ();
            // }
        }

        private void OnOpen () {
            _logs.Info ("[Verbose] _internalClient.OnOpen ");
            IsRunning = true;
            _isConnecting = false;
            Connected?.Invoke ();

            // #pragma warning disable 4014
            //                 Task.Factory.StartNew (ReceiveMessages, _connectionCts.Token, TaskCreationOptions.LongRunning,
            //                     TaskScheduler.Default);
            // #pragma warning restore 4014
        }

        private void OnError (string e) {
            //ConnectionFailed?.Invoke();
            _logs.Warning ("[Verbose] _internalClient.OnError :" + e);
            IsRunning = false;

            //ConnectionFailed?.Invoke();
        }

        private void OnMessage (byte[] msg) {
            var msgString = System.Text.Encoding.UTF8.GetString (msg);

            _logs.Info ("[Verbose] _internalClient.OnMessage :" + msgString);
            _receiveQueue.Enqueue (msgString);
        }

        // private void SetEventListener () {

        //     _internalClient.OnClose += (closeCode) => {
        //         _logs.Warning ("_internalClient.OnClose :" + closeCode.ToString ());
        //         IsRunning = false;

        //         if (isConnecting) {
        //             _logs.Warning ("_internalClient.OnClose ConnectionFailed Invoke");

        //             isConnecting = false;
        //             //연결 시도 실패시에만 Invoke 되어야한다.
        //             ConnectionFailed?.Invoke ();
        //         } else if (closeCode == WebSocketCloseCode.Abnormal) {

        //             _logs.Warning ("_internalClient.OnClose Try Reconnect");
        //             // _internalClient.Connect();
        //             ConnectAsync (url);
        //         }

        //         //if (closeCode != WebSocketCloseCode.Normal)
        //         //    ConnectionFailed?.Invoke ();

        //         // if (closeCode == WebSocketCloseCode.Abnormal){
        //         //      ConnectionFailed?.Invoke ();
        //         // }
        //     };

        //     _internalClient.OnOpen += () => {
        //         _logs.Info ("_internalClient.OnOpen ");
        //         IsRunning = true;
        //         isConnecting = false;
        //         Connected?.Invoke ();

        //         // #pragma warning disable 4014
        //         //                 Task.Factory.StartNew (ReceiveMessages, _connectionCts.Token, TaskCreationOptions.LongRunning,
        //         //                     TaskScheduler.Default);
        //         // #pragma warning restore 4014
        //     };

        //     _internalClient.OnError += (e) => {
        //         //ConnectionFailed?.Invoke();
        //         _logs.Warning ("_internalClient.OnError :" + e);
        //         IsRunning = false;

        //         //ConnectionFailed?.Invoke();
        //     };

        //     _internalClient.OnMessage += (msg) => {

        //         var msgString = System.Text.Encoding.UTF8.GetString (msg);

        //         _logs.Info ("_internalClient.OnMessage :" + msgString);
        //         _receiveQueue.Enqueue (msgString);
        //     };
        // }

        //         private async Task ReceiveMessages () {
        // #if !UNITY_WEBGL || UNITY_EDITOR
        //             while (IsRunning) {
        //                 _internalClient.DispatchMessageQueue ();
        //                 await new WaitForUpdate ();
        //             }
        // #endif
        //         }

        public async Task Send (string message) {
            _logs.Info ("[Verbose] _internalClient.Send :" + message);
            await _internalClient.SendText (message);
        }

        public bool TryDequeueMessage (out string message) {
#if !UNITY_WEBGL || UNITY_EDITOR
            _internalClient.DispatchMessageQueue ();
#endif
            return _receiveQueue.TryDequeue (out message);
        }
    }
}