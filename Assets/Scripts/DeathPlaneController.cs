using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneController : MonoBehaviour
{
    public Transform spawnPosint;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<PlayerBehavior>();
            player.controller.enabled = false;
            player.transform.position = spawnPosint.position;
            player.controller.enabled = true;
        }
    }
}
