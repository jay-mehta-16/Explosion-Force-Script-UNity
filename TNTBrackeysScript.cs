using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTBrackeysScript : MonoBehaviour
{

    //! Getting Hand of Particles
    [SerializeField] GameObject blastParticles;

    //! About the blast Effect
    public float blastDelay = 3f;
    float countDown;
    bool hasExploded = false;

    //!Getting the Blast
    [SerializeField] float explosionForce;
    [SerializeField] float explosionRadius;

    // Start is called before the first frame update
    void Start()
    {
        countDown = blastDelay;
    }

    // Update is called once per frame
    void Update()
    {
        countDown -= Time.deltaTime;
        if (countDown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Debug.Log("Boom!");

        //Show Explosion Effect
        Instantiate(blastParticles, transform.position, transform.rotation);


        //Get NearBy Objects

            //Get A list of them

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            //Add force to them to explode

        foreach ( Collider nearbyObjects in colliders) {
            //Add force

            Rigidbody rb = nearbyObjects.GetComponent<Rigidbody>();

            if ( rb != null) {
                rb.AddExplosionForce(explosionForce , transform.position , explosionRadius);
            }
        }

        //Remove Granade
        Destroy(gameObject);
        Debug.Log("I'm Gone");

    }
}
