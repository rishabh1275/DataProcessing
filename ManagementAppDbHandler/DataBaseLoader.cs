using System.Collections.Generic;
using MongoDB.Driver;

namespace ManagementAppDbHandler
{
    class DataBaseLoader
    {
        public static void MongoDBLoader()
        {
            _ = new Opportunity();
            var client = new MongoClient("mongodb://localhost:27017");
            //Database Name we are using it is same database we are getting list from and updating at end.
            var database = client.GetDatabase("UpdatedDataTest");
            //Collection Name
            var EvolvingOpportunityInfo = database.GetCollection<Opportunity>("EvolvingOpportunityInfo");
            // below we are calling comparator function to perform its task and storing the returned list which we are going to push to DB.
            List<Opportunity> EvolvingOpportunityList = OpportunityComparator.Comparator();
            //Before pushing we are going to remove existing collection from Database so that we will not merge new object with previous ones in collection.
            database.DropCollection("EvolvingOpportunityInfo");
            //pushing new list to DB
            EvolvingOpportunityInfo.InsertMany(EvolvingOpportunityList);
        }
    }
}
