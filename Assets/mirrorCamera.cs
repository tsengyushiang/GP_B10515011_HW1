using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirrorCamera : MonoBehaviour
{
    public Transform target;
    public Transform obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        var deltPos=obj.transform.position - target.transform.position;
        transform.position = target.transform.position+ new Vector3(deltPos.x, deltPos.y, -deltPos.z);

    }
}
