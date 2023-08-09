using System.Collections.Generic;
using Assets.Scripts.Base.Events;
using Assets.Scripts.Base.Input;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.Base.Gameplay
{
    //[CreateAssetMenu(fileName = "GameState", menuName = "Gameplay/GameState")]
    public class GameStateSO : DescriptionBaseSO
    {
        public GameState CurrentGameState => _currentGameState;

        [Header("Game states")]
        
        [SerializeField] [ReadOnly]
        private GameState _currentGameState;

        [SerializeField] [ReadOnly]
        private GameState _previousGameState;

        [Header("Broadcasting on")]
        
        [SerializeField]
        private BoolEventChannelSO _onCombatStateEvent;

        private List<Transform> _alertEnemies;

        private void Start()
        {
            _alertEnemies = new List<Transform>();
        }

        public void AddAlertEnemy(Transform enemy)
        {
            if (!_alertEnemies.Contains(enemy))
            {
                _alertEnemies.Add(enemy);
            }

            UpdateGameState(GameState.Combat);
        }

        public void RemoveAlertEnemy(Transform enemy)
        {
            if (_alertEnemies.Contains(enemy))
            {
                _alertEnemies.Remove(enemy);

                if (_alertEnemies.Count == 0)
                {
                    UpdateGameState(GameState.Gameplay);
                }
            }
        }

        public void UpdateGameState(GameState newGameState)
        {
            if (newGameState == CurrentGameState)
                return;

            if (newGameState == GameState.Combat)
            {
                _onCombatStateEvent.RaiseEvent(true);
            }
            else
            {
                _onCombatStateEvent.RaiseEvent(false);
            }

            _previousGameState = _currentGameState;
            _currentGameState = newGameState;
        }

        public void ResetToPreviousGameState()
        {
            if (_previousGameState == _currentGameState)
                return;

            if (_previousGameState == GameState.Combat)
            {
                _onCombatStateEvent.RaiseEvent(false);
            }
            else if (_currentGameState == GameState.Combat)
            {
                _onCombatStateEvent.RaiseEvent(true);
            }

            GameState stateToReturnTo = _previousGameState;
            _previousGameState = _currentGameState;
            _currentGameState = stateToReturnTo;
        }
    }
}