using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class LerpScript : MonoBehaviour
{
	public Transform leftPos, rightPos;
	
	public GameObject indicator;

	public float maxValue = 100;
	public float currentValue = 0;

	public float deltaSpeed = 10;

	public TextMeshPro valueText;

	public MeshRenderer leftGem, rightGem;

	private Color startColor;
	public Color endColor;

    // Start is called before the first frame update
    void Start()
    {
     	startColor = leftGem.material.color;
     	LerpValue();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
        	currentValue += deltaSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
        	currentValue -= deltaSpeed * Time.deltaTime; 
        }

        currentValue = Mathf.Clamp(currentValue, 0, maxValue);
        LerpValue();
    }

    void LerpValue()
    {
    	float t = currentValue / maxValue;

    	valueText.text = "ttt"; 
    	indicator.transform.position = Vector3.Lerp(leftPos.position, rightPos.position, t); 
    	leftGem.material.color = rightGem.material.color * Color.Lerp(startColor, endColor, t);
    }
}
