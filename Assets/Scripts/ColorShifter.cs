using UnityEngine;

public class ColorShifter : MonoBehaviour
{
    private GameObject _pipe;
    
    
    //Making the pipe the parent of the object so it moves with it!.
    //Color changing happens in Ball Script.
    private void Start()
    {
        _pipe = GameObject.FindGameObjectWithTag("Pipe");
        gameObject.transform.SetParent(_pipe.transform);
    }
}
