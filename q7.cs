using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar1
{
    internal class VersionedStack<T>
    {
        public class StackElement (T value, StackElement? previous)
        {
            public T Value { get; } = value;
            public StackElement? Previous { get; } = previous;

            public override string? ToString() => Value?.ToString();
        }

        private StackElement? _top;
        private StackElement? Top
        {
            get => _top;
            set
            {
                _top = value;
                _states[_states.Count] = _top;
            }
        }
        
        private readonly Dictionary<int, StackElement?> _states = new();

        public void Push(T item) =>
            Top = new StackElement(item, Top);

        public T Pop()
        {
            if (Top is null)
                throw new InvalidOperationException("Stack is empty");
            var value = Top.Value;
            Top = Top.Previous;
            return value;
        }

        public void Rollback(int state)
        {
            if (_states.TryGetValue(state, out var value))
                Top = value;
            else
                throw new InvalidOperationException("State not found");
        }
    }
}
