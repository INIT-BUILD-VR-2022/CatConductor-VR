using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTrigger : MonoBehaviour
{
    public GameObject[] volcanicPrefab;
    public string[] tags;
    private bool changeLevel = false;
    private int level = 0;

    public Transform child;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            level++;
            changeLevel = true;
            Debug.Log(changeLevel);
        }
    }

    public void changeTerrian()
    {
        level++;
        changeLevel = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (changeLevel)
        {
            if (other.CompareTag(tags[level - 1]))
            {
                Destroy(other.gameObject);
            }

            if (other.CompareTag(tags[level]))
            {
                other.GetComponent<MeshRenderer>().enabled = true;
                child = other.transform.GetChild(0);
                child.gameObject.SetActive(true);
            }
        }
        Debug.Log("OnTriggerEnter is Active");
        Debug.Log("level was: " + (level - 1));
        Debug.Log("level is: " + level);
    }
}
