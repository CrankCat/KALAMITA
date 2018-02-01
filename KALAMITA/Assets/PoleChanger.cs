using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleChanger : MonoBehaviour {

    public Material positive;
    public Material negative;

    public enum Pole {POSITIVE, NEGATIVE};

    public Pole imanPolo;

    public MeshRenderer myMRenderer;
    public Rigidbody myRB;

    public GameObject cuboPositivo;
    public GameObject cuboNegativo;

    Transform target;

    

	void Start ()
    {
        imanPolo = Pole.NEGATIVE;
	}
	
	void Update ()
    {
        CheckPole();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangePole();
        }

        Atract();
	}


    void CheckPole()
    {
        switch (imanPolo)
        {
            case Pole.POSITIVE:
                myMRenderer.material = positive;
                target = cuboNegativo.transform;
                break;
            case Pole.NEGATIVE:
                myMRenderer.material = negative;
                target = cuboPositivo.transform;
                break;
        }
    }

    void ChangePole()
    {
        if (imanPolo == Pole.NEGATIVE)
            imanPolo = Pole.POSITIVE;
        else
            imanPolo = Pole.NEGATIVE;
    }

    void Atract()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, target.position, Time.deltaTime * 2);
    }
}
