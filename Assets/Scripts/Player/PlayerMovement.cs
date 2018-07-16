using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public GamePausedManager gamePausedManager;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRidgidBody;
    int floorMask;
    float camRayLength = 100f;

    private Vector2 touchOrigin = -Vector2.one;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRidgidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (gamePausedManager == null || !gamePausedManager.IsGamePaused)
        {
            float h = 0;
            float v = 0;
            h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            v = CrossPlatformInputManager.GetAxisRaw("Vertical");


            Move(h, v);
            Turning();
            Animate(h, v);
        }


	}

	private void Move (float h, float v)
	{
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRidgidBody.MovePosition (transform.position + movement);
	}

	private void Turning()
	{
        float mouseX = CrossPlatformInputManager.GetAxis("Mouse X");
        float mouseY = CrossPlatformInputManager.GetAxis("Mouse Y");
        Vector3 pos = Input.mousePosition;
        Debug.Log("mouseX: " + mouseX + "    mouseY: " + mouseY);

        Debug.Log("posX: " + pos.x + "    posZ: " + pos.z);


        Ray camRay = Camera.main.ScreenPointToRay (pos);
		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

            Debug.Log("playerToMouseX: " + playerToMouse.x + "playerToMouseZ : " + playerToMouse.z);
            Vector3 stickRotation = new Vector3(mouseX, 0, mouseY);
            Quaternion newRotation = Quaternion.LookRotation (stickRotation);
			playerRidgidBody.MoveRotation (newRotation);

		}
	}

	private void Animate(float h, float v)
	{
		bool walking = h != 0F || v != 0F;
		anim.SetBool ("IsWalking", walking);

	}
}
