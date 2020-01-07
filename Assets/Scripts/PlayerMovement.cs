using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    public GameObject finish;
    public TextMeshProUGUI finishText;
    private Rigidbody rigidbody;

    private void Start() {
        finish.active = false;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = true;
    }
     
    private void Update() {
        if (!finish.activeInHierarchy) {
            Vector3 vTmp = new Vector3(-Input.GetAxis("Horizontal"), 0, 
                                       -Input.GetAxis("Vertical")) * (500 * Time.deltaTime);

            rigidbody.AddForce(vTmp);
        }

        if (transform.position.y < -6f) {
            FinishGame("You are dead!");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Pickable")) {
            UIManager.instance.Points += 1;

            other.transform.parent.gameObject.SetActive(false);
        }
        
        else if (other.CompareTag("Finish")) {
            FinishGame("You win!");
        }
    }

    private void FinishGame(string message) {
        finishText.text = message;
        finish.SetActive(true);
        
        rigidbody.useGravity = false;
    }
    
    public void ResetGame() {
        finish.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
