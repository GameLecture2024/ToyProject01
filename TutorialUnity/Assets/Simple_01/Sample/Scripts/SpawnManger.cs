using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject powerupObject;
    [SerializeField] private Transform enemySpawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        // �� ���� ����, Ư�� ��ġ���� �����Ǵ� �ڵ� �ۼ�
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        GameObject enemyObj = Instantiate(enemy, enemySpawnPosition.position, Quaternion.identity);     
    }
}
