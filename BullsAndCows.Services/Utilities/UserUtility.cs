﻿using System.Collections.Generic;
using System.Linq;
using Bytes2you.Validation;
using BullsAndCows.Data.Contracts;
using BullsAndCows.Factories;
using BullsAndCows.Models;
using BullsAndCows.Services.Utilities.Contracts;

namespace BullsAndCows.Services.Utilities
{
    public class UserUtility : IUserUtility
    {
        private readonly IRepository<User> userRepository;
        private readonly IUserFactory userFactory;
        private readonly IUnitOfWork unitOfWork;

        public UserUtility(IRepository<User> userRepository,
            IUserFactory userFactory,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(userRepository, "userRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(userFactory, "userFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.userRepository = userRepository;
            this.userFactory = userFactory;
            this.unitOfWork = unitOfWork;
        }

        //TODO add paging
        public IEnumerable<User> GetAll()
        {
            return this.userRepository.Entities.ToList();
        }

        public User GetById(string id)
        {
            return this.userRepository.GetById(id);
        }
    }
}