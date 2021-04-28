using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{

    private Vector3 position = Vector3.zero;
    [SerializeField] private EffectController controller;
    [SerializeField] private float timeDelay = 0.05f;
    private List<Transform> spawnPool = new List<Transform>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Transform vfxObj = Instantiate(controller.transform);
            vfxObj.position = new Vector3(this.transform.position.x, this.transform.position.y);
            StartCoroutine(RunAction(vfxObj));

            List<Transform> spawnPool = new List<Transform>();
        }

    }
    public IEnumerator RunAction(Transform vfxObj)
    {
        float startTime = Time.time;

        while (position != vfxObj.transform.position)
        {
            yield return null;
            vfxObj.transform.position = Vector3.MoveTowards(vfxObj.transform.position, position, 60f * Time.deltaTime);

            if (Time.time >= startTime + timeDelay* Time.deltaTime)
            {
                if (spawnPool.Count < 20)
                {
                    Transform afterimage = Instantiate(controller.transform);
                    afterimage.position = vfxObj.position;
                    spawnPool.Add(afterimage);
                    startTime = Time.time;
                }
                else
                {
                    Transform firstPosition = spawnPool[0];
                    firstPosition.position = vfxObj.position;

                    spawnPool.Remove(firstPosition);
                    spawnPool.Add(firstPosition);
                    startTime = Time.time;

                }
                

            }

        }
        GameObject.Destroy(vfxObj.gameObject);

    }

}