using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{

    private MusicController theMC;

    public int newTrack;

    public bool switchOnStart;

    // Start is called before the first frame update
    void Start()
    {
        theMC = FindObjectOfType<MusicController>();

        if (switchOnStart)
        {
            theMC.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            theMC.SwitchTrack(newTrack);
            gameObject.SetActive(false);
        }
    }
}
