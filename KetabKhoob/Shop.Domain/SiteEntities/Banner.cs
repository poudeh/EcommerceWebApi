﻿using Common.Domain.Exceptions;
using Common.Domain;

namespace Shop.Domain.SiteEntities;

public class Banner : BaseEntity
{
    public string Link { get; private set; }
    public string ImageName { get; private set; }
    public BannerPosition Position { get; private set; }

    public Banner(string link, string imageName, BannerPosition position)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        Position = position;
    }

    public void Edit(string link, string imageName, BannerPosition position)
    {
        Guard(link, imageName);
        Link = link;
        ImageName = imageName;
        Position = position;
    }

    public void Guard(string link, string imageName)
    {
        NullOrEmptyDomainDataException.CheckString(link, nameof(link));
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
    }
}

public enum BannerPosition
{
    زیر_اسلایدر,
    سمت_چپ_اسلایدر,
    بالای_اسلایدر,
    سمت_راست_شگفت_انگیز,
    وسط_صفحه
}