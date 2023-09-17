using System.Linq;
using Ganss.Excel;
using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace ManagementAppDbHandler
{
    public class Opportunity : IComparable<Opportunity>, IVersion, INotesCollection
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [Ignore]
        public string _id { get; set; }
        public Accounts AccountsObj { get; set; }
        public Stages StagesObj { get; set; }
        public Opportunity() { }
        public string Territory { get; set; }
        [Column("Leading Solution Line")]
        public string LeadingSolutionLine { get; set; }
        [Column("Opportunity Name")]
        public string OpportunityName { get; set; }
        [Column("Opportunity Owner")]
        public string OpportunityOwner { get; set; }
        public Double? TCV { get; set; }
        [Column("Bid Type")]
        public string BidType { get; set; }
        [Column("Sales Process")]
        public string SalesProcess { get; set; }
        [Column("Close Date")]
        public DateTime? CloseDate { get; set; }
        [Column("Created Date")]
        public DateTime? CreatedDate { get; set; }
        [Column("Bid Submission Date")]
        public DateTime? BidSubmissionDate { get; set; }
        [Column("Bid Code")]
        public string BidCode { get; set; }
        [Column("Approval Status")]
        public string ApprovalStatus { get; set; }
        [Column("Opportunity ID")]
        public string OpportunityID { get; set; }
        [Column("Forecast Category")]
        public string ForecastCategory { get; set; }
        [Column("Top X Opportunity")]
        public Boolean? TopXOpportunity { get; set; }
        [Ignore]
        public int Version { get; set; }
        int IVersion.Version { get => Version; set => Version = value; }
        [Ignore]
        public List<Notes> NotesCollection {get;set;}
        List<Notes> INotesCollection.NotesCollection { get => NotesCollection; set => NotesCollection = value; }



        //Comparer

        public int CompareTo(Opportunity other)
        {

            int value = OpportunityID.CompareTo(other.OpportunityID);
            if (value == 0)
            {
                if (Version == 0 && other.Version == 0)
                {
                    value = 0;
                }
                else
                    value = Version.ToString().CompareTo(other.Version.ToString());
            }
            if (value == 0)
            {
                if (Territory == null)
                {
                    Territory = "";
                }
                if (other.Territory == null)
                {
                    other.Territory = "";
                }
                else value = Territory.CompareTo(other.Territory);
            }
            if (value == 0)
            {
                if (LeadingSolutionLine == null)
                {
                    LeadingSolutionLine = "";
                }
                if (other.LeadingSolutionLine == null)
                {
                    other.LeadingSolutionLine = "";
                }
                else
                    value = LeadingSolutionLine.ToString().CompareTo(other.LeadingSolutionLine.ToString());
            }
            if (value == 0)
            {
                if (AccountsObj.AccountName == null)
                {
                    AccountsObj.AccountName = "";
                }
                if (other.AccountsObj.AccountName == null)
                {
                    other.AccountsObj.AccountName = "";
                }
                else
                    value = AccountsObj.AccountName.ToString().CompareTo(other.AccountsObj.AccountName.ToString());
            }
            if (value == 0)
            {
                if (OpportunityName == null)
                {
                    OpportunityName = "";
                }
                if (other.OpportunityName == null)
                {
                    other.OpportunityName = "";
                }
                else
                    value = OpportunityName.CompareTo(other.OpportunityName);
            }
            if (value == 0)
            {
                if (OpportunityOwner == null)
                {
                    OpportunityOwner = "";
                }
                if (other.OpportunityOwner == null)
                {
                    other.OpportunityOwner = "";
                }
                else
                    value = OpportunityOwner.CompareTo(other.OpportunityOwner);
            }
            if (value == 0)
            {
                if (TCV == null)
                {
                    TCV = 0;
                }
                if (other.TCV == null)
                {
                    other.TCV = 0;
                }
                else
                    value = TCV.Value.CompareTo(other.TCV.Value);
            }
            if (value == 0)
            {
                if (SalesProcess == null)
                {
                    SalesProcess = "";
                }
                if (other.SalesProcess == null)
                {
                    other.SalesProcess = "";
                }
                else
                    value = SalesProcess.CompareTo(other.SalesProcess);
            }
            if (value == 0)
            {
                if (CloseDate == null && other.CloseDate == null)
                {
                    value = 0;
                }
                else
                    value = CloseDate.Value.ToShortDateString().CompareTo(other.CloseDate.Value.ToShortDateString());
            }
            if (value == 0)
            {
                if (CreatedDate == null && other.CreatedDate == null)
                {
                    value = 0;
                }
                else
                    value = CreatedDate.Value.ToShortDateString().CompareTo(other.CreatedDate.Value.ToShortDateString());
            }
            if (value == 0)
            {
                if (ApprovalStatus == null)
                {
                    ApprovalStatus = "";
                }
                if (other.ApprovalStatus == null)
                {
                    other.ApprovalStatus = "";
                }
                
                else
                    value = ApprovalStatus.CompareTo(other.ApprovalStatus);
            }
            if (value == 0)
            {

                if (StagesObj.Stage == null)
                {
                    StagesObj.Stage = "";
                }
                if (other.StagesObj.Stage == null)
                {
                    other.StagesObj.Stage = "";
                }
                else
                    value = StagesObj.Stage.CompareTo(other.StagesObj.Stage);
            }
            if (value == 0)
            {
                if (TopXOpportunity == null && other.TopXOpportunity == null)
                {
                    value = 0;
                }
                else
                    value = TopXOpportunity.Value.CompareTo(other.TopXOpportunity.Value);
            }
            if (value == 0)
            {
                if (BidCode == null)
                {
                    BidCode = "";
                }
                if (other.BidCode == null)
                {
                    other.BidCode = "";
                }
                else
                    value = BidCode.CompareTo(other.BidCode);
            }
            if (value == 0)
            {
                if (BidType == null)
                {
                    BidType = "";
                }
                if (other.BidType == null)
                {
                    other.BidType = "";
                }
                else
                    value = BidType.CompareTo(other.BidType);
            }
            if (value == 0)
            {
                if (BidSubmissionDate == null && other.BidSubmissionDate == null)
                {
                    value = 0;
                }
                else
                    value = BidSubmissionDate.Value.ToShortDateString().CompareTo(other.BidSubmissionDate.Value.ToShortDateString());
            }
            if (value == 0)
            {
                if (ForecastCategory == null)
                {
                    ForecastCategory = "";
                }
                if (other.ForecastCategory == null)
                {
                    other.ForecastCategory = "";
                }
                else
                    value = ForecastCategory.CompareTo(other.ForecastCategory);
            }
            return value;
        }
    }
}
