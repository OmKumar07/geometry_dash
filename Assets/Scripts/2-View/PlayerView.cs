using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject destroyEffect;
    private SpriteRenderer player;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        player = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            PlayDeathAnimation();
            StartCoroutine(playerController.KillPlayer());
        }   
    }
    public void UpdatePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void ResetPlayer()
    {
        destroyEffect.SetActive(false);
        player.enabled = true;
    }

    public void PlayDeathAnimation()
    {
        destroyEffect.SetActive(true);
        player.enabled = false;
    }

}
