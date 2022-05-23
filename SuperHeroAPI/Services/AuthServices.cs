﻿//using SuperHeroAPI.Data;
//using SuperHeroAPI.Models;
//using SuperHeroAPI.Repository;

//namespace SuperHeroAPI.Services
//{
//    public class AuthServices : IAuthServices
//    {

//        private readonly DataContext Context;
//        public AuthServices(DataContext context)
//        {
//            Context = context;
//        }
//        public string Login(string username, string password)
//        {
//            throw new NotImplementedException();
//        }

//        public ServiceResponses<int> Register(User user, string password)
//        {
//            ServiceResponses<int> response = new ServiceResponses<int>();

//            if (UserExists(user.Userame))
//            {
//                response.Success = false;
//                response.Message = "User already exists.";
//                return response;
//            }
            
//            CreatePasswordHash(password,
//                out byte[] passwordHash,
//                out byte[] passwordSalt);
//            user.PasswordHash = passwordHash;
//            user.PasswordSalt = passwordSalt;

//            Context.Users.Add(user);
//            Context.SaveChanges();

//            response.Data = user.Id;
//            return response;
//        }

//        public bool UserExists(string username)
//        {
//            if(Context.Users.Any(x => x
//            .Userame.ToLower()
//            .Equals(username.ToLower())))
//                return true;
//            return false;
//        }

//        // Using the HSHA 512 cryptography algorithm to generate a key and create the password hash
//                                        // Parameter        // Argument                 // Argument
//        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
//        {
//             using (var hmac = new System.Security.Cryptography.HMACSHA512())
//            {
//                passwordSalt = hmac.Key;
//                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//            }
//        }

//    }
//}
