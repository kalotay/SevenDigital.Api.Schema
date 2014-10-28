﻿using System.Threading.Tasks;
using NUnit.Framework;
using SevenDigital.Api.Schema.Artists;
using SevenDigital.Api.Wrapper;

namespace SevenDigital.Api.Schema.Integration.Tests.EndpointTests.Artists
{
	public class ArtistSimilarTests
	{
		[Test]
		public async Task Can_hit_endpoint()
		{
			var request = Api<ArtistSimilar>
				.Create
				.WithArtistId(1)
				.WithParameter("country", "GB");
			var artistSimilar = await request.Please();

			Assert.That(artistSimilar, Is.Not.Null);
		}

		[Test]
		public async Task Can_get_multiple_results()
		{
			var request = Api<ArtistSimilar>.Create
				.WithArtistId(1)
				.WithParameter("page", "1")
				.WithParameter("pageSize", "20");
			var artistSimilar = await request.Please();

			Assert.That(artistSimilar.Artists.Count, Is.GreaterThan(1));
		}

		[Test]
		public async Task Can_do_paging()
		{
			var request = Api<ArtistSimilar>
				.Create
				.WithArtistId(1)
				.WithParameter("page", "2")
				.WithParameter("pageSize", "2");
			var artistSimilar = await request.Please();

			Assert.That(artistSimilar.Page, Is.EqualTo(2));
			Assert.That(artistSimilar.Artists.Count, Is.EqualTo(2));
		}
	}
}