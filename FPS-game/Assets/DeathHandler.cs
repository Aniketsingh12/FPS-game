using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas Gameover;
    void Start()
    {
        Gameover.enabled = false; 
    }

    // Update is called once per frame
    public void Handler()
    {
        Gameover.enabled=true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible =true;
    }
}
