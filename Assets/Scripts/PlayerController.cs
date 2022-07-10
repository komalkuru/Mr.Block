using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace PlayerMovement
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed;
        private Rigidbody2D rb2d;
        private BoxCollider2D boxcollider;
        [SerializeField] private GameOverController gameOverController;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            boxcollider = GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            float xSpeed = Input.GetAxisRaw("Horizontal");
            float ySpeed = Input.GetAxisRaw("Vertical");

            Vector3 scale = transform.localScale;
            horizontalMove(scale, xSpeed);
            verticalMove(scale, ySpeed);
        }        

        void horizontalMove(Vector3 scale, float xSpeed)
        {
            Vector3 positionX = transform.position;
            positionX.x += xSpeed * moveSpeed * Time.deltaTime;

            if (xSpeed < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (xSpeed > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;                      
            transform.position = positionX;
        }

        void verticalMove(Vector3 scale, float ySpeed)
        {
            if (ySpeed < 0)
            {
                scale.y = -1f * Mathf.Abs(scale.y);
            }
            else if (ySpeed > 0)
            {
                scale.y = Mathf.Abs(scale.y);
            }
            transform.localScale = scale;

            Vector3 positionY = transform.position;
            positionY.y += ySpeed * moveSpeed * Time.deltaTime;
            transform.position = positionY;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if(collider.CompareTag("Enemy"))
            {
                gameOverController.Invoke("GameOver", 0f);
            }

            if(collider.GetComponent<Door>())
            {
                GameWin();
            }
        }        

        void GameWin()
        {
            SceneManager.LoadScene(1);
        }
    }
}
