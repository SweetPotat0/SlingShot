using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShotPlayer : MonoBehaviour
{
    public enum PlayerMode
    {
        MidAir,
        Grounded
    }
    public enum AboutTo
    {
        Nothing,
        Bounce,
        Stick
    }

    public PlayerMode playerMode = SlingShotPlayer.PlayerMode.Grounded;

    public AboutTo aboutTo = AboutTo.Nothing;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().player = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
