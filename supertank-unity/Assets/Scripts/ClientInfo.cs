public class ClientInfo {
    public readonly string clientId;
    public string roomId;

    public ClientInfo(string clientId, string roomId) {
        this.clientId = clientId;
        this.roomId = roomId;
    }
}