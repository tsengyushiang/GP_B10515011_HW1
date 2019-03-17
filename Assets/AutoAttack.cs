using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    public float mvoeSpeed;
    public float sounddis;
    Transform target;

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.name == "Player") {
            target = collider.gameObject.transform;
            transform.parent.Find("mummy_rig").GetComponent<Animator>().Play("run");
        }
    }

    private void OnTriggerExit(Collider collider)
    {

        if (collider.gameObject.name == "Player")
        {
            target =null;
            transform.parent.Find("mummy_rig").GetComponent<Animator>().Play("idle03");
            transform.parent.GetComponent<Rigidbody>().velocity=Vector3.zero;
        }
    }

    void Update() {


        if (target != null)
        {
            if (Vector3.Distance(target.position, transform.position) < sounddis) GetComponent<AudioSource>().Play();
            transform.parent.Find("mummy_rig").transform.LookAt(target);
            var vec = (transform.parent.Find("mummy_rig").transform.forward) * mvoeSpeed;
            vec.y = transform.parent.GetComponent<Rigidbody>().velocity.y;
            transform.parent.GetComponent<Rigidbody>().velocity = vec;
        }

    }

}
