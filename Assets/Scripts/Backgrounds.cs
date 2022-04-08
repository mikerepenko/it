using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backgrounds : MonoBehaviour
{
    public GameObject sky_1;
    public GameObject sky_2;

    public GameObject grass_1;
    public GameObject grass_2;

    public GameObject road_1;
    public GameObject road_2;

    public GameObject home_1;
    public GameObject home_2;
    public GameObject home_3;

    private float coeff = 1f;

    void Update()
    {
        Move(sky_1, 5f, 22f);
        Move(sky_2, 5f, 22f);

        Move(grass_1, 10f, 22f);
        Move(grass_2, 10f, 22f);

        Move(road_1, 10f, 21f);
        Move(road_2, 10f, 21f);

        Move(home_1, 10f, 34f);
        Move(home_2, 10f, 34f);
        Move(home_3, 10f, 34f);
    }

    void Move(GameObject obj, float speed, float nextPos)
    {
        if (obj.transform.position.x <= -20f)
        {
            obj.transform.position = new Vector3(nextPos, obj.transform.position.y);
        }
        obj.transform.Translate(-Time.deltaTime * speed * coeff, transform.position.y, 0);
    }
}