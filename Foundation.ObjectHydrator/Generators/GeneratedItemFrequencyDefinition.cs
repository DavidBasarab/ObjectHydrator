﻿using System;
using System.Collections.Generic;

namespace Foundation.ObjectHydrator.Generators
{
    internal class GeneratedItemFrequencyDefinition<T>
    {
        public GeneratedItemFrequencyDefinition(T value, int frequency= 1)
        {
            if (frequency < 0)
            {
                throw new ArgumentException("The frequency must be greater than or equal to zero", nameof(frequency));
            }
            Value = value;
            Frequency = frequency;
        }

        public GeneratedItemFrequencyDefinition(KeyValuePair<T, int> value)
        {
            Value = value.Key;
            Frequency = value.Value;
        }

        public T Value { get; }
        public int Frequency { get; }

        public IReadOnlyCollection<T> ToValues
        {
            get
            {
                var valuesAtFrequency = new List<T>(this.Frequency);
                for (int i = 0; i < this.Frequency; i++)
                {
                    valuesAtFrequency.Add(this.Value);
                }

                return valuesAtFrequency;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} x {1}", Value == null ? "null": Value.ToString(), Frequency);
        }
    }
}