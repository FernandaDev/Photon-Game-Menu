using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : ServerLauncher
{
    [SerializeField] TMP_Text currentRoomNameText;
    [SerializeField] Transform startGameButton;
    [SerializeField] Transform loadingText;
    [SerializeField] Transform panelsTransform;
    
    Dictionary<PanelName, MenuPanel> panels = new Dictionary<PanelName, MenuPanel>();
    string currentRoomName;

    private void Awake()
    {
        foreach (Transform panel in panelsTransform)
        {
            var currPanel = panel.GetComponent<MenuPanel>();
            if (currPanel)
                panels.Add(currPanel.PanelName, currPanel);
        }
    }

    void ShowPanel(PanelName panelToShow, bool shouldShow) => panels[panelToShow].TooglePanel(shouldShow);

    public override void ConnectToMaster()
    {
        base.ConnectToMaster();
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master.");
        loadingText.gameObject.SetActive(false);
        ShowPanel(PanelName.Menu, true);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        ShowPanel(PanelName.Disconnected, true);
    }

    public override void JoinRoom(RoomInfo info)
    {
        base.JoinRoom(info);
        ShowPanel(PanelName.Room, true);
        currentRoomNameText.text = info.Name;
        startGameButton.gameObject.SetActive(IsMaster);
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(currentRoomName))
            currentRoomName = $"{Nickname}'s Room";

        base.CreateRoom(currentRoomName);
        currentRoomNameText.text = currentRoomName;

        ShowPanel(PanelName.RoomCreation, false);
        ShowPanel(PanelName.Room, true);
    }

    public void CancelRoomCreation()
    {
        currentRoomName = "";
        ShowPanel(PanelName.RoomCreation, false);
        ShowPanel(PanelName.Menu, true);
    }

    public override void LeaveRoom()
    {
        base.LeaveRoom();

        currentRoomName = "";
        ShowPanel(PanelName.Room, false);
        ShowPanel(PanelName.Menu, true);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Failed to join the room - <color=red>{message}</color>");
        ShowPanel(PanelName.RoomCreationFailed, true);
    }

    public override void OnNicknameChange(string newNickname)
    {
        base.OnNicknameChange(newNickname);
    }

    public void OnRoomNameChange(string roomName)
    {
        currentRoomName = roomName;
    }
}
