using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;

    //state variables
    [SerializeField] int timesHit;  //debug

   // GameStatus gameSts;

    private void Start()
    {
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNesxHitSprite();
        }
    }

    private void ShowNesxHitSprite()
    {
        int spriteIntex = timesHit - 1;
        if (hitSprites[spriteIntex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIntex];
        }
        else
        {
            Debug.LogError("Block sprite is missing form array"+gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameSession>().addToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        //gameSts = FindObjectOfType<GameStatus>();
        //gameSts.addToScore();
        TriggerSparklesVFX();
        Destroy(gameObject);

        level.BlockDestroyed();
    }

    public void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
