using UnityEngine;
using System.Collections;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax;
    private float speed = 7;
    // Use this for initialization
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        Destroy(this.gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.Self);
    }
}
