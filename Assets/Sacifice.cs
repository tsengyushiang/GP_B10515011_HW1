using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacifice : MonoBehaviour
{
    public GameObject bridge;
    public hintword fire;

    private void OnTriggerEnter(Collider col) {

        if (col.gameObject.tag == "enemy") {
            Destroy(col.gameObject);
            bridge.SetActive(true);
            fire.hintWord = "一條新路被打開了";
        }

    }

}
