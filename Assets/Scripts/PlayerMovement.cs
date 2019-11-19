using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {
    
    
    
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Vector3 vTmp = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")) * 500 * Time.deltaTime;
        
        GetComponent<Rigidbody>().AddForce(vTmp);

        if (transform.position.y < -6f) {
            Debug.Log("game over");

            SceneManager.LoadScene(0);
        }
    }
}
