using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contact : MonoBehaviour
{
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnColliderEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if(other.gameObject.CompareTag("Enemy"))
            enemy.TakeDamage(damage);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
