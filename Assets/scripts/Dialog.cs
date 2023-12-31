using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] lines;
    [SerializeField] float TextSpeed;

    public static Dialog Instance { get; set; }

    public int index = 0;
    void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        text.text = string.Empty;
        StartDialog();
    }

    // Update is called once per frame
    public void Update()
    {
       
            if (Input.GetMouseButtonDown(0))
            {
                if (text.text == lines[index])
                {
                    IsNextLine();

                }
                else
                {
                    StopAllCoroutines();
                    text.text = lines[index];
                }
            } 
    }

    void StartDialog()
    {
        StartCoroutine(TypeLine());
    }



    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }
    }


    void IsNextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
