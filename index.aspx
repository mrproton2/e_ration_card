<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="e_ration_card.index" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
  /* Make the image fully responsive */ 
  .carousel-inner img {
    width: 100%;
    height: 100%;
  }
  </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <%--<div class="container-fluid">--%>
        <div id="demo" class="carousel slide" data-ride="carousel">
  <ul class="carousel-indicators">
    <li data-target="#demo" data-slide-to="0" class="active"></li>
    <li data-target="#demo" data-slide-to="1"></li>
    <li data-target="#demo" data-slide-to="2"></li>
  </ul>
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img class="img-fluid" src="Assets/Images/onenationoneration.jpg"  alt="Los Angeles">
      <div class="carousel-caption">
        <h3>One nation One Ration Card</h3>
        <p>To commemorate 75 Years of India's Independence as part of the ongoing ‘Azadi Ka Amrit Mahotsav’, this call for submission of Tagline/slogan for ‘One Nation One Ration ...</p>
      </div>   
    </div>
    <div class="carousel-item">
      <img src="Assets/Images/cereals.jpg" alt="Chicago">
      <div class="carousel-caption">
        <h3>Cereals</h3>
        <p>The affluent families do not purchase foodgrains under PDS and therefore with a view to curb diversion of foodgrains and provide more foodgrains to the needy families</p>
      </div>   
    </div>
    <div class="carousel-item">
      <img src="Assets/Images/ration%20taking.jpg" alt="New York">
      <div class="carousel-caption">
        <h3>........</h3>
        <p>.............</p>
      </div>   
    </div>
  </div>
  <a class="carousel-control-prev" href="#demo" data-slide="prev">
    <span class="carousel-control-prev-icon"></span>
  </a>
  <a class="carousel-control-next" href="#demo" data-slide="next">
    <span class="carousel-control-next-icon"></span>
  </a>
</div>
    </section>
</asp:Content>
