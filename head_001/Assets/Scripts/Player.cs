using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterHp: MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool isJumping = false;
    private Rigidbody2D rb;

    private string initialSceneName;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        initialSceneName = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        // ĳ���� �̵�
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� �� ���� ���� �� �ٴڿ� ������ ����
        if (collision.gameObject.CompareTag("Reset"))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(initialSceneName);
    }
}
