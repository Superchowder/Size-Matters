using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class ResetPosition : MonoBehaviour
    {
        bool grounded;
        Transform trans;
        [SerializeField] private Text text;
        private int lives;
        // Start is called before the first frame update
        void Start()
        {
            lives = 3;
        grounded = true;
        }

        // Update is called once per frame
        void Update()
        {
            //grounded = GetComponent<PlatformerCharacter2D>().grounded;
            if (grounded)
            {
                trans = transform;
            }

            text.text = lives.ToString();

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!(CompareTag("OOB")))
            {
                return;
            }

            transform.position = trans.position;

            if (lives > 0)
            {
                lives--;
            }

        }
    }




