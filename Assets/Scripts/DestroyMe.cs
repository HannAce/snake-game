using System.Collections;
using UnityEngine;

namespace SnakeGame
{
    public class DestroyMe : MonoBehaviour
    {
        [SerializeField] private float m_lifetime;
        [SerializeField] private bool m_autoDestroy = false;

        private void Start()
        {
            if (!m_autoDestroy)
            {
                return;
            }
        
            StartCountdown();
        }

        public void StartCountdown()
        {
            StartCoroutine(nameof(WaitAndDestroy));
        }

        public void SetLifetime(float lifetime)
        {
            m_lifetime = lifetime;
        }
    
        private IEnumerator WaitAndDestroy()
        {
            yield return new WaitForSeconds(m_lifetime);
            Destroy(gameObject);
        }

    }
}
