using ORKFramework;
using ORKFramework.Behaviours;
using ORKFramework.Menu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float speed = 5.0f;

    private string axis_y_movement = "Vertical";
    private string axis_x_movement = "Horizontal";

    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update () {
        float y = Input.GetAxisRaw(axis_y_movement);
        float x = Input.GetAxisRaw(axis_x_movement);
        bool accept = Input.GetKeyDown("return");
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * speed;
        GameObject player = ORK.Game.GetPlayer();
        InteractionController ic = player.GetComponentInChildren<InteractionController>();
        Transform t = ic.transform;
        if (x == 0 && y == 0)
        {
            playerAnimator.SetBool("Idle", true);
            Debug.Log("Idle");
        }
        else
        {
            if (x == 1)
            {
                playerAnimator.SetBool("Right", true);
                playerAnimator.SetBool("Up", false);
                playerAnimator.SetBool("Down", false);
                playerAnimator.SetBool("Left", false);
                //if (t.localPosition.x == 0.15f)
                //{
                ic.transform.localPosition = new Vector2(0.15f, 0);
                //}
                //if (t.localRotation.z == 0)
                //{
                    ic.transform.Rotate(new Vector3(0, 0, 0));
                //}
                Debug.Log("Right");
            }
            if (x == -1)
            {
                playerAnimator.SetBool("Left", true);
                playerAnimator.SetBool("Up", false);
                playerAnimator.SetBool("Down", false);
                playerAnimator.SetBool("Right", false);
                ic.transform.localPosition = new Vector2(-0.15f, 0);
                ic.transform.localRotation = new Quaternion(0, 0, 0, 0);
                Debug.Log("Left");
            }
            if (y == 1)
            {
                playerAnimator.SetBool("Up", true);
                playerAnimator.SetBool("Down", false);
                playerAnimator.SetBool("Right", false);
                playerAnimator.SetBool("Left", false);
                ic.transform.localPosition = new Vector2(0, 0);
                ic.transform.localRotation = new Quaternion(0, 0, 90, 0);
                Debug.Log("Up");
            }
            if (y == -1)
            {
                playerAnimator.SetBool("Down", true);
                playerAnimator.SetBool("Up", false);
                playerAnimator.SetBool("Right", false);
                playerAnimator.SetBool("Left", false);
                ic.transform.localPosition = new Vector2(0, -0.2f);
                ic.transform.localRotation = new Quaternion(0, 0, 90, 0);
                Debug.Log("Down");
            }
            playerAnimator.SetBool("Idle", false);
        }
        //Debug.Log("X: " + playerAnimator.GetFloat("x"));
        //GameObject icPre = ORK.GameControls.interaction.icPrefab;
        //InteractionController ic = icPre.GetComponent<InteractionController>();
        //Debug.Log(ic.AvailableCount);
        if (accept && ic.AvailableCount > 0)
        {
            Debug.Log("ENTER!");
            ic.Interact();
        }
    }

    void OnDisable()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    void OnEnable()
    {
    }
}
