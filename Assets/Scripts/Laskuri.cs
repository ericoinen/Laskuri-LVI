using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Laskuri : MonoBehaviour
{
    public TextMeshProUGUI tu;
    public TextMeshProUGUI hu;
    public TextMeshProUGUI t1;
    public TextMeshProUGUI h1;
    public TextMeshProUGUI t2;
    public TextMeshProUGUI h2;
    public TextMeshProUGUI t3;
    public TextMeshProUGUI h3;
    public TextMeshProUGUI t4;
    public TextMeshProUGUI h4;
    public TextMeshProUGUI t5;
    public TextMeshProUGUI h5;
    public TextMeshProUGUI t6;
    public TextMeshProUGUI h6;
    public TextMeshProUGUI t7;
    public TextMeshProUGUI h7;
    public TextMeshProUGUI t7w;
    public TextMeshProUGUI h7w;
    public TextMeshProUGUI t8;
    public TextMeshProUGUI h8;
    public TextMeshProUGUI t9;
    public TextMeshProUGUI h9;
    public TextMeshProUGUI t10;
    public TextMeshProUGUI h10;
    public TextMeshProUGUI t11;
    public TextMeshProUGUI h11;
    public TMP_InputField temp1;
    public TMP_InputField humidity1;

    public GameObject rotatingObject1;
    public GameObject rotatingObject2;
    public float rotationSpeed = 30f;

    public AudioClip clickSound;
    public AudioSource audioSource;


    public void OnClick()
    {
        float t = float.Parse(temp1.text);
        float h = float.Parse(humidity1.text);
        tu.text = t.ToString();
        this.hu.text = h.ToString() + "%";
        t1.text = t.ToString();

        t2.text = t.ToString();

        float pu = ((h * 0.01f) * (101325f * Mathf.Exp(11.78f * ((t + 273.15f) - 372.79f) / ((t + 273.15f) - 43.15f))));//с22 = C21*C16 (С16 = h * 0.01f) page number 2
        //Debug.Log("pu =" + pu.ToString());
        float E45 = 0.622f * (pu / (101325f - pu));//c23 = 0.622 * (C22 / (101325 - C22)) page number 2, C17 = 101325

        //h1 =R37/Q37        
        float R37 = E45 * 1000f / 1000f / (0.622f + E45 * 1000f / 1000f) * 101325f;
       // Debug.Log("R37 =" + R37.ToString());
        //Q37= 100000 * EXP(11.78 * (273.15 + O37 - 372.79) / (273.15 + O37 - 43.15))
        float Q37 = 100000f * Mathf.Exp(11.78f * (273.15f + t - 372.79f) / (273.15f + t  - 43.15f));
       // Debug.Log("Q37 =" + Q37.ToString());
        float h1f = R37 / Q37;
       // Debug.Log("h1f =" + h1f.ToString());
        h1.text = Mathf.RoundToInt(h1f * 100f) + "%";

        h2.text = h.ToString() + "%";
       // Debug.Log("xu =" + xu.ToString());
        float hk = (t * 1.006f) + E45 * (2501f + 1.85f * t);//c28 = (C14 * 1.006) + C23 * (2501 + 1.85 * C14) page number 2, C14 = t
        //Debug.Log("hk =" + hk.ToString());
        float phh = (101325f * Mathf.Exp(11.78f * ((t + 273.15f) - 372.79f) / ((t + 273.15f) - 43.15f)));//c21 page number 2
       // Debug.Log("phh =" + phh.ToString());
        float roi = 0.028964f * (101325f - phh * (h * 0.01f)) / (8.314f * (t + 273.15f));//c25 = c19 * (c17 - c22) / (c18 * c15); page number 2, c19 = 0.028964, c18 = 8.314, c15 = 273,15 kelvin
        //h2 =R38/Q38
        //R38 = S38/1000/(0.622+S38/1000)*101325
        //S38 = E57*1000
        //E57 = =(E40*E53*E45+E40*(1-E53)*H66)/(E40*E53+E40*(1-E53))
        //40 = roi * E37
        float E37 = 1;
        float E40 = roi * E37;
        float E53 = 1;
        float i16 = 30 * 0.01f;
        //Debug.Log("i16 =" + i16.ToString());
        float i15 = 22 + 273.15f;
        // Debug.Log("i15 =" + i15.ToString());
        //I21 = C17*EXP(11.78*(I15-372.79)/(I15-43.15))
        float i21 = 101325f * Mathf.Exp(11.78f * (i15 - 372.79f) / (i15 - 43.15f));
        // Debug.Log("i21 =" + i21.ToString());
        float i22 = i21 * i16;
        // Debug.Log("i22 =" + i22.ToString());
        float i25 = 0.028964f * (101325f - i22) / (8.314f * (i15));
        // Debug.Log("i25 =" + i25.ToString());
        float H40 = 1.205f * i25;
        // Debug.Log("H40 =" + H40.ToString());
        float E83 = roi * 1 / H40;
        float E86 = 2 / (1 + E83) * 0.83f;
        //we find h4
        float E87 = 2 / (1 + E83) * 0.564f;
        float H87 = E87 * E83;
        float H45 = 0.622f * (i22 / (101325f - i22));
        float H66 = H45 - H87 * (H45 - E45);
        float i53 = 1;
        float E66 = (roi * i53 * E45 + roi * (1 - i53) * H66) / (roi * i53 + roi * (1 - i53));
        float E90 = E66 + E87 * (H45 - E66);
        //E57 = =(E40*E53*E45+E40*(1-E53)*H66)/(E40*E53+E40*(1-E53))
        float E57 = (E40 * E53 * E45 + E40 * (1 - E53) * H66) / (E40 * E53 + E40 * (1 - E53));
        float S38 = E57 * 1000;
        //R38 = S38/1000/(0.622+S38/1000)*101325
        float R38 = S38 / 1000f / (0.622f + S38 / 1000f) * 101325f;
        // E55 = (E40*E53*E43+E40*(1-E53)*H63)/(E40*E53+E40*(1-E53))
        float E43 = t;
        float H63 = 0.5f;
        float E55 = (E40 * E53 * E43 + E40 * (1 - E53) * H63) / (E40 * E53 + E40 * (1 - E53));
        float O38 = E55;
        //Q38 =100000*EXP(11.78*(273.15+O38-372.79)/(273.15+O38-43.15))
        float Q38 = 100000f * Mathf.Exp(11.78f * (273.15f + O38 - 372.79f) / (273.15f + O38 - 43.15f));
        float h2f = R38 / Q38;
        h2.text = Mathf.RoundToInt(h2f * 100f) + "%";

        
        // Debug.Log("roi =" + roi.ToString());
        float E69 = hk + 27.6f / (1 * roi);//E69 = E46 + E63 / E40; page 1, E46 = hk, E63 = 27.6, E40 = roi * E37
       // Debug.Log("hkelp =" + hkelp.ToString());
        float t3Value = (E69 - (E45 * 2501f)) / (1.006f + (E45 * 1.85f));//E64 = (E69 - E66 * 2501) / (E39 + E66 * 1.85); E69 = hkelp, E66 = xu, E39 = 1.006
        t3.text = (Mathf.Round(t3Value * 10f) / 10f).ToString();
        float phelp = E45 / (0.622f + E45) * 101325f;//E68 = E66 / (0.622 + E66) * 101325; E66 = xu
        //Debug.Log("phelp =" + phelp.ToString());
        float t3f = float.Parse(t3.text);
       // Debug.Log("t3f =" + t3f.ToString());
        float phelp2 = 100000f * Mathf.Exp(11.78f * (t3f + 273.15f - 372.79f) / (t3f + 273.15f - 43.15f));//E67 = 100000 * EXP(11.78 * (E64 + 273.15 - 372.79) / (E64 + 273.15 - 43.15)); E64 = t3
       // Debug.Log("phelp2 =" + phelp2.ToString());
        float h3Value = (phelp / phelp2) * 100f;// E65 = E68 / E67 * 100; E68 = phelp, E67 = phelp2
        h3.text = Mathf.RoundToInt(h3Value) + "%";
        float h3f = float.Parse(h3.text.Replace("%", ""));
        // Debug.Log("h3f =" + h3f.ToString());

        //t4 and h4
        //t4 = E88, E88 =E64+E86*(H43-E64), E64 = t3, E86 = 2/(1+E83)*E84, H43 = 22
        //E83 =E40/H40, E40 = roi * a, a is the speed of air passage in 1 second (E37), H40 = H37 * i25; H37 = 1.205(air outlet speed), 
        //i25 = c19 * (c17 - i22) / (c18 * (H43 + 273.15)); page number 2, c19 = 0.028964, c18 = 8.314,
        //c17 = 101325, c19 = 0.028964, c18 = 8.314,
        //i22 = =I21*I16, 
        //i15 = H43 + 273.15
        //I21 = C17*EXP(11.78*(I15-372.79)/(I15-43.15))
        //i16 = 30 * 0.01f

        //h4 = =R40/Q40
        //R40 = S40/1000/(0.622+S40/1000)*101325
        //Q40 = =100000*EXP(11.78*(273.15+O40-372.79)/(273.15+O40-43.15))
        //O40 = t4

        //S40 = =E90*1000
        //E90 = =E66+E87*(H45-E66)
        //E66 = =(E40*E53*E45+E40*(1-E53)*H66)/(E40*E53+E40*(1-E53))
        //E87 = 2/(1+E83)*E85
        //H45 =0.622*(I22/(C17-I22))
        //E40 = roi * a, a this is the speed of air passage in 1 second (E37), 
        //E53 = 1, 100% air intake from the street
        //E45 = xu
        //H66 = H45-H87*(H45-E45)
        //h87 = E87*E83
        //E85 = 0.564
        //E87 = 2/(1+E83)*E85
        //temperature calculation

        float S40 = E90 * 1000;
        float t4f = t3f + E86 * (22 - t3f);
        //Q40 = =100000*EXP(11.78*(273.15+O40-372.79)/(273.15+O40-43.15))
        float Q40 = 100000f * Mathf.Exp(11.78f * (273.15f + t4f - 372.79f) / (273.15f + t4f - 43.15f));
        //R40 = S40/1000/(0.622+S40/1000)*101325
        float R40 = S40 / 1000f / (0.622f + S40 / 1000f) * 101325f;
        float h4f = R40 / Q40;
        t4.text = (Mathf.Round(t4f * 10f) / 10f).ToString();
        h4.text = Mathf.RoundToInt(h4f * 100f) + "%";

        //t5 and h5
        //t5 = E98, E98 =t4+0.5;
        //h5 = =R41/Q41
        //R41=E90*1000/1000/(0.622+E90*1000/1000)*101325
        //Q41 =100000*EXP(11.78*(273.15+O41-372.79)/(273.15+O41-43.15))
        float t5f = t4f + 0.5f;
        t5.text = (Mathf.Round(t5f * 10f) / 10f).ToString();
        float R41 = E90 * 1000f / 1000f / (0.622f + E90 * 1000f / 1000f) * 101325f;
        float Q41 = 100000f * Mathf.Exp(11.78f * (273.15f + (t5f + 0.5f) - 372.79f) / (273.15f + (t5f + 0.5f) - 43.15f));
        float h5f = R41 / Q41;
        h5.text = Mathf.RoundToInt(h5f * 100f) + "%";

        //t6 and h6
        //t6 = 20;
        float t6f = 20f;
        t6.text = (Mathf.Round(t6f * 10f) / 10f).ToString();
        //h6 = =R42/Q42
        //float R42 = E90 / 1000 / (0.622 + E90 / 1000) * 101325;
        float R42 = E90 * 1000f / 1000f / (0.622f + E90 * 1000f / 1000f) * 101325f;
        //Debug.Log("R42 =" + R42.ToString());
        float Q42 = 100000f * Mathf.Exp(11.78f * (273.15f + (t6f + 0.5f) - 372.79f) / (273.15f + (t6f + 0.5f) - 43.15f));
        //Debug.Log("Q42 =" + Q42.ToString());
        float h6f = R42 / Q42;
        //Debug.Log("h6f =" + h6f.ToString());
        h6.text = Mathf.RoundToInt(h6f * 100f) + "%";

        //t7 and h7
        float t7f = 20f;
        t7.text = (Mathf.Round(t6f * 10f) / 10f).ToString();
        //h7 = =R43/Q43
        float R43 = E90 * 1000f / 1000f / (0.622f + E90 * 1000f / 1000f) * 101325f;
        float Q43 = 100000f * Mathf.Exp(11.78f * (273.15f + (t7f + 0.5f) - 372.79f) / (273.15f + (t7f + 0.5f) - 43.15f));
        float h7f = R43 / Q43;
        h7.text = Mathf.RoundToInt(h7f * 100f) + "%";

        float t7fw = t7f;
        float h7fw = h7f;
        t7w.text = (Mathf.Round(t7fw * 10f) / 10f).ToString();
        h7w.text = Mathf.RoundToInt(h7fw * 100f) + "%";

        //t8 and h8
        //t8 = H43; H43 = 22
        float t8f = 22f;
        t8.text = (Mathf.Round(t8f * 10f) / 10f).ToString();
        //h8 = =R44/Q44
        float R44 = H45 * 1000f / 1000f / (0.622f + H45 * 1000f / 1000f) * 101325f;
        float Q44 = 100000f * Mathf.Exp(11.78f * (273.15f + (t8f + 0.5f) - 372.79f) / (273.15f + (t8f + 0.5f) - 43.15f));
        float h8f = R44 / Q44;
        h8.text = Mathf.RoundToInt(h8f * 100f) + "%";

        //t9 and h9
        //t9 = H88; 
        //H88 = (H93-H90*2501)/(H39+H90*2501)
        //H93 = H46-E94/H40        
        float H46 = 22 * 1.006f + H45 * (2501f + 1.85f * 22);
        //E94 = E40*(E93-E69)
        //float E40 = roi * 1;
        //E93 = =E88*$E$39+E90*(2501+1.85*E88)        
        float E93 = t4f * 1.01f + E90 * (2501 + 1.85f * t4f);
        float E94 = E40 * (E93 - E69);
        float H93 = H46 - E94 / H40;
        //H90 = H45-H87*(H45-E45)
        float H90 = H45 - H87 * (H45 - E45);
        float H39 = 1.006f;
        float H88 = (H93 - H90 * 2501f) / (H39 + H90 * 2501f);
        float t9f = H88;
        t9.text = (Mathf.Round(t9f * 10f) / 10f).ToString();
        //h9 = =R45/Q45
        //R45 = H90*1000/1000/(0.622+H90*1000/1000)*101325
        float R45 = H90 * 1000f / 1000f / (0.622f + H90 * 1000f / 1000f) * 101325f;  
        //Debug.Log("R45 =" + R45.ToString());
        //Q45 =  =100000*EXP(11.78*(273.15+O45-372.79)/(273.15+O45-43.15))
        float Q45 = 100000f * Mathf.Exp(11.78f * (273.15f + t9f - 372.79f) / (273.15f + t9f - 43.15f));
        //Debug.Log("Q45 =" + Q45.ToString());    
        float h9f = R45 / Q45;
        //Debug.Log("h9f =" + h9f.ToString());
        h9.text = Mathf.RoundToInt(h9f * 100f) + "%";

        //t10 and h10
        //t10 = H64;
        //H64 = =H88+H63
        float H64 = H88 + 0.5f;
        float t10f = H64;
        t10.text = (Mathf.Round(t10f * 10f) / 10f).ToString();
        //h10 = =R46/Q46
        //R46 = =S46/1000/(0.622+S46/1000)*101325
        float S46 = H66 * 1000;
        //Debug.Log("S46 =" + S46.ToString());
        float R46 = S46  / 1000f / (0.622f + S46 / 1000f) * 101325f;
        //Debug.Log("R46 =" + R46.ToString());
        //Q46 = =100000*EXP(11.78*(273.15+O46-372.79)/(273.15+O46-43.15))
        //O46 = H46
        float Q46 = 100000f * Mathf.Exp(11.78f * (273.15f + t10f - 372.79f) / (273.15f + t10f - 43.15f)); 
        //Debug.Log("Q46 =" + Q46.ToString());
        float h10f = R46 / Q46;
       // Debug.Log("h10f =" + h10f.ToString());
        h10.text = Mathf.RoundToInt(h10f * 100f) + "%";

        //t11 and h11
        //t11 = H64;
        float t11f = H64;
        t11.text = (Mathf.Round(t11f * 10f) / 10f).ToString();
        //h11 = =R47/Q47
        //R47 = =S47/1000/(0.622+S47/1000)*101325
        float H57 = H66;
        float S47 = H57 * 1000;
        float R47 = S47 / 1000f / (0.622f + S47 / 1000f) * 101325f;
        //Q47 = =100000*EXP(11.78*(273.15+O47-372.79)/(273.15+O47-43.15))
        float Q47 = 100000f * Mathf.Exp(11.78f * (273.15f + t11f - 372.79f) / (273.15f + t11f - 43.15f));
        float h11f = R47 / Q47;
        h11.text = Mathf.RoundToInt(h11f * 100f) + "%";


        StartCoroutine(RotateObject(rotatingObject1));
        StartCoroutine(RotateObject(rotatingObject2));
        // Play the sound
        audioSource.PlayOneShot(clickSound);
    }
    IEnumerator RotateObject(GameObject obj)
    {
        while (true)
        {
            obj.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
    public void OnClickSummer()
    {
        float t = float.Parse(temp1.text);
        float h = float.Parse(humidity1.text);
        tu.text = t.ToString();
        this.hu.text = h.ToString() + "%";
        t1.text = t.ToString();
        //h1 = R149/Q149 
        //R149 = S149/1000/(0.622+S149/1000)*101325
        // S149 =E151*1000
        //E151   = C65
        //C65 = =0.622*(C64/(C59-C64))
        //C64 = =C63*C58
        //C63 = =C59*EXP(11.78*(C57-372.79)/(C57-43.15))
        float E150 = h / 100;
        float C58 = E150;
        float C59 = 101325f;
        float C57 = t + 273.15f;
        float C63 = C59 * Mathf.Exp(11.78f * (C57 - 372.79f) / (C57 - 43.15f));
        float C64 = C63 * E150;
        float C65 = 0.622f * (C64 / (C59 - C64));
        float E151 = C65;
        float S149 = E151 * 1000;
        float R149 = S149 / 1000f / (0.622f + S149 / 1000f) * 101325f;
        //Q149 = ==
    }
}
