using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    //public CartStats cartStats;
    Vector3 ImpulseVector = new Vector3(0.0f, 5000.0f, 10000.0f);
    Vector3 spinVector = new Vector3(50000.0f, 50000.0f, 50000.0f);

    public rotation rotScript;


    void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Collide());
        }
        
        
    }

    IEnumerator Collide()
    {

        
        
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(rotScript.rotationSpeed * .75f);

        Time.timeScale = 1;

        
        transform.parent = null;
        GetComponent<Rigidbody>().AddForce(ImpulseVector, ForceMode.Force);
        GetComponent<Rigidbody>().AddTorque(spinVector, ForceMode.Force);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Collider>().enabled = false; 

        yield return new WaitForSecondsRealtime(3f);
        Destroy(gameObject);
        
    }
}
