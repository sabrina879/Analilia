using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.DialogueTrees;

// Actions for Interacting with NPCs
public class InteractNPC : MonoBehaviour
{
    public DialogueTreeController dialogue;
    public Transform target; // Focus
    private Transform player; //players camera
    private Quaternion temp;
    Coroutine smoothMove = null;

    void Start()
    {
        player = GameObject.Find("Main Camera 1").GetComponent<Transform>();
    }
    void Update()
    {
        // if running focus on npc
        if (target != null)
        {
            if (dialogue.isRunning)
            {
            
                var targetRotation = Quaternion.LookRotation(target.position - player.position);
                // Smoothly rotate towards the target point.
                player.rotation = Quaternion.Lerp(player.rotation, targetRotation, 5 * Time.deltaTime);
                temp = player.rotation;
                LookSmoothly();
            }

        }
    }

    // Has the camera look "smoothly" towards target NPC
    void LookSmoothly()
    {
        float time = 1f;

        Vector3 lookAt = player.position;
        lookAt.y = transform.position.y;

        //Start new look-at coroutine
        if (smoothMove == null)
            smoothMove = StartCoroutine(LookAtSmoothly(transform, lookAt, time));
        else
        {
            //Stop old one then start new one
            StopCoroutine(smoothMove);
            smoothMove = StartCoroutine(LookAtSmoothly(transform, lookAt, time));
        }
    }

    IEnumerator LookAtSmoothly(Transform objectToMove, Vector3 worldPosition, float duration)
    {
        Quaternion currentRot = objectToMove.rotation;
        Quaternion newRot = Quaternion.LookRotation(worldPosition - objectToMove.position, objectToMove.TransformDirection(Vector3.up));

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.fixedDeltaTime;
            objectToMove.rotation = Quaternion.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
    }

    // Starts the dialogue associated with target NPC
    // Unlocks player cursor and locks player movement
    public void Interact()
    {
        dialogue.StartDialogue();
        GameObject.Find("Analilia").GetComponent<Animator>().SetBool("isWalking", false);

        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.Confined;
        Camera.main.GetComponent<MouseLook>().enabled = false;
        GameObject.Find("Analilia").GetComponent<Player>().enabled = false;
        GameObject.Find("PlayerCanvas").GetComponent<PauseMenu>().enabled = false;
    }

    // Locks player cursor and unlocks player movement
    public void Uninteract()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Camera.main.GetComponent<MouseLook>().enabled = true;
        GameObject.Find("Analilia").GetComponent<Player>().enabled = true;
        GameObject.Find("PlayerCanvas").GetComponent<PauseMenu>().enabled = true;
    }
}
