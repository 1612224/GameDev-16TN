using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TrailerController : MonoBehaviour
{
    public GameObject VideoTrailer;
    public GameObject MenuUI;

    private bool trailerFinished = false;

    private void Start()
    {
        VideoTrailer.GetComponent<VideoPlayer>().loopPointReached += onTrailerEnd;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            skipTrailer();
        }
    }

    private void onTrailerEnd(VideoPlayer source)
    {
        skipTrailer();
    }

    private void skipTrailer()
    {
        if (!trailerFinished)
        {
            VideoTrailer.SetActive(false);
            MenuUI.SetActive(true);
            trailerFinished = true;
        }
    }
}
