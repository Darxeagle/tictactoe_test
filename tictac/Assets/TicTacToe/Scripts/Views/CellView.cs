using System;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Scripts.Views
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private GameObject glowImage;
        [SerializeField] private GameObject crossContainer;
        [SerializeField] private GameObject circleContainer;
        [SerializeField] private Button button;

        private CellModel model;

        public Action<CellModel> Clicked;

        private void Awake()
        {
            button.onClick.AddListener(OnClicked);
            glowImage.SetActive(false);
        }
        
        public void SetModel(CellModel _model)
        {
            model = _model;
            model.StateChanged += OnStateChanged;
            model.GlowChanged += OnGlowChanged;
        }

        private void OnStateChanged(CellState _state)
        {
            crossContainer.SetActive(_state == CellState.cross);
            circleContainer.SetActive(_state == CellState.circle);
        }
        
        private void OnGlowChanged(bool _glow)
        {
            glowImage.SetActive(_glow);
        }
        
        private void OnClicked()
        {
            if (model != null)
            {
                Clicked?.Invoke(model);
            }
        }
    }
}