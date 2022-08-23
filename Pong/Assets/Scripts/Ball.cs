using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float maxInitialAngle = 0.67f;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float maxStartY = 4f;

    private float startX = 0f;

    private void Start()
    {
        InitialPush();
    }

    private void InitialPush() {
        Vector2 dir = Random.value < 0.5f ? Vector2.left : Vector2.right;
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.velocity = dir * moveSpeed;
    }

    private void Resetball()
    {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone) {
            gameManager.OnScoreZoneReached(scoreZone.id);
            Resetball();
            InitialPush();
        }

    }
}
