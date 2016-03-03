using eZet.EveLib.EveCrestModule;
using eZet.EveLib.EveCrestModule.Models.Resources;
using eZet.EveLib.EveXmlModule;
using eZet.EveLib.EveXmlModule.Models;
using eZet.EveLib.EveXmlModule.Models.Character;
using eZet.EveLib.EveXmlModule.Models.Corporation;
using eZet.EveLib.EveXmlModule.Models.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Orwell
{
    public partial class ThingsToKnockDown : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO Pretty error catching here!
            if (String.IsNullOrEmpty("" + Session["KeyID"]))
                Server.Transfer("~/Default.aspx", false);
            if (String.IsNullOrEmpty("" + Session["vCode"]))
                Server.Transfer("~/Default.aspx", false);

            //lblUTC.Text = DateTime.Now.ToUniversalTime().ToString("hh:mm tt");

            if (!IsPostBack)
            {
                CharacterKey ck = null;
                try
                {
                    ck = EveXml.CreateCharacterKey(Convert.ToInt32(Session["KeyID"]), (string)Session["vCode"]);
                }
                catch
                {
                    Server.Transfer("~/Default.aspx", false);
                }
                EveXmlResponse<eZet.EveLib.EveXmlModule.Models.Character.ContactList> contacts = null;
                List<eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact> cList = new List<eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact>();

                try
                {
                    contacts = ck.Characters[0].GetContactList();


                    foreach (eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact ct in contacts.Result.AllianceContacts)
                        cList.Add(ct);
                    foreach (eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact ct in contacts.Result.CorporationContacts)
                        cList.Add(ct);
                    foreach (eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact ct in contacts.Result.PersonalContacts)
                        cList.Add(ct);
                }
                catch { }

                try
                {
                    contacts = ck.Characters[1].GetContactList();


                    foreach (eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact ct in contacts.Result.AllianceContacts)
                        cList.Add(ct);
                    foreach (eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact ct in contacts.Result.CorporationContacts)
                        cList.Add(ct);
                    foreach (eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact ct in contacts.Result.PersonalContacts)
                        cList.Add(ct);
                }
                catch { }

                try
                {
                    contacts = ck.Characters[2].GetContactList();


                    foreach (eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact ct in contacts.Result.AllianceContacts)
                        cList.Add(ct);
                    foreach (eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact ct in contacts.Result.CorporationContacts)
                        cList.Add(ct);
                    foreach (eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact ct in contacts.Result.PersonalContacts)
                        cList.Add(ct);
                }
                catch { }


                Dictionary<long, string> ThingsIDontLike = new Dictionary<long, string>();

                foreach (eZet.EveLib.EveXmlModule.Models.Character.ContactList.Contact ct in cList)
                    if (ct.Standing < 0)
                    {
                        //Corporation
                        if (ct.ContactTypeId == 2)
                        {
                            try
                            {
                                EveXmlResponse<CorporationSheet> corpDetails = new Eve().GetCorporationSheet(ct.ContactId);

                                if (!ThingsIDontLike.ContainsKey(corpDetails.Result.AllianceId))
                                    ThingsIDontLike.Add(corpDetails.Result.AllianceId, ct.ContactName + "'s Standing");
                            }
                            catch
                            { }
                        }
                        else if (ct.ContactTypeId == 16159) //Alliance
                            ThingsIDontLike.Add(ct.ContactId, ct.ContactName + "'s Standing");
                        else
                        {
                            try
                            {
                                EveXmlResponse<CharacterAffiliation> aff = new eZet.EveLib.EveXmlModule.Eve().GetCharacterAffiliation(ct.ContactId);

                                foreach (CharacterAffiliation.CharacterAffiliationData cad in aff.Result.Characters)
                                {
                                    if (!ThingsIDontLike.ContainsKey(cad.AllianceId))
                                        ThingsIDontLike.Add(cad.AllianceId, ct.ContactName + "'s Standing");
                                }
                            }
                            catch
                            { }
                        }

                    }


                var crest = new EveCrest();
                var root = crest.GetRoot();

                var structures = root.Query(r => r.Sovereignty.Structures);

                List<DAL.SovVulnerability> Soon = new List<DAL.SovVulnerability>();
                List<DAL.SovVulnerability> Active = new List<DAL.SovVulnerability>();
                List<DAL.SovVulnerability> OnFire = new List<DAL.SovVulnerability>();

                Dictionary<int, string> RegionLookup = DAL.SDE.GetRegionsLookup();
                Dictionary<int, int> SystemToRegion = DAL.SDE.GetSystemToRegionLookup();

                foreach (SovStructureCollection.Structure SovStruct in structures.AllItems())
                {
                    if (ThingsIDontLike.Keys.Contains(SovStruct.Alliance.Id))
                    {
                        //Already on fire
                        if (SovStruct.VulnerableStartTime == SovStruct.VulnerableEndTime)
                            OnFire.Add(new DAL.SovVulnerability(SovStruct, RegionLookup[SystemToRegion[SovStruct.SolarSystem.Id]], (long)SystemToRegion[SovStruct.SolarSystem.Id], ThingsIDontLike[SovStruct.Alliance.Id]));
                        else if (SovStruct.VulnerableStartTime < DateTime.Now)
                            Active.Add(new DAL.SovVulnerability(SovStruct, RegionLookup[SystemToRegion[SovStruct.SolarSystem.Id]], (long)SystemToRegion[SovStruct.SolarSystem.Id], ThingsIDontLike[SovStruct.Alliance.Id]));
                        else
                            Soon.Add(new DAL.SovVulnerability(SovStruct, RegionLookup[SystemToRegion[SovStruct.SolarSystem.Id]], (long)SystemToRegion[SovStruct.SolarSystem.Id], ThingsIDontLike[SovStruct.Alliance.Id]));
                    }
                }

                rptSovHappening.DataSource = Active.OrderBy(o => o.VulnerabilityStart).ToList();
                rptSovHappening.DataBind();

                rptSovUpcoming.DataSource = Soon.OrderBy(o => o.VulnerabilityStart).ToList();
                rptSovUpcoming.DataBind();
            }
        }
    }
}
