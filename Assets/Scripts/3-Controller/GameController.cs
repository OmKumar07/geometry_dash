using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameModel gameModel;
    private PlayerModel playerModel;
    public float playerSpeed;
    public float speedIncreaseRate;
    public float jumpForce;
    public Vector3 spawnPoint;

    void Start()
    {
        gameModel = new GameModel(5f, 1f, 12f);
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
        gameModel.PlayerSpeed += Time.deltaTime * 0.1f;
        gameModel.IncreaseScore(Time.deltaTime * gameModel.PlayerSpeed);
    }
}
