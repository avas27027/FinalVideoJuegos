using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectilController : MonoBehaviour
{
    public float timeToDestroy;
    private float mTimer1 = 0f;
    public string noCollide ="";


    private void Start()
    {
        //mDirection = GameManager.GetInstance().hero.GetDirection();
        //target = transform;
    }

    private void Update()
    {
        //transform.position += speed * Time.deltaTime * mDirection;
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        mTimer1 += Time.deltaTime;
        if (mTimer1 > timeToDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
