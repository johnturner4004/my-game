using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private float xBound = 23.5f;
  private float jumpForce = 500.0f;
  private float horizontalInput;
  private float moveSpeed = 10.0f;
  private bool isOnGround = true;
  private Rigidbody playerRigidbody;
  // Start is called before the first frame update
  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    PlayerMovement();
    PositionConstraints();
  }

  private void PlayerMovement()
  {
    if (Input.GetKey(KeyCode.Space) && isOnGround)
    {
      playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      isOnGround = false;
    }

    horizontalInput = Input.GetAxis("Horizontal");
    transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
  }

  private void PositionConstraints()
  {
    if (transform.position.x <= -xBound)
    {
      transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
    }

    if (transform.position.x >= xBound)
    {
      transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      isOnGround = true;
    }
  }
}
