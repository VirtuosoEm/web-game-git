using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private float explosionForce = 100f;
    [SerializeField] private float explosionRadius = 2f;
    [SerializeField] private ParticleSystem explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        // ������������� ������ ������
        if (explosionEffect != null)
        {
            explosionEffect.Play();
        }

        // ������� ��� ������� � ������� ������
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in hitColliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // ������������ �������
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // ������� ���� ����� �������� �����
        Destroy(gameObject, 1f);
    }
}
