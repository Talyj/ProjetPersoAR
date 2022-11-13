using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RA : MonoBehaviour
{
    public AudioSource audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        audiosrc.mute = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void soundOnOFF()
    {
        audiosrc.mute = !audiosrc.mute;
    }
}
