using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    //cached reference
    Level level;
   // GameStatus gameSts;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameStatus>().addToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        //gameSts = FindObjectOfType<GameStatus>();
        //gameSts.addToScore();
        Destroy(gameObject);

        level.BlockDestroyed();
    }
}
