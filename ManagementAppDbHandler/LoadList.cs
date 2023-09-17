using System.Collections.Generic;
using Ganss.Excel;
using System;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;

namespace ManagementAppDbHandler
{
    class LoadList
    {
        //This method will read new list from filesystem.
        public static List<T> GetNewList<T>()
        {
            //This newlist will be the list we need to scan for detecting changes and new opportunities
            List<T> newList = new();
            //This path has to be changed each time before selecting the new list
            string file = @"C:\Users\Rishabh.Gupta\Desktop\FinalTest\First_0706.xlsx";
            var excel = new ExcelMapper(file);
            // Custom Mapping because the Date format doesn't meet language criteria
            excel.AddMapping<Opportunity>("Created Date", p => p.CreatedDate).SetPropertyUsing(v => DateTime.ParseExact((string)v, "dd/MM/yyyy", null).ToLocalTime());
            excel.AddMapping<Opportunity>("Close Date", x => x.CloseDate).SetPropertyUsing(s => DateTime.ParseExact((string)s, "dd/MM/yyyy", null).ToLocalTime());
            excel.AddMapping<Opportunity>("Bid Submission Date", x => x.BidSubmissionDate).SetPropertyUsing(s => DateTime.ParseExact((string)s, "dd/MM/yyyy", null).ToLocalTime());
            var properties = excel.Fetch<T>();
            foreach (var op in properties)
            {
                newList.Add(op);
            }
            return newList;
        }
        

        // This method will get List from Database to compare with NewList.
        public static List<T> ReadDBDocs<T>()
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = dbClient.GetDatabase("UpdatedDataTest");
            var opportunitiesInfo = database.GetCollection<T>("EvolvingOpportunityInfo");
            return opportunitiesInfo.Find(new BsonDocument()).ToList();
        }
    }
}
