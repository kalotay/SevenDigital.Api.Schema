﻿using System;
using System.Xml.Serialization;
using SevenDigital.Api.Schema.Artists;
using SevenDigital.Api.Schema.Attributes;
using SevenDigital.Api.Schema.Legacy;
using SevenDigital.Api.Schema.Media;
using SevenDigital.Api.Schema.Packages;
using SevenDigital.Api.Schema.ParameterDefinitions.Get;
using SevenDigital.Api.Schema.Pricing;

namespace SevenDigital.Api.Schema.Releases
{
	[Serializable]
	[XmlRoot("release")]
	[ApiEndpoint("release/details")]
	public class Release : HasReleaseIdParameter
	{
		[XmlAttribute("id")]
		public int Id { get; set; }

		[XmlElement("title")]
		public string Title { get; set; }

		[XmlElement("version")]
		public string Version { get; set; }

		[XmlElement("type")]
		public ReleaseType Type { get; set; }

		[XmlElement("barcode")]
		public string Barcode { get; set; }

		[XmlElement("year")]
		public string Year { get; set; }

		[XmlElement("explicitContent")]
		public bool ExplicitContent { get; set; }

		[XmlElement("artist")]
		public Artist Artist { get; set; }

		[XmlElement("url")]
		public string Url { get; set; }

		[XmlElement("image")]
		public string Image { get; set; }

		[XmlElement("releaseDate")]
		public DateTime? ReleaseDate { get; set; }

		[XmlElement("addedDate")]
		public DateTime AddedDate { get; set; }
		
		[XmlIgnore]
		public bool AddedDateSpecified { get { return AddedDate > DateTime.MinValue; } }

		[Obsolete]
		public Price Price { get { return PriceLegacyMapper.PrimaryPackagePrice(Download); } }

		[Obsolete]
		public FormatList Formats { get { return FormatLegacyMapper.PrimaryPackageFormats(Download); } }

		[XmlElement("label")]
		public Label Label { get; set; }

		[XmlElement("licensor")]
		public Licensor Licensor { get; set; }

		[XmlElement("streamingReleaseDate")]
		public DateTime? StreamingReleaseDate { get; set; }

		[XmlElement("duration")]
		public int Duration { get; set; }

		[XmlElement("trackCount")]
		public int? TrackCount { get; set; }

		[XmlElement("download")]
		public Download Download { get; set; }

		public override string ToString()
		{
			return string.Format("{0}: {1} {2} {3}, Barcode {4}", Id, Title, Version, Type, Barcode);
		}
	}
}