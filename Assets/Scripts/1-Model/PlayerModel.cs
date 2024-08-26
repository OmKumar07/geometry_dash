using UnityEngine;
public class PlayerModel
{
    public bool IsAlive { get; set; }
    public Vector3 RespawnPosition { get; set; }

    public PlayerModel(Vector3 initialRespawnPosition)
    {
        IsAlive = true;
        RespawnPosition = initialRespawnPosition;
    }
}
