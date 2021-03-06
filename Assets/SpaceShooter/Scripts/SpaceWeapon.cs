using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceWeapon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform[] spawnTransforms;
    [SerializeField] float fireRate;

    float fireTimer = 0;

    private void Update()
    {
        fireTimer -= Time.deltaTime;
    }

    public void Fire()
    {
        if (fireTimer > 0) return;
        fireTimer = fireRate;
        foreach(Transform spawnTransform in spawnTransforms)
        {
            Instantiate(projectilePrefab, spawnTransform.position, spawnTransform.rotation);
        }
    }
}
