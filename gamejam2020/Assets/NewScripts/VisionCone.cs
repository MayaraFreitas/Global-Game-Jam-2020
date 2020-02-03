using Assets.NewScripts;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    private Mesh mesh;
    private Vector3 origin;
    public float fov = 60;
    public float viewDistance = 15f;

    private float startingAngle;
    private bool followThePlayer;
    private bool playerHasFound;
    private void Start()
    {
        this.transform.position = Vector3.zero;
        fov = fov == 0 ? 60 : fov;
        viewDistance = viewDistance == 0 ? 15f : viewDistance;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh; // Criando malha
        followThePlayer = false;
        playerHasFound = false;
    }

    private void LateUpdate()
    {
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        

    Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i=0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GenericGame.GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                // No hit object
                vertex = origin + GenericGame.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                // Hit object
                vertex = raycastHit2D.point;
                if (raycastHit2D.collider.gameObject.name == "Player")
                {
                    playerHasFound = true;
                }
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

        if (playerHasFound)
        {
            followThePlayer = true;
            playerHasFound = false;
        }
        else
        {
            followThePlayer = false;
        }
     
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public bool FollowThePlayer()
    {
        return followThePlayer;
    }

    public void SetOrigin(Vector3 playerOrigin)
    {
        origin = playerOrigin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        // Somando 90 por conta das posições do mapa
        startingAngle = GenericGame.GetAngleFromVectorFloat(aimDirection) - fov / 2 + fov;
    }
}
