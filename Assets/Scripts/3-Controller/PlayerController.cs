using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel playerModel;
    public GameModel gameModel;
    private PlayerView playerView;
    private Rigidbody2D rb;

    void Start()
    {
        playerView = GetComponent<PlayerView>();
        rb = GetComponent<Rigidbody2D>();
        playerModel = new PlayerModel(Vector3.zero);
        gameModel = new GameModel(5f, 1f, 12f);
    }

    void Update()
    {
        if (playerModel.IsAlive)
        {
            HandleInput();
        }
        else
        {
            RespawnPlayer();
        }
    }

    void HandleInput()
    {
        MoveForward();

        if (Input.GetKeyDown(KeyCode.Space) && gameModel.IsGrounded)
        {
            Jump();
        }
    }

    void MoveForward()
    {
        rb.velocity = new Vector2(gameModel.PlayerSpeed, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, gameModel.JumpForce);
        gameModel.IsGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            gameModel.IsGrounded = true;
        }
    }

    public IEnumerator KillPlayer()
    {
        yield return new WaitForSeconds(1);
        gameModel.PlayerSpeed = 5f;
        playerModel.IsAlive = false;
        playerView.ResetPlayer();
    }

    void RespawnPlayer()
    {
        playerModel.IsAlive = true;
        playerView.UpdatePosition(playerModel.RespawnPosition);
    }
}
