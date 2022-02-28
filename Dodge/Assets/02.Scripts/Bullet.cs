using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRb;
    public float bulletSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        bulletRb.velocity = transform.forward * bulletSpeed;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //tag ���� comparetag�� ����ϴ°� ȿ���� ����(�޸�, �±װ� �����ϴ��� �˻�)
        {
            PlayerController pc = other.GetComponent<PlayerController>();

            if (pc != null)
            {
                pc.Die();
            }
        }
    }
}
