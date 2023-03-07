using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] float health = 100f;

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            GetComponent<DeathHandler>().Handler();
                           
        }

    }
}
