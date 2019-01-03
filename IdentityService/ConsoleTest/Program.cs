﻿using Common;
using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var userLibrary = new UserIdentityRepository();
            var userTest = new UserIdentity
            {
                Email = "rit@g.com",
                FirstName = "sanad",
                LastName = "cohen",
                Age = 20,
                Address = "bet shan",
                WorkAddress = "sela"
            };

            //userLibrary.AddUserIdentity(userTest);
            //var u = userLibrary.GetUserIdentity("it@g.com");
            userLibrary.ModifyUserIdentity(userTest);
            //Console.WriteLine(u);

            string url = "http://localhost:39265/";
            UserIdentity user;
            string email = "it@g.com";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var result = client.GetAsync($"api/Identity/GetUserIdentity?email={email}").Result;
                if (!result.IsSuccessStatusCode)
                {
                    throw new Exception(result.Content.ReadAsStringAsync().Result);
                }

                string response = result.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<UserIdentity>(response);
            }

            Console.WriteLine(user.ToString());

            //var userMaker = new UserIdentityMaker();
            //var userLibrary = new UserIdentityRepository();

            ////var test =
            ////{
            ////    "name" = "fg",
            ////    "age" = "fg",
            ////    "addresss" = "fg",
            ////}

            ////Console.WriteLine(userLibrary.GetUserIdentity("omer cohen"));
            ///*Intialize and create tables if they don't already exist*/
            //userMaker.Init();
            //var userTest = new UserIdentity
            //{
            //    Email = "it@g.com",
            //    FullName = "omer cohen",
            //    Age = 20,
            //    Address = "bet shan",
            //    WorkAddress = "sela"
            //};

            //userLibrary.AddUserIdentity(userTest);
            ////Console.ReadLine();
            /////*CREATE*/
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
            UserIdentity theUserIdentity = userLibrary.SearchUserIdentities("gmail").SingleOrDefault();
            if (theUserIdentity != null)
            {
                theUserIdentity.Address = "ramat gan";
                userLibrary.ModifyUserIdentity(theUserIdentity);
            }


            ///*Delete*/
            //UserIdentity omerCohen = userLibrary.SearchUserIdentities("gmail", "omer cohen").SingleOrDefault();
            //Console.WriteLine("omer in delete: " + omerCohen);
            //if (omerCohen != null)
            //{
            //    userLibrary.DeleteUserIdentity(omerCohen);
            //}
        }
    }
}
