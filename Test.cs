using NUnit.Framework;

namespace Seminar1
{

    [TestFixture]
    internal class Tests
    {
        [Test]
        public void Q1()
        {
            var stack = new GetMaxStack<int>();
            stack.Push(2);
            stack.Push(10);
            stack.Push(5);
            Assert.That(10, Is.EqualTo(stack.GetMax()));
            stack.Pop();
            stack.Pop();
            stack.Push(1);
            Assert.That(2, Is.EqualTo(stack.GetMax()));
        }

        [Test]
        public void Q2()
        {
            var stackQueue = new StackQueue<int>();
            stackQueue.Add(1);
            stackQueue.Add(2);
            stackQueue.Add(3);
            Assert.That(1, Is.EqualTo(stackQueue.Remove()));
            stackQueue.Add(4);
            Assert.That(2, Is.EqualTo(stackQueue.Remove()));
            Assert.That(3, Is.EqualTo(stackQueue.Remove()));
            Assert.That(4, Is.EqualTo(stackQueue.Remove()));
        }

        [Test]
        public void Q7()
        {
            var stack = new VersionedStack<int>();
            stack.Push(1); // 0 (1)
            stack.Push(2); // 1 (1,2)
            stack.Push(3); // 2 (1,2,3)
            stack.Push(4); // 3 (1,2,3,4)
            stack.Pop(); // 4 (1,2,3)
            stack.Push(10); // 5 (1,2,3,10)

            stack.Rollback(3); // 6 (1,2,3,4)
            Assert.That(4, Is.EqualTo(stack.Pop()));

            stack.Rollback(0); // 7 (1)
            Assert.That(1, Is.EqualTo(stack.Pop()));

            stack.Rollback(5); // 8 (1,2,3,10)
            Assert.That(10, Is.EqualTo(stack.Pop()));

            stack.Rollback(6); // 9 (1,2,3,4)
            Assert.That(4, Is.EqualTo(stack.Pop()));
        }

    }
}
