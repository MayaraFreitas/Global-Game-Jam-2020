﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;

    public bool dialogActive;

    public string[] dialogueLines;
    public int currentLine;

    private PlayerController thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyUp(KeyCode.Space)) 
        {
            //dBox.SetActive(false);
            //dialogActive = false;

            currentLine++;
        }

        if(currentLine >= dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;
            thePlayer.canMove = true;
        }

        dText.text = dialogueLines[currentLine];
    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
