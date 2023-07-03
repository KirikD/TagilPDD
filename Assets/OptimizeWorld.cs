using EasyRoads3Dv3;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptimizeWorld : MonoBehaviour
{
    public float GlobalDistance = 300;
    List<GameObject> GetAllObjectsOnlyInScene()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (!EditorUtility.IsPersistent(go.transform.root.gameObject) && !(go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave))
                objectsInScene.Add(go);
        }

        return objectsInScene;
    }
    // ���������� �� �������



    public GameObject[] allObjects;
    public Transform Cam;
    void Start()
    {
        allObjects = GetAllObjectsOnlyInScene().ToArray();
        Cam = Camera.main.gameObject.transform;
        if (SceneManager.GetSceneByBuildIndex(2).IsValid() == false)
            SceneManager.LoadSceneAsync("Tagil_Buildnings", LoadSceneMode.Additive);

        if (SceneManager.GetSceneByBuildIndex(1).IsValid() == false)
            SceneManager.LoadSceneAsync("Tagil_Ways", LoadSceneMode.Additive);
        Invoke("OptimizeAll", 10);
    }
    bool enablerUpdate = false;
    void OptimizeAll()
    {
        allObjects = GetAllObjectsOnlyInScene().ToArray();
        Cam = Camera.main.gameObject.transform;
        print(Cam.gameObject.name + " is an active object");

        for (int i = 0; i < allObjects.Length; i++)
        {
            if (allObjects[i].GetComponent<MeshRenderer>() != null && allObjects[i].gameObject.tag == "WorldObjs") //
            {
                Opt.Add(allObjects[i].GetComponent<MeshRenderer>());

            }
            if (allObjects[i].GetComponent<ERModularRoad>() != null)
                Destroy(allObjects[i].GetComponent<ERModularRoad>());
        }
        coords = new Vector3[Opt.Count];
        for (int ii = 0; ii < Opt.Count; ii++)
        {
            Bounds Bou = Opt[ii].GetComponent<MeshFilter>().mesh.bounds;
            coords[ii] = Bou.center;
            float dist = math.distance(Cam.position, Opt[ii].transform.TransformPoint(coords[ii]));
            if (dist > GlobalDistance)
            { Opt[ii].enabled = false; }
            else
                Opt[ii].enabled = true;

            /*GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = Opt[ii].transform.TransformPoint(coords[ii]);
            sphere.name = Opt[ii].name;
            Opt[ii].gameObject.isStatic = true;*/

            /*LODGroup group = Opt[ii].gameObject.AddComponent<LODGroup>();
            LOD[] lods = new LOD[2];
            MeshRenderer[] r = new MeshRenderer[1];
            r[0] = Opt[ii];
            lods[0] = new LOD(0.5f, r);
            group.SetLODs(lods);
            group.size = Bou.size.magnitude;
            group.RecalculateBounds();
            Opt[ii].gameObject.GetComponent<LODGroup>().RecalculateBounds();
            
            group = null;
            lods = null;*/
        }
        enablerUpdate = true;
    }
    void UpdHid()
    {
        for (int ii = 0; ii < Opt.Count; ii++)
        {
            float dist = math.distance(Cam.position, Opt[ii].transform.TransformPoint(coords[ii]));
            if (dist > GlobalDistance)
            { Opt[ii].enabled = false; }
            else
                Opt[ii].enabled = true;
        }
    }
    public List<MeshRenderer> Opt = new List<MeshRenderer>();
    public Vector3[] coords;
    int adder = 0;
    void FixedUpdate()
    { if (enablerUpdate) { 
        float dist = math.distance(Cam.position, Opt[adder].transform.TransformPoint(coords[adder]));
        if (dist > GlobalDistance)
        { Opt[adder].enabled = false; }
        else
            Opt[adder].enabled = true;
        adder++;
        if (adder > Opt.Count - 1)
            adder = 0;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdHid();
        }
    } 
}
}
