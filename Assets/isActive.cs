using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class isActive : Entity
{
    
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] lines;
    [SerializeField] float TextSpeed;


    private int index;
    void Start()
    {
        if (hero.Instance.transform.position.x >= 318)
        {
            text.text = string.Empty;
            StartDialog();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (hero.Instance.transform.position.x >= 318)
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
       
    }

    void StartDialog()
    {
        if (hero.Instance.transform.position.x >= 318)
        {
            index = 0;
            StartCoroutine(TypeLine());
        }
    }



    IEnumerator TypeLine()
    {
            if (hero.Instance.transform.position.x >= 318)
            {
                foreach (char c in lines[index].ToCharArray())
                {
                    text.text += c;
                    yield return new WaitForSeconds(TextSpeed);
                }
            }
                
    }


    void IsNextLine()
    {
            if (hero.Instance.transform.position.x >= 318)
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
}
