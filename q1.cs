using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar1
{
    public class GetMaxStack <T> where T : IComparable
    {
        private class StackElement(T value, T max, StackElement? previous)
        {
            public T Value { get; } = value;
            public T Max { get; } = max;
            public StackElement? Previous { get; } = previous;
        }

        private StackElement? _top;

        public void Push(T value) =>
            _top = new StackElement(value, GetMax(value), _top);

        public T GetMax()
        {
            if (_top is null)
                throw new InvalidOperationException("Stack is empty");
            return _top.Max;
        }

        public T Pop()
        {
            if (_top is null)
                throw new InvalidOperationException("Stack is empty");

            var value = _top.Value;
            _top = _top.Previous;
            return value;
        }

        private T GetMax(T value)
        {
            if (_top is null)
                return value;

            return _top.Max.CompareTo(value) > 0 ? _top.Max : value;
        }

    }
}
