using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TicTacToe.Scripts.Views
{
    public class GameplayView : MonoBehaviour
    {
        [Inject] private FieldModel fieldModel;

        [SerializeField] private List<CellView> cellViews;

        public Action<CellModel> CellClicked;

        private void Awake()
        {
            foreach (var cellView in cellViews)
            {
                cellView.Clicked += OnCellClicked;
            }

            for (int i = 0; i < 9; i++)
            {
                cellViews[i].SetModel(fieldModel.CellModels[i]);
            }
        }

        private void OnCellClicked(CellModel _cellModel)
        {
            CellClicked?.Invoke(_cellModel);
        }
    }
}
