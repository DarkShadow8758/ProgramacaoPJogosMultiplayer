using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class CameraController : NetworkBehaviour
{
    public Camera mainCam;
    public override void Spawned()
    {
        if (HasInputAuthority)
        {
            mainCam.enabled = true;
            mainCam.GetComponent<AudioListener>().enabled = true;
        }
        else
        {
            mainCam.enabled = false;
            mainCam.GetComponent<AudioListener>().enabled = false;   
        }
        base.Spawned();
    }
    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        base.Despawned(runner, hasState);
        if (HasInputAuthority)
        {
            mainCam.gameObject.SetActive(false);
        }
    }
}
