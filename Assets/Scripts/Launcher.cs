using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] private List<Ball> balls = new List<Ball>();
    private bool canLaunch = true;
    [SerializeField] private float delay;
    private float elapsaedTime;
    private int index = 0;
    [SerializeField] private CinemachineVirtualCamera camera;
    [SerializeField] private TMP_Text nextBallDisplay;

    private void Start()
    {
        ViewBall();
    }

    private void Update()
    {
        if (canLaunch)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Launch();
            }
        }
        else
        {
            elapsaedTime += Time.deltaTime;
            if (elapsaedTime > delay)
            {
                EndLaunch();
            }
        }
    }

    private void EndLaunch()
    {
        canLaunch = true;
        elapsaedTime = 0;
        camera.Priority = 1;
    }

    private void Launch()
    {
        canLaunch = false;
        Ball ball = Instantiate(balls[index], transform.position, transform.rotation).GetComponent<Ball>();
        index++;
        if (index >= balls.Count) index = 0;
        ball.Launch();

        camera.Priority = 20;

        ViewBall();
    }

    private void ViewBall()
    {
        
        nextBallDisplay.text = balls[index].name;
        nextBallDisplay.color = balls[index].color;
    }
}
