using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    private RubyController rubyController;
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        GameObject rubyControllerObject = GameObject.FindWithTag("RubyController");

        if (rubyControllerObject != null)
        {
            rubyController = rubyControllerObject.GetComponent<RubyController>();
            print ("Found the RubyConroller Script!");
        }

        if (rubyController == null)
        {
            print ("Cannot find GameController Script!");
        }
    }
    
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    
    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }

        HardEnemyController h = other.collider.GetComponent<HardEnemyController>();
        if (h != null)
        {
            h.Fix();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            rubyController.ChangeScore();
        }
    
        Destroy(gameObject);
    }
}