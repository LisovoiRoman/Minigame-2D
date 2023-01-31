using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpawnerPoint : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    public void Move()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _spawner.transform.position.z);
    }
}
