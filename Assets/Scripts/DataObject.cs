using UnityEngine;
using UnityEngine.UI;

public class DataObject : MonoBehaviour
{
    [SerializeField]
    private float m_value;
    [SerializeField]
    float m_Saturation;
    [SerializeField]
    float m_Value;


    [SerializeField]
    bool scaleHeight;
    
    [SerializeField]
    bool scaleUniform;

    Renderer m_Renderer;

    void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
        m_value = Random.Range(0, 101);
        
    }

    public void setValue(float value) => m_value = value;

    public float getValue() => m_value; 

    void Update()
    {
        if (scaleHeight)
            ScaleHeightToValue();
        else if (scaleUniform)
            scaleUniformly();
        SetColorToValue();
    }

    private void scaleUniformly()
    {
        var s = m_value / 100 + 1;
        transform.localScale = new Vector3(s,s,s);
    }

    void ScaleHeightToValue()
    {
        transform.localScale = new Vector3(1F, m_value / 100 + 1, 1F);
        transform.position = new Vector3(transform.position.x, (m_value / 100)  / 2, transform.position.z);
    }

    void SetColorToValue()
    {
        m_Renderer.material.color = Color.HSVToRGB(m_value / 360, m_Saturation, m_Value);
    }
}
