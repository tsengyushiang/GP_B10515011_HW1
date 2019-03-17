using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
   
    void OnCollisionEnter(Collision coll)
    {
        GetComponent<AudioSource>().Play();
        if (coll.gameObject.tag == "enemy")
        {
            coll.gameObject.transform.Find("mummy_rig").GetComponent<Animator>().Play("jumpSplitted_F");
            coll.gameObject.GetComponent<Rigidbody>()
                .AddExplosionForce(100, coll.gameObject.transform.position, 100.0f, 3.0f);
        }
        else if (coll.gameObject.name == "Rock") {
            if (transform.parent.Find("Axe").gameObject.activeSelf) {
                Destroy(coll.gameObject);
            }
        }
    }
}
