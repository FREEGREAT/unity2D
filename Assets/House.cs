using UnityEngine;
using UnityEngine.SceneManagement;

public class House : MonoBehaviour
{
   [SerializeField] public GameObject player; // ��������� �� ��������� �����

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == hero.Instance.gameObject)
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
