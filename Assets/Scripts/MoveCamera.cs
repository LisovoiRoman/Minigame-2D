using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private Player _player;

   private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _player.transform.position.z + 3.7f);
    }
}
