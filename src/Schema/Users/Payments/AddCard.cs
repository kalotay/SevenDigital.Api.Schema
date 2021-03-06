﻿using System;
using System.Xml.Serialization;
using SevenDigital.Api.Schema.Attributes;
using SevenDigital.Api.Schema.OAuth;
using SevenDigital.Api.Schema.ParameterDefinitions.Post;

namespace SevenDigital.Api.Schema.Users.Payments
{
	[Serializable]
	[ApiEndpoint("user/payment/card/add")]
	[OAuthSigned]
	[RequireSecure]
	[HttpPost]
	[XmlRoot("card")]
	public class AddCard : Card, HasAddCardParameter
	{
	}
}
