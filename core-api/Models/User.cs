namespace core-api.Models

{
    public class User
{
    [key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LasttName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }






}
}