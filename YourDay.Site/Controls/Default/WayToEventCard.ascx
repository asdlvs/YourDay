﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WayToEventCard.ascx.cs" Inherits="YourDay.Site.Controls.Default.WayToEventCard" %>
<div class="waytoec">
    <div class="arrow">
        <div class="arrowContext">
            <strong>1 Шаг. Создайте событие</strong><br />
            Просто создайте и опубликуйте свое событие.
        </div>
    </div>

    <div class="arrow">
        <div class="arrowContext">
             <strong>2 Шаг. Выберите контрагентов</strong><br />
            Подберите контрагентов, просматривая  фото
        </div>
    </div>

    <a border="0" runat="server" href="#" id="anchorCreateEvent" clientidmode="Static" >
        <div class="createEvent">
        </div>
    </a>
</div>