using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    private static int score;
    private static double speed;
    public static bool gameState, doubleCar;
    float trafficUpdate, sidewalkUpdate;
    int laneNum,laneNum2, doubleCarInt, sidewalkNum,sidewalkNumSide;
    public static int difficulty, diffCount,increaseScore;
    private Quaternion spawnRotation;

    void Start () {
        score = 0;
        increaseScore = 1;
        gameState = true;
        trafficUpdate = 0;
        sidewalkUpdate = 0;
        spawnRotation = Quaternion.Euler(90, 0, 0);
    }

    public static void SetScore(int amount) {
        score += amount;
    }
    public static int GetScore()
    {
        return score;
    }

    public static void gameOver() {
        gameState = false;
    }

    public static double getSpeed() {
        speed = 2 + .2 * (score/5);
        return speed;
    }

    void Update()
    {
        if (Time.time - trafficUpdate >= 1f && gameState == true)
        {
            doubleCarInt = Random.Range(0, 2);
            laneNum = Random.Range(-1, 2);
            do
            {
                laneNum2 = Random.Range(-1, 2);
            } while (laneNum2 == laneNum);
            trafficUpdate = Time.time;
            if(score > 150)
            {
                Instantiate(Resources.Load("Traffic"), new Vector3(laneNum, .5f, 4f), transform.rotation);
                if (doubleCarInt == 1 && score > 10)
                {
                    Instantiate(Resources.Load("Traffic"), new Vector3(laneNum2, .5f, 4f), transform.rotation);

                }
            }
            else
            {
                Instantiate(Resources.Load("Traffic"), new Vector3(laneNum, .5f, 4f), transform.rotation);
                Instantiate(Resources.Load("Traffic"), new Vector3(laneNum2, .5f, 4f), transform.rotation);
            }
           
        }
        if (Time.time - sidewalkUpdate >= 2.3f && gameState == true) {
            sidewalkUpdate = Time.time;
            sidewalkNum = Random.Range(0,10);
            sidewalkNumSide = Random.Range(1, 2);
            if (sidewalkNum == 7 && sidewalkNumSide == 1){
                Instantiate(Resources.Load("Parkinglot"), new Vector3(-2.2f, .01f, 4f), spawnRotation);
                Instantiate(Resources.Load("Streetlight"), new Vector3(2f, .5f, 4f), transform.rotation);
            }
            else if (sidewalkNum == 7 && sidewalkNumSide == 2) {
                Instantiate(Resources.Load("Streetlight"), new Vector3(-2f, .5f, 4f), transform.rotation);
                Instantiate(Resources.Load("Parkinglot"), new Vector3(2.2f, .01f, 4f), spawnRotation);
            }
            else
            {
                Instantiate(Resources.Load("Streetlight"), new Vector3(-2f, .5f, 4f), transform.rotation);
                Instantiate(Resources.Load("Streetlight"), new Vector3(2f, .5f, 4f), transform.rotation);
            }

        }

    }

}
