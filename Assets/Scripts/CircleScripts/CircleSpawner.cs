using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace CircleScripts
{
    public class CircleSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> circleList;
        [SerializeField] private List<GameObject> colorShifterList;
        
        private GameObject _pipe;
        
        void Start()
        {
            GetComponents();
            Spawn();
        }
    
        private void Spawn()
        {
            var minRange = 3;
            var maxRange = 21;
            
            for (int i = 0; i < colorShifterList.Count+1; i++)
            {
                for (int j = minRange; j < maxRange; j += 3)
                {
                    SpawnCircle(i, j);
                }
                minRange += 21;
                maxRange += 21;
            }
            
        }
        private void SpawnCircle(int listIndex, int index)
        {
            var spawnLocation = new Vector3(0, -1, index);
            Instantiate(circleList[listIndex], spawnLocation, Quaternion.Euler(0,0,Random.Range(index*-10,index*10)), gameObject.transform);
        }

        private void GetComponents()
        {
            _pipe = GameObject.FindGameObjectWithTag("Pipe");
            gameObject.transform.parent = _pipe.transform;
        }
        
    }
}
