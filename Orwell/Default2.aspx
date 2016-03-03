<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="Orwell._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

        <table class="table table-hover" id="timersHappening">
        <thead>
            <tr>
                <th><a href="#" onclick="sort('region');">Region<span style="float: none;" id="region"></span></a></th>
                <th><a href="#" onclick="sort('system');">System<span style="float: none;" id="system"></span></a></th>
                <th><a href="#" onclick="sort('type');">Type<span style="float: none;" id="type"></span></a></th>
                <th><a href="#" onclick="sort('owner');">Owner<span style="float: none;" id="owner"></span></a></th>
                <th><a href="#" onclick="sort('time');">Time<span style="float: none;" id="time"><i class="fa fa-sort-amount-asc"></i></span></a></th>
                <th><a href="#" onclick="sort('time');">Remaining<span style="float: none;" id="remaining"></span></a></th>
                <!--<th><a href="#" onclick="sort('defended');">Defender Score<span style="float: none;" id="defended"></span></a></th>-->
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptSovHappening" runat="server">
                <ItemTemplate>
                    <tr style="display: table-row;" class="timer_row" data-tags="active">
                        <td class="region"><%# Eval("RegionName") %></td>
                        <td class="system"><a href='<%# "http://evemaps.dotlan.net/search?q=" + Eval("SystemName") %>' target="_blank"><%# Eval("SystemName") %></a></td>
                        <td class="type"><%# Eval("EventTypeDescription") %></td>
                        <td class="owner"><a href='<%# "http://evemaps.dotlan.net/search?q=" + Eval("OwnerName") %>' target="_blank"><%# Eval("OwnerName") %></a></td>
                        <td class="time"><%# Eval("EventStarts") %></td>
                        <td class="remaining" style="width: 150px;"><div data-countdown='<%# Convert.ToDateTime(Eval("EventStarts")).ToString("s") %>'></div></td>
                        <!--<td class="defended">35%</td>-->
                    </tr>

                </ItemTemplate>

            </asp:Repeater>
        </tbody>
    </table>

    <table class="table table-hover" id="timersUpcoming">
        <thead>
            <tr>
                <th><a href="#" onclick="sort('region');">Region<span style="float: none;" id="region"></span></a></th>
                <th><a href="#" onclick="sort('system');">System<span style="float: none;" id="system"></span></a></th>
                <th><a href="#" onclick="sort('type');">Type<span style="float: none;" id="type"></span></a></th>
                <th><a href="#" onclick="sort('owner');">Owner<span style="float: none;" id="owner"></span></a></th>
                <th><a href="#" onclick="sort('time');">Time<span style="float: none;" id="time"><i class="fa fa-sort-amount-asc"></i></span></a></th>
                <th><a href="#" onclick="sort('time');">Remaining<span style="float: none;" id="remaining"></span></a></th>
                <!--<th><a href="#" onclick="sort('defended');">Defender Score<span style="float: none;" id="defended"></span></a></th>-->
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptSovUpcoming" runat="server">
                <ItemTemplate>
                    <tr style="display: table-row;" class="timer_row" data-tags="active">
                        <td class="region"><%# Eval("RegionName") %></td>
                        <td class="system"><a href='<%# "http://evemaps.dotlan.net/search?q=" + Eval("SystemName") %>' target="_blank"><%# Eval("SystemName") %></a></td>
                        <td class="type"><%# Eval("EventTypeDescription") %></td>
                        <td class="owner"><a href='<%# "http://evemaps.dotlan.net/search?q=" + Eval("OwnerName") %>' target="_blank"><%# Eval("OwnerName") %></a></td>
                        <td class="time"><%# Eval("EventStarts") %></td>
                        <td class="remaining" style="width: 150px;"><div data-countdown='<%# Convert.ToDateTime(Eval("EventStarts")).ToString("s") %>'></div></td>
                        <!--<td class="defended">35%</td>-->
                    </tr>

                </ItemTemplate>

            </asp:Repeater>
        </tbody>
    </table>

    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-countdown]').each(function () {
                var $this = $(this), finalDate = $(this).data('countdown');
                $this.countdown(finalDate, function (event) {
                    $this.html(event.strftime('%D days %H:%M:%S'));
                });
            });
        });
    </script>


</asp:Content>
