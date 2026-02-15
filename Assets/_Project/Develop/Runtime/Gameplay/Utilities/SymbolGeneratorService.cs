using System;
using Random = UnityEngine.Random;

namespace _Project.Develop.Runtime.Gameplay.Utilities
{
    public class SymbolGeneratorService
    {
        private string _inputSymbols;

        public SymbolGeneratorService(String inputSymbols)
        {
            _inputSymbols = inputSymbols;
        }

        public string GenerateRandom(int desiredLength)
        {
            string resultString = "";
            char randomChar;

            for (int i = 0; i < desiredLength; i++)
            {
                randomChar = _inputSymbols[Random.Range(0, _inputSymbols.Length)];
                resultString += randomChar;
            }
            
            return resultString;
        }
        
        
    }
}