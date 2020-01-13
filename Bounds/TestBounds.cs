using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class TestBounds : MonoBehaviour {

    Renderer rend;
    void OnEnable()
    {
        rend = GetComponent<Renderer>();
        bd = tr.GetComponent<Renderer>().bounds;
        Debug.Log("    start      "+rend.bounds.center+"     "+ rend.bounds.extents+" //  " + bd.center + "    " + bd.extents);        
    }
    
    // Draws a wireframe sphere in the Scene view, fully enclosing
    // the object.
    Vector3 center;
     float radius;
    void OnDrawGizmosSelected()
    {   
        // A sphere that fully encloses the bounding box.
        center = rend.bounds.center;
        radius= rend.bounds.extents.magnitude;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center, radius);
    }

    private void OnDrawGizmos1()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(center, radius);
    }

    public Transform tr;
    Bounds bd;
    public void TestExtentsBounds()
    {
       
        rend.bounds.Encapsulate(bd);
    }
    private void OnGUI()
    {
        if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,100,100),new GUIContent("测试")))
        {
            TestExtentsBounds();
            //Debug.Log(rend.bounds.center+"    "+ rend.bounds.extents);
            Debug.Log("    change      " + rend.bounds.center + "     " + rend.bounds.extents + " //  " + bd.center + "    " + bd.extents);
        }
    }
}
