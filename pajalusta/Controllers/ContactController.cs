using Microsoft.AspNetCore.Mvc;
using VintageCarGarageAPI.Models;

namespace VintageCarGarageAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // POST /api/contact
        [HttpPost]
        public IActionResult SubmitContactForm([FromBody] ContactFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Ensure required fields are not null
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Message))
            {
                return BadRequest("Name, Email, and Message are required.");
            }

            // Process the contact form data (e.g., save to database or send email)
            // For now, we'll just return a success message.
            return Ok(new { message = "Message sent successfully!" });
        }
    }

    public class ContactFormModel
    {
        public string Name { get; set; } = string.Empty; // Initialize with a default value
        public string Email { get; set; } = string.Empty; // Initialize with a default value
        public string Message { get; set; } = string.Empty; // Initialize with a default value
    }
}