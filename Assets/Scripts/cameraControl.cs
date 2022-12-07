using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    public Transform player;
    Vector3 camVec;
    public int camSpeed = 25;

    private void Start()
    {
        camVec = new Vector3(0, 0, -10);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,player.transform.position + camVec, camSpeed * Time.deltaTime);
    }
}
