using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartG : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            PlayGame();
        }
    }

}
