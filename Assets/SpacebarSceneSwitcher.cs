using UnityEngine;
using UnityEngine.SceneManagement;

public class SpacebarSceneSwitcher : MonoBehaviour
{
    // ����� �����, �� ��� �� ������ ������������
    public string targetSceneName = "SampleScene";

    void Update()
    {
        // ����������, �� ��������� ������ �����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ����������� ������� �����
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
