using Microsoft.AspNetCore.Mvc;
using Project1.DTOs;
using Project1.Entities;
using Project1.Models;
using System.Security.Cryptography;
using System.Text;
using BCrypt;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security;

namespace Project1.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly ProjectContext _context;
        private readonly IConfiguration _configuration;
        public UserController(ProjectContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<UserDTO> ud = _context.Users
                .Select(m => new UserDTO
                {
                    IdUser = m.Id,
                    Name = m.Name,
                    Email = m.Email,
                    Password = m.Password,
                    Tel = m.Tel,
                    Address = m.Address,
                    Role = m.Role,
                })
                .ToList();
            return Ok(ud);

        }
        //Register
            [HttpPost("register")]
            public IActionResult Register(UserModel model)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                    if (!model.Email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                    {
                        return BadRequest("Vui lòng sử dụng địa chỉ email Gmail.");
                    }
                    
                    // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
                    User users = new User
                        {
                            Name = model.Name,
                            Email = model.Email,
                            Password = hashedPassword, // Lưu chuỗi hash vào cơ sở dữ liệu
                            Tel = model.Tel,
                            Address = model.Address,
                            Role = model.Role,
                        };
                        _context.Users.Add(users);
                        _context.SaveChanges();

                        return Created("", new UserDTO
                        {
                            IdUser = users.Id,
                            Name = users.Name,
                            Email = users.Email,
                            Password = hashedPassword,
                            Tel = users.Tel,
                            Address = users.Address,
                            Role = users.Role,
                        });
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
                // token user
            var token = GenerateToken(model.IdUser, model.Name);
            return Ok(new {Token = token});
            }
        private string GenerateToken (int IdUser, string  Name)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, IdUser.ToString()),
            new Claim(ClaimTypes.Name, Name),
            // Các claim khác có thể thêm vào đây để định danh người dùng
        };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Thời gian hết hạn của token
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //Login
        [HttpPost("Login")]
        public IActionResult Login(UserModel model)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email ==  model.Email);
            if (user == null || !VerifyPassword(user.Password,model.Password))
            {
                return Unauthorized();
            }
            var token = GenerateTokenLogin(user.Id, user.Name);
            return Ok(new {Token = token});
        }
        private bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            // compare enterpass with hashpass
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
        private string GenerateTokenLogin(int Id, string Name)
        {
            // Tạo một key có kích thước đủ lớn (256 bits)
            var securityKey = new byte[32]; // 32 bytes = 256 bits

            // Sử dụng một cơ chế để tạo key ngẫu nhiên
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(securityKey);
            }

            var credentials = new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256);

            // Tạo token
            var token = new JwtSecurityToken(
                issuer: "your_issuer_here",
                audience: "your_audience_here",
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            // Trả về token dưới dạng chuỗi
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPut]
        public IActionResult Edit(UserModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

                    _context.Users.Update(new User
                    {
                        Id = model.IdUser,
                        Name = model.Name,
                        Email = model.Email,
                        Password = hashedPassword,
                        Tel = model.Tel,
                        Address = model.Address,
                        Role = model.Role,
                    });
                    _context.SaveChanges();
                    return Ok("Successfully");
                }
                catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Error");
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
           
                try
                {
                    User user = _context.Users.Find(id);
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return NoContent();
                }catch(Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            
        }
        
    }

    
}
