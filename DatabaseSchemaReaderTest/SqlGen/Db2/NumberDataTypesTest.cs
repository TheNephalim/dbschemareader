﻿using DatabaseSchemaReader.DataSchema;
using DatabaseSchemaReader.SqlGen.Db2;
#if !NUNIT
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestContext = System.Object;
#endif

namespace DatabaseSchemaReaderTest.SqlGen.Db2
{
    [TestClass]
    public class NumberDataTypesTest
    {
        private readonly DatabaseColumn _column = new DatabaseColumn { Nullable = true };

        [TestMethod]
        public void TestInteger()
        {
            //arrange
            _column.DbDataType = "INT";

            //act
            var result = DataTypeWriter.DataType(_column);

            //assert
            Assert.AreEqual("INTEGER", result);
        }

        [TestMethod]
        public void TestSmallInt()
        {
            //arrange
            _column.DbDataType = "SMALLINT";

            //act
            var result = DataTypeWriter.DataType(_column);

            //assert
            Assert.AreEqual("SMALLINT", result);
        }

        [TestMethod]
        public void TestNumber()
        {
            //arrange
            _column.DbDataType = "NUMBER";
            _column.Precision = 10;
            _column.Scale = 2;

            //act
            var result = DataTypeWriter.DataType(_column);

            //assert
            Assert.AreEqual("NUMERIC (10,2)", result);
        }

        [TestMethod]
        public void TestNumeric()
        {
            //arrange
            _column.DbDataType = "NUMERIC";
            _column.Precision = 10;
            _column.Scale = 2;

            //act
            var result = DataTypeWriter.DataType(_column);

            //assert
            Assert.AreEqual("NUMERIC (10,2)", result);
        }

        [TestMethod]
        public void TestDecimal()
        {
            //arrange
            _column.DbDataType = "DECIMAL";
            _column.Precision = 10;
            _column.Scale = 2;

            //act
            var result = DataTypeWriter.DataType(_column);

            //assert
            Assert.AreEqual("DECIMAL (10,2)", result);
        }

        [TestMethod]
        public void TestDec()
        {
            //arrange
            _column.DbDataType = "DEC";
            _column.Precision = 10;
            _column.Scale = 2;

            //act
            var result = DataTypeWriter.DataType(_column);

            //assert
            Assert.AreEqual("DECIMAL (10,2)", result);
        }

        [TestMethod]
        public void TestBit()
        {
            //arrange
            _column.DbDataType = "BIT";

            //act
            var result = DataTypeWriter.DataType(_column);

            //assert
            Assert.AreEqual("SMALLINT", result);
        }

        [TestMethod]
        public void TestMoney()
        {
            //arrange
            _column.DbDataType = "MONEY";

            //act
            var result = DataTypeWriter.DataType(_column);

            //assert
            Assert.AreEqual("DECIMAL(19,4)", result);
        }
    }
}