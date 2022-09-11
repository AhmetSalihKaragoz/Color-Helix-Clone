using UnityEngine;

namespace CircleScripts
{
    public class CircleController : MonoBehaviour
    {
        [SerializeField] private float rotateSpeed;

        private void Update()
        {
            Rotate();
        }
        private void Rotate()
        {
            CircleRotate();
        }
        private void CircleRotate()
        {
            if (Input.GetMouseButton(0))
            {
                if (GetNormalizedScreenWidth() <  0.5f)
                {
                    gameObject.transform.Rotate(Vector3.back * (Time.deltaTime * rotateSpeed));
                }
                else
                {
                    gameObject.transform.Rotate(Vector3.back * (Time.deltaTime * -rotateSpeed));
                }
            }
            
        }
        private float GetNormalizedScreenWidth()
        {
            return (Input.mousePosition.x - 0) / (Screen.width - 0);
        }
    }
}
