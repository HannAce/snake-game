using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int m_scoreValue = 10;
    private ScoreManager m_scoreManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_scoreManager = ScoreManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        
        m_scoreManager.AddScore(m_scoreValue);
        Destroy(this.gameObject);
    }
}
