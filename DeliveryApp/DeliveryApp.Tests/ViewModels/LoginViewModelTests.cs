using DeliveryApp.ViewModels;
using NUnit.Framework;
using System.Collections.Generic;

namespace DeliveryApp.Tests.ViewModels
{
    /// <summary>
    /// Tests for LoginViewModel that do not invoke commands (commands require Xamarin runtime).
    /// To test command execution fully, UserService should be extracted behind an interface
    /// and injected via constructor, allowing Moq-based substitution.
    /// </summary>
    [TestFixture]
    public class LoginViewModelTests
    {
        [Test]
        public void Constructor_InitializesDisable_ToFalse()
        {
            var vm = new LoginViewModel();

            Assert.That(vm.Disable, Is.False);
        }

        [Test]
        public void Constructor_InitializesIsBusy_ToFalse()
        {
            var vm = new LoginViewModel();

            Assert.That(vm.IsBusy, Is.False);
        }

        [Test]
        public void Constructor_LoginCommand_IsNotNull()
        {
            var vm = new LoginViewModel();

            Assert.That(vm.LoginCommand, Is.Not.Null);
        }

        [Test]
        public void Constructor_RegisterCommand_IsNotNull()
        {
            var vm = new LoginViewModel();

            Assert.That(vm.RegisterCommand, Is.Not.Null);
        }

        [Test]
        public void Username_SetValue_RaisesPropertyChanged()
        {
            var vm = new LoginViewModel();
            var raised = new List<string>();
            vm.PropertyChanged += (s, e) => raised.Add(e.PropertyName!);

            vm.Username = "testuser";

            Assert.That(raised, Contains.Item("Username"));
        }

        [Test]
        public void Password_SetValue_RaisesPropertyChanged()
        {
            var vm = new LoginViewModel();
            var raised = new List<string>();
            vm.PropertyChanged += (s, e) => raised.Add(e.PropertyName!);

            vm.Password = "secret";

            Assert.That(raised, Contains.Item("Password"));
        }

        [Test]
        public void IsBusy_SetValue_RaisesPropertyChanged()
        {
            var vm = new LoginViewModel();
            var raised = new List<string>();
            vm.PropertyChanged += (s, e) => raised.Add(e.PropertyName!);

            vm.IsBusy = true;

            Assert.That(raised, Contains.Item("IsBusy"));
        }

        [Test]
        public void Disable_SetValue_RaisesPropertyChanged()
        {
            var vm = new LoginViewModel();
            var raised = new List<string>();
            vm.PropertyChanged += (s, e) => raised.Add(e.PropertyName!);

            vm.Disable = true;

            Assert.That(raised, Contains.Item("Disable"));
        }

        [Test]
        public void Username_SetAndGet_RetainsValue()
        {
            var vm = new LoginViewModel();

            vm.Username = "john_doe";

            Assert.That(vm.Username, Is.EqualTo("john_doe"));
        }

        [Test]
        public void Password_SetAndGet_RetainsValue()
        {
            var vm = new LoginViewModel();

            vm.Password = "p@ssw0rd";

            Assert.That(vm.Password, Is.EqualTo("p@ssw0rd"));
        }
    }
}
