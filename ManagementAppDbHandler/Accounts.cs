using Ganss.Excel;

namespace ManagementAppDbHandler
{
    public class Accounts
    {
        [Column("Opportunity ID")]
        public string OpportunityID { get; set; }
        [Column("Account Name")]
        public string AccountName { get; set; }
        [Column("Account Owner SFID")]
        public string AccountOwnerSFID { get; set; }
        [Column("Account ID")]
        public string AccountID { get; set; }
    }
}
