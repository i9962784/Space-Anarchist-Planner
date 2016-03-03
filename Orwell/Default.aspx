<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Orwell.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Set-Up</h2>
    <table>
        <tr>
            <td>Key Id</td>
            <td>
                <asp:TextBox ID="txtKeyID" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>vCode</td>
            <td>
                <asp:TextBox ID="txtvCode" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:LinkButton ID="lnkGo" runat="server" OnClick="lnkGo_Click">Find my enemies so I can hear the lamentation of their sovereignty!</asp:LinkButton></td>
        </tr>
    </table>

    <h2>F.A.Q.</h2>

    <h3>What is this?</h3>
    Some things just look better on fire. That's the general idea that drove the development of this application; I wanted to know when the infrastructure of organisation or people I don't like was vulnerable so I could wreck their stuff.
    <h3>How does it do it?</h3>
    SAP loads your character info to get your contact list, which is then used to sort out which structure you should like to see burn.
    <h3>Tinfoil-time</h3>
    Why a API key and not a SSO integration? Good question, you see, when I'm not working on SAP, I'm trying to convince myself that I need to be working on SAP; and virtual money doesn't help to pay real rent so there were only so many hours available in the 14 days of the challenge. So rest assured, I'm way too busy to even consider logging your APIs for nefarious stuff (see TODO list).
    <h3>Risk-Mitigation</h3>
    Well, if you don't trust me (I wouldn't), the key you submit can be limited to character list and the contact list. You could even submit a character key with only the permision on the contact list.
    <h3>Todo</h3>
    <ul>
        <li>SSO integration</li>
        <li>Character picker so we can avoid the character blob</li>
        <li>Filter by region (space somalia, other)</li>
        <li>Javascript for countdowns a la timerboard</li>
        <li>Triggers for refresh when a timer reaches zero</li>
        <li>Scrape killboards, ships in space stats to make educated guess on how hot a timer is. (Probably need a historical baseline to compare to)</li>
        <li>Review caching expensive operations</li>
        <li>More EVE-like space pixels theme (internet space ships, etc...)</li>
        <li>EVE-like logo</li>
        <li>DB in the background to store data, cache it, speeds things up a little.</li>
        <li>Log API keys for nefarious stuff (Annoy-o-tron -> redirects autopilot randomly (nearest gate camp maybe? First red contact's capital system?))</li>
    </ul>
</asp:Content>
