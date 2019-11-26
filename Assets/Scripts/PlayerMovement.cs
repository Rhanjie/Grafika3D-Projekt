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

    private void Start() {
        finish.active = false;
    }
    
    private void Update() {
        if (!finish.activeInHierarchy) {
            Vector3 vTmp = new Vector3(-Input.GetAxis("Horizontal"), 0, 
                                       -Input.GetAxis("Vertical")) * (500 * Time.deltaTime);

            GetComponent<Rigidbody>().AddForce(vTmp);
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

    public void FinishGame(string message) {
        finishText.text = message;
        finish.SetActive(true);
    }
    
    public void ResetGame() {
        finish.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
