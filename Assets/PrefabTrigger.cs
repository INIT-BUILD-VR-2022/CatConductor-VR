using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTrigger : MonoBehaviour
{
    public GameObject[] volcanicPrefab;
    public string[] tags;
    private bool changeLevel = false;
    private int level = 0;
    private int prevLevel = -1;

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
        prevLevel = level - 1;

        if(level >= tags.Length){
            level = 0;
        }
        changeLevel = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (changeLevel)
        {
            if (other.CompareTag(tags[prevLevel]))
            {
                other.GetComponent<MeshRenderer>().enabled = false;
                child = other.transform.GetChild(0);
                child.gameObject.SetActive(false);
            }

            if (other.CompareTag(tags[level]))
            {
                other.GetComponent<MeshRenderer>().enabled = true;
                child = other.transform.GetChild(0);
                child.gameObject.SetActive(true);
            }
        }
        
    }
}
