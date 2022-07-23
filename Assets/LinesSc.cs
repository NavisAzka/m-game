using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinesSc : MonoBehaviour
{
    [SerializeField] InputField inputAngle;

    [SerializeField] LineRenderer line;
    [SerializeField] Transform pointStart;
    [SerializeField] Transform pointEnd;

    [SerializeField] Trigono sin;
    [SerializeField] Trigono cos;
    [SerializeField] Trigono tan;

    public float ag;

    public int angle;

    // Start is called before the first frame update
    void Start()
    {
        SetLine(line, pointStart.position, pointEnd.position);
    }

    public void SetAngles()
    {
        string isi = "";

        if (inputAngle.text == "" || inputAngle.text == null)
        {
            isi = "0";
        }
        else
        {
            isi = inputAngle.text;
        }

        angle = int.Parse(isi);

        transform.GetChild(0).rotation = Quaternion.Euler(0, 0, angle);

        SetLine(line, pointStart.position, pointEnd.position);
        SetLine(sin.line, pointStart.position, new Vector2(pointStart.position.x, pointEnd.position.y));
        SetLine(cos.line, pointStart.position, new Vector2(0, pointStart.position.y));

        sin.result.text = "Sin : " + Mathf.Sin(ag * Mathf.Deg2Rad).ToString();
        cos.result.text = "Cos : " + Mathf.Cos(ag * Mathf.Deg2Rad).ToString();
    }

    private void Update()
    {
    }

    void SetLine (LineRenderer _line, Vector2 posS, Vector2 posE)
    {
        _line.SetPosition(0, posS);
        _line.SetPosition(1, posE);
    }


}
