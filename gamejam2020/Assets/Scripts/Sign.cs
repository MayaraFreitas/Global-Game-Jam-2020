using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sign : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;


    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            dialogBox.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
