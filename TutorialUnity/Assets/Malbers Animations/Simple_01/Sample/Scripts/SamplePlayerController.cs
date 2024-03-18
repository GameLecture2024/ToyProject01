using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamplePlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;               // �÷��̾��� �̵� �ӵ�

    private Rigidbody rigidbody;                            // �÷��̾� ���� ������ ���� ������Ʈ
   
    [SerializeField] private GameObject powerIndicator;     // �Ŀ��� ���¸� Ȯ�ν��� �ֱ� ���� ���� ������Ʈ

    public bool IsPowerUp = false;

    [SerializeField] private float powerUpDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v).normalized;

        rigidbody.AddForce(direction * moveSpeed);

        if (IsPowerUp)
        {
            Invoke("PowerUpTimeOver", powerUpDuration);   // 7f : �Ŀ����� ���ӵǱ⸦ ���ϴ� �ð� -> ����ȭ ���Ѽ� �����͸� �����Ű�ų� ������ �� �ֽ��ϴ�.
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            Debug.Log($"{other.gameObject.name}");
            Destroy(other.gameObject);               // ������Ʈ�� �Ծ����Ƿ� �ش� ������Ʈ�� �ı��Ѵ�.
            IsPowerUp = true;                        // ������Ʈ�� �Ծ��� �� ����� ����
            powerIndicator.SetActive(true);          // ������Ʈ�� Ȱ��ȭ �Ǵ� �ڵ�
        }
    }

    void PowerUpTimeOver()
    {
        // �÷��̾��� �Ŀ��� ���°� �������� ǥ���� �� �ִ� �ڵ� 1���� �ۼ��غ�����. 
        IsPowerUp = false;
        powerIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    Debug.Log("���� �浹�Ͽ���!");
        //    // ���� �浹���� �� ���� ������ �� �� ���󰡰� ���ִ� ����� �߰��غ���.

        //    Vector3 powerVector = (transform.position - collision.transform.position).normalized;    // �浹(�÷��̾�)�� Enemy ������ ���Ѵ� ( normalized�� ���� ���� ũ�⸦ �� ���⸸ ���� �� �ִ�.)
        //    Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();               // Enemy�� ���� �ִ� Rigidbody�� �����ؼ� Enemy�� ���� ȿ���� ������ �� �ִ�.
        //    enemyRigidbody.AddForce(powerVector * pushPower, ForceMode.Impulse);                     // EnemyRigidbody. AddForce �Լ��� �̿��ؼ� Enemy�� �浹�� �� �� ũ�� ���󰡵��� �����Ͽ���.

        //}
    }

}
