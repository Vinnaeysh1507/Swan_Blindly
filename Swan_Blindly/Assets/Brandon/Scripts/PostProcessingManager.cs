using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    //intisialing Volume profiles
    public Volume volume;
    public VolumeProfile[] profiles;
    public int ID = 0;

    // Getting individual Post FX values 
    public static Vignette vignette;
    Bloom bloom;
    ChromaticAberration chrome;


    //Setting variables
    public int resetProfileTimer = 5;


    void Start()
    {
        volume.profile.TryGet<Bloom>(out bloom);
        volume.profile.TryGet<Vignette>(out vignette);
        volume.profile.TryGet<ChromaticAberration>(out chrome);
    }

    private void Update()
    {
        Debug.Log(ID);
    }

    void FixedUpdate()
    {
        if (volume.profile != profiles[ID])
        {
            volume.profile = profiles[ID];
            volume.profile.TryGet<Bloom>(out bloom);
            volume.profile.TryGet<Vignette>(out vignette);
            volume.profile.TryGet<ChromaticAberration>(out chrome);
            vignette.color.value = Color.black;
            vignette.intensity.value = 0.267f;

        }

        if (DamageController.collided == true)
        {
            volume.profile = profiles[0];
            vignette.color.value = Color.red;
            vignette.intensity.value = Mathf.PingPong(Time.time * 0.2f, 0.3f);
        }
        else if (DamageController.collided == false)
        {
            volume.profile = profiles[1];
        }

        //Tutorial container Lighting
        //if(ID == 2)
        //bloom.intensity.value = Mathf.PingPong(Time.time * 2, 5);
        //vignette.intensity.value = Mathf.PingPong(Time.time * 2, 0.7f);
        //chrome.intensity.value = Mathf.PingPong(Time.time * 2, 1);
    }

    IEnumerator changingVolumeProfile()
    {
        yield return new WaitForSeconds(resetProfileTimer);
    }
}
