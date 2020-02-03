using UnityEngine;

public class DrontDestroy : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
