using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAudioSource : MonoBehaviour
{
    private int value;
    private float speed = 100;
    public GameObject audioListenerPos;
    public GameObject[] obstacles;
    public AudioSource[] audiosrcs;

    public enum state
    {
        Horizontal,
        Vertical,
        RotationHorizontale,
        RotationVerticale,
        Stop
    }
    public state etat;

    // Start is called before the first frame update
    void Start()
    {
        value = 100;
        etat = state.Stop;
    }

    // Update is called once per frame
    void Update()
    {
        switch (etat)
        {
            case state.Horizontal:
                HorizontalMove();
                break;
            case state.Vertical:
                VerticalMove();
                break;
            case state.RotationHorizontale:
                GoAround(Vector3.up);
                break;
            case state.RotationVerticale:
                GoAround(Vector3.left);
                break;
            case state.Stop:
                break;
        }
    }

    public void ChangeState() 
    {
        transform.position = new Vector3(0, 0, 0);
        etat = etat > state.RotationVerticale ? 0 : etat + 1;
    }
    
    public void ObstacleOnOff()
    {
        foreach(var obs in obstacles)
        {
            obs.SetActive(!obs.activeSelf);
        }
    }

    public void SoundOnOff()
    {
        foreach (var audio in audiosrcs)
        {
            audio.mute = !audio.mute;
        }
    }

    private void HorizontalMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(value, 0, 0), speed * Time.deltaTime);
        if (transform.position.x == value) value *= -1;
    }

    private void VerticalMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, value, 0), speed * Time.deltaTime);
        if (transform.position.y == value) value *= -1;
    }

    private void GoAround(Vector3 direction)
    {
        transform.RotateAround(audioListenerPos.transform.position, direction, speed * Time.deltaTime);
    }
}
