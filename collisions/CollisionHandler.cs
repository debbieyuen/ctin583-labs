using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private ParticleSystem enemyParticles;

    [SerializeField] Material[] myMaterials;
    [SerializeField] List<string> myList;
    List<string> myList = new List<string>() { "Debbie", "Nile", "Kathy" };



    private void OnCollisionEnter(Collision collision)
    {


        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Destroy(gameObject);
                break;

            case "Gem":
                meshRenderer.material = collision.gameObject.GetComponent<Renderer>().material;
                Destroy(collision.gameObject);
                PlayParticles();
                break;

            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Number of names: " + myList.Count);
        myList.Add("Debbie");
        meshRenderer.material = myMaterials[Random.Range(0, myMaterials.Length)];

        StartCoroutine(loopDelay());
    }

    IEnumerator loopDelay()
    {
        for (int i = 0; i < myMaterials.Length; i++)
        {
            meshRenderer.material = myMaterials[i];
            yield return new WaitForSeconds(2.00f);
        }
        StartCoroutine(loopDelay());
    }

    private void PlayParticles()
    {
        enemyParticles.Play();
    }
}
