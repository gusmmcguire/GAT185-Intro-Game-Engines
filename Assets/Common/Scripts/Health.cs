using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject deathPrefab;
    [SerializeField] bool destroyOnDeath = true;
    [SerializeField] float maxHealth = 100;
    [SerializeField] bool destroyRoot = false;

    public float health { get; set; }
    bool isDead = false;
    public float max { get { return maxHealth; } }

    void Start()
    {
        health = maxHealth;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if(!isDead && health <= 0)
        {
            isDead = true;
            if(TryGetComponent<IDestructable>(out IDestructable destructable))
            {
                destructable.Destroyed();
            }

            if (deathPrefab)
            {
                Instantiate(deathPrefab, transform.position, transform.rotation);
            }
            if (destroyOnDeath)
            {
                if (destroyRoot) Destroy(gameObject.transform.root.gameObject);
                else Destroy(gameObject);
            }
        }
    }
}
