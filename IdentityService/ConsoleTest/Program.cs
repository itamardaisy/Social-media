using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var userMaker = new UserIdentityMaker();
            var userLibrary = new UserIdentityRepository();

            Console.WriteLine(userLibrary.GetUserIdentity("omer cohen"));

            /*Intialize and create tables if they don't already exist*/
            //userMaker.Init();

            ///*CREATE*/
            //foreach (var user in userMaker.UserIdentities)
            //{
            //    userLibrary.AddUserIdentity(user);
            //}


            ///*Read*/
            //IEnumerable<UserIdentity> savedUserIdentities = userLibrary.GetAllUserIdentities();

            //foreach (var saveUser in savedUserIdentities)
            //{
            //    Console.WriteLine("Items");
            //    Console.WriteLine("FullName : {0}", saveUser.FullName);
            //    Console.WriteLine("Age : {0}", saveUser.Age);
            //    Console.WriteLine("Address : {0}", saveUser.Address);
            //}

            ///*Update*/
            ////DVD theDarkKnightDvd = dvdLibrary.SearchDvds("The Dark Knight", 2008).SingleOrDefault();
            ////if (theDarkKnightDvd != null)
            ////{
            ////    theDarkKnightDvd.Director = "Will Smith";
            ////    dvdLibrary.ModifyDvd(theDarkKnightDvd);

            ////}


            ///*Delete*/
            //UserIdentity omerCohen = userLibrary.SearchUserIdentities("omer cohen", 24).SingleOrDefault();
            //if (omerCohen != null)
            //{
            //    userLibrary.DeleteUserIdentity(omerCohen);
            //}
        }
    }
}
