using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(AudioSource))]
public class Signalization : MonoBehaviour
{
    private AudioSource _soundtrack;
    private BoxCollider _alertTrigger;
    private bool _alert = false;

    void Start()
    {
        _soundtrack = GetComponent<AudioSource>();
        _alertTrigger = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            _alert = true;
            _soundtrack.Play();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<PlayerMover>(out PlayerMover player))
        {
            _alert = false;
        }
    }

    private void Update()
    {
        if (_soundtrack.isPlaying)
        {
            ChangeVolume();
        }        
    }

    private void ChangeVolume() 
    {
        if (_alert == true)
        {
            _soundtrack.volume += Mathf.Lerp(0, 1, Time.deltaTime * 0.2f);
        }
        else
        {
            _soundtrack.volume -= Mathf.Lerp(0, 1, Time.deltaTime * 0.2f);
            if (_soundtrack.volume == 0f)
            {
                _soundtrack.Pause();
            }
        }       
    }
}
