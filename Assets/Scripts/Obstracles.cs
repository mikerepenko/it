using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstracles : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject[] obstraclePrefabs;

    private GameObject coin;
    private GameObject obstracle;

    private float coeff = 1f;

    void Update()
    {
        MoveCoin(coinPrefab, 10f);
        MoveObstracle(10f);
    }

    void MoveCoin(GameObject prefab, float speed)
    {
        if (coin == null)
        {
            coin = Instantiate(prefab, new Vector2(22f, -3.55f), transform.rotation);
        }

        if (coin.transform.position.x <= -11f)
        {
            Destroy(coin);
        }
        coin.transform.Translate(-Time.deltaTime * speed * coeff, 0, 0);
    }

    void MoveObstracle(float speed)
    {
        if (obstracle == null)
        {
            obstracle = Instantiate(obstraclePrefabs[Random.Range(1, 3) - 1], transform.position, transform.rotation);
        }

        if (obstracle.transform.position.x <= -11f)
        {
            Destroy(obstracle);
        }
        obstracle.transform.Translate(-Time.deltaTime * speed * coeff, 0, 0);
    }
}