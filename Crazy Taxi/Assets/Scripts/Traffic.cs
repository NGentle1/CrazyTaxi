using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour {


    private void Start()
    {
    }

    void Update()
    {
        if(Manager.gameState == true)
        transform.position += Vector3.back * Time.deltaTime * (int)Manager.getSpeed();
    }
   
}
