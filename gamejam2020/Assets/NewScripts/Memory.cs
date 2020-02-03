using UnityEngine;

public class Memory : MonoBehaviour
{
    public int order;
    public string textMemory;
    public GameObject playerIcon;
    private Sprite icon;

    private void Start()
    {
        icon = transform.GetComponent<SpriteRenderer>().sprite;
        //addToDataBase(this);
    }
}
