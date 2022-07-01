using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace TicTacToe.Scripts.Views
{
    public class UIView : MonoBehaviour
    {
        [Inject] private GameStateModel stateModel;
        
        [SerializeField] private GameObject playerTurnTooltip;
        [SerializeField] private GameObject enemyTurnTooltip;
        [SerializeField] private ResultWindowView resultView;

        public event Action ResultOkClicked;
        
        private void Start()
        {
            resultView.gameObject.SetActive(false);
            ApplyTurnTooltip(stateModel.State);
            stateModel.StateChanged += OnStateChanged;
            resultView.OkClicked += OnResultOkClicked;
        }

        private void OnStateChanged(GameState _state)
        {
            ApplyTurnTooltip(_state);
            
            if (_state == GameState.resultDraw || _state == GameState.resultWin || _state == GameState.resultLose)
            {
                resultView.SetState(_state);
                StartCoroutine(ShowResult());
            }
            else
            {
                resultView.gameObject.SetActive(false);
            }
        }

        private IEnumerator ShowResult()
        {
            yield return new WaitForSeconds(1f);
            resultView.gameObject.SetActive(true);
        }

        private void OnResultOkClicked()
        {
            ResultOkClicked?.Invoke();
        }

        private void ApplyTurnTooltip(GameState _state)
        {
            playerTurnTooltip.SetActive(_state == GameState.playerTurn);
            enemyTurnTooltip.SetActive(_state == GameState.enemyTurn);
        }
    }
}