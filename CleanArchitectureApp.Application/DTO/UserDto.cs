namespace CleanArchitectureApp.Application.DTO
{
    public class UserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public UserDto(string name, string password, string email) 
        {
            Name = name;
            Password = password;
            Email = email;
        }

        public UserDto() { }
    }
}
