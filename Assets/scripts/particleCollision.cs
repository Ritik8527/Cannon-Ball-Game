using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleCollision : MonoBehaviour
{
    [SerializeField] ParticleSystem boxBurstParticles;
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("box"))
        {
            Instantiate(boxBurstParticles, other.transform.position, Quaternion.identity);
            Destroy(other);
        }
    }
}
