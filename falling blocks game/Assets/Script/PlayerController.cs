using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;

    private float screenHalfWidthInWorldUnits = 9.5f;
    public event System.Action OnPlayerDeath;

    private Spawner spawner;
    // Use this for initialization
    void Start()
    {
        float halfPlayerWidth = transform.lossyScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
        spawner = FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawner.isStartGame) return;
        float inputX = 0;
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_STANDALONE_WIN
        inputX = Input.GetAxisRaw("Horizontal");
#elif UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE
        inputX=Input.acceleration.x;
        inputX+=inputX*2.5f;
#endif


        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);
        if (transform.position.x < -screenHalfWidthInWorldUnits)
            transform.position = new Vector3(screenHalfWidthInWorldUnits, transform.position.y);
        else if (transform.position.x > screenHalfWidthInWorldUnits)
            transform.position = new Vector3(-screenHalfWidthInWorldUnits, transform.position.y);

    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Falling Block")
        {
            if (OnPlayerDeath != null) OnPlayerDeath.Invoke();
            Destroy(this.gameObject);
        }
    }
}
