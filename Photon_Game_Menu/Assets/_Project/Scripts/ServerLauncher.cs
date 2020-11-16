using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ServerLauncher : MonoBehaviourPunCallbacks
{
    public string Nickname => PhotonNetwork.NickName;
    public bool IsMaster => PhotonNetwork.IsMasterClient;

    #region Connection

    public virtual void ConnectToMaster()
    {
        Debug.Log("Starting connecting...");
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected. - "+ cause.ToString());
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        
    }

    #endregion

    #region Room

    public virtual void OnNicknameChange(string newNickname)
    {
        PhotonNetwork.NickName = newNickname;
    }

    public virtual void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
    }

    public virtual void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    public virtual void LeaveRoom()
    {
        Debug.Log("Left the room");
        PhotonNetwork.LeaveRoom();
    }

    #endregion
}
