using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

    public Text scoreText;
    public Text speedText;
    public Slider offRoad;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + Manager.GetScore().ToString();
        speedText.text = "Speed: " + Manager.getSpeed().ToString();
        offRoad.value = PlayerMovement.getOffRoadTime();
    }
}
