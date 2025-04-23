using UnityEngine;
using TMPro;

// animate the text by making it scale up and down

class TitleAnimation : MonoBehaviour
{
    [SerializeField] private float scaleSpeed = 0.2f;
    [SerializeField] private float maxScale = 1.2f;
    [SerializeField] private float minScale = 0.8f;

    private TextMeshProUGUI textMeshPro;
    private Vector3 originalScale;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        originalScale = textMeshPro.transform.localScale;
    }

    void Update()
    {
        float scale = Mathf.PingPong(Time.time * scaleSpeed, maxScale - minScale) + minScale;
        textMeshPro.transform.localScale = originalScale * scale;
    }
}