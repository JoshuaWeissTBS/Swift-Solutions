﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by Reqnroll (https://www.reqnroll.net/).
//      Reqnroll Version:1.0.0.0
//      Reqnroll Generator Version:1.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace PopNGo_BDD_Tests.Features
{
    using Reqnroll;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reqnroll", "1.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Recaptcha verification on explore page")]
    public partial class RecaptchaVerificationOnExplorePageFeature
    {
        
        private Reqnroll.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "PG-293.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureSetupAsync()
        {
            testRunner = Reqnroll.TestRunnerManager.GetTestRunnerForAssembly(null, NUnit.Framework.TestContext.CurrentContext.WorkerId);
            Reqnroll.FeatureInfo featureInfo = new Reqnroll.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Recaptcha verification on explore page", "Should appear when making enough queries while not logged in on the explore page " +
                    "to help prevent abuse", ProgrammingLanguage.CSharp, featureTags);
            await testRunner.OnFeatureStartAsync(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual async System.Threading.Tasks.Task FeatureTearDownAsync()
        {
            await testRunner.OnFeatureEndAsync();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public async System.Threading.Tasks.Task TestInitializeAsync()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public async System.Threading.Tasks.Task TestTearDownAsync()
        {
            await testRunner.OnScenarioEndAsync();
        }
        
        public void ScenarioInitialize(Reqnroll.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public async System.Threading.Tasks.Task ScenarioStartAsync()
        {
            await testRunner.OnScenarioStartAsync();
        }
        
        public async System.Threading.Tasks.Task ScenarioCleanupAsync()
        {
            await testRunner.CollectScenarioErrorsAsync();
        }
        
        public virtual async System.Threading.Tasks.Task FeatureBackgroundAsync()
        {
#line 5
#line hidden
            Reqnroll.Table table6 = new Reqnroll.Table(new string[] {
                        "UserName",
                        "Email",
                        "FirstName",
                        "LastName",
                        "Password"});
            table6.AddRow(new string[] {
                        "Joshua Weiss",
                        "knott@example.com",
                        "Joshua",
                        "Weiss",
                        "FAKE PW"});
#line 6
 await testRunner.GivenAsync("the following users exist", ((string)(null)), table6, "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Recaptcha modal appears after making over ten searches on the explore page while " +
            "not logged in")]
        public async System.Threading.Tasks.Task RecaptchaModalAppearsAfterMakingOverTenSearchesOnTheExplorePageWhileNotLoggedIn()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("Recaptcha modal appears after making over ten searches on the explore page while " +
                    "not logged in", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 5
await this.FeatureBackgroundAsync();
#line hidden
#line 11
  await testRunner.GivenAsync("I am logged out", ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 12
  await testRunner.AndAsync("I am on the \"Explore\" page", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 13
  await testRunner.WhenAsync("I make over ten searches on the explore page", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 14
  await testRunner.ThenAsync("I should see the recaptcha modal appear", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Recaptcha modal does not appear after making over ten searches on the explore pag" +
            "e while logged in")]
        public async System.Threading.Tasks.Task RecaptchaModalDoesNotAppearAfterMakingOverTenSearchesOnTheExplorePageWhileLoggedIn()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            Reqnroll.ScenarioInfo scenarioInfo = new Reqnroll.ScenarioInfo("Recaptcha modal does not appear after making over ten searches on the explore pag" +
                    "e while logged in", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 16
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                await this.ScenarioStartAsync();
#line 5
await this.FeatureBackgroundAsync();
#line hidden
#line 17
  await testRunner.GivenAsync("I am a user with first name \'Joshua\'", ((string)(null)), ((Reqnroll.Table)(null)), "Given ");
#line hidden
#line 18
   await testRunner.AndAsync("I login", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 19
  await testRunner.AndAsync("I am on the \"Explore\" page", ((string)(null)), ((Reqnroll.Table)(null)), "And ");
#line hidden
#line 20
  await testRunner.WhenAsync("I make over ten searches on the explore page", ((string)(null)), ((Reqnroll.Table)(null)), "When ");
#line hidden
#line 21
  await testRunner.ThenAsync("I should not see the recaptcha modal appear", ((string)(null)), ((Reqnroll.Table)(null)), "Then ");
#line hidden
            }
            await this.ScenarioCleanupAsync();
        }
    }
}
#pragma warning restore
#endregion
