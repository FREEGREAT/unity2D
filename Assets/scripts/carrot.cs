using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class carrot : MonoBehaviour
{
    private int carr = 0;
    [SerializeField] private Text Score;

    private void OnTriggerEnter2D(Collider2D collisinon)
    {
        if (collisinon.tag == "Carrot")
        {
            carr+=1;
            Destroy(collisinon.gameObject);
            Score.text = "Carrot: " + carr;
        }
    }
}
