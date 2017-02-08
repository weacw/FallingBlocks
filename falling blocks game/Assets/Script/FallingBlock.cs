using UnityEngine;
using System.Collections;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax;
    private float speed = 7;
    public TrailRenderer trailRenderer;
    // Use this for initialization
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        trailRenderer.startWidth = transform.localScale.x;
        trailRenderer.endWidth = transform.localScale.x/5;
        Destroy(this.gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
    }
}
