using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class ResetPos : MonoBehaviour
    {
        bool grounded;
        Vector3 pos;
        [SerializeField] private TextMeshProUGUI text;
        private int lives;
        PlatformerCharacter2D pc;
        float speed;
        // Start is called before the first frame update
        void Start()
        {
            pos = transform.position;
            lives = 3;
            grounded = true;
            pc = GetComponent<PlatformerCharacter2D>();
            //StartCoroutine("check");
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("Reset Start");
            if (!(collision.CompareTag("OOB")))
            {
                return;
            }

            if (lives > 0)
            {
                lives--;
                if (text)
                {
                    text.text = lives.ToString();
                }

            }
            else
            {
                PlayGame();
            }
            StartCoroutine("blink");
            speed = pc.MaxSpeed;
            GetComponent<Animator>().SetTrigger("isDead");
            transform.position = pos;
        }

        IEnumerator blink()
        {
            var counter = 3;
            while (counter > 0)
            {

                LeanTween.alpha(this.gameObject, 0, 0.5f);
                yield return new WaitForSeconds(0.5f);
                pc.MaxSpeed = 0f;
                LeanTween.alpha(this.gameObject, 1, 0.5f);
                yield return new WaitForSeconds(0.5f);
                counter--;
            }
            pc.MaxSpeed = speed;
            //GetComponent<Animator>().enabled = true;
        }

        IEnumerator check()
        {
            while (true)
            {
                grounded = GetComponent<PlatformerCharacter2D>().grounded;
                if (grounded)
                {
                    pos = transform.position;
                }
                else
                {
                    bool gr = false;
                    //while (!gr)
                    {
                        grounded = GetComponent<PlatformerCharacter2D>().grounded;
                        if (grounded)
                        {
                            pos = transform.position;
                            gr = true;
                        }
                    }
                }

                yield return new WaitForSeconds(1f);
            }
        }
        public void PlayGame()
        {
            SceneManager.LoadScene("End");
        }
    }

}
