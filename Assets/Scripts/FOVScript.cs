using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVScript : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask layerMask2;
    private Mesh mesh;
    private Vector3 origin;
    private float startingAngle;

    private bool player;
    public bool target;
    float fov;
    float viewDistance;
    int rayCount;

    void Start()
    {
        player = false;
        rayCount = 50;
        target = false;
        fov = 45.0f;
        mesh = new Mesh();
        viewDistance = 80.0f;
        mesh = GetComponent<MeshFilter>().mesh;
    }

    void LateUpdate()
    {
        if (player)
        {
            rayCount = 100;
        }
        else
        {
            rayCount = 20;
        }
        if (player && GameManager.instance.darkness)
        {
            gameObject.layer = 1;
        }
        else if (player && !GameManager.instance.darkness)
        {
            gameObject.layer = 9;
        }
        else
        {
            gameObject.layer = 1;
        }
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int hitAmount = 0;
        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i < rayCount; i++)
        {
            RaycastHit2D raycastHit2D;
            Vector3 vertex;
            if (player)
            {
                raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask2);
            }
            else
            {
                raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            }
            if (raycastHit2D.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
                hitAmount++;
            }
            else if (raycastHit2D.collider != null && raycastHit2D.collider.tag == "Player")
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
                if (!target)
                {
                    target = true;
                }
            }
            else if (raycastHit2D.collider != null && raycastHit2D.collider.tag == "Enemy")
            {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
                raycastHit2D.collider.gameObject.layer = 0;
            }
            else 
            {
                vertex = raycastHit2D.point;
                hitAmount++;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        if (hitAmount >= 20 && target)
        {
            target = false;
        }

        hitAmount = 0;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000);
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleToRad = angle * (Mathf.PI / 180.0f);
        return new Vector3(Mathf.Cos(angleToRad), Mathf.Sin(angleToRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    public void setOrigin (Vector3 origin)
    {
        this.origin = origin;
    }

    public void setAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) + fov / 2f;
    }

    public void setFov(float fov)
    {
        this.fov = fov;
    }

    public void setDistance(float distance)
    {
        this.viewDistance = distance;
    }

    public void setPlayer(int number)
    {
        if (number == 1)
        {
            this.player = true;
        }
        else
        {
            this.player = false;
        }
    }


}
