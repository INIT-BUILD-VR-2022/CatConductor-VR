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
        scoreText.text = string.Format("0000", score.score);
    }
}
