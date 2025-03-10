﻿using Common.Application;

namespace Shop.Application.Orders.CheckOut;

public class CheckoutOrderCommand:IBaseCommand
{
    public CheckoutOrderCommand(long userId, string shire, string city, string postalCode, 
        string postalAddress, string phoneNumber, string name, string family, string nationalCode, long shippingMethodId)
    {
        UserId = userId;
        Shire = shire;
        City = city;
        PostalCode = postalCode;
        PostalAddress = postalAddress;
        PhoneNumber = phoneNumber;
        Name = name;
        Family = family;
        NationalCode = nationalCode;
        ShippingMethodId = shippingMethodId;
    }

    public long UserId { get; private set; }
    public string Shire { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string PostalAddress { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Name { get; private set; }
    public string Family { get; private set; }
    public string NationalCode { get; private set; }
    public long ShippingMethodId { get; private set; }
}