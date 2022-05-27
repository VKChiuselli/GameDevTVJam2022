using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour {

    [SerializeField] GameObject vfxWin;
    [SerializeField] AudioClip sound;
    [SerializeField] AudioSource paAudioSource;
    [SerializeField] float delaySound=0.3f;


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            vfxWin.SetActive(true);
            Invoke("Sound", delaySound);
            Invoke("NextLevel", 2.3f);
        }
    }

    private void Sound() {
        paAudioSource.PlayOneShot(sound);
    }

    public void NextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void Update() {
        RestartLevel();
    }

    private void RestartLevel() {
        if (Input.GetKeyDown(KeyCode.O)) {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
