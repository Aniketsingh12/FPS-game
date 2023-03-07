using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    PlayerHealth target;
    [SerializeField] float damage = 30f;
    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    void AttackHIt()
    {
        if(target == null) { return; }
        target.takeDamage(damage);

    }
}
