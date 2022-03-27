using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public PlayerCharacter character; // A reference to the PlayerCharacter
    public Transform playerCamera; // A reference to the main camera

    private void FixedUpdate()
    {
        // read inputs
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var jump = Input.GetButtonDown("Jump");

        if (playerCamera == null)
            return;
        
        // calculate camera relative direction to move:
        var camForward = Vector3.Scale(playerCamera.forward, new Vector3(1, 0, 1)).normalized;
        var move = v * camForward + h * playerCamera.right;

        character.Move(move, jump);
    }
}
