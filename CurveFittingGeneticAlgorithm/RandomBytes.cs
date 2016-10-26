﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurveFittingGeneticAlgorithm
{
    public class RandomBufferGenerator
    {
        private readonly Random _random = new Random();
        private readonly byte[] _seedBuffer;

        public RandomBufferGenerator(int maxBufferSize)
        {
            _seedBuffer = new byte[maxBufferSize];

            _random.NextBytes(_seedBuffer);
        }

        public byte[] GenerateBufferFromSeed(int size)
        {
            int randomWindow = _random.Next(0, size);

            byte[] buffer = new byte[size];

            Buffer.BlockCopy(_seedBuffer, randomWindow, buffer, 0, size - randomWindow);
            Buffer.BlockCopy(_seedBuffer, 0, buffer, size - randomWindow, randomWindow);

            return buffer;
        }
    }
}
