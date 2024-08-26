using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameModel gameModel;
    private PlayerModel playerModel;
    public float playerSpeed;
    public float speedIncreaseRate;
    public float jumpForce;
    public Vector3 spawnPoint;
    [SerializeField]
    private float score;

    void Start()
    {
        gameModel = new GameModel(playerSpeed, speedIncreaseRate, jumpForce);
        playerModel = new PlayerModel(spawnPoint);
    }

    void Update()
    {
        if (playerModel.IsAlive)
        {
            UpdateGame();
        }
    }

    void UpdateGame()
    {
        gameModel.IncreaseSpeed(Time.deltaTime * 0.1f);
        gameModel.IncreaseScore(Time.deltaTime * gameModel.PlayerSpeed);
        score = gameModel.Score;
    }
}
