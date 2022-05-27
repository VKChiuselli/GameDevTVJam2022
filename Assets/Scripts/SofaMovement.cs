using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaMovement : MonoBehaviour {

    public float movementSpeed = 5.0f;
    public float jumpSpeed = 0.3f;
    public float clockwise = 1000.0f;
    public float counterClockwise = -5.0f;
    [SerializeField] GameObject firevfx;
    [SerializeField] AudioClip sound;
    [SerializeField] AudioSource paAudioSource;


    void Update() {
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * Time.deltaTime * movementSpeed;
        }

        if (Input.GetKey(KeyCode.Space)) {
            transform.position += Vector3.up * Time.deltaTime * jumpSpeed;
        }
    }

    private void OnDisable() {
        GameObject g = Instantiate(firevfx, transform.position, transform.rotation);
        paAudioSource.PlayOneShot(sound);
        Destroy(g, 0.5f);
    }
}