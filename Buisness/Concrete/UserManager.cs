using Buisness.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Buisness.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
     

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

     

        public IResult Add(User user)
        {
            _userDal.Add(user);

            return new SuccessResult("User added.");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("User deleted.");

        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), "All users listed");
        }

        public IDataResult<User> GetById(int id)
        {

            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == id), id+" numbered user has been brought");
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("User updated.");
        }
    }
}
