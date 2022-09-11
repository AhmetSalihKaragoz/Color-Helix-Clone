using System;
using UnityEngine;


public class FinishLine : MonoBehaviour
{
    [SerializeField] private float moveSpeed;


    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!GameManager.Instance.HasStarted) return;
        gameObject.transform.position += Vector3.back * (Time.deltaTime * moveSpeed);
    }
}
