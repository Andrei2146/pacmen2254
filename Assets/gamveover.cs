using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamveover : MonoBehaviour
{

    public Text points;
   public void Setup(int score)
    {
        gameObject.SetActive(true);
        points.text = score.ToString() + "Points";
    }
}
