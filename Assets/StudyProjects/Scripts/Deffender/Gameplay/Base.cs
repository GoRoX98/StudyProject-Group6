using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private int _health = 5;
    public event Action ActionGameOver;


    private void OnTriggerEnter(Collider obj)
    {
        if (obj.GetComponent<Enemy>())
        {
            _health -= 1;
            Destroy(obj.gameObject);

            if (_health <= 0)
            {
                print("Game Over");
                ActionGameOver?.Invoke();
            }
        }
    }
}
