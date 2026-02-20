using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;



public class CustomTrackableEventHandler : DefaultObserverEventHandler {    

    [SerializeField] private AudioSource audioSource;

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        audioSource.Play();
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        audioSource.Stop();
    }
}