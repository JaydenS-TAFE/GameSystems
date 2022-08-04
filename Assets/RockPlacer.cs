using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPlacer : MonoBehaviour
{
    public Transform[] rockMarkers;
    public GameObject[] rockPrefabs;
    public Vector2 randomSizeRange = new Vector2(1f, 1f);
    public Vector2 randomRotationRange = new Vector2(-10f, 10f);

    private void Start()
    {
        for (int i = 0; i < rockMarkers.Length; i++)
        {
            if (Physics.Raycast(rockMarkers[i].position + new Vector3(0f, 10f, 0f), Vector3.down, out RaycastHit hit))
            {
                GameObject rock = Instantiate(rockPrefabs[Random.Range(0, rockPrefabs.Length)], hit.point, Quaternion.identity);

                rock.transform.up = hit.normal;
                rock.transform.Rotate(Random.Range(randomRotationRange.x, randomRotationRange.y), Random.Range(0f, 360f), 0f);
                rock.transform.localScale = rock.transform.localScale * Random.Range(randomSizeRange.x, randomSizeRange.y);

                Destroy(rockMarkers[i].gameObject);
            }
            
        }
    }
}
