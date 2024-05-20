using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPPP;

namespace PruebaUnitaria
{
    [TestClass]
    public class AbriImagenTest
    {
        [TestMethod]
        public void AbrirToolStripMenuItem_Click_Should_Not_Throw_Exception()
        {
            // Arrange
            InterfazPrincipal form = new InterfazPrincipal();
            bool exceptionThrown = false;

            // Act
            try
            {
                form.abrirToolStripMenuItem_Click(null, null);
            }
            catch
            {
                exceptionThrown = true;
            }

            // Assert
            Assert.IsFalse(exceptionThrown, "Exception was thrown");
        }
    }
}

