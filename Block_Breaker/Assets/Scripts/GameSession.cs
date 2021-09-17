using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [Range(0f, 1000f)] [SerializeField] int pointsPerBlock;
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] bool isAutoPlayEnabled;

    float fixedDeltaTime;
    int gameStatusCount;

    // Singleton Implementation
    private void Awake()
    {
        fixedDeltaTime = Time.fixedDeltaTime;

        gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        DisplayScore();
    }

    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = gameSpeed;
        Time.fixedDeltaTime = fixedDeltaTime * gameSpeed;
    }

    public void CountScore()
    {
        score += pointsPerBlock;
    }

    public void DisplayScore()
    {
        tmp.text = score.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
