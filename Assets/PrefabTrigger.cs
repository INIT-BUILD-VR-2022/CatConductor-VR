using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTrigger : MonoBehaviour
{
    public GameObject[] volcanicPrefab;
    public string[] tags;
    public bool changeLevel = false;
    private int level = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            level++;
            changeLevel = true;
            Debug.Log(changeLevel);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (changeLevel)
        {
            if (other.CompareTag(tags[level - 1]))
            {
                Debug.Log("Destroy Activated");
                Destroy(other.gameObject);
            }

            if (other.CompareTag(tags[level]))
            {
                Debug.Log("lol Activated");
                other.GetComponent<MeshRenderer>().enabled = true;
            }
        }
        Debug.Log("OnTriggerEnter is Active");
        Debug.Log("level was: " + (level - 1));
        Debug.Log("level is: " + level);
    }
}
