using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinGame : MonoBehaviour {
    public Text text;

    public int displayTime = 5;
    private float currentTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (text.IsActive()){
            currentTime += Time.deltaTime;

            if (currentTime >= displayTime) {
                currentTime = 0;

                text.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("you win");

            SceneManager.LoadScene(0);
            text.text = "You win!";
            text.enabled = true;
        }
    }
}
