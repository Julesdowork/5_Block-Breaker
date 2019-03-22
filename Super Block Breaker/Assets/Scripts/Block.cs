using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;

    // State variables
    [SerializeField] int timesHit;      // only serialized for debugging purposes

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Breakable"))
        {
            HandleHit();
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

    private void HandleHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
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

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
}
