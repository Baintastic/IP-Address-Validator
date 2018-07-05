using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class IPAddressValidatorTests
    {
        [TestCase(false, "")]
        [TestCase(false, " ")]
        [TestCase(false, null)]
        public void ValidateIpv4Address_GivenEmptyIpAddress_ShouldReturnFalse(bool expected, string Ipv4Address)
        {
            //Arrange
            var sut = new IPAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(Ipv4Address);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(false, "Hello")]
        [TestCase(false, "Hello.is.me.25")]
        [TestCase(false, "12.is.13.1")]
        public void ValidateIpv4Address_GivenInvalidIpAddress_ShouldReturnFalse(bool expected, string Ipv4Address)
        {
            //Arrange
            var sut = new IPAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(Ipv4Address);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(false, "0.0.0.0")]
        [TestCase(false, "255.192.5.0")]
        [TestCase(false, "1.1.1.0")]
        public void ValidateIpv4Address_GivenIpAddressEndingWith0_ShouldReturnFalse(bool expected , string Ipv4Address) {
            //Arrange
            var sut = new IPAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(Ipv4Address);

            //Assert
            Assert.AreEqual(expected,actual);
        }

        
        [TestCase(false, "255.255.255.255")]
        [TestCase(false, "255.192.5.255")]
        [TestCase(false, "168.1.1.255")]
        public void ValidateIpv4Address_GivenIpAddressEndingWith255_ShouldReturnFalse(bool expected, string Ipv4Address)
        {
            //Arrange
            var sut = new IPAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(Ipv4Address);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(true, "255.255.255.30")]
        [TestCase(true, "172.168.0.253")]
        [TestCase(true, "168.1.1.132")]
        public void ValidateIpv4Address_GivenAValidIpAddressNotEndingWith255Or0_ShouldReturnTrue(bool expected, string Ipv4Address)
        {
            //Arrange
            var sut = new IPAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(Ipv4Address);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(false, "168.1.1")]
        [TestCase(false, "168.1.1.132.96")]
        [TestCase(false, "168.1.1.233.2.1")]
        public void ValidateIpv4Address_GivenIpAddressNotGroupedInto4Blocks_ShouldReturnFalse(bool expected, string Ipv4Address)
        {
            //Arrange
            var sut = new IPAddressValidator();

            //Act
            var actual = sut.ValidateIpv4Address(Ipv4Address);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
