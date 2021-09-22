using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Sample : MonoBehaviour
{
    string[] selectVsyncCounts = { "0", "1", "2" };
    int selectVsyncCountIdx;

    string[] targetFrameRates = { "-1", "30", "45", "60", "90", "120" };
    int targetFrameRateIdx;

    float deltaTimeMin;
    float deltaTimeMax;
    

    // Start is called before the first frame update
    void Start()
    {

        Screen.SetResolution(480, 800, true);


        selectVsyncCountIdx = QualitySettings.vSyncCount;
        switch (Application.targetFrameRate)
        {
            case 30:
                targetFrameRateIdx = 1;
                break;
            case 45:
                targetFrameRateIdx = 2;
                break;
            case 60:
                targetFrameRateIdx = 3;
                break;
            case 90:
                targetFrameRateIdx = 4;
                break;
            case 120:
                targetFrameRateIdx = 5;
                break;

            default:
                targetFrameRateIdx = 0;
                break;
        }
        deltaTimeMax = 0f;
        deltaTimeMin = float.MaxValue;
        
    }

    // Update is called once per frame
    void Update()
    {

    }




    private void OnGUI()
    {       
        if (deltaTimeMin > Time.deltaTime)
        {
            deltaTimeMin = Time.deltaTime;
        }
        if (deltaTimeMax < Time.deltaTime)
        {
            deltaTimeMax = Time.deltaTime;
        }        


        GUILayout.Label("Screen.currentResolution.refreshRate " + Screen.currentResolution.refreshRate + "[Hz]");
        GUILayout.Label("Time.deltaTime " + Time.deltaTime * 1000.0f + "[ms] " + 1.0f / Time.deltaTime + "[FPS]");
        GUILayout.Label("Time.smoothDeltaTime " + Time.smoothDeltaTime * 1000.0f + "[ms] " + 1.0f / Time.smoothDeltaTime + "[FPS]");
        GUILayout.Label("deltaTime" + deltaTimeMin * 1000.0f + " ~ " + deltaTimeMax * 1000.0f + "[min]");


        GUILayout.Space(100);

        GUILayout.BeginHorizontal();
        {
            GUILayout.Label("VSync");
            var tmp = selectVsyncCountIdx;
            selectVsyncCountIdx = GUILayout.SelectionGrid(selectVsyncCountIdx, selectVsyncCounts, 3);
            if (selectVsyncCountIdx != tmp)
            {
                QualitySettings.vSyncCount = selectVsyncCountIdx;
                deltaTimeMax = 0f;
                deltaTimeMin = float.MaxValue;
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20);

        GUILayout.BeginHorizontal();
        {
            GUILayout.Label("Target Frame Rate");
            var tmp = targetFrameRateIdx;
            targetFrameRateIdx = GUILayout.SelectionGrid(targetFrameRateIdx, targetFrameRates, 6);
            if (targetFrameRateIdx != tmp)
            {
                switch (targetFrameRateIdx)
                {
                    case 0:
                        Application.targetFrameRate = -1;
                        break;

                    case 1:
                        Application.targetFrameRate = 30;
                        break;

                    case 2:
                        Application.targetFrameRate = 45;
                        break;

                    case 3:
                        Application.targetFrameRate = 60;
                        break;

                    case 4:
                        Application.targetFrameRate = 90;
                        break;

                    case 5:
                        Application.targetFrameRate = 120;
                        break;
                }
                deltaTimeMax = 0f;
                deltaTimeMin = float.MaxValue;
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(20);

        if (GUILayout.Button("Reset"))
        {
            deltaTimeMax = 0f;
            deltaTimeMin = float.MaxValue;
        }
    }

    void ValueReset()
    {

    }
}
