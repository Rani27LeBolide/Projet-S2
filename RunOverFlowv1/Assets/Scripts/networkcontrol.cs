using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class networkcontrol : MonoBehaviour {

    // Use this for initialization
    private string _gameversion = "0.1";
    public GameObject sorcierPrefab;
	void Start () {
        PhotonNetwork.ConnectUsingSettings(_gameversion);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void OnJoinedLobby()
    {
        Debug.Log("On tente une connexion a une room aleatoire");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join Random room, on en créer une");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("on vient de rejoindre une room");
        PhotonNetwork.Instantiate("Prefabs/" + sorcierPrefab.name, sorcierPrefab.transform.position,sorcierPrefab.transform.rotation, 0);
    }
}
