using Photon.Pun;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public void StartGame()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public void GoToMenu()
    {
        PhotonNetwork.LoadLevel("Menu");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
