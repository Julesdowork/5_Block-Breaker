using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    // Cached reference
    Level level;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Breakable"))
        {
            DestroyBlock();
        }
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (gameObject.CompareTag("Breakable"))
        {
            level.CountBlocks();
        }
    }

    private void DestroyBlock()
    {
        PlayDestroySFX();
        TriggerSparkles();
        Destroy(gameObject);
        level.BlockDestroyed();
    }

    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }

    private void PlayDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddToScore();
    }
}
