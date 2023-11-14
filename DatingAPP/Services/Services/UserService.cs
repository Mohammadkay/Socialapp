using AutoMapper;
using DatingAPP;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Services.helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class UserService : IUserService
    {
        private IReposiotryUnitOfWork _reposiotryUnitOfWork;
        private IAuthServices _authServices;
        private IMapper _mapper;
        public UserService(IReposiotryUnitOfWork reposiotryUnitOfWork, IAuthServices authServices,IMapper mapper)
        {
            _reposiotryUnitOfWork = reposiotryUnitOfWork;
            _authServices = authServices;
            _mapper = mapper ?? new MapperConfiguration(cfg=>cfg.AddProfile<AutoMapperProfiles>()).CreateMapper();
        }
        public ActionResult Add(User entity)
        {
            try
            {
                _reposiotryUnitOfWork.UserRepository.Value.Add(entity);
                return new OkObjectResult("User added successfully");
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult(ex.Message);

            }
        }

        public ActionResult AddRange(IEnumerable<User> entities)
        {
            try
            {
              _reposiotryUnitOfWork.UserRepository.Value.AddRange(entities);

                return new OkObjectResult("the users add successfully");
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public ActionResult Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public ActionResult DeleteRange(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }

        //public ActionResult FindEmail(string email)
        //{
        //    try
        //    {
        //        var 
        //    }
        //    catch(Exception ex)
        //    {
        //        return new BadRequestObjectResult(ex.Message);
        //    }
        //  }

        public ActionResult<IEnumerable<User>> GetAll()
        {
            return _reposiotryUnitOfWork.UserRepository.Value.GetAll().ToList();

        }

        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAllUsers()
        {
            try
            {

                 var users =await _reposiotryUnitOfWork.UserRepository.Value.GetAllUsers();
                var userToReturn=_mapper.Map<IEnumerable<MemberDto>>(users);
                return new OkObjectResult(userToReturn);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public ActionResult<User> GetById(int Id)
        {
            try
            {
                var user=_reposiotryUnitOfWork.UserRepository.Value.GetUsserbyId(Id);
                return new OkObjectResult(user);
            }catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public async Task<ActionResult<MemberDto>> GetbyUserName(string userName)
        {
            try
            {
                var user=await _reposiotryUnitOfWork.UserRepository.Value.GetbyUserName(userName);
                var userToReturn=_mapper.Map<MemberDto>(user);
                return new OkObjectResult(userToReturn);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public async Task<ActionResult<MemberDto>> GetUsserbyId(int id)
        {
            try
            {
                var user =await _reposiotryUnitOfWork.UserRepository.Value.GetUsserbyId(id);
                var userToReturn = _mapper.Map<MemberDto>(user);
                return new OkObjectResult(userToReturn);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }
        }

        public ActionResult<AuthDto> Login(LoginDto entity)
        {
            try
            {
                var user = _reposiotryUnitOfWork.UserRepository.Value.Find(x=>x.UserName==entity.UserName);

                if (user == null)
                {
                    return new BadRequestObjectResult("You must Register");
                }
                using var hmac = new HMACSHA512(user.Saltpassword);
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(entity.Password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != user.HashPassword[i])
                    { return new BadRequestObjectResult("please check the password or username"); }
                }

                AuthDto logedIn = new AuthDto
                {

                    Name = user.UserName,
                    Token = _authServices.CreateToken(user)
                };

                return new OkObjectResult(logedIn);





            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public ActionResult Register(RegisterDto entity)
        {
            try
            {
                var user = _reposiotryUnitOfWork.UserRepository.Value.Find(x=>x.UserName==entity.UserName);
                if (user == null)
                {
                    using var hmac = new HMACSHA512();
                    var newuser = new User
                    {
                        UserName = entity.Email,
                        Email = entity.Email,
                        HashPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(entity.Password)),
                        Saltpassword = hmac.Key
                    };
                    _reposiotryUnitOfWork.UserRepository.Value.Add(newuser);
                    return new OkObjectResult(entity);
                }
                else
                {
                    return new NotFoundObjectResult("the Emal is already exisst");
                }
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public ActionResult UpdateById(User entity)
        {
            throw new NotImplementedException();
        }

        ActionResult<IQueryable<User>> IService<User>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
