using System;
using WeakEvents;
using Xunit;
using FluentAssertions;

namespace XUnitTest.WeakEvents.Tests
{
    public class WeakEventsTests
    {
        class TestData
        {
            public int Value;
        }

        class Listener
        {
            public TestData observe { get; internal set; }

            internal void Listen(TestData data)
            {
                observe.Value = data.Value;
            }
        }

        [Fact]
        public void InstanceListener()
        {
            var sourceData = new TestData() { Value = 1 };
            var observeData1 = new TestData();
            var observeData2 = new TestData();

            var publisher = new Publisher<TestData>();
            var listener1 = new Listener() { observe = observeData1 };
            var listener2 = new Listener() { observe = observeData2 };

            publisher.AddListener(listener1.Listen);
            publisher.AddListener(listener2.Listen);
            publisher.Raise(sourceData);

            observeData1.Value.Should().Be(1);
            observeData2.Value.Should().Be(1);

            listener1 = null;


        }
    }
}
