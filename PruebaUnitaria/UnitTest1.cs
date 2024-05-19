using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PPPP;

namespace PruebaUnitaria
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void CalcularEspaciosLibres_Test_ConPosicionesOcupadas()
        {
            // Arrange
            int hojaAncho = 2550;
            int hojaAlto = 3300;
            List<Rectangle> posicionesOcupadas = new List<Rectangle>
            {
                new Rectangle(0, 0, 1000, 1000),
                new Rectangle(1000, 1000, 500, 500)
            };

            // Act
            List<Rectangle> espaciosLibres = Metodos.CalcularEspaciosLibres(hojaAncho, hojaAlto, posicionesOcupadas);

            // Assert
            Assert.AreEqual(4, espaciosLibres.Count);
        }
    }




}

  
