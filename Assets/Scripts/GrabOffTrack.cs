using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabOffTrack : MonoBehaviour
{
    public void Detach(){
        transform.parent = null;
    }

    public void Destroy(){
        StartCoroutine(LongGoodbye());
    }

    IEnumerator LongGoodbye(){

        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
