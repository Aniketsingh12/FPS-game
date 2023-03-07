using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons : MonoBehaviour
{
    [SerializeField] Camera FPcam;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    public ParticleSystem mesh;
    public GameObject hiteffect;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        ParticalEffect();
        Hiting();

    }

    void ParticalEffect()
    {
        mesh.Play();
    }

    private void Hiting()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPcam.transform.position, FPcam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Hited(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target == null) { return; }
            target.takeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void Hited(RaycastHit hit)
    {
        GameObject effect = Instantiate(hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(effect, 0.1f);
    }
}
