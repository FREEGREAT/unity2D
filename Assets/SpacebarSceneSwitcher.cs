using UnityEngine;
using UnityEngine.SceneManagement;

public class SpacebarSceneSwitcher : MonoBehaviour
{
    // Назва сцени, на яку ви хочете перекинутися
    public string targetSceneName = "SampleScene";

    void Update()
    {
        // Перевіряємо, чи натиснута клавіша пробіл
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Завантажуємо цільову сцену
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
