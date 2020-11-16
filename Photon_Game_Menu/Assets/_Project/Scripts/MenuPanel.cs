using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] PanelName panelName;
    public PanelName PanelName => panelName;
    Transform content;

    private void Awake()
    {
        content = transform.GetChild(0);
    }

    public void TooglePanel(bool show)
    {
        content.gameObject.SetActive(show);
    }
}

public enum PanelName
{
    Username,
    Menu,
    RoomsList,
    RoomCreation,
    RoomCreationFailed,
    Room,
    Disconnected
}