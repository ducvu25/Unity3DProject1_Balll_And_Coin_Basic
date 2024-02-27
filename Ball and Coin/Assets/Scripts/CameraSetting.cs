using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{

    [SerializeField] GameObject goPlayer;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(goPlayer.transform.position);
    }
}
