using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum PlatformType
    {
        Jumpy,
        Glass,
        Ice,
        Finish,
        Regular
    }

    [SerializeField]
    public PlatformType platformType;

    private GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        GameManager.platforms.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        switch (platformType)
        {
            case PlatformType.Finish:
                break;
            case PlatformType.Jumpy:
                Debug.Log("Jump!");
                GameManager.player.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));
                break;
            case PlatformType.Glass:
                GameObject TopLeft = gameObject.transform.Find("TopLeft").gameObject;
                GameObject TopCenter = gameObject.transform.Find("TopCenter").gameObject;
                GameObject TopRight = gameObject.transform.Find("TopRight").gameObject;
                TopCenter.AddComponent<Rigidbody>();
                TopCenter.GetComponent<Rigidbody>().AddForce(new Vector3(0, -3, 0));
                TopLeft.AddComponent<Rigidbody>();
                TopRight.AddComponent<Rigidbody>();
                break;
        }
        if (GameManager.player.playerMode == SlingShotPlayer.PlayerMode.MidAir)
        {
            GameManager.player.playerMode = SlingShotPlayer.PlayerMode.Grounded;
        }
    }
}
