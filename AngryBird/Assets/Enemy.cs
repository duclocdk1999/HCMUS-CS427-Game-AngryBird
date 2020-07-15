using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _cloudParticlePrefap;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        GreenBird hitBird = collision.collider.GetComponent<GreenBird>();
        if (hitBird != null)
        {
            // hit by the bird
            Instantiate(_cloudParticlePrefap, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        // hit by the box, check contact angle. If box is on the top, destroy the pig
        if (collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticlePrefap, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        // hit by anything with velocity magnitude > 4
        if (collision.relativeVelocity.magnitude > 4)
        {
            Instantiate(_cloudParticlePrefap, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}