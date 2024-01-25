using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingOnSFX : MonoBehaviour
{
    [Header("References")]
    public PlayerController pm;
    private int playOn = 0;
    public bool playFoot = false;
    private float footCool = 0;
    public GameObject onSfx;

    private void Update()
    {
        if (footCool > 0)
            footCool -= Time.smoothDeltaTime;

        if ((pm.swinging==true) && playOn==0)
        {
            AudioManager.instance.PlaySfx3D(AudioManager.Sfx.Hook, onSfx);
            playOn = 1;
        }

        if ((pm.swinging == false) && playOn == 1)
            playOn = 0;

        if (playFoot==true)
            if (footCool <= 0)
        {
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Footstep);
            playFoot = false;

                footCool = 0.1f;
        }

    }

}
