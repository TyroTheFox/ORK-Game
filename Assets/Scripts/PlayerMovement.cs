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
	
	// Update is called once per frame
	void Update () {
        float y = Input.GetAxisRaw(axis_y_movement);
        float x = Input.GetAxisRaw(axis_x_movement);
        bool accept = Input.GetKeyDown("return");
        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * speed;
        GameObject player = ORK.Game.GetPlayer();
        InteractionController ic = player.GetComponentInChildren<InteractionController>();
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
