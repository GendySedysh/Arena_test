using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject hero;
    private float time = 1f;
    private float deltaTimeSpawn = 1.5f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > time) {
            time += deltaTimeSpawn;
            SpawnPrefab();
        }
    }

    private void SpawnPrefab() {
        float x = Random.Range(12 - hero.transform.position.x, -12 + hero.transform.position.x);
        float z = Random.Range(12 - hero.transform.position.z, -12 + hero.transform.position.z);
        Instantiate(prefab, new Vector3(x, 0.5f, z), Quaternion.identity);
    }
}
