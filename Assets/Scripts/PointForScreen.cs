using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointForScreen : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public CartStats score;

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = score.score.ToString();
        Debug.Log("The score is " + scoreText.text);

    }
}
