using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityModel.Client;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_BaseApiSDK;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApiSdk;
using BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_TodoApiSdk.ApiModels;


namespace BenjaminAbt.Samples.AspNetCore_IdentityServer.Platform_AdminConsoleClient
{
    public class Program
    {
        public class IdentitySampleOptions
        {
            public string AuthEndpoint = "http://localhost:9010";
            public string ApiEndpoint = "http://localhost:9011";
            public string ClientId = "Platform.AdminConsoleClient";
            public string ClientSecret = "adminconsole-secret";

            public string TodoApiId = "Platform.TodoApi";

            public string UserName = "ben";
            public string UserPassword = "password";
        }

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        public static async Task MainAsync(string[] args)
        {
            try
            {
                var sampleOptions = new IdentitySampleOptions();

                // Create Clients
                UserCredentialsTokenAuthClient tokenAuthClient = new UserCredentialsTokenAuthClient(sampleOptions.AuthEndpoint, sampleOptions.ClientId, sampleOptions.ClientSecret);
                TokenResponse token = await tokenAuthClient.AuthAsync(sampleOptions.UserName, sampleOptions.UserPassword, sampleOptions.TodoApiId);
                if (token.IsError)
                {
                    Console.WriteLine("Auth failed: " + token.Error);
                    return;
                }

                TodoApiClient todoApiClient = new TodoApiClient(new BearerAuthorizedApiClient(token.AccessToken), sampleOptions.ApiEndpoint);


                IList<TaskApiModel> tasks = await todoApiClient.GetTasksAsync();
                Console.WriteLine($"Received #{tasks.Count} from external API.");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"#{task.Id} | {task.Title}: {task.Description}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }


    }
}