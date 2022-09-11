using System;
using System.Collections;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Start()
    {
        StartCoroutine(StartDelay());
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (!GameManager.Instance.HasStarted) return;
        gameObject.transform.position += Vector3.back * (Time.deltaTime * moveSpeed);
        
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.HasStarted = true;
    }
    
}


