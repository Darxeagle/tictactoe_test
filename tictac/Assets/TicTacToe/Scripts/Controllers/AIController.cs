using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TicTacToe.Scripts
{
    public class AIController : MonoBehaviour
    {
        [Inject] private GameplayController gameplayController;
        [Inject] private GameStateModel stateModel;
        [Inject] private FieldModel fieldModel;

        private void Start()
        {
            stateModel.StateChanged += OnStateChanged;
        }

        private void OnStateChanged(GameState _state)
        {
            if (_state == GameState.enemyTurn)
            {
                StartCoroutine(EnemyTurn());
            }
        }

        private IEnumerator EnemyTurn()
        {
            yield return new WaitForSeconds(1f);
            gameplayController.SelectCell(fieldModel.CellModels.Where(_cell => _cell.State == CellState.empty).OrderBy(_ => Guid.NewGuid()).First());
        }
    }
}