using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Challenge3Sequence : MonoBehaviour
{
    public Camera[] cameras;
    public Animator[] characters;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (Camera camera in cameras) {
                camera.enabled = false;
            }
            cameras[0].enabled = true;

            foreach (Animator guy in characters){
                guy.SetBool("Scene 1", true);
                guy.SetBool("Scene 2", false);
                guy.SetBool("Scene 3", false);
                guy.SetBool("Scene 4", false);
                guy.SetBool("Scene 5", false);
                guy.SetBool("Scene 6", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }
            cameras[1].enabled = true;
            foreach (Animator guy in characters)
            {
                guy.SetBool("Scene 1", false);
                guy.SetBool("Scene 2", true);
                guy.SetBool("Scene 3", false);
                guy.SetBool("Scene 4", false);
                guy.SetBool("Scene 5", false);
                guy.SetBool("Scene 6", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }
            cameras[2].enabled = true;
            foreach (Animator guy in characters)
            {
                guy.SetBool("Scene 1", false);
                guy.SetBool("Scene 2", false);
                guy.SetBool("Scene 3", true);
                guy.SetBool("Scene 4", false);
                guy.SetBool("Scene 5", false);
                guy.SetBool("Scene 6", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }
            cameras[3].enabled = true;
            foreach (Animator guy in characters)
            {
                guy.SetBool("Scene 1", false);
                guy.SetBool("Scene 2", false);
                guy.SetBool("Scene 3", false);
                guy.SetBool("Scene 4", true);
                guy.SetBool("Scene 5", false);
                guy.SetBool("Scene 6", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }
            cameras[4].enabled = true;
            foreach (Animator guy in characters)
            {
                guy.SetBool("Scene 1", false);
                guy.SetBool("Scene 2", false);
                guy.SetBool("Scene 3", false);
                guy.SetBool("Scene 4", false);
                guy.SetBool("Scene 5", true);
                guy.SetBool("Scene 6", false);
            }
            characters[3].SetLayerWeight(1, 1f);
            characters[3].SetLayerWeight(2, 1f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            foreach (Camera camera in cameras)
            {
                camera.enabled = false;
            }
            cameras[5].enabled = true;
            foreach (Animator guy in characters)
            {
                guy.SetBool("Scene 1", false);
                guy.SetBool("Scene 2", false);
                guy.SetBool("Scene 3", false);
                guy.SetBool("Scene 4", false);
                guy.SetBool("Scene 5", false);
                guy.SetBool("Scene 6", true);
            }
            characters[3].SetLayerWeight(1, 1f);
            characters[3].SetLayerWeight(2, 1f);

        }
    }
}
