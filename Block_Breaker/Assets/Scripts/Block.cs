using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("Hit Sprites")]
    [SerializeField] Sprite[] hitSprites;

    [Header("SFX")]
    [SerializeField] AudioClip destroySound;
    [SerializeField] float volume;

    [Header("VFX")]
    [SerializeField] GameObject blockSparclesVFX;
    [SerializeField] float destroyVFXDelay;

    [Header("Hits")]
    [SerializeField] int maxHits;

    Level level;
    GameSession status;

    [SerializeField] int hits = 0; // serialized for debugging purposes

    private void Awake()
    {
        level = FindObjectOfType<Level>();
    }

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    void HandleHit()
    {
        hits++;

        if (hits >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    void ShowNextHitSprite()
    {
        int spriteIndex = hits - 1;

        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError($"Block sprite is missing from array. Block name: {name}");
        }
    }

    void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }

        status = FindObjectOfType<GameSession>();
    }


    void PlayParticleAnimation()
    {
        GameObject sparcles = Instantiate(blockSparclesVFX, transform.position, transform.rotation);
        Destroy(sparcles, destroyVFXDelay);
    }

    void DestroyBlock()
    {
        PlayDestroySound();
        DisplayScore();
        PlayParticleAnimation();
        Destroy(gameObject);
        level.BlockDestroyed();
    }

    void PlayDestroySound()
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position, volume);
    }

    void DisplayScore()
    {
        status.CountScore();
        status.DisplayScore();
    }
}
