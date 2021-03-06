﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPerso : MonoBehaviour {

    private Vector3 _correctPlayerPos;
    private Quaternion _correctPlayerRot;
    private PhotonView _view;

    void Start()
    {
        _view = GetComponent<PhotonView>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!_view.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, this._correctPlayerPos, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(transform.rotation, this._correctPlayerRot, Time.deltaTime * 5);
        }
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

        }
        else
        {
            // Network player, receive data
            this._correctPlayerPos = (Vector3)stream.ReceiveNext();
            this._correctPlayerRot = (Quaternion)stream.ReceiveNext();
        }
    }
}
