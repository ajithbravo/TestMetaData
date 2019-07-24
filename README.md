# Clone the repo 
# Right click on Solution on go to properties 
# Go to Application Tab  change the Output type to Class library
# Build the application will create a dll in  the \bin\Debug folder
# Create a Test project and refer the DLL .
# Code Snippet

using System;
using MetaDataAttributes;
using MetaDataAttributes.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testattribute
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext textcontextinstance;
        public TestContext TestContext
        {
            get
            {
                return textcontextinstance;
            }
            set
            {
                textcontextinstance = value;
            }
        }

        
        [ClassInitialize()]
        public static void BeforeClasses(TestContext tc)
        {
            MetaData data = new MetaData();
            data.GetAttributeValues(typeof(UnitTest1));
            Console.WriteLine("Before classes are run");
        }

        
        [MetaData(Application = Application.ApplicationOne)]
        [TestMethod]
        public void TestMethod1()
        {
            
        }

        [MetaData(Application = Application.ApplicationTwo)]
        [TestMethod]
        public void TestMethod2()
        {
            
        }

        [MetaData(Application = Application.ApplicationOne)]
        [TestMethod]
        public void TestMethod3()
        {
            //Assert.Fail(); 
        }

        [MetaData(Application = Application.ApplicationOne)]
        [TestMethod]
        public void TestMethod4()
        {
            
        }

        [MetaData(Application = Application.ApplicationTwo)]
        [TestMethod]
        public void TestMethod5()
        {
            //Assert.Fail();
        }

        [TestCleanup]
        public void TestCleanUp()
        {           
            CreateReportFile.UpdateReport1(TestContext.TestName.ToString() , TestContext.CurrentTestOutcome.ToString());
            
        }

        [ClassCleanup]
        public static void TestClassCleanUp()
        {     
            CreateReportFile.CreateReport();
        }

    }
}
