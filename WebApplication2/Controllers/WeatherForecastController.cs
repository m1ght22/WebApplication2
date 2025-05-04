using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Supabase.Gotrue;
using Supabase.Interfaces;
using System.Text.RegularExpressions;
using WebApplication2;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Supabase.Client _supabaseClient;
        private readonly SupaBaseContext _supabaseContext;

        public WeatherForecastController(Supabase.Client supabaseClient, SupaBaseContext supaBaseContext)
        {
            _supabaseClient = supabaseClient;
            _supabaseContext = supaBaseContext;
        }

        [HttpGet("GetAllUsers", Name = "GetAllUsers")]
        public async Task<string> GetAllUsers()
        {
            try
            {
                var result = await _supabaseContext.GetUsers(_supabaseClient);
                return JsonConvert.SerializeObject(result, Formatting.Indented);
            }
            catch (Exception ex)
            {
                return "";
            }

        }

        [HttpPost("addUser", Name = "addUser")]
        public async Task<ActionResult> AddUser([FromBody] UserData newUser)
        {
            var email = newUser.email;
            var password = newUser.password;

            try
            {
                if (string.IsNullOrEmpty(newUser.email) || string.IsNullOrEmpty(newUser.password))
                {
                    return BadRequest("Почта или пароль пустой!");
                }
                else
                {
                    if (email.Contains("@"))
                    {
                        int indexOfChar = email.IndexOf("@");
                        var login_edited = email.Substring(indexOfChar);
                        if (login_edited.Contains("."))
                        {
                            if (password.Length < 6)
                                return BadRequest("Длина пароля меньше 6 символов");

                            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
                                return BadRequest("Пароль содержит не латинские буквы");

                            if (!Regex.IsMatch(password, "[A-Z]"))
                                return BadRequest("Пароль не содержит заглавной буквы");

                            var model = new User
                            {
                                name = newUser.name,
                                age = newUser.age,
                                email = email,
                                password = password

                            };
                            await _supabaseContext.InsertUsers(_supabaseClient, model);
                            return Ok("Успешно");
                        }
                    }
                    return BadRequest("Неправильный формат логина!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Ошибка!");
            }


        }

        [HttpPatch("updateUserName", Name = "updateUserName")]

        public async Task<string> updateUserName([FromBody] updatingName user)
        {
            try
            {
                await _supabaseContext.updateUserName(_supabaseClient, user);
                return "Успешно!";
            }
            catch (Exception ex)
            {
                return "Ошибка!";
            }

        }

        [HttpPatch("updateUserEmail", Name = "updateUserEmail")]

        public async Task<string> updateUserEmail([FromBody] updatingEmail user)

{
            try
            {
                await _supabaseContext.updateUserEmail(_supabaseClient, user);
                return "Успешно!";
            }
            catch (Exception ex)
            {
                return "Ошибка!";
            }

        }

        [HttpPatch("updateUserPassword", Name = "updateUserPassword")]

public async Task<string> updateUserPassword([FromBody] updatingPassword user)
{
    try
    {
        await _supabaseContext.updateUserPassword(_supabaseClient, user);
        return "Успешно!";
    }
    catch (Exception ex)
    {
        return "Ошибка!";
    }

}

[HttpDelete("deleteUser", Name = "deleteUser")]
public async Task<string> deleteUser([FromBody] deleteUser user)
{
    try
    {
        await _supabaseContext.deleteUser(_supabaseClient, user);
        return "Успешно!";
    }
    catch (Exception ex)
    {
        return "Ошибка!";
    }

}

        public class UserData
        {
            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("password")]
            public string password { get; set; }

            [JsonProperty("email")]
            public string email { get; set; }

            [JsonProperty("age")]
            public int age { get; set; }
        }
    }

    
}