
using Newtonsoft.Json;
using System.Text;

namespace LogisticService.Middlewares
{
	public class CustomTokenMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			if (/*context.Request.Path.StartsWithSegments("/your-endpoint") &&*/ context.Request.Method == "POST" || context.Request.Method == "GET")
			{
				string body;
				using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
				{
					body = await reader.ReadToEndAsync();
				}

				byte[] requestData = Encoding.UTF8.GetBytes(body);
				context.Request.Body = new MemoryStream(requestData);

				var tokenModel = JsonConvert.DeserializeObject<TokenModel>(body);
				if (tokenModel != null && !string.IsNullOrEmpty(tokenModel.Token))
				{
					context.Request.Headers.Add("Authorization", "Bearer " + tokenModel.Token);
				}
			}

			await next(context);
		}
	}
}
