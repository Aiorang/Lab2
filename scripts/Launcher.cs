using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject loginUI;
    public GameObject nameUI;
    public InputField roomID;
    public InputField playername;
    public GameObject play;
    public GameObject load;

    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        //nameUI.SetActive(true);
        play.SetActive(true);
    }

    public void openUI()
    {
        nameUI.SetActive(true);
        play.SetActive(false);
    }

    public void closeUI()
    {
        nameUI.SetActive(false);
        loginUI.SetActive(false);
        play.SetActive(true);
    }

    public void playButton()
    {
        nameUI.SetActive(false);
        PhotonNetwork.NickName = playername.text;
        loginUI.SetActive(true);
    }

    public void joinorcreate()
    {
        load.SetActive(true);
        SceneManager.LoadScene(1);
        if (roomID.text.Length < 2)
            return;
        loginUI.SetActive(false);

        RoomOptions options = new RoomOptions { MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomID.text, options,default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

}
