using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text stateText;
    public GameObject moveAudioSource;
    private MoveAudioSource mas;


    public GameObject cameraPos;
    public Slider CameraX;
    public Slider CameraY;
    public Slider CameraZ;

    // Start is called before the first frame update
    void Start()
    {
        mas = moveAudioSource.GetComponent<MoveAudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        stateText.text = mas.etat.ToString();
        cameraPos.transform.position = Vector3.MoveTowards(cameraPos.transform.position, new Vector3(CameraX.value, CameraY.value, CameraZ.value), 100 * Time.deltaTime);
    }

    public void ResetPosition()
    {
        CameraX.value = 0;
        CameraY.value = 1;
        CameraZ.value = -50;
    }
}
