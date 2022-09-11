using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

namespace CircleScripts
{
    public class RewardCirclePiece : MonoBehaviour
    {
        [SerializeField] private AudioClip audioClip;
        
        private Star _star;

        private void Start()
        {
            _star = GetComponentInChildren<Star>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Ball")) return;
            PlayAudioClip();
            PassedNormally();
            PassedPerfectly();
        }

        private void PassedPerfectly()
        {
            if (_star.PassedThroughStar)
            {
                GameManager.Instance.HasScoredPerfect = true;
                GameManager.Instance.UpdateScoreText();
            }
        }

        private void PassedNormally()
        {
            if (!_star.PassedThroughStar)
            {
                GameManager.Instance.HasScoredNormal = true;
                GameManager.Instance.UpdateScoreText();
            }
        }

        private void PlayAudioClip()
        {
            AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
        }
    }
}

