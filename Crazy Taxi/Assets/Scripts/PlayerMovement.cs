using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    int counter,minOffRoad,maxOffRoad;
    private static int offRoadTime;
    bool onRoad;
    float lastUpdate;

    Rigidbody playerRigidbody;


    private void Start()
    {
        lastUpdate = 0;
        counter = 0;
        offRoadTime = 0;
        onRoad = true;
        minOffRoad = 0;
        maxOffRoad = 3;
    }

    // Update is called once per frame
    void Update() {
        if (Manager.gameState == true) { 
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left")){
                if (counter > -1) {
                    moveLeft();
                   // Debug.Log("Moving Left, Counter: "+ counter);
                }
                else if (counter == -1) {
                    offRoadLeft();
                   // Debug.Log("going off road left, Counter: "+ counter);
                }     
            }
            if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
            {
                if (counter < 1) {
                    moveRight();
                  //  Debug.Log("Moving right, Counter: " + counter);
                }
                else if (counter == 1) {
                    offRoadRight();
                   // Debug.Log("going off road right, Counter: " + counter);
                }
            }

            if (onRoad == false && offRoadTime == 0 && counter == -2)
            {
                moveRight();
            }
            if (onRoad == false && offRoadTime == 0 && counter == 2)
            {
                moveLeft();
            }
            if (Time.time - lastUpdate >= 1f) {
                lastUpdate = Time.time;
                if (onRoad == false && offRoadTime > minOffRoad) { offRoadTime--; }
                    
                if (onRoad == true && offRoadTime < maxOffRoad) { offRoadTime++; }
                Debug.Log(onRoad);
            }
            if (counter != -2 && counter != 2) {
                onRoad = true;
            }
        }

}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Traffic")
        {
            Destroy(gameObject);
            Manager.gameOver();
        }
        if (other.gameObject.tag == "Streetlight") {
            Destroy(gameObject);
            Manager.gameOver();
        }
        if (other.gameObject.tag == "Parkinglot") {
            Destroy(other.gameObject);
            Manager.increaseScore++;
        }
    }
    public static int getOffRoadTime() {
        return offRoadTime;
    }

    void offRoadLeft() {
        moveLeft();
        onRoad = false;
    }

    void offRoadRight()
    {
        moveRight();
        onRoad = false;
    }
    public void moveLeft() {
        transform.position += Vector3.left;
        counter--;
    }
    public  void moveRight() {
        transform.position += Vector3.right;
        counter++;
    }
}
