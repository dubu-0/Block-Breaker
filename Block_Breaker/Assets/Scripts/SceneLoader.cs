using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // My (inefficient) way to load next scenes

    /* 
	
	Block[] remainingBlocks;
	private void Update()
	{
		remainingBlocks = FindObjectsOfType<Block>();

		if (remainingBlocks.Length == 0)
		{
			LoadNextScene();
		}
	} 
	
	*/

    GameSession status;

    private void Start()
    {
        status = FindObjectOfType<GameSession>();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadFirstScene()
    {
        status.ResetGame();
        SceneManager.LoadScene(0);
    }
}
