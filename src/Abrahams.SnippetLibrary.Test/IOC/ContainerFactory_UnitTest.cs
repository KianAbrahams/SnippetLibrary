using Abrahams.SnippetLibrary.DomainModel.Validation;
using Microsoft.Practices.Unity;
using Abrahams.SnippetLibrary.DomainModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace Abrahams.SnippetLibrary.Test.IOC
{
    [TestFixture]
    public class ContainerFactory_UnitTest : UnitTestBase
    {
        [Test]
        public void Return_IsValid_Given_a_valid_tag()
        {
            // Arrange
            var result = new List<object>();
            int expectedCount = 0;

            // Act
            foreach (var registration in this.Container.Registrations)
            {
                try
                {
                    var instance = Container.Resolve(registration.RegisteredType);
                    instance.Should().NotBeNull();
                    instance.Should().BeAssignableTo(registration.RegisteredType);
                    result.Add(instance);
                    expectedCount += 1;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unable to instantiate '{registration.RegisteredType.FullName}'", ex);
                }
            }

            // Assert
            result.Should().HaveCount(expectedCount);
        }
    }
}
