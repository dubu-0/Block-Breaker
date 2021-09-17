using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float PaddleWidthInPixels;
    [SerializeField] float PaddlePixelsPerUnit;

    float min;
    float max;
    float PaddleWidthInUnits;
    float ScreenWidthInUnits;

    bool autoplay;
    Ball ball;

    // Start is called before the first frame update
    private void Start()
    {
        ScreenWidthInUnits = (Camera.main.orthographicSize * 2) * 4 / 3;
        PaddleWidthInUnits = PaddleWidthInPixels / PaddlePixelsPerUnit;
        min = PaddleWidthInUnits / 2;
        max = ScreenWidthInUnits - PaddleWidthInUnits / 2;
        autoplay = FindObjectOfType<GameSession>().IsAutoPlayEnabled();
        ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(GetXPos(), min, max), transform.position.y);
    }

    float GetXPos()
    {
        if (autoplay)
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        }
    }
}
