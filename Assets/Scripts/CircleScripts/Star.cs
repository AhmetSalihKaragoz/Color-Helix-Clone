using UnityEngine;

public class Star : MonoBehaviour
{
    public bool PassedThroughStar { get; private set; }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            PassedThroughStar = true;
            Debug.Log(PassedThroughStar);
        }
    }
}
