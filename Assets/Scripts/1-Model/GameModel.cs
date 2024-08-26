public class GameModel
{
    public float PlayerSpeed { get; set; }
    public float Score { get; private set; }
    public float SpeedIncreaseRate { get; private set; }
    public float JumpForce { get; private set; }
    public bool IsGrounded { get; set; }

    public GameModel(float playerSpeed, float speedIncreaseRate, float jumpForce)
    {
        PlayerSpeed = playerSpeed;
        SpeedIncreaseRate = speedIncreaseRate;
        JumpForce = jumpForce;
        Score = 0f;
        IsGrounded = true;
    }

    public void IncreaseScore(float amount)
    {
        Score += amount;
    }

    public void IncreaseSpeed(float amount)
    {
        PlayerSpeed += amount;
    }

    public void SetJumpForce(float jumpForce)
    {
        JumpForce = jumpForce;
    }
}
