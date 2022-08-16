using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventfulAssignment
{
    internal class AccountAccess //publisher
    {
        public delegate void NotifyUser();
        public event NotifyUser NotifyOtherClasses;

        public void MultipleLogin()
        {
            Console.WriteLine("Login on another device in progress");
            System.Threading.Thread.Sleep(10000);
            //when Multiple login is detected
            OnMultyUser();
        }
        protected virtual void OnMultyUser()
        {
            NotifyOtherClasses?.Invoke();  //raise event
        }

    }

    public class Notifier  //subscriber
    {
        public void ActOnMultipleLogin()
        {
            var accAcc = new AccountAccess();
            accAcc.NotifyOtherClasses += LoginDetectorActions;
            accAcc.NotifyOtherClasses += () => Console.WriteLine("Send a notification to email to verify user");

            accAcc.MultipleLogin();
        
        }

        public void LoginDetectorActions()
        {
            Console.WriteLine("Send a notification to email to verify user");
            Console.ReadLine();
        }
    }
}

