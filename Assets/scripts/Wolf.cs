using UnityEngine;
using UnityEngine.SceneManagement;

public class Wolf : Entity
{
    [SerializeField]  private float radius = 5f; // ����� ���� ���� ������
    [SerializeField] private int lives = 1;
    [SerializeField] private float moveSpeed = 2f; // �������� ���� ������
    [SerializeField] private Transform player; // ��������� �� ������
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isDead = false; 

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isDead)
            return; 

        
        bool isPlayerInView = Physics2D.OverlapCircle(transform.position, radius, LayerMask.GetMask("Heroes"));

       
        animator.SetBool("move", isPlayerInView);

        if (isPlayerInView)
        {
            // ���������� �������� �� ������
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // ���������� ���� ���������
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // ���� �������� ��������� ������
            Flip(angle);

            // ����������� ������ � �������� ������ � �������� moveSpeed
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void Flip(float angle)
    {
        if (angle > 90f || angle < -90f)
        {
            // ���� �������� ��������� ����
            spriteRenderer.flipX = false;
        }
        else
        {
            // ���� �������� ��������� ������
            spriteRenderer.flipX = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == hero.Instance.gameObject)
        {
            hero.Instance.GetDamage();
        }


    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == hero.Instance.gameObject)
        {
            lives--;
        }
        if (lives == 0)
        {
            Die();
        }

    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
