using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary2lab4
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        List<String> getUsers();
        [OperationContract]
        User loginUser(string Email, string Password);
        [OperationContract]
        int registerUser(User User);
        [OperationContract]
        void deleteUser(string Email);
        [OperationContract]
        void updateUser(User user,string Email);
        [OperationContract]
        User viewUser(string UserId);
        [OperationContract]
        User viewUser1(string Email);
    }
}
