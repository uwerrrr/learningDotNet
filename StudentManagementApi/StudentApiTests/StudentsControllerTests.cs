using Microsoft.AspNetCore.Mvc;
using Moq;
using StudentManagementApi.Interfaces;
using StudentManagementApi.Controllers;
using StudentManagementApi.Models;

namespace StudentApiTests;

[TestFixture]  // Indicates this class contains unit tests
public class StudentsControllerTests
{
    private Mock<IStudentService> _mockStudentService;  // Mocking the student service
    private StudentsController _controller;  // The controller to be tested

    [SetUp]  // This method runs before each test, setting up the environment
    public void Setup()
    {
        _mockStudentService = new Mock<IStudentService>();  // Create a mock IStudentService
        _controller = new StudentsController(_mockStudentService.Object); // Pass the mock service into the controller
    }
    
    
    
    
    
    ////// GET tests
    
    [Test] // Marks this method as a unit test
    public void GetStudentById_ValidId_ReturnsOkResult()
    {
        // Arrange
        var student = new Student { Id = 1, Name = "John Doe" };
        _mockStudentService.Setup(service => service.GetStudentById(1)).Returns(student);
        // Sets up the mock IStudentService to return a valid 'student' object when GetStudentById(1) is called
    
        // Act
        var result = _controller.GetStudentById(1);
    
        // Assert
        var okResult = result as OkObjectResult; // casting result to OkObjectResult type
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult.Value, Is.EqualTo(student));
    }

    [Test]
    public void GetStudentById_InvalidId_ReturnsNotFoundResult()
    {
        // Arrange
        _mockStudentService.Setup(service => service.GetStudentById(99)).Returns((Student)null); 
            // casting null to Student type because service.GetStudentById() expects return type Student
    
        // Act
        var result = _controller.GetStudentById(99);
    
        // Assert
        Assert.That(result, Is.TypeOf<NotFoundResult>());
            // controller.GetStudentById() returns NotFound() when null
    }
    
    
    
    
    
    
    ////// CREATE tests
    
    [Test]
    public void CreateStudent_ValidStudent_ReturnsCreatedResult()
    {
        // Arrange
        var student = new Student { Id = 1, Name = "John Doe" };
        _mockStudentService.Setup(service => service.CreateStudent(student));

        // Act
        var result = _controller.CreateStudent(student);

        // Assert
        var createdResult = result as CreatedAtActionResult;
        Assert.That(createdResult, Is.Not.Null);
        Assert.That(createdResult.ActionName, Is.EqualTo(nameof(_controller.GetStudentById)));
        Assert.That(createdResult.RouteValues["id"], Is.EqualTo(student.Id));
        Assert.That(createdResult.Value, Is.EqualTo(student));
    }

    [Test]
    public void CreateStudent_InvalidStudent_ReturnsBadRequestResult()
    {
        // Arrange
        _controller.ModelState.AddModelError("Name", "Required");

        // Act
        var result = _controller.CreateStudent(new Student());

        // Assert
        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
    }
    
    
    
    
    
    
    
    ////// UPDATE tests
    [Test]
    public void UpdateStudent_ValidId_ReturnsNoContentResult()
    {
        // Arrange
        var student = new Student { Id = 1, Name = "John Doe" };
        _mockStudentService.Setup(service => service.GetStudentById(1)).Returns(student);

        // Act
        var result = _controller.UpdateStudent(1, student);

        // Assert
        Assert.That(result, Is.TypeOf<NoContentResult>());
    }

    [Test]
    public void UpdateStudent_InvalidId_ReturnsNotFoundResult()
    {
        // Arrange
        _mockStudentService.Setup(service => service.GetStudentById(99)).Returns((Student)null);

        // Act
        var result = _controller.UpdateStudent(99, new Student());

        // Assert
        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }

    [Test]
    public void UpdateStudent_InvalidData_ReturnsBadRequestResult()
    {
        // Arrange
        _controller.ModelState.AddModelError("Name", "Required");
            // Simulates: 'Name' property of the student is missing but is required for validation

        // Act
        var result = _controller.UpdateStudent(1, new Student());

        // Assert
        Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    ////// DELETE tests
    [Test]
    public void DeleteStudent_ValidId_ReturnsNoContentResult()
    {
        // Arrange
        var student = new Student { Id = 1, Name = "John Doe" };
        _mockStudentService.Setup(service => service.GetStudentById(1)).Returns(student);

        // Act
        var result = _controller.DeleteStudent(1);

        // Assert
        Assert.That(result, Is.TypeOf<NoContentResult>());
    }

    [Test]
    public void DeleteStudent_InvalidId_ReturnsNotFoundResult()
    {
        // Arrange
        _mockStudentService.Setup(service => service.GetStudentById(99)).Returns((Student)null);

        // Act
        var result = _controller.DeleteStudent(99);

        // Assert
        Assert.That(result, Is.TypeOf<NotFoundResult>());
    }
}