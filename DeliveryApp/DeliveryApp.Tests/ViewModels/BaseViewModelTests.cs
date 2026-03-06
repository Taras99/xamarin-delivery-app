using DeliveryApp.ViewModels;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;

namespace DeliveryApp.Tests.ViewModels
{
    [TestFixture]
    public class BaseViewModelTests
    {
        private class TestViewModel : BaseViewModel
        {
            private string _value = string.Empty;
            public string Value
            {
                get => _value;
                set { _value = value; OnPropertyChanged(); }
            }

            private int _count;
            public int Count
            {
                get => _count;
                set { _count = value; OnPropertyChanged(); }
            }
        }

        [Test]
        public void OnPropertyChanged_RaisesEvent_WithCorrectPropertyName()
        {
            var vm = new TestViewModel();
            var raisedProperties = new List<string>();
            vm.PropertyChanged += (s, e) => raisedProperties.Add(e.PropertyName);

            vm.Value = "hello";

            Assert.That(raisedProperties, Contains.Item("Value"));
        }

        [Test]
        public void OnPropertyChanged_RaisesEvent_OnEachPropertyChange()
        {
            var vm = new TestViewModel();
            var raisedCount = 0;
            vm.PropertyChanged += (s, e) => raisedCount++;

            vm.Value = "first";
            vm.Value = "second";
            vm.Count = 10;

            Assert.That(raisedCount, Is.EqualTo(3));
        }

        [Test]
        public void PropertyChanged_EventSender_IsViewModel()
        {
            var vm = new TestViewModel();
            object? capturedSender = null;
            vm.PropertyChanged += (s, e) => capturedSender = s;

            vm.Value = "test";

            Assert.That(capturedSender, Is.SameAs(vm));
        }

        [Test]
        public void PropertyChanged_NoSubscribers_DoesNotThrow()
        {
            var vm = new TestViewModel();

            Assert.DoesNotThrow(() => vm.Value = "safe");
        }

        [Test]
        public void BaseViewModel_ImplementsINotifyPropertyChanged()
        {
            var vm = new TestViewModel();

            Assert.That(vm, Is.InstanceOf<INotifyPropertyChanged>());
        }
    }
}
