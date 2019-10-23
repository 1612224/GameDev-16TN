using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TrailerController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GetComponent<VideoPlayer>().loopPointReached += onTrailerEnd;       
    }

    private void onTrailerEnd(VideoPlayer source)
    {
        gameObject.SetActive(false);
    }
}
