using UnityEngine;
using Voody.UniLeo;

namespace FootballECS
{
    public class PlayerProvider : MonoBehaviour
    {
        [field: SerializeField] public Renderer[] BodyRenderers {get; private set;}
    }    
}