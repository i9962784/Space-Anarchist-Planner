using System;
using System.Collections.Generic;
using System.Web.UI;
using eZet.EveLib.EveCrestModule;
using System.Linq;

namespace Orwell
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var ec = new EveCrest();

                //https://developers.eveonline.com/blog/article/aegis-sovereignty-api-changes/?_ga=1.108969479.467410419.1447695510


                Dictionary<int, int> SystemToRegionLookup = DAL.SDE.GetSystemToRegionLookup();
                Dictionary<int, string> RegionsLookup = DAL.SDE.GetRegionsLookup();

                // setup
                var crest = new EveCrest();
                // get root object
                var root = crest.GetRoot();
                var timers = root.Query(r => r.Sovereignty.Campaigns);

                List<DAL.SovEvent> SovEventUpcoming = new List<DAL.SovEvent>();
                List<DAL.SovEvent> SocEventHappening = new List<DAL.SovEvent>();


                foreach (eZet.EveLib.EveCrestModule.Models.Resources.SovCampaignsCollection.Campaign obj in timers.Items)
                {
                    DAL.SovEvent sov = new DAL.SovEvent();
                    sov.ConstellationName = obj.Constellation.Name;
                    sov.ConstellationID = obj.Constellation.Id;
                    sov.EventStarts = obj.StartTime;
                    sov.EventType = (DAL.Constants.TimerType)obj.EventType;
                    if (obj.Defender != null)
                    {
                            sov.OwnerName = obj.Defender.Defender.Name;
                            sov.OwnerID = obj.Defender.Defender.Id;
                            sov.DefenderScore = (int)obj.Defender.Score;
                    }
                    sov.RegionID = SystemToRegionLookup[obj.SourceSolarSystem.Id];
                    sov.RegionName = RegionsLookup[sov.RegionID];
                    
                    sov.SystemID = obj.SourceSolarSystem.Id;
                    sov.SystemName = obj.SourceSolarSystem.Name;

                    if (obj.Attackers != null)
                        sov.AttackerScore = (int)obj.Attackers.Score;

                    if (obj.StartTime < DateTime.Now)
                        SocEventHappening.Add(sov);
                    else
                        SovEventUpcoming.Add(sov);

                }

                rptSovHappening.DataSource = SocEventHappening.OrderBy(o => o.RegionName).ThenBy(n => n.SystemName).ToList();
                rptSovHappening.DataBind();

                rptSovUpcoming.DataSource = SovEventUpcoming.OrderBy(o => o.RegionName).ThenBy(n => n.SystemName).ToList();
                rptSovUpcoming.DataBind();
            }
        }
    }
}