
namespace Seminar1
{
    internal class StackQueue<T>
    {
        private enum State
        {
            Adding,
            Removing
        }
        
        private State _state = State.Adding;
        private readonly Stack<T> _main = new();
        private readonly Stack<T> _additional = new();

        public void Add(T item)
        {
            if (_state == State.Removing)
                Swap(_additional, _main);

            _state = State.Adding;
            _main.Push(item);
        }
        
        public T Remove()
        {
            if (_state == State.Adding)
                Swap(_main, _additional);

            _state = State.Removing;
            var item = _additional.Pop();
            return item;
        }

        private static void Swap(Stack<T> from, Stack<T> to)
        {
            if (from.Count < 0)
                throw new InvalidOperationException("StackQueue is empty");

            while (from.Count > 0)
                to.Push(from.Pop());
        }
    }
}
