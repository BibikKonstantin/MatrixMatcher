using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Renderer))]
    public class MatrixView : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        
        public Renderer Renderer => _renderer;
    }
}