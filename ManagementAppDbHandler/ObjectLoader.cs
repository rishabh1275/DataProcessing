using System.Linq;
using System.Collections.Generic;
using Ganss.Excel;
using System;

namespace ManagementAppDbHandler
{
    public class ObjectLoader
    {
        //Here we will be using the logics we had formed in Loadlist Class to populate the Lists.
        // With GetNewList method we are getting Accounts and Stages and we will combine them later with Opportunity ID
        public static List<Accounts> LoadNewAccounts()
        {
            var newAccountsList = LoadList.GetNewList<Accounts>();
            return newAccountsList;
        }
        public static List<Stages> LoadNewStages()
        {
            var newStagesList = LoadList.GetNewList<Stages>();
            return newStagesList;
        }
        //Loading Old Opportunity with ReadDBDocs method
        public static List<Opportunity> LoadOldOpportunity()
        {
            List<Opportunity> oldOpportunityList = LoadList.ReadDBDocs<Opportunity>();
            return oldOpportunityList;
        }
        //below we are combining All objects wi=hich will create a new opportunity list.
        public static List<Opportunity> LoadNewOpportunity()
        {
            List<Opportunity> incompletedNewOpportunityPropList = LoadList.GetNewList<Opportunity>();
            List<Accounts> accountsList = LoadNewAccounts();
            List<Stages> stagesList = LoadNewStages();
            List<Notes> notesList = new();
            List<Opportunity> newOpportunityList = new();

            for (int i = 0; i < incompletedNewOpportunityPropList.Count; i++)
            {
                Opportunity opportunityObj = incompletedNewOpportunityPropList[i];
                opportunityObj.AccountsObj = accountsList.FirstOrDefault(x => x.OpportunityID == opportunityObj.OpportunityID);
                opportunityObj.StagesObj = stagesList.FirstOrDefault(x => x.OpportunityID == opportunityObj.OpportunityID);
                newOpportunityList.Add(opportunityObj);
            }
            return newOpportunityList;
        }
    }
}
