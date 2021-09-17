using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;

    SceneLoader sl;
    Block block;

    private void Start()
    {
        sl = FindObjectOfType<SceneLoader>();
        block = FindObjectOfType<Block>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;

        if (breakableBlocks <= 0)
        {
            sl.LoadNextScene();
        }
    }
}
