using System.Net;

namespace DynamicApplication.Service.Utilities;

public sealed record Error (HttpStatusCode Code, string? Message = null);