using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace UnityStandardAssets._2D
{

    public class SizeChange : MonoBehaviour
    {
        private bool isSmall;
        Rigidbody2D rb;
        PlatformerCharacter2D pc;
        [SerializeField] private Camera cam;
        [SerializeField] private GameObject walls;

        void Start()
        {
            isSmall = false;
            rb = GetComponent<Rigidbody2D>();
            pc = GetComponent<PlatformerCharacter2D>();

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("q") && !LeanTween.isTweening(gameObject))
            {
                if (isSmall)
                {
                    if(Physics2D.Raycast(transform.position + Vector3.up * GetComponent<Renderer>().bounds.extents.y, Vector2.up, 1f))
                    {
                        //play error sound effect
                        return;
                    }

                    ToggleWalls(true);
                    zoomOut();

                    if (transform.localScale.x < 0)
                    {
                        LeanTween.scale(this.gameObject, new Vector3(-1.5f, 1.5f, 1.5f), 1f);
                    }
                    else
                    {
                        LeanTween.scale(this.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 1f);
                    }

                    isSmall = false;
                }
                else
                {
                    ToggleWalls(false);
                    zoomIn();
                    if (transform.localScale.x < 0)
                    {

                        LeanTween.scale(this.gameObject, new Vector3(-0.10f, 0.10f, 0.10f), 1f);
                    }
                    else
                    {
                        LeanTween.scale(this.gameObject, new Vector3(0.10f, 0.10f, 0.10f), 1f);
                    }

                    isSmall = true;
                }
            }
            else if (LeanTween.isTweening(gameObject))
            {
                pc.MaxSpeed = 0f;
                GetComponent<Animator>().enabled = false;
            }
            else
            {
                GetComponent<Animator>().enabled = true;
                if (isSmall)
                {
                    pc.MaxSpeed = 1f;
                    pc.GetComponent<Rigidbody2D>().gravityScale = 0.60f;
                    pc.JumpForce = 100f;
                }
                else
                {
                    pc.MaxSpeed = 7f;
                    pc.GetComponent<Rigidbody2D>().gravityScale = 4;
                    pc.JumpForce = 800f;
                }
            }

        }

        public void zoomIn()
        {
            if (LeanTween.isTweening(cam.gameObject))
            {
                LeanTween.cancel(cam.gameObject);
            }

            LeanTween.value(cam.gameObject, cam.orthographicSize, 0.40f, 1f)
                .setOnUpdate(flt => cam.orthographicSize = flt);
        }

        public void zoomOut()
        {
            if (LeanTween.isTweening(cam.gameObject))
            {
                LeanTween.cancel(cam.gameObject);
            }

            LeanTween.value(cam.gameObject, cam.orthographicSize, 6f, 1f)
                .setOnUpdate(flt => cam.orthographicSize = flt);
        }

        public void ToggleWalls(bool on)
        {
            GameObject.FindGameObjectsWithTag("InvisoWall")
                .ToList()
                .ForEach(i =>
                {
                    var c = i.GetComponent<Collider2D>();
                    LeanTween.alpha(i, Convert.ToSingle(on), 1f);
                    c.enabled = !c.enabled;

                });
        }
    }

}
