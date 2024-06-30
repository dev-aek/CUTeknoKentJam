using UnityEngine;

public class GlowingSphere : MonoBehaviour
{
    public Color glowColor = Color.green; // Fosforlu renk
    public float glowIntensity = 5f;      // Fosforlu yoğunluk

    void Start()
    {
        // Yeni bir malzeme oluştur ve küreye uygula
        Renderer renderer = GetComponent<Renderer>();
        Material material = new Material(Shader.Find("Standard"));

        // Emission özelliğini etkinleştir
        material.EnableKeyword("_EMISSION");

        // Emission rengini ve yoğunluğunu ayarla
        material.SetColor("_EmissionColor", glowColor * glowIntensity);

        // Malzemeyi objeye uygula
        renderer.material = material;
    }
}
