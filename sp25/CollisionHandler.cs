using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ParticleSystem enemyParticles; 
    [SerializeField] private Material[] myMaterials;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // define a switch statement
        switch(collision.gameObject.tag) {
            // I want the enemy to destroy the player when it reaches me
            case "Enemy":
                Destroy(gameObject);
                break;

            // I want to collect different gems in the game
            case "Gem":
                meshRenderer.material = collision.gameObject.GetComponent<Renderer>().material;
                Destroy(collision.gameObject);
                PlayParticles(); 
                break; 

            default: 
                break;
        }
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // meshRenderer.material = myMaterials[Random.Range(0, myMaterials.Length)];
    //     // StartCoroutine(loopDelay());
    // }

    // Defining a coroutine
    IEnumerator loopDelay()
    {
        for (int i = 0; i < myMaterials.Length; i++) 
        {
            meshRenderer.material = myMaterials[i];
            yield return new WaitForSeconds(2.00f);
        }
        StartCoroutine(loopDelay());
    }

    void PlayParticles()
    {
        enemyParticles.Play();
    }
}
