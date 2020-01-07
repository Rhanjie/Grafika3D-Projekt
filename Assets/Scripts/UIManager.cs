using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    
    public Text pointsText;
    private int points = 0;
    public int Points {
       get { return points; }
       set {
          points = value;
          pointsText.text = "POINTS: " + points.ToString();
       }
    }

    void Start() {
        instance = this;
        points = 0;
    }
}
