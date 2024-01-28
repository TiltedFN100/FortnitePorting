﻿using FortnitePorting.Framework.ViewModels.Endpoints.Models;
using RestSharp;

namespace FortnitePorting.Framework.ViewModels.Endpoints;

public class FortnitePortingEndpoint : EndpointBase
{
    public const string AES_URL = "https://halfheart.dev/fortnite-porting/api/v2/aes.json";
    public const string MAPPINGS_URL = "https://halfheart.dev/fortnite-porting/api/v2/mappings.json";
    private const string RELEASE_URL = "https://halfheart.dev/fortnite-porting/api/v2/release.json";
    private const string CHANGELOG_URL = "https://halfheart.dev/fortnite-porting/api/v2/changelog.json";
    private const string FEATURED_URL = "https://halfheart.dev/fortnite-porting/api/v2/featured.json";

    public FortnitePortingEndpoint(RestClient client) : base(client)
    {
    }
    
    public async Task<ReleaseResponse?> GetReleaseAsync()
    {
        return await ExecuteAsync<ReleaseResponse>(RELEASE_URL);
    }

    public ReleaseResponse? GetRelease()
    {
        return GetReleaseAsync().GetAwaiter().GetResult();
    }

    public async Task<ChangelogResponse[]?> GetChangelogsAsync()
    {
        return await ExecuteAsync<ChangelogResponse[]>(CHANGELOG_URL);
    }

    public ChangelogResponse[]? GetChangelogs()
    {
        return GetChangelogsAsync().GetAwaiter().GetResult();
    }

    public async Task<FeaturedResponse[]?> GetFeaturedAsync()
    {
        return await ExecuteAsync<FeaturedResponse[]>(FEATURED_URL);
    }

    public FeaturedResponse[]? GetFeatured()
    {
        return GetFeaturedAsync().GetAwaiter().GetResult();
    }
    
    public async Task<T?> GetBackupAsync<T>(string url)
    {
        var response = await ExecuteAsync<BackupApiResponse<T>>(url);
        return response?.Active ?? false ? response.Data : default;
    }

    public T? GetBackup<T>(string url)
    {
        return GetBackupAsync<T>(url).GetAwaiter().GetResult();
    }
}