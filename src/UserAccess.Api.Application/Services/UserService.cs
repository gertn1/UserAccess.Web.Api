
//using UserAccess.Api.Application.Dtos;
//using UserAccess.Api.Application.Responses;
//using UserAccess.Api.Domain.Entities;
//using UserAccess.Api.Domain.Interfaces.Repositories;
//using UserAccess.Api.Domain.Interfaces.Services;

//namespace UserAccess.Api.Application.Services
//{s
//    public class UserService : IUserService
//    {
//        private readonly IUserRepository _userRepository;

//        public UserService(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

//        public async Task<ResponseModel<List<User>>> ListAsync()
//        {
//            var response = new ResponseModel<List<User>>();
//            try
//            {
//                var users = await _userRepository.ListAllAsync();
//                response.Dados = users;
//                response.Mensagem = "Users retrieved successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }

//        public async Task<ResponseModel<User?>> GetByIdAsync(int id)
//        {
//            var response = new ResponseModel<User?>();
//            try
//            {
//                var user = await _userRepository.GetByIdAsync(id);
//                if (user == null)
//                {
//                    response.Status = false;
//                    response.Mensagem = "User not found.";
//                    return response;
//                }
//                response.Dados = user;
//                response.Mensagem = "User retrieved successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }

//        public async Task<ResponseModel<User>> CreateAsync(User user)
//        {
//            var response = new ResponseModel<User>();
//            try
//            {
//                var createdUser = await _userRepository.CreateAsync(user);
//                response.Dados = createdUser;
//                response.Mensagem = "User created successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }

//        public async Task<ResponseModel<User?>> UpdateAsync(User user)
//        {
//            var response = new ResponseModel<User?>();
//            try
//            {
//                var updatedUser = await _userRepository.UpdateAsync(user);
//                if (updatedUser == null)
//                {
//                    response.Status = false;
//                    response.Mensagem = "User not found.";
//                    return response;
//                }
//                response.Dados = updatedUser;
//                response.Mensagem = "User updated successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }

//        public async Task<ResponseModel<bool>> DeleteAsync(int id)
//        {
//            var response = new ResponseModel<bool>();
//            try
//            {
//                var deleted = await _userRepository.DeleteAsync(id);
//                if (!deleted)
//                {
//                    response.Status = false;
//                    response.Mensagem = "User not found.";
//                    return response;
//                }
//                response.Dados = true;
//                response.Mensagem = "User deleted successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }

//        // Implementação de métodos específicos da interface IUserService
//        public async Task<ResponseModel<User>> CreateUserAsync(UserCreationDto userDto)
//        {
//            var response = new ResponseModel<User>();
//            try
//            {
//                var user = new User
//                {
//                    Name = userDto.Name,
//                    Email = userDto.Email,
//                    Password = userDto.Password,
//                    RoleId = (int)userDto.RoleId
//                };

//                var createdUser = await _userRepository.CreateAsync(user);
//                response.Dados = createdUser;
//                response.Mensagem = "User created successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }

//        public async Task<ResponseModel<User?>> UpdateUserAsync(UserEditDto userDto)
//        {
//            var response = new ResponseModel<User?>();
//            try
//            {
//                var user = await _userRepository.GetByIdAsync(userDto.Id);
//                if (user == null)
//                {
//                    response.Status = false;
//                    response.Mensagem = "User not found.";
//                    return response;
//                }

//                user.Name = userDto.Name;
//                user.Email = userDto.Email;
//                user.Password = userDto.Password;
//                user.RoleId = (int)userDto.RoleId;

//                var updatedUser = await _userRepository.UpdateAsync(user);
//                response.Dados = updatedUser;
//                response.Mensagem = "User updated successfully.";
//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Mensagem = $"An error occurred: {ex.Message}";
//            }
//            return response;
//        }
//    }
//}


using UserAccess.Api.Application.Dtos;
using UserAccess.Api.Application.Responses;
using UserAccess.Api.Domain.Entities;
using UserAccess.Api.Domain.Interfaces.Repositories;
using UserAccess.Api.Domain.Interfaces.Services;

namespace UserAccess.Api.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseModel<List<User>>> ListAsync()
        {
            var response = new ResponseModel<List<User>>();
            try
            {
                var users = await _userRepository.ListAllAsync();
                response.Dados = users;
                response.Mensagem = "Users retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel<User?>> GetByIdAsync(int id)
        {
            var response = new ResponseModel<User?>();
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                {
                    response.Status = false;
                    response.Mensagem = "User not found.";
                    return response;
                }
                response.Dados = user;
                response.Mensagem = "User retrieved successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel<User?>> CreateAsync(UserCreationDto userDto)
        {
            var response = new ResponseModel<User?>();
            try
            {
                var user = new User
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    RoleId = (int)userDto.RoleId
                };

                var createdUser = await _userRepository.CreateAsync(user);
                response.Dados = createdUser;
                response.Mensagem = "User created successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel<User?>> UpdateAsync(UserEditDto userDto)
        {
            var response = new ResponseModel<User?>();
            try
            {
                var user = await _userRepository.GetByIdAsync(userDto.Id);
                if (user == null)
                {
                    response.Status = false;
                    response.Mensagem = "User not found.";
                    return response;
                }

                user.Name = userDto.Name;
                user.Email = userDto.Email;
                user.Password = userDto.Password;
                user.RoleId = userDto.RoleId;

                var updatedUser = await _userRepository.UpdateAsync(user);
                response.Dados = updatedUser;
                response.Mensagem = "User updated successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }

        public async Task<ResponseModel<bool>> DeleteAsync(int id)
        {
            var response = new ResponseModel<bool>();
            try
            {
                var deleted = await _userRepository.DeleteAsync(id);
                if (!deleted)
                {
                    response.Status = false;
                    response.Mensagem = "User not found.";
                    return response;
                }
                response.Dados = true;
                response.Mensagem = "User deleted successfully.";
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = $"An error occurred: {ex.Message}";
            }
            return response;
        }
    }
}
