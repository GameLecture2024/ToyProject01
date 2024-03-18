using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject powerupObject;
    [SerializeField] private Transform enemySpawnPosition;

    public int enemyCount = 0;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(waveNumber);

        // �� ���� ����, Ư�� ��ġ���� �����Ǵ� �ڵ� �ۼ�
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<SampleEnemy>().Length; // ���̾��Ű���� SampleEnemy ��ũ��Ʈ�� ���� �ִ� ������Ʈ�� ã�Ƽ� �� ������ ��ȯ�ϴ� �ڵ�

        if (enemyCount == 0)                                  // SampleEnemy ��ũ��Ʈ�� ���� �ִ� ������Ʈ 0 "��� Enemy�� �׾��� ��" ���� �����Ѵ�.
        {
            waveNumber++;
            SpawnEnemy(waveNumber);
        }
    }

    private void SpawnEnemy(int spawnNumber)                  // ���� ���� óġ�� �� ���� Wave�� ���� 1�� �����ϰ�, ������ Wave �� ��ŭ ���� ���̺�(Enemy)�� �����Ѵ�.
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            GameObject enemyObj = Instantiate(enemy, enemySpawnPosition.position, Quaternion.identity);
        }  
    }
}
