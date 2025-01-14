﻿using System;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TestAutomationPractice.Helpers;
using TestAutomationPractice.Pages;

namespace AutomationPracticeFramework.Steps
{
    [Binding]
    public class MyAccountSteps : Base

    {
        Utilities ut = new Utilities(Driver);
        HomePage hp = new HomePage(Driver);
        private readonly PersonData personData;
        public MyAccountSteps(PersonData personData)
    {
       this.personData= personData;
    }

      

        [Given(@"user opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
            ut.ClickOnElement(hp.signIn);
        }
        
        [Given(@"enters correct credentials")]
        public void GivenEntersCorrectCredentials()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.username, TestConstants.Username);
           ut.EnterTextInElement(ap.Password, TestConstants.Password);
        }
        
        [When(@"user submits the login form")]
        public void WhenUserSubmitsTheLoginForm()

        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(hp.signIn);
        }
        
        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            MyAccountPage mp = new MyAccountPage(Driver);
            Assert.True((bool)ut.ElementIsDisplayed(mp.signOutbtn), "User is not logged in");
        }

        [Given(@"initiates a flow for creating an account")]
        public void GivenInitiatesAFlowForCreatingAnAccount()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.email, ut.GenerateRandomEmail());
            ut.ClickOnElement(ap.createAcc);

        }

        [Given(@"user enters all required personal details")]
        public void GivenUserEntersAllRequiredPersonaldetails()
        {
            SignUpPage sup = new SignUpPage(Driver);
            ut.EnterTextInElement(sup.firstName, TestConstants.FirstName);
            ut.EnterTextInElement(sup.lastName, TestConstants.LastName);
            personData.FullName= TestConstants.FirstName + ""+TestConstants.LastName;
            ut.EnterTextInElement(sup.password, TestConstants.Password);
            ut.EnterTextInElement(sup.address, TestConstants.Adress);
            ut.EnterTextInElement(sup.city, TestConstants.City);
            ut.DropDownSelect(sup.state, TestConstants.State);
            ut.EnterTextInElement(sup.zipCode, TestConstants.ZipCode);
            ut.EnterTextInElement(sup.phone, TestConstants.MobilePhone);

        }

        [When(@"user submits the sign up form")]
        public void WhenUserSubmitsTheSignUpForm()
        {
            SignUpPage sup = new SignUpPage(Driver);
            ut.ClickOnElement(sup.registerBtn);
        }

        [Then(@"user's full name is displayed")]
        public void ThenUserSFullNameIsDisplayed()
        {
        Assert.True(ut.TextPresentInElement(personData.FullName), "user's full name is not dispalayed");
        }
    }

    
    }

