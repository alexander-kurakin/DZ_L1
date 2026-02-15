using System;
using _Project.Develop.Runtime.Configs.Gameplay;
using _Project.Develop.Runtime.Gameplay.Utilities;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Logic
{
    public class GameplayCycleService
    {
        public event Action OnWin;
        public event Action OnLose;
        
        private SymbolGeneratorService _symbolGeneratorService;
        private LevelConfig _currentLevelConfig;
        private string _targetSequence;
        private bool _shouldCheckInput;
        private string _currentUserInput;
        private int _currentIndex = 0;
        private bool _winConditionReached;
        private bool _loseConditionReached;

        public GameplayCycleService(SymbolGeneratorService symbolGeneratorService, LevelConfig currentLevelConfig)
        {
            _symbolGeneratorService = symbolGeneratorService;
            _currentLevelConfig = currentLevelConfig;
        }

        public void Prepare()
        {
            Debug.Log("Preparing target sequence");
            SetTargetSequence();
        }

        public void Launch()
        {
            if (_targetSequence != null)
            {
                Debug.Log("Launching target sequence= " + _targetSequence);
                _shouldCheckInput = true;
            }
            else
            {
                throw new ArgumentException("Target sequence is empty");
            }

        }

        public void SetTargetSequence()
        {
            _targetSequence = _symbolGeneratorService.GenerateRandom(_currentLevelConfig.CheckStringLength);
        }

        public void Update(float deltaTime)
        {
            if (_shouldCheckInput)
            {
                CheckUserInput();
            }
            else
            {
                if (_winConditionReached ||  _loseConditionReached)
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        if (_winConditionReached)
                            OnWin?.Invoke();
                        else
                            OnLose?.Invoke();
                    }
            }
        }

        private void CheckUserInput()
        {
            if (Input.anyKeyDown)
            {
                _currentUserInput = Input.inputString;
                
                foreach (char inputSymbol in _currentUserInput)
                {
                    if (char.IsLetterOrDigit(inputSymbol) == false)
                        continue;
                    
                    if (char.ToLower(inputSymbol) == char.ToLower(_targetSequence[_currentIndex]))
                    {
                        _currentIndex++;
                        Debug.Log($"Верно! {_currentIndex}/{_targetSequence.Length}");

                        if (_currentIndex >= _targetSequence.Length)
                        {
                            Debug.Log("Win! Press space to continue");
                            _winConditionReached = true;
                            _shouldCheckInput = false;
                        }
                    }
                    else
                    {
                        Debug.Log("Error! Press space to try again");
                        _loseConditionReached = true; 
                        _shouldCheckInput = false;
                    }
                }
            }
        }
    }
}