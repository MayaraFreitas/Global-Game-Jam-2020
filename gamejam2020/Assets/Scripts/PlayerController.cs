using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private static float _DialogTime = 7;

    public float moveSpeed;
    public bool canMove;
    public VectorValue startingPosition;
    public GameObject dialogBox;
    public List<Memory> chacacterMemories = new List<Memory>();

    private Animator anim;
    private bool dialogOn;
    private float dialogTime;
    private bool playerMoving;
    private Vector2 lastMove;
    private Rigidbody2D myRigidbody;

    public int sceneNumber;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        canMove = true;
        transform.position = startingPosition.initialValue;

        startScene();
    }

    // Update is called once per frame
    void Update()
    {

        if (dialogOn)
        {
            dialogTime -= Time.deltaTime;
            if (dialogTime <= 0)
                unactiveDialof();
        }

        if (!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }

        playerMoving = false;
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0.0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,  0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }

    void getMemory(Collider2D collision)
    {
        Memory memory = collision.transform.GetComponent<Memory>();
        activeDialog(memory.textMemory);
        memory.playerIcon.GetComponent<Image>().color = Color.white;
        chacacterMemories.Add(memory);
        Destroy(collision.transform.gameObject);
    }

    void activeDialog(string text)
    {
        dialogBox.GetComponentInChildren<UnityEngine.UI.Text>().text = text;
        dialogTime = _DialogTime;
        dialogBox.SetActive(true);
        dialogOn = true;
    }

    void unactiveDialof()
    {
        dialogBox.GetComponentInChildren<UnityEngine.UI.Text>().text = "";
        dialogBox.SetActive(false);
        dialogOn = false;
    }

    void startScene()
    {
        if (sceneNumber == 1)
        {
            activeDialog("Onde.... estou tonta... [Tente entender oque aconteceu procurando 3 fragmentos de memória antes de subir para o próximo andar]");
        }
        else if (sceneNumber == 1)
        {
            activeDialog("Elly... Preciso.. [Tente entender oque aconteceu procurando 2 fragmentos de memória antes de subir para o próximo andar]");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Memory")
        {
            getMemory(collision);
        }
        if (collision.gameObject.layer == 9) // Monster
        {
            SceneManager.LoadScene("Morte");
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {

    }
}
