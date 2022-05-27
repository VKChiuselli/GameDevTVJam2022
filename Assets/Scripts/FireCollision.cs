using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour
{

    RespawnManager respawnManager;

    private void Start() {
        respawnManager = FindObjectOfType<RespawnManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            respawnManager.SpawnSofa();
        }
    }

}
