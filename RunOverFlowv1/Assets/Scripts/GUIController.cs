using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIController : MonoBehaviour
{

    Text StatusText,masterText;

    // Use this for initialization
    void Start()
    {
        StatusText = GameObject.Find("StatusText").GetComponent<Text>();
        masterText = GameObject.Find("masterText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        StatusText.text = "Status :" + PhotonNetwork.connectionStateDetailed.ToString();
        masterText.text = "isMaster :" + PhotonNetwork.isMasterClient;
    }
}
