using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOffTrack : MonoBehaviour
{
    public void Detach(){
        transform.parent = null;
        StartCoroutine(LongGoodbye());
    }

 

    IEnumerator LongGoodbye(){
        yield return new WaitForSeconds(15f);
        Destroy(gameObject);
    }
}
