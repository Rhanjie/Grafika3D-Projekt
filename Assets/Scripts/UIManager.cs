using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    static public UIManager instance;
    
    public Text pointsText;
    int points = 0;
    public int Points {
       get { return points; }
       set {
          points = value;
          pointsText.text = "POINTS: " + points.ToString();
       }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        points = 0;
    }
}
