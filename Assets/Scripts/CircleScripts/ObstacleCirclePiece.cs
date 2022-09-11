using System.Collections;
using UnityEngine;

namespace CircleScripts
{
    public class ObstacleCirclePiece : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer splashImage;
        [SerializeField] private AudioClip audioClip;

        private Vector3 _splashPos;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            PlayAudioClip();
            DestroyBall(other.gameObject);
            InstantiateAndColorSplash(other.gameObject);
            StartCoroutine(LoadCurrentSceneAfterDelay());
        }
        
        private void PlayAudioClip()
        {
            AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
        }
        private void DestroyBall(GameObject other)
        {
            Destroy(other);
            GameManager.Instance.HasStarted = false;
        }
        
        private IEnumerator LoadCurrentSceneAfterDelay()
        {
            yield return new WaitForSeconds(1f);
            LevelManager.Instance.LoadCurrentLevel();
        }

        private void InstantiateAndColorSplash(GameObject other)
        {
            var splash = Instantiate(splashImage, GetSplashPos(other.transform.position), Quaternion.identity,gameObject.transform);
            splash.material.color = ColorManager.Instance.CurrentColor;
        }
        
        private Vector3 GetSplashPos(Vector3 ballPos)
        {
            _splashPos = new Vector3(ballPos.x, ballPos.y, gameObject.transform.position.z - 0.01f);
            return _splashPos;
        }
    }
}
