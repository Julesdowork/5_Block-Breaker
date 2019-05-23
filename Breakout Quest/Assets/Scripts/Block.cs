using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] Sprite[] hitSprites;
    int maxHits;

    Level level;

    [SerializeField] int timesHit;  // TODO deserialize this

    // Start is called before the first frame update
    void Start()
    {
        CountBreakableBlocks();
        maxHits = hitSprites.Length + 1;
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
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
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
