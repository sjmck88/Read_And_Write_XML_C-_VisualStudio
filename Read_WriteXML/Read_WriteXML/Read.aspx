<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Read.aspx.cs" Inherits="Read_WriteXML.Read" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FileUpload ID ="FileUpload" runat ="server" />
    <p>
    <asp:Button ID="UploadFileButton" runat="server" Text="Upload File " OnClick="UploadFileButton_Click" />
    </p>
</asp:Content>
