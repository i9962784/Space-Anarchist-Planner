<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThingsToKnockDown.aspx.cs" Inherits="Orwell.ThingsToKnockDown" %>


<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    “In the absence of orders, go find something and kill it.”<br />
    – Field Marshall Erwin Rommel

    <h2>Vulnerable</h2>
        <table class="table table-hover" id="timersHappening">
        <thead>
            <tr>
                <th><a href="#" onclick="sort('region');">Region<span style="float: none;" id="region"></span></a></th>
                <th><a href="#" onclick="sort('system');">System<span style="float: none;" id="system"></span></a></th>
                <th><a href="#" onclick="sort('type');">Type<span style="float: none;" id="type"></span></a></th>
                <th><a href="#" onclick="sort('owner');">Owner<span style="float: none;" id="owner"></span></a></th>
                <th><a href="#" onclick="sort('time');">Ends<span style="float: none;" id="time"><i class="fa fa-sort-amount-asc"></i></span></a></th>
                <th><a href="#" onclick="sort('reason');">Reason<span style="float: none;" id="reason"></span></a></th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptSovHappening" runat="server">
                <ItemTemplate>
                    <tr style="display: table-row;" class="timer_row" data-tags="active">
                        <td class="region"><%# Eval("RegionName") %></td>
                        <td class="system"><a href='<%# "http://evemaps.dotlan.net/search?q=" + Eval("SystemName") %>' target="_blank"><%# Eval("SystemName") %></a></td>
                        <td class="type"><%# Eval("StructureType") %></td>
                        <td class="owner"><a href='<%# "http://evemaps.dotlan.net/search?q=" + Eval("AllianceName") %>' target="_blank"><%# Eval("AllianceName") %></a></td>
                        <td class="End"><%# Eval("VulnerabilityEnd") %></td>
                        <td class="End"><%# Eval("Reason") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

    <h2>Soon!</h2>
    <table class="table table-hover" id="timersUpcoming">
        <thead>
            <tr>
                <th><a href="#" onclick="sort('region');">Region<span style="float: none;" id="region"></span></a></th>
                <th><a href="#" onclick="sort('system');">System<span style="float: none;" id="system"></span></a></th>
                <th><a href="#" onclick="sort('type');">Type<span style="float: none;" id="type"></span></a></th>
                <th><a href="#" onclick="sort('owner');">Owner<span style="float: none;" id="owner"></span></a></th>
                <th><a href="#" onclick="sort('time');">Starts<span style="float: none;" id="time"><i class="fa fa-sort-amount-asc"></i></span></a></th>
                <th><a href="#" onclick="sort('time');">Ends<span style="float: none;" id="remaining"></span></a></th>
                <th><a href="#" onclick="sort('reason');">Reason<span style="float: none;" id="reason"></span></a></th>
                
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="rptSovUpcoming" runat="server">
                <ItemTemplate>
                    <tr style="display: table-row;" class="timer_row" data-tags="active">
                        <td class="region"><%# Eval("RegionName") %></td>
                        <td class="system"><a href='<%# "http://evemaps.dotlan.net/search?q=" + Eval("SystemName") %>' target="_blank"><%# Eval("SystemName") %></a></td>
                        <td class="type"><%# Eval("StructureType") %></td>
                        <td class="owner"><a href='<%# "http://evemaps.dotlan.net/search?q=" + Eval("AllianceName") %>' target="_blank"><%# Eval("AllianceName") %></a></td>
                        <td class="time"><%# Eval("VulnerabilityStart") %></td>
                        <td class="End"><%# Eval("VulnerabilityEnd") %></td>
                        <td class="End"><%# Eval("Reason") %></td>
                    </tr>

                </ItemTemplate>

            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>

