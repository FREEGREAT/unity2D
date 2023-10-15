using UnityEngine;
using UnityEngine.SceneManagement;

public class Wolf : Entity
{
    [SerializeField]  private float radius = 5f; // Радіус поля зору ворога
    [SerializeField] private int lives = 1;
    [SerializeField] private float moveSpeed = 2f; // Швидкість руху ворога
    [SerializeField] private Transform player; // Посилання на гравця
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
            // Визначення напрямку до гравця
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            // Обчислення кута обертання
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Зміна напрямку обертання ворога
            Flip(angle);

            // Пересування ворога в напрямку гравця зі швидкістю moveSpeed
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void Flip(float angle)
    {
        if (angle > 90f || angle < -90f)
        {
            // Зміна напрямку обертання вліво
            spriteRenderer.flipX = false;
        }
        else
        {
            // Зміна напрямку обертання вправо
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
