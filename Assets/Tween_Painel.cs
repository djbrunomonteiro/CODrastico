using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Tween_Painel : MonoBehaviour
{
    public GameObject painel;

    [SerializeField]
    private int duract;
    [SerializeField]
    private float pos;
    [SerializeField]
    private float startPosX;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        MoveCima();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {

            StartCoroutine(MoveBaixo(0.1f));
        }

        if (Input.GetKeyDown(KeyCode.B)) {
            MoveCima();
        }

    }

	void MoveCima() {

        //Mover
        painel.GetComponent<RectTransform>().DOAnchorPosY(pos, duract, true);
	}

	IEnumerator MoveBaixo(float temp) {

        //Mover
        painel.GetComponent<RectTransform>().DOMoveY(-startPosX, duract, true);
        yield return new WaitForSeconds(temp);

        }

}
