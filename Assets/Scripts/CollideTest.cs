using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideTest : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
       
        print(other.gameObject);
        
    }
}
