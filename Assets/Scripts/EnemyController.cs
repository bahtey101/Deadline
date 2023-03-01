using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float agrDistance = 0.6f;
    public float damage = 10f;
    public float attack_range = 0.3f;
    public float attack_speed = 0.3f;
    public float speed = 0.5f;
    public GameObject hitbox;

    private float time_waiting = 6f;
    private Rigidbody2D rb;
    private GameObject[] players;
    private int layerMask;
    private Vector3 start_pos;
    private Vector3 movement;

    void Start() 
    {
        layerMask = 1 << 3;
        layerMask = ~layerMask;

        rb = GetComponent<Rigidbody2D>();

        start_pos = this.transform.position;
        
        if (players == null)
        {
            players = GameObject.FindGameObjectsWithTag("Player");
        }
    }

    void Update()
    {  
        GameObject target = FindTarget();
        if (target)
        {
            float time_left = time_waiting;
            while (time_left > 0)
            {
                Attack(target);
                time_left -= Time.deltaTime;
            }
        }
        else 
        {
            MoveTo(start_pos);
        }
    }

    GameObject FindTarget()
    {
        float min_distance = agrDistance;
        GameObject target = null;

        foreach(GameObject player in players)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < agrDistance)
            {
                target = distance < min_distance ? player : target;
            }
        }

        return target;
    }

    void Attack(GameObject target)
    {   
        if (Vector2.Distance(transform.position, target.transform.position) > attack_range / 2)
            MoveTo(target.transform.position);
        else 
        {
            GiveDamage();
        }
    }

    void MoveTo(Vector3 point)
    {
        Vector3 direction = point - transform.position;
        direction.Normalize();
        movement = direction;

        rb.MovePosition((Vector2)transform.position + (Vector2)(direction * speed * Time.deltaTime));
    }

    void GiveDamage()
    {
        hitbox.SetActive(true);
        for (float time_left = 0.1f; time_left > 0; time_left -= Time.deltaTime);
        hitbox.SetActive(false);
    }
}
