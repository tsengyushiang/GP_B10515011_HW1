using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        Debug.Log(coll.gameObject.name);
        if (coll.gameObject.name == "hit")
        {
            transform.GetComponent<AudioSource>().Play();
        }
    }
}
