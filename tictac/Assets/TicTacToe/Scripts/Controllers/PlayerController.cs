using TicTacToe.Scripts.Views;
using UnityEngine;
using Zenject;

namespace TicTacToe.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [Inject] private GameplayView gameplayView;
        [Inject] private GameplayController gameplayController;
        [Inject] private GameStateModel stateModel;

        private void Start()
        {
            gameplayView.CellClicked += OnCellClicked;
        }

        private void OnCellClicked(CellModel _cellModel)
        {
            if (stateModel.State == GameState.playerTurn && _cellModel.State == CellState.empty)
            {
                gameplayController.SelectCell(_cellModel);
            }
        }
    }
}