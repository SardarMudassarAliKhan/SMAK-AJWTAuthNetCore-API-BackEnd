﻿using SMAK_AJWTAuthNetCore_Core.Entities;
using SMAK_AJWTAuthNetCore_Core.Interfaces;

namespace SMAK_AJWTAuthNetCore_Services.Services
{
    public class UserService : IUserService<ApplicationUser>
    {
        private readonly IUsersRepository<ApplicationUser> _usersRepository;

        public UserService(IUsersRepository<ApplicationUser> usersRepository)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
        }

        // Create a new user
        public async Task<ApplicationUser> Create(ApplicationUser _object)
        {
            try
            {
                if (_object == null)
                {
                    throw new ArgumentNullException(nameof(_object), "User object cannot be null");
                }

                return await _usersRepository.Create(_object);
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                // Log the exception and rethrow
                throw new ServiceException("Error occurred while creating user", ex);
            }
        }

        // Delete an existing user
        public void Delete(ApplicationUser _object)
        {
            try
            {
                if (_object == null)
                {
                    throw new ArgumentNullException(nameof(_object), "User object cannot be null");
                }

                _usersRepository.Delete(_object);
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                throw new ServiceException("Error occurred while deleting user", ex);
            }
        }

        // Retrieve all users
        public IEnumerable<ApplicationUser> GetAll()
        {
            try
            {
                return _usersRepository.GetAll();
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                throw new ServiceException("Error occurred while retrieving all users", ex);
            }
        }

        // Retrieve user by ID
        public ApplicationUser GetById(int Id)
        {
            try
            {
                if (Id==null)
                {
                    throw new ArgumentException("Id cannot be null or empty", nameof(Id));
                }

                return _usersRepository.GetById(Id);
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                throw new ServiceException("Error occurred while retrieving user by Id", ex);
            }
        }

        // Update an existing user
        public void Update(ApplicationUser _object)
        {
            try
            {
                if (_object == null)
                {
                    throw new ArgumentNullException(nameof(_object), "User object cannot be null");
                }

                _usersRepository.Update(_object);
            }
            catch (Exception ex)
            {
                // Log the exception and rethrow
                throw new ServiceException("Error occurred while updating user", ex);
            }
        }
    }

    // Custom exception class for service layer
    public class ServiceException : Exception
    {
        public ServiceException(string message) : base(message) { }
        public ServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
