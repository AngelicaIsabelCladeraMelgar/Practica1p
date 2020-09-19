using System;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplicationPractica1p.Controllers;
using WebApplicationPractica1p.Models;

namespace UnitTestProjectWebApiPactica1p.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class UnitTestStudents
        {
            [TestMethod]
            public void TestMethodGetStudent()
            {
                //Arrange
                StudentsController studentsController = new StudentsController();

                //Act
                var ListaEstudiante = studentsController.GetStudents();

                //Assert
                Assert.IsNotNull(ListaEstudiante);
            }
        }
            [TestMethod]
        public void TestMethodPostStudent2()
        {
            //Arrange
            Student student_expected = new Student()
            {
                StudentID = 1,
                LastName = "Marca",
                FirstName = "Ana",
                EnrollmentDate = DateTime.Today,
            };
            StudentsController studentsController = new StudentsController();

            //Act
            IHttpActionResult actionResult = studentsController.PostStudent(student_expected);
            var student_actual = actionResult as CreatedAtRouteNegotiatedContentResult<Student>;

            //Assert
            Assert.IsNotNull(student_actual);
            // Assert.AreEqual("DefaultApi", student_actual.RouteName);
            //  Assert.AreEqual(student_expected.StudentID, student_actual.RouteValues["id"]);
            Assert.AreEqual(student_expected.FirstName, student_actual.Content.FirstName);
            Assert.AreEqual(student_expected.LastName, student_actual.Content.LastName);
        }

        [TestMethod]
        public void TestMethodPut()
        {
            //Arrange
            Student student_expected = new Student()
            {
                StudentID = 1,
                LastName = "Marca",
                FirstName = "Ana",
                EnrollmentDate = DateTime.Today,
            };
            StudentsController studentsController = new StudentsController();

            //Act
            var result = studentsController.PutStudent(student_expected.StudentID, student_expected);
            var studet_actual = result as OkNegotiatedContentResult<Student>;
            //student

            //Assert
            Assert.IsNull(studet_actual);
            //porque no trae ningun valor por eso solo si es nulo esta bien
            //Assert.AreEqual(HttpStatusCode.NoContent, result);
            //Assert.AreEqual(student_expected, studet_actual);
        }
        [TestMethod]
        public void TestMethodDelete()
        {
            //Arrange
            Student student_expected = new Student()
            {
                StudentID = 1,
                LastName = "Marca",
                FirstName = "Ana",
                EnrollmentDate = DateTime.Today,
            };
            StudentsController studentsController = new StudentsController();

            //Act
            IHttpActionResult actionResult = studentsController.PostStudent(student_expected);
            IHttpActionResult actionResult_Delete = studentsController.DeleteStudent(student_expected.StudentID);
            //var student_actual = actionResult as OkNegotiatedContentResult<Student>;

            //Assert
            Assert.IsInstanceOfType(actionResult_Delete, typeof(OkNegotiatedContentResult<Student>));
        }

    }
}
