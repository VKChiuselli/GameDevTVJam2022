using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour {

    void Update() {
        if (Input.GetKeyDown(KeyCode.Y) && SceneManager.GetActiveScene().name == "LevelTwo") {
            GameObject toDestroy = FindObjectOfType<TVMovement>().gameObject;
            GameObject g = Instantiate(FindObjectOfType<TVMovement>().gameObject, transform.position, transform.rotation);
            g.transform.Rotate(0f, 100f, 0f);
            toDestroy.tag = "Finish";
            Destroy(toDestroy.GetComponent<TVMovement>());
        }else
        if (Input.GetKeyDown(KeyCode.Y) && SceneManager.GetActiveScene().name == "LevelOne") {
            GameObject toDestroy = FindObjectOfType<TableMovement>().gameObject;
            GameObject g = Instantiate(FindObjectOfType<TableMovement>().gameObject, transform.position, transform.rotation);
            g.transform.Rotate(0f, 0f, 90f);
            toDestroy.tag = "Finish";
            Destroy(toDestroy.GetComponent<TableMovement>());
        }else
        if (Input.GetKeyDown(KeyCode.Y) && SceneManager.GetActiveScene().name == "LevelThree") {
            SpawnSofa();
        }
    }

    public void SpawnSofa() {
        GameObject toDestroy = FindObjectOfType<SofaMovement>().gameObject;
        GameObject g = Instantiate(FindObjectOfType<SofaMovement>().gameObject, transform.position, transform.rotation);
        g.transform.Rotate(0f, 0f, 90f);
        toDestroy.tag = "Finish";
        Destroy(toDestroy.GetComponent<SofaMovement>());
    }
}
