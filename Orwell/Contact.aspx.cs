using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eZet.EveLib;
using eZet.EveLib.EveXmlModule.Models.Map;
using eZet.EveLib.EveXmlModule.Models.Character;
using eZet.EveLib.EveCrestModule;
using eZet.EveLib.EveXmlModule.Models.Misc;
using System.Data;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveCrestModule.Models.Links;

namespace Orwell
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CharacterKey ck = EveXml.CreateCharacterKey(4223652, "rSEwbLT6U2KyZxvRVyR0vt6Pgl9Q3hv5B8Q4wcd5kykCDSvmuXn1riOM1qHrJKVa");



            //EveXmlResponse<StandingsList>  standings = ck.Characters[0].GetStandings();


            //ck.Characters[0].m

            //EveXmlResponse<ConquerableStations> station = EveXml.Eve.GetConquerableStations();


            //EveXmlResponse<IndustryJobs> jobs = ck.Characters[0].GetIndustryJobs();

            //HttpContext.Current.Response.Write("2");
            //EveXmlResponse<ContractList> cl = 
            //object obj = DAL.SDE.GetRegionsLookup();


            EveXmlResponse<ContactList>  contacts = ck.Characters[0].GetContactList();

            /*
            var crest = new EveCrest();
            var root = crest.GetRoot();

            var structures = root.Query(r => r.Sovereignty.Structures);
            */



            //            eZet.EveLib.EveCrestModule.Models.Links.Href<eZet.EveLib.EveCrestModule.Models.Resources.RegionCollection> sd = new EveCrest().GetRoot().Regions;
            /*
    EveXmlRowCollection<ContractList.Contract> contracts =  ck.Characters[0].GetContracts().Result.Contracts;

    EveXmlRowCollection<ContractItems.ContractItem> ci = ck.Characters[2].GetContractItems(100498243).Result.Items;
    */

            /*
            EveXmlResponse<Sovereignty> lst = EveXml.Map.GetSovereignty();

            foreach (Sovereignty.SolarSystem sv in lst.Result.SolarSystems)
            {
                HttpContext.Current.Response.Write(sv.SolarSystemId + " " + sv.SolarSystemName + "</br>");
            }
            */

            //EveXml.Eve.

            /*
            ApiKey key = new ApiKey(4223652, "rSEwbLT6U2KyZxvRVyR0vt6Pgl9Q3hv5B8Q4wcd5kykCDSvmuXn1riOM1qHrJKVa"); // A user gave me some key info, and I have no idea if its for a char or corp
           Character c = key.GetCharacterList().Result.Characters.Single(c => c.CharacterName == "Kjode Gauk");

            string temp = character.CorporationName;
            */
        }
    }
}