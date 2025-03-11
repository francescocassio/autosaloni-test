<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        @keyframes colorChange {
            0% {
                color: #ff5733;
                opacity: 0;
            }

            10% {
                opacity: 1;
            }

            33% {
                color: #ffc300;
            }

            66% {
                color: #33ff57;
            }

            100% {
                color: #339fff;
            }
        }

        @keyframes fadeIn {
            from {
                opacity: 0;
            }

            to {
                opacity: 1;
            }
        }

        @keyframes slideDiagonal {
            from {
                transform: translate(0, 0);
            }

            to {
                transform: translate(354px, 454px);
            }
        }

        @keyframes backgroundChange {
            0% {
                background-color: #ff5733;
            }

            33% {
                background-color: #ffc300;
            }

            66% {
                background-color: #33ff57;
            }

            100% {
                background-color: #339fff;
            }
        }

        #welcome p {
            font-size: 26px;
            font-weight: bold;
            text-align: center;
            animation: fadeIn alternate 4s ease-in infinite;
        }

        #MioDiv {
            height: 50px;
            position: absolute;
            top: 0;
            left: 0;
            width: 150px;
            background-color: rebeccapurple;
            animation: slideDiagonal 6s cubic-bezier(.42,0,1,-0.02) infinite alternate, backgroundChange 6s linear infinite alternate;
        }

        #MioDiv2 {
            height: 50px;
            position: absolute;
            width: 150px;
            background-color: red;
            animation: slideDiagonal 6s cubic-bezier(.42,0,1,-0.02) infinite alternate-reverse;
        }

        #MioDiv3 {
            height: 50px;
            position: absolute;
            width: 150px;
            background-color: #c600ff;
            animation: slideDiagonal 6s linear infinite alternate;
        }

        #MioDiv4 {
            height: 50px;
            position: absolute;
            width: 150px;
            background-color: #00e8ff;
            animation: slideDiagonal 6s linear infinite alternate-reverse;
        }

        #container {
            position: relative;
            width: 500px;
            height: 500px;
            border: 2px solid #1c6c13;
        }

        .main {
            flex-direction: column;
        }
    </style>
    <div id="welcome">
        <p>Welcome to Autosaloni s.r.l </p>
    </div>
    <div id="container">
        <div id="MioDiv">
            <p>CIAO</p>
        </div>

        <div id="MioDiv2">
            <p>CIAO</p>
        </div>

        <div id="MioDiv3">
            <p>CIAO</p>
        </div>

        <div id="MioDiv4">
            <p>CIAO</p>
        </div>

    </div>
</asp:Content>


