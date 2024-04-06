using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSlow : MonoBehaviour
{
    Vector3 ImpulseVector = new Vector3(0.0f, 5000.0f, 10000.0f);
    Vector3 spinVector = new Vector3(50000.0f, 50000.0f, 50000.0f);
    public rotation rotScript;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        rotScript.SlowDownRotation();
        if (other.gameObject.tag == "HitBox")
        {
            StartCoroutine(Collide());
        }
    }

    IEnumerator Collide()
    {


        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(rotScript.rotationSpeed * .25f);

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


