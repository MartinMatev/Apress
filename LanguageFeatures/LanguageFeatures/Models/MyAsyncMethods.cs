using System.Net.Http;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class MyAsyncMethods
    {
        public static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpTask = client.GetAsync("http://apress.com");

            // we could do other things here while we are waiting
            // for the HTTP request to complete

            return httpTask.ContinueWith(
                (Task<HttpResponseMessage> antecedent) => { return antecedent.Result.Content.Headers.ContentLength; });
        }

        public async static Task<long?> GetPageLengthVerTwo()
        {
            HttpClient client = new HttpClient();
            // I used the await keyword when calling the asynchronous method. This tells the C# compiler that I want to wait for the
            // result of the Task that the GetAsync method returns and then carry on executing other statements in the same method.

            var httpMessage = await client.GetAsync("http://apress.com");

            // we could do other things here while we are waiting
            // for the HTTP request to complete

            return httpMessage.Content.Headers.ContentLength;
        }
    }
}