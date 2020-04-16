using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SocketIO;

public class LobbyPanelManager : PanelManager {
    [SerializeField] Button joinButton;             // 방 입장
    [SerializeField] Button unJoinButton;           // 방 나가기
    [SerializeField] Button readyButton;            // 준비
    [SerializeField] Button unReadyButton;          // (준비)취소

    [SerializeField] ScrollRect scrollRect;         // Log 화면

    public enum LobbyState { None, Lobby, RoomNotReady, RoomReady, Play }
    private LobbyState currentLobbyState = LobbyState.None;
    private LobbyState CurrentLobbyState {
        get {
            return currentLobbyState;
        }
        set {
            switch (value) {
                case LobbyState.None:
                {
                    joinButton.gameObject.SetActive(false);
                    unJoinButton.gameObject.SetActive(false);
                    readyButton.gameObject.SetActive(false);
                    unReadyButton.gameObject.SetActive(false);
                    break;
                }
                case LobbyState.Lobby:
                {
                    // Lobby Panel 화면에 나타내기
                    Show();

                    joinButton.interactable = true;
                    joinButton.gameObject.SetActive(true);

                    unJoinButton.gameObject.SetActive(false);
                    readyButton.gameObject.SetActive(false);
                    unReadyButton.gameObject.SetActive(false);
                    break;
                }
                case LobbyState.RoomNotReady:
                {
                    readyButton.interactable = true;
                    readyButton.gameObject.SetActive(true);
                    unJoinButton.interactable = true;
                    unJoinButton.gameObject.SetActive(true);

                    joinButton.gameObject.SetActive(false);
                    unReadyButton.gameObject.SetActive(false);
                    break;
                }
                case LobbyState.RoomReady:
                {
                    unReadyButton.interactable = true;
                    unReadyButton.gameObject.SetActive(true);
                    unJoinButton.interactable = false;
                    unJoinButton.gameObject.SetActive(true);

                    joinButton.gameObject.SetActive(false);
                    readyButton.gameObject.SetActive(false);
                    break;
                }
                case LobbyState.Play:
                {
                    Hide();
                    GameController gameController = GameObject.Find("GameController").GetComponent<GameController>();                        
                    bool result = gameController.StartGame(clientInfo);

                    if (!result)
                    {
                        // TODO: 오류 표시
                    }
                    break;
                }
            }
            currentLobbyState = value;
        }
    }

    private SocketIOComponent socket;               // Socket.io 객체
    private ClientInfo clientInfo;                  // 클라이언트의 socket id와 room id 저장할 변수

#region MonoBehaviour methods
    private void Start() {
        InitSocket();
    }
#endregion

#region Socket.io methods
    // Socket의 초기화
    private void InitSocket() {
        GameObject socketObject = GameObject.Find("SocketIO");
        socket = socketObject.GetComponent<SocketIOComponent>();

        // Socket.io 이벤트 등록
        socket.On("res_connect", EventConnect);             // 클라가 서버에 연결 되었을때 호출
        socket.On("res_createroom", EventCreateRoom);       // 방을 생성해서 참여했을때 호출
        socket.On("res_joinroom", EventJoinRoom);           // 기존 방에 참여했을때 호출
        socket.On("res_unjoinroom", EventUnJoinRoom);       // 방에서 나왔을때 호출
        socket.On("res_ready", EventReady);                 // 준비가 완료되었을때 호출
        socket.On("res_unready", EventUnReady);             // 준비취소가 완료되었을때 호출
        socket.On("res_play", EventPlay);                   // 게임 시작을 알리는 이벤트

        socket.On("res_otherjoinroom", EventOtherJoinRoom);         // 내 방에 다른 누군가가 참여했을때 호출
        socket.On("res_otherunjoinroom", EventOtherUnJoinRoom);     // 내 방에서 다른 누군가가 빠져나갔을때 호출
        socket.On("res_otherready", EventOtherReady);               // 내 방에서 다른 누군가가 준비완료 했을 때
        socket.On("res_otherunready", EventOtherUnReady);           // 내 방에서 다른 누군가가 준비취소 했을 때
    }

    private void EventConnect(SocketIOEvent e) {
        string clientId = e.data.GetField("clientId").str;
        clientInfo = new ClientInfo(clientId, null);
        SetLog("서버에 접속함. ClientId: " + clientId);

        CurrentLobbyState = LobbyState.Lobby;
    }
    
    private void EventCreateRoom(SocketIOEvent e) {
        string roomId = e.data.GetField("roomId").str;
        clientInfo.roomId = roomId;
        SetLog("방 생성함. RoomId: " + roomId);

        CurrentLobbyState = LobbyState.RoomNotReady;
    }

    private void EventJoinRoom(SocketIOEvent e) {
        string roomId = e.data.GetField("roomId").str;
        JSONObject otherClientIds = e.data.GetField("otherClientIds");
        int clientsNumber = -1;
        e.data.GetField(ref clientsNumber, "clientsNumber");

        clientInfo.roomId = roomId;
        SetLog("방에 참여함. RoomId: " + roomId + " (" + clientsNumber + "/2)");

        SetLog("##### 기존 유저목록 #####");
        foreach (JSONObject o in otherClientIds.list)
        {
            SetLog("유저명: " + o.str);
        }
        SetLog("------------------------");

        CurrentLobbyState = LobbyState.RoomNotReady;
    }

    private void EventUnJoinRoom(SocketIOEvent e) {
        string roomId = e.data.GetField("roomId").str;
        clientInfo.roomId = null;
        SetLog("[" + roomId + "] 방에서 빠져나옴.");

        CurrentLobbyState = LobbyState.Lobby;
    }

    private void EventReady(SocketIOEvent e) {
        SetLog("준비완료");
        CurrentLobbyState = LobbyState.RoomReady;
    }

    private void EventUnReady(SocketIOEvent e) {
        SetLog("준비취소");
        CurrentLobbyState = LobbyState.RoomNotReady;
    }

    private void EventPlay(SocketIOEvent e)
    {
        CurrentLobbyState = LobbyState.Play;
    }

    private void EventOtherJoinRoom(SocketIOEvent e) {
        string roomId = e.data.GetField("roomId").str;
        string otherClientId = e.data.GetField("otherClientId").str;
        int clientsNumber = -1;
        e.data.GetField(ref clientsNumber, "clientsNumber");
        SetLog("[" + otherClientId + "] 님이 방에 참여함. (" + clientsNumber + "/2)");
    }

    private void EventOtherUnJoinRoom(SocketIOEvent e) {
        string otherClientId = e.data.GetField("otherClientId").str;
        SetLog("[" + otherClientId + "] 님이 방에서 나감");
    }

    private void EventOtherReady(SocketIOEvent e) {
        string otherClientId = e.data.GetField("otherClientId").str;
        SetLog("[" + otherClientId + "] 님 준비완료");
    }

    private void EventOtherUnReady(SocketIOEvent e) {
        string otherClientId = e.data.GetField("otherClientId").str;
        SetLog("[" + otherClientId + "] 님 준비취소");
    }

#endregion

#region OnClick Events
    public void OnClickJoin(Button button) {
        button.interactable = false;

        JSONObject data = new JSONObject();
        data.AddField("clientId", clientInfo.clientId);
        socket.Emit("req_joinroom", data);
    }
    public void OnClickUnJoin(Button button) {
        button.interactable = false;

        if (clientInfo.roomId != null) {
            JSONObject data = new JSONObject();
            data.AddField("clientId", clientInfo.clientId);
            data.AddField("roomId", clientInfo.roomId);
            socket.Emit("req_unjoinroom", data);
        } else {
            // TODO: 오류표시
        }
    }
    public void OnClickReady(Button button) {
        button.interactable = false;

        JSONObject data = new JSONObject();
        data.AddField("clientId", clientInfo.clientId);
        data.AddField("roomId", clientInfo.roomId);
        socket.Emit("req_ready", data);
    }
    public void OnClickUnReady(Button button) {
        button.interactable = false;

        JSONObject data = new JSONObject();
        data.AddField("clientId", clientInfo.clientId);
        data.AddField("roomId", clientInfo.roomId);
        socket.Emit("req_unready", data);
    }
#endregion

#region Etc.
    private void SetLog(string message) {
        Text logText = scrollRect.content.GetComponent<Text>();
        logText.text += message + "\n";
        Invoke("SetScrollDown", 0.1f);
    }

    private void SetScrollDown()
    {
        scrollRect.verticalNormalizedPosition = 0;
    }
#endregion
}
