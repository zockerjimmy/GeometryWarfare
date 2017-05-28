using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class GridMesh : MonoBehaviour
{

    /* public int GridSize;

     void Awake()
     {
         MeshFilter filter = gameObject.GetComponent<MeshFilter>();
         var mesh = new Mesh();
         var verticies = new List<Vector3>();

         var indicies = new List<int>();
         for (int i = 0; i < GridSize; i++)
         {
             verticies.Add(new Vector3(i, 0, 0));
             verticies.Add(new Vector3(i, 0, GridSize));

             indicies.Add(4 * i + 0);
             indicies.Add(4 * i + 1);

             verticies.Add(new Vector3(0, 0, i));
             verticies.Add(new Vector3(GridSize, 0, i));

             indicies.Add(4 * i + 2);
             indicies.Add(4 * i + 3);
         }

         mesh.vertices = verticies.ToArray();
         mesh.SetIndices(indicies.ToArray(), MeshTopology.Lines, 0);
         filter.mesh = mesh;

         MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
         meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
         meshRenderer.material.color = Color.white;
     }*/

    Spring[] springs;
    PointMass[,] points;  

    public GridMesh(Rect size, Vector2 spacing)
    {
        var springList = new List<Spring>();

        int numColumns = (int)(size.width / spacing.x) + 1;
        int numRows = (int)(size.height / spacing.y) + 1;
        points = new PointMass[numColumns, numRows];

        PointMass[,] fixedPoints = new PointMass[numColumns, numRows];

        int column = 0, row = 0;
        for (float y = size.yMin; y < size.yMax; y += spacing.y)
        {
            for (float x = size.xMin; x <= size.xMax; x += spacing.x)
            {
                points[column, row] = new PointMass(new Vector3(x, y, 0), 1);
                fixedPoints[column, row] = new PointMass(new Vector3(x, y, 0), 0);
                column++;
            }
            row++;
            column = 0;
        }

        for (int y = 0; y < numRows; y++)
            for (int x = 0; x < numColumns; x++)
            {
                if (x == 0 || y == 0 || x == numColumns - 1 || y == numRows - 1)
                    springList.Add(new Spring(fixedPoints[x, y], points[x, y], 0.1f, 0.1f));
                else if (x % 3 == 0 && y % 3 == 0)
                    springList.Add(new Spring(fixedPoints[x, y], points[x, y], 0.002f, 0.002f));

                const float stiffness = 0.28f;
                const float damping = 0.06f;
                if (x > 0)
                    springList.Add(new Spring(points[x - 1, y], points[x, y], stiffness, damping));
                if (y > 0)
                    springList.Add(new Spring(points[x, y - 1], points[x, y], stiffness, damping));
            }
        springs = springList.ToArray();
    }

    private void Start()
    {
        //GGridMesh(new Rect(0,0, 5f,5f), new Vector2(1f,1f));
    }

    public void Update()
    {
       // Debug.Log(springs.Length);
        /*foreach (Spring spring in springs)
        {
            spring.Update();
        }*/
        /* foreach (PointMass mass in points)
         {
             mass.Update();
         }*/
    }

    private class PointMass
    {
        public Vector3 Position;
        public Vector3 Velocity;
        public float InverseMass;

        private Vector3 acceleration;
        private float damping = 0.98f;

        public PointMass(Vector3 position, float invMass)
        {
            Position = position;
            InverseMass = invMass;
        }

        public void ApplyForce(Vector3 force)
        {
            acceleration += force * InverseMass;
        }

        public void IncreaseDamping(float factor)
        {
            damping *= factor;
        }

        public void Update()
        {
            Velocity += acceleration;
            Position += Velocity;
            acceleration = Vector3.zero;
            if (Velocity.sqrMagnitude < 0.001f * 0.001f) Velocity = Vector3.zero;

            Velocity *= damping;
            damping = 0.98f;
        }
    }

    private struct Spring
    {
        public PointMass End1;
        public PointMass End2;
        public float TargetLength;
        public float Stiffness;
        public float Damping;

        public Spring(PointMass end1, PointMass end2, float stiffness, float damping)
        {
            End1 = end1;
            End2 = end2;
            Stiffness = stiffness;
            Damping = damping;
            TargetLength = Vector3.Distance(End1.Position, End2.Position) * 0.95f;
        }

        public void Update()
        {
            var x = End1.Position - End2.Position;

            float length = x.magnitude;
            if (length <= TargetLength)
            {
                return;
            }

            x = (x / length) * (length - TargetLength);
            var dv = End2.Velocity - End1.Velocity;
            var force = Stiffness * x - dv * Damping;

            End1.ApplyForce(-force);
            End2.ApplyForce(force);
        }
    }


    public void ApplyDirectedForce(Vector3 force, Vector3 position, float radius)
    {
        foreach (var mass in points)
            if((position - mass.Position).sqrMagnitude < radius * radius)
                mass.ApplyForce(10 * force / (10 + Vector3.Distance(position, mass.Position)));
            //if (Vector3.DistanceSquared(position, mass.Position) < radius * radius)
    }

    public void ApplyImplosiveForce(float force, Vector3 position, float radius)
    {
        foreach (var mass in points)
        {
            //float dist2 = Vector3.DistanceSquared(position, mass.Position);
            float dist2 = (position - mass.Position).sqrMagnitude;
            if (dist2 < radius * radius)
            {
                mass.ApplyForce(10 * force * (position - mass.Position) / (100 + dist2));
                mass.IncreaseDamping(0.6f);
            }
        }
    }

    public void ApplyExplosiveForce(float force, Vector3 position, float radius)
    {
        foreach (var mass in points)
        {
            //float dist2 = Vector3.DistanceSquared(position, mass.Position);
            float dist2 = (position - mass.Position).sqrMagnitude;
            if (dist2 < radius * radius)
            {
                mass.ApplyForce(100 * force * (mass.Position - position) / (10000 + dist2));
                mass.IncreaseDamping(0.6f);
            }
        }
    }

}


