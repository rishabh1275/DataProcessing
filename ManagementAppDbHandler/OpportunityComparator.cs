using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAppDbHandler
{
    public class OpportunityComparator
    {
        public static List<Opportunity> Comparator()
        {
            // We are creating dictionary for storing both list we got from file system and database setting their OpportunityID as key
            Dictionary<string, Opportunity> EvolvingOpportunityDict = new();
            Dictionary<string, Opportunity> NewOpportunityDict = new();
            var EvolvingOpportunityList = ObjectLoader.LoadOldOpportunity();
            //Sorting List on the basis of our IComparable
            EvolvingOpportunityList.Sort();
            
            //List in Database can have multiple version of a single opportunity so we are only storing Opportunity with maximum version below
            foreach (var op in EvolvingOpportunityList)
            {
                /*After sorting we may not need to use the logic "EvolvingOpportunityDict[op.OpportunityID].Version > op.Version"
                but for being double sure it will help if something goes wrong*/
                if (EvolvingOpportunityDict.ContainsKey(op.OpportunityID) && EvolvingOpportunityDict[op.OpportunityID].Version > op.Version)
                {
                    continue;
                }
                else
                {
                    EvolvingOpportunityDict.Remove(op.OpportunityID);
                }
                EvolvingOpportunityDict.Add(op.OpportunityID, op);
            }

            var NewOpportunityList = ObjectLoader.LoadNewOpportunity();
            NewOpportunityList.Sort();
            foreach (var op in NewOpportunityList)
            {
                /* we are setting Version 1 as default because it can have new opportunities introduced as well and for
                 existing opportunities we will be matching their version from database one later in program.*/
                op.Version = 1;
                NewOpportunityDict.Add(op.OpportunityID, op);
            }

            // method for identifying and adding new opportunities if any to DB.
            void IdentifyNewVersion()
            {
                var New = NewOpportunityDict.Keys.Except(EvolvingOpportunityDict.Keys);
                foreach (var i in New)
                {
                    
                    EvolvingOpportunityList.Add(NewOpportunityDict[i]);
                    EvolvingOpportunityDict.Add(NewOpportunityDict[i].OpportunityID, NewOpportunityDict[i]);
                    
                }
            }

            void compareOpportunity()
            {
                //Calling identify new version in main comparator logic.
                IdentifyNewVersion();
                //Comparision Logic
                foreach(var Opp in NewOpportunityDict.Keys)
                {
                    /*Matching version of NewOpportunitylist from EvolvingOpportunityList(i.e. database one)
                    As we are having Version in our IComparable logic so we are matching them here and it will help us to increase
                    version number if changes are there.*/
                    NewOpportunityDict[Opp].Version = EvolvingOpportunityDict[Opp].Version;

                    if (Opp == EvolvingOpportunityDict[Opp].OpportunityID)
                    {
                        int value = NewOpportunityDict[Opp].CompareTo(EvolvingOpportunityDict[Opp]);
                        if (value != 0)
                        {
                            NewOpportunityDict[Opp].Version++;
                            EvolvingOpportunityList.Add(NewOpportunityDict[Opp]);
                        }
                    }
                }
            }
            //Calling compare function before returning updated list.
            compareOpportunity();
            
            return EvolvingOpportunityList;
        }
    }
}