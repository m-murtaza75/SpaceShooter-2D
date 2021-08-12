/*
Student Name: Muhammad Murtaza
Student ID: K00223470 
Desc: Script responsible for giving the background-scrolling effect 	 
*/

using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    public float scroll_speed = 5.4f;
    private float x_Scroll;

    private MeshRenderer mesh_Renderer;
    // Start is called before the first frame update
    void Awake()
    {
        mesh_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        x_Scroll = Time.time * scroll_speed;

        Vector2 offset = new Vector2(x_Scroll, 0f);
        mesh_Renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
