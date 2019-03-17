using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeFall : MonoBehaviour
{

    public hintword fireCamp;

    IEnumerator Fall()
    {  
        yield return new WaitForSeconds(2);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(false);
    }


    public void fall() {

        GetComponent<Animator>().Play("treeFall");
        StartCoroutine(Fall());
        transform.GetChild(0).GetComponent<hintword>().hintWord = "沿著樹走過去吧 ";
        fireCamp.hintWord = "這火看來可以燒死木乃伊 ";


    }
}
