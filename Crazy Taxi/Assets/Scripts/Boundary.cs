using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Traffic")
        {
            Destroy(other.gameObject);
            Manager.SetScore(Manager.increaseScore);
            Manager.diffCount++;
        }
        else {
            Destroy(other.gameObject);
        }
    }
}
