<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style>
        

        @keyframes colorChange {
            0% { color: #ff5733; opacity: 0; }
            10% { opacity: 1; }
            33% { color: #ffc300; }
            66% { color: #33ff57; }
            100% { color: #339fff; }
        }

        #welcome p {
            font-size: 26px;
            font-weight: bold;
            text-align: center;
            animation: colorChange 4s ease-in-out infinite alternate;
        }
    </style>
    <div id="welcome">
        <p> Welcome to Autosaloni s.r.l </p>
    </div>
</asp:Content>


