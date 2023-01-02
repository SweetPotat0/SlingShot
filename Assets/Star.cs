using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public enum StarType
    {
        TimeBonus,
        Sticky,
        Bouncy
    }

    [SerializeField]
    public StarType starType;

    private GameManager GameManager;
    private bool isEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        GameManager.stars.Add(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (isEnabled)
        {
            isEnabled = false;
            switch (starType)
            {
                case StarType.TimeBonus:
                    GameManager.seconds -= 1;
                    break;
                case StarType.Bouncy:
                    GameManager.player.aboutTo = SlingShotPlayer.AboutTo.Bounce;
                    break;
                case StarType.Sticky:
                    GameManager.player.aboutTo = SlingShotPlayer.AboutTo.Stick;
                    break;

            }
            Destroy(gameObject);
        }
    }
}
