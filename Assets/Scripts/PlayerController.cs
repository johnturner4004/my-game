using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float jumpForce;
  public float moveSpeed;
  private Rigidbody playerRigidbody;
  public bool isOnGround = true;
  private float horizontalInput;
  // Start is called before the first frame update
  void Start()
  {
    playerRigidbody = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.Space) && isOnGround)
    {
      playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      isOnGround = false;
    }

    horizontalInput = Input.GetAxis("Horizontal");
    transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * horizontalInput);
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      isOnGround = true;
    }
  }
}
