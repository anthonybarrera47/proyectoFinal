using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.BLL.Tests
{
    [TestClass()]
    public class FactoriaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = true;
            Factoria factoria = new Factoria()
            {
                
                Direccion = "Las Guaranas",
                FechaRegistro = DateTime.Now,
                Nombre = "Comercial Herrera",
                Telefono = "829-111-1111"
            };
            paso = FactoriaBLL.Guardar(factoria);
            Assert.AreEqual(paso,true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}