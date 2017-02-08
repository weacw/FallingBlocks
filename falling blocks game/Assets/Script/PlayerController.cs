using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed = 7;

    private float screenHalfWidthInWorldUnits = 9.5f;
    public event System.Action OnPlayerDeath;
    public GameObject deathEffect;
    private GameObject deathEffectTmp;
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
        //inputX = MobileTouchOperater().x;
        //#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_STANDALONE_WIN
        //        inputX = Input.GetAxisRaw("Horizontal");
        //#elif UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE
        //        //inputX=Input.acceleration.x;
        //        //inputX+=inputX*2.5f;
        //        inputX=MobileTouchOperater().x;
        //#endif
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(MobileTouchOperater().x, transform.position.y, transform.position.z), Time.deltaTime*speed);

        //float velocity = inputX * speed;
        //transform.Translate(Vector2.right * velocity * Time.deltaTime);
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
            if (null == deathEffectTmp)
            {
                deathEffectTmp = Instantiate(deathEffect, transform.position, Quaternion.identity) as GameObject;
                Destroy(deathEffectTmp, 1);
            }
            Destroy(this.gameObject);
        }
    }

    Vector3 MobileTouchOperater()
    {
       if (Input.touchCount < 1) return Vector3.zero;
        Vector3 fingerPosition = Input.mousePosition;
        Vector3 fingerPosToWorldPos= Camera.main.ScreenToWorldPoint(fingerPosition);
        fingerPosToWorldPos.y = transform.position.y;
        fingerPosToWorldPos.z = transform.position.z;
        return fingerPosToWorldPos;
    }
}
